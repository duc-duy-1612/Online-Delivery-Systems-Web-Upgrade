# Detailed Use Cases — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Detailed Use Case Specification
Source Baseline: S1 — Validated Portfolio BRD
Depends On: 00_README_BA_Evidence_Pack.md — APPROVED v1.0; TO_BE_Cross_Role_Process.md — APPROVED v1.0; Business_Rules_Catalogue.md — APPROVED v1.0; Order_State_Diagram.md — APPROVED v1.0
Last Reviewed: 15 Aug 2026

## 1. Purpose

This artefact translates approved functional requirements into actor-goal interactions. It defines preconditions, triggers, main success flows, and supported alternatives/exceptions for the core business processes. It connects Functional Requirements (FRs), Business Rules (BRs), and Order lifecycle states to ensure a comprehensive, behavior-driven view of the system. 

It intentionally separates user/business actions from system responses and preserves unresolved requirements instead of inventing behaviour. This document provides the controlled upstream baseline for subsequent User Stories, Acceptance Criteria, Requirements Traceability Matrix (RTM), and User Acceptance Testing (UAT) artefacts.

## 2. Use Case Inventory

| Use Case ID | Use Case Name | Primary Actor | Goal | Related FRs | Related BRs | Lifecycle Relevance | Evidence Classification |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| **UC-CUS-01** | Manage Profile | Customer | Update profile and password | FR-CUS-01 | — | — | BASELINE |
| **UC-CUS-02** | Browse Restaurants & Manage Cart | Customer | Build shopping cart | FR-CUS-02, FR-CUS-03 | — | — | BASELINE |
| **UC-CUS-03** | Checkout and Place Order | Customer | Submit order via COD/QR Payment Simulation | FR-CUS-04, FR-CUS-05, FR-CUS-06 | BR-DEL-01, BR-FEE-01, BR-FEE-02 | ST-01, "Chờ xác nhận" | BASELINE |
| **UC-CUS-04** | Track Active Order | Customer | View order progress | FR-CUS-07 | — | Current Order.Status as applicable | BASELINE |
| **UC-CUS-05** | View Orders, History & Details | Customer | View current orders, completed order history, and details of a selected order | FR-CUS-09 | — | — | BASELINE |
| **UC-CUS-06** | Submit Order Review | Customer | Rate Restaurant and Shipper | FR-CUS-08 | BR-ORDER-01 | "Hoàn thành" | BASELINE |
| **UC-RES-01** | Manage Store & Menu | Restaurant | Update store and menu data | FR-RES-01, FR-RES-02, FR-RES-03 | — | — | BASELINE |
| **UC-RES-02** | Process Incoming Order | Restaurant | Prepare and mark order ready | FR-RES-04, FR-RES-05 | BR-PARTNER-01 | ST-02, "Đang lấy món" | BASELINE (confirmed endpoints); intermediate semantics NOT EVIDENCED |
| **UC-RES-03** | View Statistics and Reviews | Restaurant | View revenue and reviews | FR-RES-06, FR-RES-07 | — | — | BASELINE |
| **UC-SHP-01** | View Available Deliveries | Shipper | View unassigned orders | FR-SHP-01 | BR-PARTNER-01 | Non-state condition: Unassigned | BASELINE |
| **UC-SHP-02** | Accept Delivery Assignment | Shipper | Claim a delivery order | FR-SHP-02 | BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01 | "Đang lấy món" | BASELINE |
| **UC-SHP-03** | Execute Delivery | Shipper | Complete physical delivery | FR-SHP-03 | BR-PARTNER-01 | ST-03, ST-04, "Đang giao", "Hoàn thành" | BASELINE |
| **UC-SHP-04** | View Delivery History & Income | Shipper | View completed deliveries and income | FR-SHP-04 | — | — | BASELINE |
| **UC-SHP-05** | Manage Profile | Shipper | View/update profile and account information | FR-SHP-05 | — | — | BASELINE |
| **UC-ADM-01** | Manage User Accounts | Administrator | Manage system users | FR-ADM-01 | — | — | BASELINE |
| **UC-ADM-02** | Approve Partner Registrations | Administrator | Approve partners | FR-ADM-02 | BR-PARTNER-01 | — | BASELINE |
| **UC-ADM-03** | View and Export System Statistics | Administrator | View operational/revenue statistics and export revenue statistics | FR-ADM-03, FR-ADM-04 | — | — | BASELINE |

## 3. Functional Requirement Coverage

| FR ID | Requirement Summary | Mapped Use Case(s) | Coverage Type | Notes |
| :--- | :--- | :--- | :--- | :--- |
| FR-AUTH-01 | Register account | — | Supporting / Precondition | Handled in Section 4 |
| FR-AUTH-02 | Authenticate / login | — | Supporting / Precondition | Handled in Section 4 |
| FR-CUS-01 | Update profile & password | UC-CUS-01 | Direct | |
| FR-CUS-02 | Browse restaurants & menus | UC-CUS-02 | Direct | |
| FR-CUS-03 | Manage shopping cart | UC-CUS-02 | Direct | |
| FR-CUS-04 | Validate address & distance | UC-CUS-03 | Direct | |
| FR-CUS-05 | Calculate fee & total | UC-CUS-03 | Direct | |
| FR-CUS-06 | Submit order (COD, QR) | UC-CUS-03 | Direct | |
| FR-CUS-07 | Track order & route | UC-CUS-04 | Direct | |
| FR-CUS-08 | Submit ratings/reviews | UC-CUS-06 | Direct | |
| FR-CUS-09 | View current orders, completed history & order details | UC-CUS-05 | Direct | |
| FR-RES-01 | Update store information | UC-RES-01 | Direct | |
| FR-RES-02 | Manage menu categories | UC-RES-01 | Direct | |
| FR-RES-03 | Manage food items | UC-RES-01 | Direct | |
| FR-RES-04 | View order list & details | UC-RES-02 | Direct | |
| FR-RES-05 | Mark order as ready | UC-RES-02 | Direct | |
| FR-RES-06 | View revenue & order history | UC-RES-03 | Direct | |
| FR-RES-07 | View customer ratings | UC-RES-03 | Direct | |
| FR-SHP-01 | View available deliveries | UC-SHP-01 | Direct | |
| FR-SHP-02 | Accept delivery assignment | UC-SHP-02 | Direct | |
| FR-SHP-03 | Update delivery status | UC-SHP-03 | Direct | |
| FR-SHP-04 | View completed deliveries/income | UC-SHP-04 | Direct | |
| FR-SHP-05 | Update profile | UC-SHP-05 | Direct | |
| FR-ADM-01 | Manage user accounts | UC-ADM-01 | Direct | |
| FR-ADM-02 | Approve partner registrations | UC-ADM-02 | Direct | |
| FR-ADM-03 | View system statistics | UC-ADM-03 | Direct | |
| FR-ADM-04 | Export statistics to Excel | UC-ADM-03 | Direct | |

## 4. Cross-Cutting Authentication & Access Behaviour

**FR-AUTH-01 — Registration**
Supporting actor: Guest
Outcome: account is registered under an available role: Customer / Restaurant / Shipper.

**FR-AUTH-02 — Authentication**

Actor: Registered user

Behaviour:
- Registered user submits username and password.
- System authenticates the supplied credentials.
- On successful authentication, System provides access to / redirects the user to the appropriate role-based module.

Detailed failure behaviour:
NOT EVIDENCED / REQUIRES CLARIFICATION.

### Partner Operational Access
For Restaurant and Shipper capabilities that constitute normal operation:
- the user must be authenticated under the relevant role
- Administrator approval is required under BR-PARTNER-01

Exact capability boundary covered by "normal operation":
NOT EVIDENCED / REQUIRES CLARIFICATION.

## 5. Detailed Use Case Specifications

### UC-CUS-01 — Manage Profile
**Goal:** Customer views and updates personal profile information and changes account password.
**Primary Actor:** Customer
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-CUS-01
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Customer accesses their profile settings.
**Preconditions:** Customer is authenticated.
**Success Postconditions:** Profile details are displayed; if updates are submitted, the supported changes are saved.
**Main Success Flow:**
1. Customer requests to view their profile.
2. System displays current profile details.
3. Customer submits updated information or a new password.
4. System processes and saves the supported changes.
**Alternative Flows:**
- View-only: After the System displays the current profile details, the Customer may end the Use Case without submitting changes.
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:**
- Input-validation rules: NOT EVIDENCED.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-CUS-02 — Browse Restaurants & Manage Cart
**Goal:** Customer browses available restaurants, views menus, and manages items in their shopping cart.
**Primary Actor:** Customer
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-CUS-02, FR-CUS-03
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Customer navigates to the restaurant listing or menu.
**Preconditions:** —
**Success Postconditions:** Cart contains desired items ready for checkout.
**Main Success Flow:**
1. Customer browses the list of active restaurants.
2. Customer selects a restaurant and views its menu.
3. Customer adds selected food items to the shopping cart.
4. System updates and displays the cart contents.
5. Customer adjusts item quantities or removes items as needed.
6. System updates the cart contents to reflect the Customer's changes.
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:**
- Whether authentication is required for browsing restaurants and menus is NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-CUS-03 — Checkout and Place Order
**Goal:** Customer finalizes their cart and places an order via COD or QR Payment Simulation.
**Primary Actor:** Customer
**Supporting Actors / Systems:** External Map / Routing service (for distance calculation).
**Related Functional Requirements:** FR-CUS-04, FR-CUS-05, FR-CUS-06
**Related Business Rules:** BR-DEL-01, BR-FEE-01, BR-FEE-02
**Related Order States / Transitions:** ST-01, "Chờ xác nhận"
**Trigger:** Customer initiates checkout from the shopping cart.
**Preconditions:** Customer is authenticated; Customer has items in the cart.
**Success Postconditions:** Order record exists with status "Chờ xác nhận" and is available to the Restaurant.
**Main Success Flow:**
1. Customer proceeds to checkout and provides delivery details.
2. System validates the delivery address and calculates the delivery distance.
3. System evaluates the delivery-distance rule (BR-DEL-01).
4. System calculates the applicable delivery fee (BR-FEE-01) and service fee (BR-FEE-02).
5. System displays the total order amount.
6. Customer selects either COD or QR Payment Simulation.
7. Customer confirms and submits the order.
8. System creates the Order with status "Chờ xác nhận".
**Alternative Flows:** —
**Exception / Rejection Flows:**
- If distance > 30 km, the system rejects the checkout (BR-DEL-01).
**Open Questions / Clarifications:**
- BR-FEE-01: Additional-kilometre rounding / fractional precision is NOT EVIDENCED / REQUIRES CLARIFICATION.
- BR-FEE-02: Authoritative timestamp for the service fee calculation is NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; TO_BE_Cross_Role_Process.md; Order_State_Diagram.md

### UC-CUS-04 — Track Active Order
**Goal:** Customer tracks the status of their active order and delivery routing.
**Primary Actor:** Customer
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-CUS-07
**Related Business Rules:** —
**Related Order States / Transitions:** Current Order.Status as applicable.
**Trigger:** Customer accesses their active order details.
**Preconditions:** Customer has an active order.
**Success Postconditions:** Customer is informed of the current order status and routing.
**Main Success Flow:**
1. Customer requests to view their active order.
2. System retrieves current order status and any available Shipper location/routing information.
3. System displays the tracking information to the Customer.
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:** 
- Tracking coordinate refresh frequency and notification-channel behaviour are NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-CUS-05 — View Orders, History & Details
**Goal:** Customer views current orders, completed order history, and details of a selected order.
**Primary Actor:** Customer
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-CUS-09
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Customer requests to view their orders.
**Preconditions:** Customer is authenticated.
**Success Postconditions:** Current orders, completed order history, and available details for the selected order are presented to the Customer.
**Main Success Flow:**
1. Customer requests to view their orders.
2. System presents current orders and completed order history.
3. Customer selects an order.
4. System presents the available order details.
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:** —
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-CUS-06 — Submit Order Review
**Goal:** Customer submits ratings and reviews for the Restaurant and Shipper.
**Primary Actor:** Customer
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-CUS-08
**Related Business Rules:** BR-ORDER-01
**Related Order States / Transitions:** "Hoàn thành"
**Trigger:** Customer chooses to review a past order.
**Preconditions:** Order.Status = "Hoàn thành" (BR-ORDER-01).
**Success Postconditions:** Review data is stored and associated with the Restaurant and Shipper.
**Main Success Flow:**
1. Customer selects a completed order to review.
2. System validates that the Order.Status is "Hoàn thành" (BR-ORDER-01).
3. Customer inputs ratings/reviews for the Restaurant and Shipper.
4. Customer submits the review.
5. System records the review.
**Alternative Flows:** —
**Exception / Rejection Flows:**
- If the Order.Status is not "Hoàn thành", the system rejects the review attempt.
**Open Questions / Clarifications:**
- Review cardinality (e.g., one-review-per-order) and editability are NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-RES-01 — Manage Store & Menu
**Goal:** Restaurant manages their store information, menu categories, and food items.
**Primary Actor:** Restaurant
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-RES-01, FR-RES-02, FR-RES-03
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Restaurant accesses store management module.
**Preconditions:** Restaurant is authenticated under the relevant role.
**Success Postconditions:** Store profile or menu updates are saved.
**Main Success Flow:**
1. Restaurant accesses the relevant management capability.
2. Restaurant updates store information, if required.
3. Restaurant manages menu categories, if required.
4. Restaurant creates, updates, or removes food items, if required.
5. System persists the requested changes.
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:**
- BR-PARTNER-01 applicability to this capability is NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-RES-02 — Process Incoming Order
**Goal:** Restaurant views a new order, prepares the food, and marks it ready for pickup.
**Primary Actor:** Restaurant
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-RES-04, FR-RES-05
**Related Business Rules:** BR-PARTNER-01
**Related Order States / Transitions:** "Chờ xác nhận", ST-02, "Đang lấy món"
**Trigger:** System makes a new order available to the Restaurant.
**Preconditions:** Cross-cutting authentication/access preconditions apply; Order exists with status "Chờ xác nhận".
**Success Postconditions:** Order.Status = "Đang lấy món".
**Main Success Flow:**
1. Restaurant views the incoming order details.
2. Restaurant prepares the physical order.
3. Restaurant selects "Làm xong" when preparation is complete.
4. System records the Order.Status as "Đang lấy món".
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:**
- Exact intermediate Restaurant-confirmation semantics between "Chờ xác nhận" and "Đang lấy món" are NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE (confirmed endpoints); intermediate semantics NOT EVIDENCED
**Source:** S1 — Validated Portfolio BRD; TO_BE_Cross_Role_Process.md; Order_State_Diagram.md

### UC-RES-03 — View Statistics and Reviews
**Goal:** Restaurant views their revenue statistics, order history, and customer reviews.
**Primary Actor:** Restaurant
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-RES-06, FR-RES-07
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Restaurant navigates to reports or reviews section.
**Preconditions:** Restaurant is authenticated under the relevant role.
**Success Postconditions:** Restaurant successfully views statistics and feedback.
**Main Success Flow:**
1. Restaurant requests to view statistics or reviews.
2. System compiles and displays revenue data, historical orders, and customer ratings.
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:**
- BR-PARTNER-01 applicability to this capability is NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-SHP-01 — View Available Deliveries
**Goal:** Shipper views a list of unassigned delivery orders.
**Primary Actor:** Shipper
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-SHP-01
**Related Business Rules:** BR-PARTNER-01
**Related Order States / Transitions:** Non-state condition: Unassigned
**Trigger:** Shipper opens the available orders view.
**Preconditions:** Cross-cutting authentication/access preconditions apply.
**Success Postconditions:** Shipper views available/unassigned orders.
**Main Success Flow:**
1. Shipper requests to view available deliveries.
2. System presents available/unassigned delivery opportunities according to the approved target process. (Relevant conditions: Order is unassigned, Ready-for-Pickup eligibility applies before acceptance).
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:** —
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; TO_BE_Cross_Role_Process.md

### UC-SHP-02 — Accept Delivery Assignment
**Goal:** Shipper accepts an available delivery assignment.
**Primary Actor:** Shipper
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-SHP-02
**Related Business Rules:** BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01
**Related Order States / Transitions:** "Đang lấy món"
**Trigger:** Shipper attempts to claim an available order.
**Preconditions:** Cross-cutting authentication/access preconditions apply; Order is unassigned AND Order.Status = "Đang lấy món" (BR-SHIP-02).
**Success Postconditions:** Shipper assignment is recorded for the Order.
**Main Success Flow:**
1. Shipper selects an eligible available order.
2. System evaluates the Shipper's active delivery limit constraint (BR-SHIP-01).
3. System verifies order eligibility (BR-SHIP-02).
4. Shipper confirms acceptance.
5. System records the Shipper assignment to the order.
**Alternative Flows:** —
**Exception / Rejection Flows:**
- If Order.Status is not "Đang lấy món" (Ready for Pickup), the System rejects/prevents the acceptance attempt (BR-SHIP-02).
- If the order has already been assigned to someone else, the system rejects the acceptance.
- If the Shipper violates the active delivery limit (BR-SHIP-01), the system rejects the acceptance.
**Open Questions / Clarifications:**
- Exact status/attribute derivation of "active delivery" for BR-SHIP-01 is NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; Business_Rules_Catalogue.md

### UC-SHP-03 — Execute Delivery
**Goal:** Shipper collects the order, initiates delivery, and completes it.
**Primary Actor:** Shipper
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-SHP-03
**Related Business Rules:** BR-PARTNER-01
**Related Order States / Transitions:** ST-03, "Đang giao", ST-04, "Hoàn thành"
**Trigger:** Shipper physically collects the order.
**Preconditions:** Cross-cutting authentication/access preconditions apply; Shipper is assigned to the order.
**Success Postconditions:** Order.Status = "Hoàn thành".
**Main Success Flow:**
1. Shipper travels to the restaurant and collects the physical order.
2. Shipper updates the order status to "Đang giao".
3. System records the Order.Status as "Đang giao" (ST-03).
4. Shipper travels to the Customer and completes the physical delivery.
5. Shipper updates the order status to "Hoàn thành".
6. System records the Order.Status as "Hoàn thành" (ST-04).
**Alternative Flows:** —
**Exception / Rejection Flows:**
- Shipper cancels the assignment before completion. System clears the Shipper association and returns the Order to the delivery pool. Exact post-cancellation Order.Status transition is NOT EVIDENCED / REQUIRES CLARIFICATION.
**Open Questions / Clarifications:**
- Post-Shipper-cancellation Order.Status transition is NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; TO_BE_Cross_Role_Process.md; Order_State_Diagram.md

### UC-SHP-04 — View Delivery History & Income
**Goal:** Shipper views completed deliveries and income statistics.
**Primary Actor:** Shipper
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-SHP-04
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Shipper accesses statistics modules.
**Preconditions:** Shipper is authenticated under the relevant role.
**Success Postconditions:** Income history and completed deliveries are displayed.
**Main Success Flow:**
1. Shipper requests to view their delivery history and income statistics.
2. System retrieves and displays the completed deliveries and relevant income history.
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:**
- BR-PARTNER-01 applicability to this capability is NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-SHP-05 — Manage Profile
**Goal:** View and update personal profile and account information.
**Primary Actor:** Shipper
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-SHP-05
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Shipper accesses profile settings.
**Preconditions:** Shipper is authenticated under the relevant role.
**Success Postconditions:** Profile/account information is displayed; if updates are submitted, the supported changes are saved.
**Main Success Flow:**
1. Shipper requests to view their profile.
2. System displays current profile details.
3. Shipper submits new information.
4. System processes and saves the profile updates.
**Alternative Flows:**
- View-only: After the System displays the current profile/account information, the Shipper may end the Use Case without submitting changes.
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:**
- BR-PARTNER-01 applicability to profile/account management: NOT EVIDENCED.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-ADM-01 — Manage User Accounts
**Goal:** Administrator manages system user accounts across all roles.
**Primary Actor:** Administrator
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-ADM-01
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Administrator accesses the user management module.
**Preconditions:** Administrator is authenticated.
**Success Postconditions:** User account changes are recorded.
**Main Success Flow:**
1. Administrator requests to view user accounts.
2. System displays the list of users.
3. Administrator performs account management actions.
4. System processes and records changes.
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:** —
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

### UC-ADM-02 — Approve Partner Registrations
**Goal:** Administrator approves new Restaurant and Shipper registrations.
**Primary Actor:** Administrator
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-ADM-02
**Related Business Rules:** BR-PARTNER-01
**Related Order States / Transitions:** —
**Trigger:** Administrator initiates review of registrations requiring approval.
**Preconditions:** A Restaurant or Shipper registration exists and has not yet received Administrator approval.
**Success Postconditions:** The partner account is approved for normal operation.
**Main Success Flow:**
1. Administrator views registrations requiring approval.
2. Administrator reviews a specific registration and approves it.
3. System records the approval status, permitting normal operation (BR-PARTNER-01).
**Alternative Flows:** —
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:**
- Exact approval-state vocabulary and rejection workflows are NOT EVIDENCED / REQUIRES CLARIFICATION.
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; Business_Rules_Catalogue.md

### UC-ADM-03 — View and Export System Statistics
**Goal:** Administrator views system-wide statistics and exports revenue data to Excel.
**Primary Actor:** Administrator
**Supporting Actors / Systems:** —
**Related Functional Requirements:** FR-ADM-03, FR-ADM-04
**Related Business Rules:** —
**Related Order States / Transitions:** —
**Trigger:** Administrator requests to view system-wide statistics.
**Preconditions:** Administrator is authenticated.
**Success Postconditions:** System displays statistics; if requested, provides a downloadable Excel file.
**Main Success Flow:**
1. Administrator requests system-wide statistics.
2. System presents operational and revenue statistics.
**Alternative Flows:**
- A1 — Export Revenue Statistics:
  1. Administrator requests export of revenue statistics.
  2. System generates and provides an Excel file.
**Exception / Rejection Flows:** —
**Open Questions / Clarifications:** —
**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

## 6. Cross-Use-Case Open Questions

1. Exact Restaurant confirmation/intermediate-state semantics between "Chờ xác nhận" and "Đang lấy món": NOT EVIDENCED / REQUIRES CLARIFICATION.
2. Exact post-Shipper-cancellation Order.Status transition: NOT EVIDENCED / REQUIRES CLARIFICATION.
3. Exact status/attribute derivation of "active delivery" for BR-SHIP-01: NOT EVIDENCED / REQUIRES CLARIFICATION.
4. BR-FEE-01 fractional-kilometre rounding rule: NOT EVIDENCED / REQUIRES CLARIFICATION.
5. BR-FEE-02 authoritative timestamp for service fee calculation: NOT EVIDENCED / REQUIRES CLARIFICATION.
6. BR-PARTNER-01 exact approval-state vocabulary and rejection workflows: NOT EVIDENCED / REQUIRES CLARIFICATION.
7. BR-ORDER-01 review cardinality and editability rules: NOT EVIDENCED / REQUIRES CLARIFICATION.

## 7. Source Mapping

| Use Case ID | Primary Source | Supporting Approved Artefact | Related FRs | Related BRs | State Relevance | Evidence Classification |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| UC-CUS-01 | S1 | — | FR-CUS-01 | — | — | BASELINE |
| UC-CUS-02 | S1 | — | FR-CUS-02, FR-CUS-03 | — | — | BASELINE |
| UC-CUS-03 | S1 | TO-BE Process, Order State Model | FR-CUS-04, FR-CUS-05, FR-CUS-06 | BR-DEL-01, BR-FEE-01, BR-FEE-02 | ST-01, "Chờ xác nhận" | BASELINE |
| UC-CUS-04 | S1 | — | FR-CUS-07 | — | Current Order.Status as applicable | BASELINE |
| UC-CUS-05 | S1 | — | FR-CUS-09 | — | — | BASELINE |
| UC-CUS-06 | S1 | Order State Model | FR-CUS-08 | BR-ORDER-01 | "Hoàn thành" | BASELINE |
| UC-RES-01 | S1 | — | FR-RES-01, FR-RES-02, FR-RES-03 | — | — | BASELINE |
| UC-RES-02 | S1 | TO-BE Process, Order State Model | FR-RES-04, FR-RES-05 | BR-PARTNER-01 | ST-02, "Đang lấy món" | BASELINE (confirmed endpoints); intermediate semantics NOT EVIDENCED |
| UC-RES-03 | S1 | — | FR-RES-06, FR-RES-07 | — | — | BASELINE |
| UC-SHP-01 | S1 | TO-BE Process | FR-SHP-01 | BR-PARTNER-01 | Non-state condition: Unassigned | BASELINE |
| UC-SHP-02 | S1 | Business Rules Catalogue | FR-SHP-02 | BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01 | "Đang lấy món" | BASELINE |
| UC-SHP-03 | S1 | TO-BE Process, Order State Model | FR-SHP-03 | BR-PARTNER-01 | ST-03, ST-04, "Đang giao", "Hoàn thành" | BASELINE |
| UC-SHP-04 | S1 | — | FR-SHP-04 | — | — | BASELINE |
| UC-SHP-05 | S1 | — | FR-SHP-05 | — | — | BASELINE |
| UC-ADM-01 | S1 | — | FR-ADM-01 | — | — | BASELINE |
| UC-ADM-02 | S1 | Business Rules Catalogue | FR-ADM-02 | BR-PARTNER-01 | — | BASELINE |
| UC-ADM-03 | S1 | — | FR-ADM-03, FR-ADM-04 | — | — | BASELINE |

## 8. Analysis Summary

The Use Case model provides controlled behavioural coverage of the approved functional baseline while preserving unresolved business semantics for later clarification. The model defines 17 controlled actor-goal Use Cases. The actor-specific requirements are mapped directly to these Use Cases, while FR-AUTH-01 and FR-AUTH-02 are retained as cross-cutting registration and authentication behaviours. All 27 S1 Functional Requirements are explicitly accounted for.

All primary actors (Customer, Restaurant, Shipper, Administrator) are fully represented. Authentication and basic access mechanisms are strictly managed as cross-cutting behaviours supporting the core Use Cases. Critical business rules (BR-DEL-01, BR-FEE-01, BR-FEE-02, BR-SHIP-01, BR-SHIP-02, BR-ORDER-01, BR-PARTNER-01) have been integrated as flow evaluations and preconditions. The four confirmed lifecycle states ("Chờ xác nhận", "Đang lấy món", "Đang giao", "Hoàn thành") correctly map to the order processing sequence. 

Unresolved semantics regarding fractional-km rounding, intermediate Restaurant preparation states, Shipper cancellation rollback paths, and review cardinality are intentionally documented as Open Questions, avoiding the invention of business policy. This approved Use Case baseline is ready to support downstream User Story and Acceptance Criteria modelling while preserving the documented unresolved semantics.
