# USER REQUIREMENTS DOCUMENT
## ONLINE FOOD DELIVERY SYSTEM

**Document Version:** 1.0  
**Status:** Baseline / Portfolio Evidence  
**Prepared by:** Pham Duc Duy  
**Role:** Business Analyst — Individual Portfolio Reconstruction & Validation  
**Original Project:** 2025  
**BA Case Study Reconstruction:** 2026  

---

## 1. Document Overview

This User Requirements Document (URD) specifies the user-facing capabilities and outcomes required for the Online Food Delivery System. It is an individual portfolio reconstruction based on the approved project evidence baseline. The purpose of this URD is to document what the user groups need to accomplish and what outcomes they expect from the system, acting as a conceptual bridge between the high-level Business Context and the detailed Software and Functional Requirements Specifications. 

The URD focuses strictly on user needs, actor goals, and expected capabilities, rather than detailed system behavior and postconditions.

---

## 2. Business Context

The Online Food Delivery System operates in a multi-role food delivery marketplace environment. It facilitates food ordering and delivery fulfilment through structured interactions between Customers, Restaurants, and Shippers. 
- **Customer:** Browses menus, builds a cart, and completes checkout.
- **Restaurant:** Receives incoming orders and prepares them for pickup.
- **Shipper:** Accepts eligible delivery assignments and executes the physical delivery.
- **Administrator:** Governs operational access and approvals for Restaurant and Shipper accounts.

This digital platform replaces a disjointed manual process by centralizing operational data, enforcing controlled delivery-assignment eligibility, and improving end-to-end order lifecycle visibility.

---

## 3. Stakeholders and User Groups

The system covers four primary actor groups:

| Actor | Role in System | Primary Needs |
| :--- | :--- | :--- |
| Customer | Places and tracks orders | Browse, checkout, track, review |
| Restaurant | Fulfils food orders | Process and prepare orders |
| Shipper | Performs delivery | Accept, pickup, deliver, complete |
| Administrator | Governs operational access | Approval and administration |

---

## 4. User PersonAS / ACTOR PROFILES

### Customer
- **Main objective:** To discover food items, place orders, and receive them efficiently.
- **Primary interactions:** Browsing menus, cart management, checkout, order tracking, and providing feedback.
- **Key information needs:** Order status, delivery tracking, pricing/fee transparency.
- **Key constraints:** Maximum delivery distance, valid payment selection.

### Restaurant
- **Main objective:** To process incoming orders and prepare them for delivery.
- **Primary interactions:** Menu management, accepting orders, updating order readiness.
- **Key information needs:** Incoming order details, customer requests.
- **Key constraints:** Requires Administrator approval for normal operations.

### Shipper
- **Main objective:** To execute deliveries and earn income.
- **Primary interactions:** Viewing available deliveries, accepting orders, updating delivery progress.
- **Key information needs:** Pickup location, drop-off location, order readiness status.
- **Key constraints:** Can only accept unassigned orders marked ready; limited to one active delivery; requires Administrator approval.

### Administrator
- **Main objective:** To manage and govern operational participants.
- **Primary interactions:** Approving Partner registrations, viewing system statistics.
- **Key information needs:** Partner registration details, platform performance statistics.
- **Key constraints:** Governs but does not participate in the core order lifecycle.

---

## 5. User Goals

| Actor | User Goal ID | User Goal |
| :--- | :--- | :--- |
| Customer | UG-CUS-01 | Discover restaurants and products |
| Customer | UG-CUS-02 | Build a shopping cart |
| Customer | UG-CUS-03 | Complete an eligible checkout |
| Customer | UG-CUS-04 | Track order status and delivery progress |
| Customer | UG-CUS-05 | Submit a post-completion review |
| Restaurant | UG-RES-01 | Access approved operational capabilities |
| Restaurant | UG-RES-02 | Process and prepare incoming orders |
| Restaurant | UG-RES-03 | Indicate order readiness for pickup |
| Shipper | UG-SHP-01 | Identify eligible delivery assignments |
| Shipper | UG-SHP-02 | Accept an eligible order |
| Shipper | UG-SHP-03 | Execute pickup and update delivery progress |
| Shipper | UG-SHP-04 | Complete delivery |
| Administrator | UG-ADM-01 | Manage user accounts and approve mapped operational participants |
| Administrator | UG-ADM-02 | Maintain administrative control and view statistics |

---

## 6. User Requirements

### Customer User Requirements

**UR-CUS-01**
**Title:** Account & Access
**User Need:** The Customer needs to register, access the system using the supported authentication mechanism, and manage their personal profile.
**Expected Outcome:** The Customer can access permitted account functions and profile settings after successful authentication.
**Related Requirements:** FR-AUTH-01, FR-AUTH-02, FR-CUS-01

**UR-CUS-02**
**Title:** Restaurant / Product Discovery
**User Need:** The Customer needs to browse active restaurants and view their associated menus.
**Expected Outcome:** The Customer can discover available food items to order.
**Related Requirements:** FR-CUS-02

**UR-CUS-03**
**Title:** Shopping Cart
**User Need:** The Customer needs to add/remove items and adjust quantities in a shopping cart.
**Expected Outcome:** The Customer can prepare their desired order and see cart totals before proceeding to checkout.
**Related Requirements:** FR-CUS-03

**UR-CUS-04**
**Title:** Checkout
**User Need:** The Customer needs to provide delivery information, validate the address/distance, review calculated fees (delivery and service), select a payment method (COD or QR Payment Simulation), and submit an eligible order.
**Expected Outcome:** The Customer successfully submits an order if delivery conditions are met, initiating the order lifecycle.
**Related Requirements:** FR-CUS-04, FR-CUS-05, FR-CUS-06

**UR-CUS-05**
**Title:** Order Tracking
**User Need:** The Customer needs to view current order status and monitor delivery progress/route information.
**Expected Outcome:** The Customer is informed of the order's progress throughout the fulfilment lifecycle.
**Related Requirements:** FR-CUS-07

**UR-CUS-06**
**Title:** History
**User Need:** The Customer needs to view their current orders and completed order history.
**Expected Outcome:** The Customer can access details of past and present orders.
**Related Requirements:** FR-CUS-09

**UR-CUS-07**
**Title:** Review
**User Need:** The Customer needs to submit ratings and reviews for the Restaurant and Shipper after an eligible order is completed.
**Expected Outcome:** The Customer can provide feedback only after the order reaches completion.
**Related Requirements:** FR-CUS-08

### Restaurant User Requirements

**UR-RES-01**
**Title:** Profile & Menu Management
**User Need:** The Restaurant needs to access approved operational capabilities to update store information, manage menu categories, and manage food items.
**Expected Outcome:** The Restaurant can maintain an accurate profile and current menu offerings for Customer discovery.
**Related Requirements:** FR-RES-01, FR-RES-02, FR-RES-03

**UR-RES-02**
**Title:** Order Processing
**User Need:** The Restaurant needs to receive/view incoming mapped order information, prepare the order, and indicate when the food is ready for pickup.
**Expected Outcome:** The Restaurant can process orders and trigger the readiness update to make the order available for Shippers.
**Related Requirements:** FR-RES-04, FR-RES-05

**UR-RES-03**
**Title:** History & Reviews
**User Need:** The Restaurant needs to view revenue, order history, and customer reviews.
**Expected Outcome:** The Restaurant can track business performance and monitor customer feedback.
**Related Requirements:** FR-RES-06, FR-RES-07

### Shipper User Requirements

**UR-SHP-01**
**Title:** Delivery Assignment
**User Need:** The Shipper needs to access unassigned, eligible delivery opportunities and accept an eligible order.
**Expected Outcome:** The Shipper is officially assigned to execute a delivery, provided the order is unassigned, ready for pickup, and the Shipper meets active delivery constraints.
**Related Requirements:** FR-SHP-01, FR-SHP-02

**UR-SHP-02**
**Title:** Delivery Execution
**User Need:** The Shipper needs to perform the pickup, update delivery progress, and complete the delivery within the system.
**Expected Outcome:** The Order lifecycle correctly advances to the delivery and completion states based on Shipper updates.
**Related Requirements:** FR-SHP-03

**UR-SHP-03**
**Title:** Profile, History & Income
**User Need:** The Shipper needs to manage their profile and view their delivery history and accumulated income.
**Expected Outcome:** The Shipper can monitor their earnings and maintain up-to-date account details.
**Related Requirements:** FR-SHP-04, FR-SHP-05

### Administrator User Requirements

**UR-ADM-01**
**Title:** Partner Approval
**User Need:** The Administrator needs to approve Restaurants and Shippers for mapped normal operational capabilities.
**Expected Outcome:** Only approved partner accounts are granted access to core order-processing operations.
**Related Requirements:** FR-ADM-02

**UR-ADM-02**
**Title:** User & System Administration
**User Need:** The Administrator needs to manage user accounts, view system statistics, and export revenue statistics.
**Expected Outcome:** The Administrator maintains governance control and can report on platform operations.
**Related Requirements:** FR-ADM-01, FR-ADM-03, FR-ADM-04

---

## 7. User Journeys and Cross-Role Handoffs

### End-to-End User Journey

Customer Browse
↓
Select Products
↓
Cart
↓
Checkout
↓
Address / Distance Validation
↓
Fee Calculation
↓
Create Order
↓
Chờ xác nhận
↓
Restaurant Preparation
↓
Đang lấy món
↓
Shipper Pickup
↓
Đang giao
↓
Delivery Completion
↓
Hoàn thành
↓
Customer Review

### Cross-Role Handoffs

| From | To | Trigger / Handoff | User Need |
| :--- | :--- | :--- | :--- |
| Customer | System | Checkout submission | Customer needs to place the order |
| System | Restaurant | Order created / confirmed | Restaurant needs to receive order details |
| Restaurant | System | Order ready | Restaurant needs to indicate preparation is complete |
| System | Shipper | Delivery Opportunity | Shipper needs to view unassigned, ready orders |
| Shipper | System | Delivery acceptance | Shipper needs to accept the assignment |
| Shipper | Customer | Delivery progression | Customer needs to monitor delivery progress |
| Shipper | System | Delivery completion | Shipper needs to complete the delivery |

---

## 8. User Constraints and Business Rules

The following constraints are supported by the current baseline and govern the user requirements:

- **Maximum delivery route distance:** Checkout is constrained to a 30 km delivery radius.
- **Fee calculation rules:** Distance-based delivery fees and time-based service fees are applied during checkout.
- **Shipper Assignment constraints:** An order must be unassigned and in "Đang lấy món" for a Shipper to accept it.
- **Active Delivery limit:** A Shipper cannot hold multiple active delivery orders simultaneously.
- **Completion requirement:** An order must reach the "Hoàn thành" state before a Customer is eligible to submit a review.
- **Partner Approval requirement:** Restaurant and Shipper accounts require Administrator approval before engaging in normal operations.

---

## 9. User Requirement Traceability

The URD traceability bridges Business Needs to Functional Requirements, ensuring each user need is supported downstream by detailed system behaviors.

| URD ID | Actor | User Requirement | Related FR | Related UC | Related US | Related AC | Related BR |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| UR-CUS-01 | Customer | Account & Access | FR-AUTH-01, FR-AUTH-02, FR-CUS-01 | UC-CUS-01 | US-CUS-01 | AC-US-CUS-01-01 to 03 | — |
| UR-CUS-02 | Customer | Restaurant / Product Discovery | FR-CUS-02 | UC-CUS-02 | US-CUS-02 | AC-US-CUS-02-01 | — |
| UR-CUS-03 | Customer | Shopping Cart | FR-CUS-03 | UC-CUS-02 | US-CUS-03 | AC-US-CUS-03-01 to 03 | — |
| UR-CUS-04 | Customer | Checkout | FR-CUS-04, FR-CUS-05, FR-CUS-06 | UC-CUS-03 | US-CUS-04 | AC-US-CUS-04-01 to 09 | BR-DEL-01, BR-FEE-01, BR-FEE-02 |
| UR-CUS-05 | Customer | Order Tracking | FR-CUS-07 | UC-CUS-04 | US-CUS-05 | AC-US-CUS-05-01; 02 | — |
| UR-CUS-06 | Customer | History | FR-CUS-09 | UC-CUS-05 | US-CUS-06 | AC-US-CUS-06-01 to 03 | — |
| UR-CUS-07 | Customer | Review | FR-CUS-08 | UC-CUS-06 | US-CUS-07 | AC-US-CUS-07-01; 02 | BR-ORDER-01 |
| UR-RES-01 | Restaurant | Profile & Menu Management | FR-RES-01, FR-RES-02, FR-RES-03 | UC-RES-01 | US-RES-01, US-RES-02, US-RES-03 | AC-US-RES-01-01, AC-US-RES-02-01, AC-US-RES-03-01 to 03 | — |
| UR-RES-02 | Restaurant | Order Processing | FR-RES-04, FR-RES-05 | UC-RES-02 | US-RES-04 | AC-US-RES-04-01; 02 | BR-PARTNER-01 |
| UR-RES-03 | Restaurant | History & Reviews | FR-RES-06, FR-RES-07 | UC-RES-03 | US-RES-05, US-RES-06 | AC-US-RES-05-01; 02, AC-US-RES-06-01 | — |
| UR-SHP-01 | Shipper | Delivery Assignment | FR-SHP-01, FR-SHP-02 | UC-SHP-01, UC-SHP-02 | US-SHP-01, US-SHP-02 | AC-US-SHP-01-01, AC-US-SHP-02-01 to 04 | BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01 |
| UR-SHP-02 | Shipper | Delivery Execution | FR-SHP-03 | UC-SHP-03 | US-SHP-03 | AC-US-SHP-03-01 to 03 | BR-PARTNER-01 |
| UR-SHP-03 | Shipper | Profile, History & Income | FR-SHP-04, FR-SHP-05 | UC-SHP-04, UC-SHP-05 | US-SHP-04, US-SHP-05 | AC-US-SHP-04-01; 02, AC-US-SHP-05-01; 02 | — |
| UR-ADM-01 | Administrator | Partner Approval | FR-ADM-02 | UC-ADM-02 | US-ADM-02 | AC-US-ADM-02-01 | BR-PARTNER-01 |
| UR-ADM-02 | Administrator | User & System Administration | FR-ADM-01, FR-ADM-03, FR-ADM-04 | UC-ADM-01, UC-ADM-03 | US-ADM-01, US-ADM-03, US-ADM-04 | AC-US-ADM-01-01, AC-US-ADM-03-01; 02, AC-US-ADM-04-01 | — |

---

## 10. Scope / Out of Scope

**In Scope:**
- Core order and delivery lifecycle involving the Customer, Restaurant, Shipper, and Administrator.
- Responsive Web Application implementation.
- Supported order state transitions: Chờ xác nhận, Đang lấy món, Đang giao, Hoàn thành.

**Out of Scope:**
- Native mobile applications.
- Real production payment-gateway integration.

---

## 11. Assumptions and Dependencies

**Assumptions:**
- Restaurant and Shipper normal operational capabilities require Administrator approval as defined by BR-PARTNER-01.
- COD / QR is represented as payment simulation rather than production payment-gateway integration.

**Dependencies:**
- Administrator approval is a prerequisite for partner operational flows.
- Address / route-distance calculation functionality must be supported by Map APIs.
- Order-state transitions dictate downstream participant eligibility (e.g., Shipper eligibility relies on Restaurant readiness).

---

## 12. Open Clarifications

The following semantics remain explicitly unresolved in the current baseline and affect user requirements:
- Definition of "active delivery" for the single active delivery constraint.
- Fractional-kilometre rounding logic for distance-based fee calculation.
- Authoritative timestamp for the service-fee rule.
- Wider non-core Partner capability boundary regarding Administrator approval.
- Exact post-Shipper-cancellation Order.Status transition.
- Exact Restaurant confirmation semantics between "Chờ xác nhận" and "Đang lấy món".
- Review cardinality and editability rules.

---

## 13. Relationship to System / Functional Requirements

This URD describes the "What" and "Why" from the user's perspective, providing context to the Functional Requirements Specification (FRS) which describes the "How" from the system's perspective. 

Example translation:
```text
UR-CUS-04
Customer needs validated checkout.

↓ translated into

FR-CUS-04
Validate Address & Distance

↓ supported by

UC-CUS-03
Checkout and Place Order

↓ expressed as

US-CUS-04
Complete Checkout

↓ tested by

AC-US-CUS-04-02 / 03
```

This ensures requirements are user-centered and accurately traced through the software delivery lifecycle.

---

## 14. Non-Functional User Expectations

Non-functional user expectations (such as explicit response times, uptime, security standards, and throughput targets) are not fully defined in the current baseline and are outside the confirmed scope of this URD. The system relies on the approved NFRs documented in the SRS (NFR-COMP-01, NFR-PER-01, NFR-SEC-01, NFR-SEC-02).

---

## 15. Glossary

- **Administrator:** Governs user accounts and operational approval.
- **COD:** Cash on Delivery.
- **Customer:** The user discovering items and placing orders.
- **Order.Status:** The formal lifecycle state of an order (Chờ xác nhận, Đang lấy món, Đang giao, Hoàn thành).
- **QR Payment Simulation:** Simulated payment mechanism for non-cash checkout.
- **Restaurant:** The partner processing and preparing food orders.
- **RTM:** Requirements Traceability Matrix.
- **Shipper:** The partner accepting and executing physical delivery.
- **UAT:** User Acceptance Testing.
- **TARGET:** The intended future state capabilities.
- **CURRENT:** The existing implementation behavior.

---

## 16. Document Relationship

```text
BRD
 ↓
URD
 ↓
SRS
 ↓
FRS
 ↓
UC / US / AC
 ↓
Business Rules
 ↓
State / ERD / Data Dictionary
 ↓
RTM
 ↓
UAT
```
*(This represents the controlled documentation relationship, not necessarily strict historical creation order.)*
