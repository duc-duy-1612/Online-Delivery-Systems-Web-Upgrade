# AS-IS Process Analysis — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: AS-IS Business Process Analysis
Source Baseline: S1 — Validated Portfolio BRD
Depends On: 00_README_BA_Evidence_Pack.md — APPROVED v1.0
Last Reviewed: 15 Aug 2026

## 1. Purpose
This artefact documents the assumed pre-solution business process used as the analytical baseline for identifying manual handoffs, information fragmentation, visibility limitations, operational coordination issues, and opportunities addressed by the later TO-BE process. The objective is to understand the assumed current-state problem before introducing the target system.

## 2. Evidence Classification & Assumption Disclaimer
**Evidence Classification: ASSUMPTION**

The AS-IS baseline documented here is a case-study assumption used to establish the problem context for requirements analysis. It is based primarily on the validated BRD. It was not validated through formal stakeholder interviews, and it must not be presented publicly as empirical evidence from a real restaurant operation. Downstream artefacts must preserve this qualification.

Source: S1 — Assumed Current-State Problem Context / Present Process / Assumptions & Constraints (ASM-01)

## 3. AS-IS Process Scope
This AS-IS model focuses on the assumed pre-platform process involving the Customer, Restaurant, and Shipper. The scope covers:
*   Customer ordering
*   Restaurant order recording
*   Delivery coordination
*   Delivery execution
*   Limited tracking / communication
*   Historical information storage

*Note: Automated route validation, map APIs, role-based portals, real-time tracking UI, QR Payment Simulation, automated delivery fee calculation, and Admin workflows are explicitly OUT OF SCOPE for this AS-IS baseline, as they represent future-state platform features.*

## 4. AS-IS Participants

### Customer
The assumed role in initiating an order through manual communication and receiving limited delivery-status visibility.

### Restaurant
The assumed role in receiving the order, recording it manually, and coordinating delivery.

### Shipper
The assumed role in receiving delivery requests through direct/manual coordination and completing delivery.

### Supporting Channels / Tools
*   Phone calls
*   Personal messaging
*   Paper records
*   Standalone Excel files
*   Chat groups

## 5. AS-IS Process Narrative
The assumed process begins when a customer initiates an order by directly contacting a restaurant via phone call or personal messaging. A restaurant staff member receives the order details and records them manually, either on paper or in a standalone spreadsheet. To arrange delivery, the restaurant must manually contact available freelance shippers using separate chat groups or direct phone calls. Once a shipper accepts the delivery request, the delivery is carried out completely outside of any centralized assignment workflow. During delivery, the customer has limited visibility into the exact order progress, making the delivery phase effectively a "black box". After delivery completion, the order history, revenue, and shipper income information remain fragmented across different, disconnected manual records.

## 6. AS-IS Process Steps

| Step | Primary Participant | Activity | Information / Handoff | Observed Limitation | Evidence |
| :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | Customer | Contacts the restaurant through phone or personal messaging. | Order intent and details | Manual, unstructured communication | S1 |
| 2 | Restaurant | Receives the order and records information manually on paper or in a standalone spreadsheet. | Order information capture | Prone to error, fragmented storage | S1 |
| 3 | Restaurant | Attempts to find a Shipper through direct calls, messaging, or informal chat groups. | Delivery request handoff | High coordination effort | S1; coordination implication DERIVED |
| 4 | Shipper | Receives the delivery request and carries out the delivery outside a centralized assignment workflow. | Physical delivery execution | Informal assignment | S1; absence of centralized assignment DERIVED |
| 5 | Customer | Waits for the delivery with limited visibility into the exact progress/status. | Delivery status (absent/black box) | Lack of tracking | S1 |
| 6 | Restaurant / Shipper (as applicable) | Stores operational and historical information in separate records. | Historical data storage | Difficult historical consolidation | S1 |

## 7. Information Handoffs

*   **Customer → Restaurant:**
    *   **Information:** Order request / order information
    *   **Channel:** Phone calls, personal messaging
    *   **Limitation:** Manual, unstructured, requires synchronous availability
*   **Restaurant → Shipper:**
    *   **Information:** Delivery request, order details
    *   **Channel:** Direct calls, informal chat groups
    *   **Limitation:** Requires manual coordination, slow during high demand
*   **Delivery Status Visibility:**
    *   **Information:** Exact delivery progress/status
    *   **Availability:** Not centrally available to Customer
    *   **Limitation:** Delivery process is effectively a "black box"
    *   **Evidence:** S1 — ASSUMPTION
*   **Restaurant / Shipper → Separate Records:**
    *   **Information:** Order, revenue, and delivery/income information
    *   **Storage:** Fragmented/separate records; exact storage mechanism not fully evidenced
    *   **Limitation:** Data is fragmented, preventing easy aggregation and monitoring

## 8. AS-IS Pain Points

### Manual Order Recording
Manual or fragmented recording introduces inconsistency and makes centralized tracking difficult.

### Shipper Coordination
Restaurant-to-shipper coordination depends on manual/direct communication and may be difficult during high-demand periods.

### Limited Delivery Visibility
The customer lacks a centralized mechanism for tracking delivery progress, treating the fulfillment phase as a black box.

### Fragmented Operational Data
Order history, revenue, and delivery/income information are stored separately, making aggregation and monitoring difficult.

## 9. Issue Structure

*   **Limited order visibility**
    *   → Manual cross-party communication
    *   → Customer cannot reliably track progress
*   **Fragmented data**
    *   → Separate manual records
    *   → Difficult historical consolidation
*   **Manual shipper coordination**
    *   → No centralized assignment mechanism
    *   → Increased coordination effort
*   **Inconsistent order capture [DERIVED]**
    *   → Unstructured phone/messaging input and manual recording
    *   → Increased risk of order discrepancies

## 10. Current-State Information Characteristics

| Dimension | Current-State Assumption | Main Limitation | Evidence Classification |
| :--- | :--- | :--- | :--- |
| Order Capture | Manual / fragmented (paper, Excel) | Risk of inconsistency and error | ASSUMPTION |
| Delivery Assignment | Informal direct outreach (chat groups, calls) | High coordination effort | ASSUMPTION |
| Status Visibility | No centralized delivery-status visibility / "black box" | Customer cannot reliably track progress | ASSUMPTION |
| Historical Records | Fragmented across separate manual records | Difficult to aggregate and audit | ASSUMPTION |
| Operational Reporting | Fragmented / manually consolidated | Operational and historical information is difficult and time-consuming to aggregate | ASSUMPTION |

## 11. Source Mapping

| Claim / Process Element | Source | Evidence Classification | Notes |
| :--- | :--- | :--- | :--- |
| AS-IS process is an analytical assumption | S1 | ASSUMPTION | Not formally stakeholder-validated (ASM-01) |
| Customer contacts restaurant manually | S1 | ASSUMPTION | Part of Present Process baseline |
| Manual order recording | S1 | ASSUMPTION | Paper / discrete Excel files supported by source |
| Manual shipper coordination | S1 | ASSUMPTION | Chat groups / phone calls supported by source |
| "Black box" delivery visibility | S1 | ASSUMPTION | Customers cannot track status accurately |
| Fragmented historical/revenue data | S1 | ASSUMPTION | Stored in separate records |
| Absence of centralized shipper assignment mechanism | S1 | DERIVED | Derived from manual shipper coordination via calls/chat groups |
| Risk of order discrepancies | S1 | DERIVED | Derived from manual/unstructured capture; consistent with assumed problem context |

*Note: S2 (Original Major Project Report) was reviewed for compatible historical context but was not materially relied upon for this AS-IS baseline.*

## 12. Open Questions & Not Evidenced
The following information cannot currently be established from the approved evidence:
*   exact frequency of manual order errors — NOT EVIDENCED
*   average shipper allocation time — NOT EVIDENCED
*   exact communication channel usage split — NOT EVIDENCED
*   quantitative customer waiting time — NOT EVIDENCED
*   number of orders handled manually — NOT EVIDENCED
*   measurable operational cost — NOT EVIDENCED
*   actual stakeholder satisfaction — NOT EVIDENCED

## 13. Analysis Summary
The assumed AS-IS baseline is characterised primarily by manual communication, fragmented records, informal delivery coordination, and limited status visibility. Order intent, delivery dispatch, and status updates rely heavily on unstructured channels like phone calls and chat groups, leading to a weak centralized information continuity. 

This approved AS-IS baseline will serve as the analytical foundation for the TO-BE target process (`TO_BE_Cross_Role_Process.md`).
