# BUSINESS REQUIREMENTS DOCUMENT (BRD)

## PROJECT DETAILS
| **PROJECT NAME** | Hệ thống Đặt giao đồ ăn trực tuyến (Food Delivery System) |
| :--- | :--- |
| **PREPARED BY** | Phạm Đức Duy |
| **ROLE** | Business Analyst — Portfolio Reconstruction & Validation |
| **DOCUMENT NO.** | BRD-01 |
| **DOCUMENT TYPE** | Business Requirements Document — Portfolio Edition |
| **DOCUMENT STATUS** | FINAL • CONTROLLED PORTFOLIO BASELINE |
| **DOCUMENT BASIS** | Individual portfolio reconstruction and validation based on the original academic project documentation, approved requirement baseline, controlled BA artefacts and reviewed implementation evidence. |

---

## 1. EXECUTIVE SUMMARY SNAPSHOT

**Tổng quan & Mục tiêu Dự án (Executive Summary & Goals):**
Tài liệu Yêu cầu Nghiệp vụ (BRD) này được xây dựng nhằm xác định rõ phạm vi, yêu cầu nghiệp vụ và các tiêu chí chính của dự án “Hệ thống Đặt giao đồ ăn trực tuyến”. Nền tảng kết nối ba nhóm tham gia nghiệp vụ cốt lõi gồm **Khách hàng (Customer), Nhà hàng (Restaurant) và Người giao hàng (Shipper)**, trong khi **Quản trị viên (Administrator)** chịu trách nhiệm quản lý hoạt động nền tảng và phê duyệt đối tác.

Mục tiêu của dự án là số hóa quy trình đặt hàng, chuẩn bị và giao nhận đồ ăn; giải quyết bài toán đứt gãy thông tin và theo dõi đơn hàng trực tuyến.

**Đối tượng đọc tài liệu (Audience):**
- Đội ngũ Kỹ sư Phần mềm & Kiến trúc sư hệ thống (Developers & Architects)
- Chủ sở hữu Sản phẩm (Product Owners / Business Analysts)
- Đội ngũ Đảm bảo Chất lượng (QA/QC / Testers)

---

## 2. PROJECT DESCRIPTION

**Mô tả dự án & Mục đích (Project Description & Purpose):**
Dự án là một ứng dụng Web hỗ trợ đa nền tảng (Responsive Web Design), cho phép Khách hàng lướt xem thực đơn của các Nhà hàng, đặt món ăn và theo dõi trạng thái giao hàng. Đồng thời, cung cấp một hệ thống Quản trị (Portal) riêng biệt cho Nhà hàng, Shipper và Admin để quản lý nghiệp vụ đặc thù.

**Bối cảnh Vấn đề Giả định (Assumed Current-State Problem Context):**
Trong phạm vi case study, các hạn chế sau được sử dụng làm giả định cho trạng thái nghiệp vụ hiện tại (AS-IS):
- Các nhà hàng quy mô nhỏ thiếu một nền tảng quản lý tập trung, thường ghi chép đơn hàng thủ công dẫn đến sai lệch.
- Khó khăn trong việc tìm kiếm shipper chuyên trách vào các khung giờ cao điểm.
- Khách hàng không có cơ chế theo dõi trực tuyến vị trí và tiến độ giao hàng của Shipper.

The AS-IS process and business drivers are analytical case-study assumptions derived for requirements analysis and were not validated through formal stakeholder interviews.

**Lý do cần triển khai (Why undertake the project):**
Hệ thống này cung cấp một nền tảng kết nối liền mạch, nâng cao hiệu suất hoạt động giữa ba bên, đồng thời xây dựng một cơ sở dữ liệu tập trung nhằm phục vụ cho mục đích thống kê và phân tích nghiệp vụ.

---

## 3. PROJECT SCOPE

| **IN-SCOPE ITEMS (Trong phạm vi)** | **OUT-OF-SCOPE / FUTURE CONSIDERATIONS** |
| :--- | :--- |
| **Item 1: Nền tảng Khách hàng (Customer Web):** Duyệt cửa hàng, chọn món, giỏ hàng, checkout, theo dõi đơn, đánh giá. | **[Future] Item 1 - Tích hợp cổng thanh toán VNPAY:** Hệ thống hiện tại hỗ trợ COD và QR Payment Simulation; tích hợp cổng thanh toán thực tế như VNPAY được xác định là một hướng mở rộng tiềm năng trong tương lai. |
| **Item 2: Cổng quản lý Đối tác Nhà hàng (Restaurant Portal):** Quản lý thực đơn (CRUD), xem danh sách đơn hàng, cập nhật trạng thái đã chuẩn bị xong món, thống kê. | **[Out of Scope] Item 2 - Hệ thống quản lý khiếu nại (Complaint Management):** Không nằm trong scope hiện hành. |
| **Item 3: Cổng vận hành Shipper (Shipper Portal):** Xem danh sách đơn trống, nhận đơn, cập nhật trạng thái đơn (đang giao, hoàn thành). | **[Future] Item 3 - Push Notification Engine:** Việc nhận thông báo/bắn đơn tự động là một tính năng tương lai; hiện tại Shipper cần tải lại danh sách đơn chờ. |
| **Item 4: Cổng Quản trị viên (Admin Portal):** Quản lý/phê duyệt tài khoản, thống kê tổng quan, xuất báo cáo (Excel). | **[Out of Scope] Item 4 - Quản trị Kho hàng (Inventory Management):** Không nằm trong scope hiện hành. |
| **Item 5: Tích hợp Bản đồ (Geocoding/Routing):** Xác thực địa chỉ, xác định tọa độ, tính khoảng cách và cước giao hàng bằng OpenRouteService; sử dụng OSRM/Haversine làm cơ chế fallback khi cần. | **[Out of Scope] Item 5 - Ứng dụng di động Native (Native Mobile Application):** Nằm ngoài scope. |
| **Item 6: Phương thức Thanh toán (Payment Methods):** Hỗ trợ thanh toán khi nhận hàng (COD) và luồng giả lập thanh toán bằng mã QR (QR Payment Simulation); chưa tích hợp cổng thanh toán hoặc API ngân hàng thực tế. | |

---

## 4. BUSINESS DRIVERS

*(Các yếu tố giả định dùng làm case study thúc đẩy dự án)*

- **Chuyển dịch hành vi tiêu dùng:** Nhu cầu đặt đồ ăn trực tuyến tăng cao tạo ra cơ hội triển khai dịch vụ nền tảng số.
- **Tối ưu hóa điều phối giao hàng:** Cung cấp cơ chế tập trung để Shipper xem và tiếp nhận các đơn giao hàng chưa được phân công, giảm sự phụ thuộc vào việc nhà hàng tự liên hệ người giao hàng.
- **Tập trung Dữ liệu (Data-Driven):** Thu thập dữ liệu lịch sử đặt hàng, thống kê doanh thu và đánh giá dịch vụ làm nền tảng cho việc ra quyết định.

---

## 5. PRESENT PROCESS

**Quy trình Truyền thống Giả định (AS-IS Baseline):**
1. Khách hàng sử dụng điện thoại/tin nhắn cá nhân liên hệ đến nhà hàng.
2. Nhân viên nhà hàng nghe máy, ghi đơn ra giấy hoặc file Excel rời rạc.
3. Nhà hàng liên hệ qua các nhóm chat hoặc gọi điện cho các Shipper tự do để nhờ đi giao.
4. Quá trình giao hàng là "hộp đen" - khách hàng không nắm được trạng thái chính xác của đơn hàng.
5. Lịch sử đơn hàng, doanh thu và thu nhập được lưu trữ rời rạc, khiến việc theo dõi và tổng hợp hoạt động mất nhiều thời gian.

---

## 6. PROPOSED PROCESS

**Quy trình Nghiệp vụ Mục tiêu (TO-BE Target Process):**

*Quy trình TO-BE thể hiện luồng nghiệp vụ mục tiêu của hệ thống; các khác biệt đã phát hiện giữa quy trình và prototype hiện tại được ghi nhận tại Appendix 11.1.*

| **Step** | **Process Details** |
| :---: | :--- |
| **1** | **Customer** browses restaurants and menu items and adds items to the cart. |
| **2** | At checkout, the system validates the delivery address, determines coordinates/routes and calculates delivery cost. Customer selects **COD** or **QR Payment Simulation**. |
| **3** | After confirmation, the system creates the order with status **“Chờ xác nhận”**. |
| **4** | **Restaurant** views the new order and prepares the food. Once ready, Restaurant selects **“Làm xong”**, changing the status to **“Đang lấy món”**. |
| **5** | **Shipper** views available unassigned orders and accepts a delivery. The order is officially assigned to that Shipper. |
| **6** | Shipper travels to the restaurant, collects the order and updates the delivery status to **“Đang giao”**. |
| **7** | Customer tracks order status and Shipper location/route through the web interface. |
| **8** | After delivery, Shipper changes the order status to **“Hoàn thành”**. Customer can then submit ratings/reviews for the Restaurant and Shipper. |
| **Exception** | If the Shipper cancels an assigned delivery before completion, the Shipper assignment is removed and the order is returned to the available order queue. The exact post-cancellation Order.Status remains unresolved and must be recorded in the Open Target Clarification Register. |

---

## 7. FUNCTIONAL REQUIREMENTS

**Priority Legend:**

| VALUE | STATUS      | DESCRIPTION |
| ----: | :--- | :--- |
| **1** | Immediate   | Critical to the successful operation of the core solution. |
| **2** | High        | High-value requirement but not mandatory for the minimum viable workflow. |
| **3** | Moderate    | Provides additional business/user value. |
| **4** | Low         | Non-critical enhancement. |
| **5** | Prospective | Future enhancement / currently out of scope. |

*Priority values represent analytical prioritisation for this portfolio case study and are not presented as stakeholder-approved priorities.*

Yêu cầu chức năng được tổ chức theo các Actor chính của hệ thống.

| **ID** | **REQUIREMENT** | **PRIORITY** | **PRIMARY ACTOR / SOURCE** |
| :--- | :--- | :--- | :--- |
| **FR-AUTH-01** | Users shall be able to register an account under an available role (Customer, Restaurant, Shipper). | 1 | Cross-cutting / Approved Project Baseline |
| **FR-AUTH-02** | Registered users shall be able to authenticate using their username and password and be redirected to the appropriate role-based module. | 1 | Cross-cutting / Approved Project Baseline |
| **FR-CUS-01** | Customer shall be able to view and update personal profile information and change account password. | 2 | Customer / Approved Project Baseline |
| **FR-CUS-02** | Customer shall be able to browse active restaurants and their associated menus. | 1 | Customer / Approved Project Baseline |
| **FR-CUS-03** | Customer shall be able to add, remove, and update items in the shopping cart. | 1 | Customer / Approved Project Baseline |
| **FR-CUS-04** | System shall validate the delivery address and calculate delivery distance via Map APIs. | 1 | BA Analysis / Approved Project Baseline |
| **FR-CUS-05** | System shall calculate delivery fee and total order amount before checkout confirmation. | 1 | BA Analysis / Approved Project Baseline |
| **FR-CUS-06** | Customer shall be able to submit an order using an available payment method (COD, QR Payment Simulation). | 1 | Customer / Approved Project Baseline |
| **FR-CUS-07** | Customer shall be able to track active order status and delivery routing information. | 2 | Customer / Approved Project Baseline |
| **FR-CUS-08** | Customer shall be able to submit ratings/reviews for the Restaurant and Shipper upon order completion. | 3 | Customer / Approved Project Baseline |
| **FR-CUS-09** | Customer shall be able to view current orders, completed order history, and order details. | 2 | Customer / Approved Project Baseline |
| **FR-RES-01** | Restaurant shall be able to update store information. | 1 | Restaurant / Approved Project Baseline |
| **FR-RES-02** | Restaurant shall be able to manage menu categories. | 1 | Restaurant / Approved Project Baseline |
| **FR-RES-03** | Restaurant shall be able to create, update, and remove food items. | 1 | Restaurant / Approved Project Baseline |
| **FR-RES-04** | Restaurant shall be able to view order lists and order details. | 1 | Restaurant / Approved Project Baseline |
| **FR-RES-05** | Restaurant shall be able to mark an order as ready for pickup ("Làm xong"). | 1 | Restaurant / Approved Project Baseline |
| **FR-RES-06** | Restaurant shall be able to view revenue statistics and order history. | 2 | Restaurant / Approved Project Baseline |
| **FR-RES-07** | Restaurant shall be able to view customer ratings and reviews associated with its completed orders. | 2 | Restaurant / Approved Project Baseline |
| **FR-SHP-01** | Shipper shall be able to view a list of available/unassigned delivery orders. | 1 | Shipper / Approved Project Baseline |
| **FR-SHP-02** | Shipper shall be able to accept a delivery assignment. | 1 | Shipper / Approved Project Baseline |
| **FR-SHP-03** | Shipper shall be able to update order status ("Đang giao", "Hoàn thành"). | 1 | Shipper / Approved Project Baseline |
| **FR-SHP-04** | Shipper shall be able to view completed deliveries and income statistics. | 2 | Shipper / Approved Project Baseline |
| **FR-SHP-05** | Shipper shall be able to view and update personal profile and account information. | 2 | Shipper / Approved Project Baseline |
| **FR-ADM-01** | Admin shall be able to manage user accounts. | 1 | Administrator / Approved Project Baseline |
| **FR-ADM-02** | Admin shall be able to approve new Restaurant/Shipper registrations. | 1 | Administrator / Approved Project Baseline |
| **FR-ADM-03** | Admin shall be able to view system-wide operational and revenue statistics. | 2 | Administrator / Approved Project Baseline |
| **FR-ADM-04** | Admin shall be able to export revenue statistics to an Excel file. | 2 | Administrator / Approved Project Baseline |

---

## 8. NON-FUNCTIONAL REQUIREMENTS

*Các NFR thể hiện tiêu chí chất lượng mục tiêu; mức độ đáp ứng của prototype được xác minh riêng và các sai lệch được ghi nhận trong Appendix 11.1.*

Các NFR dưới đây xác định tiêu chí chất lượng và phương pháp xác minh; các ngưỡng định lượng chưa được thiết lập trong phạm vi prototype sẽ được ghi nhận rõ là TBD.

| **ID** | **REQUIREMENT** | **VERIFICATION** |
| :--- | :--- | :--- |
| **NFR-PER-01** | Core customer operations shall meet an agreed response-time target under the expected project load; the quantitative target remains TBD for the current prototype. | Performance testing; quantitative target TBD. |
| **NFR-SEC-01** | Functions shall be restricted strictly according to authenticated user roles. | Authorization test & Role-based Access Control (RBAC) review. |
| **NFR-SEC-02** | User credentials shall be protected using an approved password-hashing mechanism. | Security code review and authentication test; current implementation gap recorded in GAP-02. |
| **NFR-COMP-01** | The web application shall support and render correctly on modern desktop and mobile browsers. | Cross-browser UI testing. |

---

## 9. GLOSSARY

| **TERM** | **EXPLANATION** |
| :--- | :--- |
| **AS-IS** | Trạng thái/quy trình nghiệp vụ hiện tại được sử dụng làm baseline phân tích. |
| **TO-BE** | Trạng thái/quy trình nghiệp vụ mục tiêu sau khi áp dụng giải pháp. |
| **BRD** | Business Requirements Document - Tài liệu Yêu cầu Nghiệp vụ. |
| **COD** | Cash on Delivery (Thanh toán tiền mặt khi nhận hàng). |
| **QR Payment Simulation** | Giả lập luồng thanh toán qua mã QR (Chưa tích hợp API ngân hàng trực tiếp). |
| **CRUD** | Create, Read, Update, Delete. |
| **RBAC** | Role-Based Access Control. |
| **ORS** | OpenRouteService. |
| **OSRM** | Open Source Routing Machine. |
| **EF6** | Entity Framework 6. |
| **UNASSIGNED ORDER** | An order that has not been assigned to a Shipper (i.e. Shipper Assignment has no assigned Shipper). “Unassigned” is an assignment condition, not an `Order.Status` value. |
| **TBD** | To Be Determined – Chưa xác định và cần được làm rõ/xác nhận sau. |

---

## 10. REFERENCES

| **NAME** | **LOCATION / PURPOSE** |
| :--- | :--- |
| Project Major Report – Food Delivery System | Internal project documentation, HUTECH, 2025 |
| ASP.NET MVC 5 Documentation | Microsoft official documentation |
| Entity Framework 6 Documentation | Microsoft official documentation |
| OpenRouteService API Documentation | Geocoding and routing reference |
| OSRM Documentation | Routing fallback reference |
| OpenStreetMap | Map data / geographic reference |
| Leaflet | Interactive web-map visualization |
| EPPlus Documentation | Excel export library |
| Reviewed Source Code Repository | Implementation validation source |

### 10.1 Supporting BA Artefacts
- AS-IS Process Analysis
- TO-BE Cross-Role Process
- Order State Diagram
- Business Rules Catalogue
- Detailed Use Cases
- User Stories & Acceptance Criteria
- Requirement Gap Analysis
- Data Dictionary
- Requirements Traceability Matrix
- UAT Test Cases

---

## 11. APPENDIX

### 11.1. Requirement Gap / Validation Findings
Đây là các khoảng cách được ghi nhận giữa yêu cầu/luồng nghiệp vụ mục tiêu và việc thực thi trong prototype hiện tại, kèm theo đề xuất cải thiện. Verified implementation gaps are based on reviewed evidence and are not an exhaustive claim that no other implementation gaps exist.

| **ID** | **Finding** | **Recommendation** |
| :--- | :--- | :--- |
| **GAP-01** | Current implementation checks the unassigned condition but does not enforce the Ready-for-Pickup status. | Only expose/allow acceptance when `Order.Status = "Đang lấy món"`. |
| **GAP-02** | Current authentication implementation stores/compares account passwords without an approved hashing mechanism. | Apply a modern password-hashing algorithm with per-user salt and migrate existing credentials before production use. |

### 11.2. Business Rules (Quy tắc Nghiệp vụ)
- **BR-ORDER-01:** Only completed orders can be reviewed. Review cardinality/editability remains an open clarification.
- **BR-SHIP-01:** A Shipper cannot hold multiple active delivery orders simultaneously. The exact definition of "active delivery" remains TBD / requires target clarification.
- **BR-SHIP-02 (Target Rule):** A Shipper may accept an order only when the order is unassigned and its status is **“Đang lấy món” (Ready for Pickup)**.
- **BR-DEL-01:** The system shall reject checkout when the calculated Restaurant-to-Customer delivery distance exceeds **30 km**.
- **BR-FEE-01:** The delivery fee is VND 15,000 for the first 3 km. For distances exceeding 3 km, an additional VND 3,000 is charged per additional kilometer based on the calculated delivery distance. Fractional-kilometre rounding remains TBD.
- **BR-FEE-02:** Based on the order time, a service fee of VND 16,000 applies before 19:00; from 19:00 onward, the service fee is VND 20,000. The authoritative timestamp used to evaluate the 19:00 boundary remains TBD.
- **BR-PARTNER-01:** Restaurant and Shipper accounts require administrative approval before accessing mapped normal operational capabilities. The wider non-core capability boundary and detailed approval/rejection semantics remain target clarifications.

### 11.3. Technical Context (Kiến trúc Kỹ thuật)
- **Framework:** ASP.NET MVC 5 trên nền tảng .NET Framework 4.7.2.
- **Database:** SQL Server sử dụng công nghệ Entity Framework 6 – Database First (thông qua tệp EDMX).
- **Giao diện (UI):** Razor View Engine kết hợp Bootstrap; jQuery/AJAX được sử dụng cho tương tác phía client và các tác vụ bất đồng bộ.

### 11.4. Assumptions & Constraints
| **ID** | **TYPE** | **DESCRIPTION** |
| :--- | :--- | :--- |
| **ASM-01** | Assumption | The AS-IS process and business drivers are case-study assumptions derived for requirements analysis and were not validated through formal stakeholder interviews. |
| **CON-01** | Constraint | Current solution scope is limited to a responsive web application; native mobile applications are excluded. |
| **CON-02** | Constraint | QR payment is implemented as a simulation and does not verify transactions through a banking/payment-gateway API. |
| **CON-03** | Constraint | Quantitative performance targets were not established for the academic prototype and remain TBD. |

### 11.5 Open Target Clarifications

| No. | Clarification Required | Related Requirement / Rule | Status |
| :--- | :--- | :--- | :--- |
| 1 | Quantitative response-time / performance target | NFR-PER-01 | TBD / OPEN |
| 2 | Restaurant intermediate confirmation semantics | ST-01 / ST-02 | TBD / OPEN |
| 3 | Exact post-Shipper-cancellation Order.Status | US-SHP-03 | TBD / OPEN |
| 4 | Exact definition of "active delivery" | BR-SHIP-01 | TBD / OPEN |
| 5 | Fractional-kilometre rounding rule | BR-FEE-01 | TBD / OPEN |
| 6 | Authoritative timestamp for service-fee calculation | BR-FEE-02 | TBD / OPEN |
| 7 | Partner approval-state vocabulary and rejection logic | BR-PARTNER-01 | TBD / OPEN |
| 8 | Review cardinality and editability | BR-ORDER-01 | TBD / OPEN |
| 9 | Whether browsing requires authentication | US-CUS-02 | TBD / OPEN |
| 10 | Customer profile input-validation rules | US-CUS-01 | TBD / OPEN |
| 11 | Tracking refresh frequency and notification behaviour | US-CUS-05 | TBD / OPEN |
| 12 | Partner non-core capability boundary | BR-PARTNER-01 | TBD / OPEN |
| 13 | Detailed authentication failure behaviour | FR-AUTH-02 | TBD / OPEN |
| 14 | Detailed menu-category operations | US-RES-02 | TBD / OPEN |
| 15 | Detailed Administrator user-account management actions | US-ADM-01 | TBD / OPEN |

### 11.6 Key Data Concepts

Core business entities include: Customer, Restaurant, Shipper, Order, Order Detail, Food/Menu Item, and Review.

Key business data concepts include: Order.Status, Shipper Assignment, Total Amount, Delivery Fee, Service Fee, and Payment Method.

Detailed logical-to-physical mappings and persistence evidence are maintained separately in the controlled Data Dictionary.
