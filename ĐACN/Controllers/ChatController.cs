using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Web.Mvc;
using ĐACN.Models;

namespace ĐACN.Controllers
{
    public class ChatController : Controller
    {
        // In-memory thread-safe queue to store chat messages
        private static ConcurrentQueue<ChatMessage> _messages = new ConcurrentQueue<ChatMessage>();

        [HttpPost]
        public ActionResult SendMessage(string senderId, string senderName, string receiverId, string message, string maDon)
        {
            if (string.IsNullOrEmpty(message)) return Json(new { success = false });

            var chatMsg = new ChatMessage
            {
                SenderId = senderId,
                SenderName = senderName,
                ReceiverId = receiverId,
                Message = message,
                MaDon = maDon
            };
            _messages.Enqueue(chatMsg);
            
            // Limit in-memory messages to prevent memory leak
            while (_messages.Count > 10000)
            {
                _messages.TryDequeue(out _);
            }

            return Json(new { success = true, msg = new {
                id = chatMsg.Id,
                senderId = chatMsg.SenderId,
                senderName = chatMsg.SenderName,
                receiverId = chatMsg.ReceiverId,
                message = chatMsg.Message,
                timestamp = (long)(chatMsg.Timestamp.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds
            }});
        }

        [HttpGet]
        public ActionResult GetMessages(string userId, string partnerId, string maDon, long lastTimestamp = 0)
        {
            DateTime dtOrigin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime lastTime = dtOrigin.AddMilliseconds(lastTimestamp).ToLocalTime();

            var query = _messages.Where(m => 
                (m.SenderId == userId && m.ReceiverId == partnerId) ||
                (m.SenderId == partnerId && m.ReceiverId == userId)
            );

            if (!string.IsNullOrEmpty(maDon))
            {
                query = query.Where(m => m.MaDon == maDon);
            }

            var newMsgs = query.Where(m => m.Timestamp > lastTime).OrderBy(m => m.Timestamp).ToList();

            var result = newMsgs.Select(m => new {
                id = m.Id,
                senderId = m.SenderId,
                senderName = m.SenderName,
                receiverId = m.ReceiverId,
                message = m.Message,
                timestamp = (long)(m.Timestamp.ToUniversalTime() - dtOrigin).TotalMilliseconds
            });

            return Json(new { success = true, messages = result }, JsonRequestBehavior.AllowGet);
        }
    }
}
