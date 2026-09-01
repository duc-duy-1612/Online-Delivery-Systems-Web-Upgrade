# User Stories & Acceptance Criteria — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: User Story & Acceptance Criteria Specification
Source Baseline: S1 — Validated Portfolio BRD
Depends On: Business_Rules_Catalogue.md — APPROVED v1.0; Order_State_Diagram.md — APPROVED v1.0; Detailed_Use_Cases.md — APPROVED v1.0
Last Reviewed: 15 Aug 2026

## 1. Purpose

This artefact decomposes approved Use Cases into implementable actor-goal User Stories and defines testable Acceptance Criteria. It preserves traceability to FRs, BRs, and lifecycle states, identifying positive, boundary, and rejection behaviour where evidenced. It keeps unresolved requirements explicitly unresolved and provides a controlled input to Requirements Traceability Matrix (RTM) and User Acceptance Testing (UAT) downstream.

## 2. User Story Inventory

| User Story ID | Story Name | Primary Actor | Source Use Case | Related FRs | Related BRs | State Relevance | Evidence Classification |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| **US-CUS-01** | Manage Personal Profile & Password | Customer | UC-CUS-01 | FR-CUS-01 | — | — | BASELINE |
| **US-CUS-02** | Browse Restaurants & Menus | Customer | UC-CUS-02 | FR-CUS-02 | — | — | BASELINE |
| **US-CUS-03** | Manage Shopping Cart | Customer | UC-CUS-02 | FR-CUS-03 | — | — | BASELINE |
| **US-CUS-04** | Checkout & Place Order | Customer | UC-CUS-03 | FR-CUS-04, FR-CUS-05, FR-CUS-06 | BR-DEL-01, BR-FEE-01, BR-FEE-02 | ST-01, "Chờ xác nhận" | BASELINE |
| **US-CUS-05** | Track Active Order | Customer | UC-CUS-04 | FR-CUS-07 | — | Current Order.Status as applicable | BASELINE |
| **US-CUS-06** | View Orders, History & Details | Customer | UC-CUS-05 | FR-CUS-09 | — | — | BASELINE |
| **US-CUS-07** | Review Completed Order | Customer | UC-CUS-06 | FR-CUS-08 | BR-ORDER-01 | "Hoàn thành" | BASELINE |
| **US-RES-01** | Update Store Information | Restaurant | UC-RES-01 | FR-RES-01 | — | — | BASELINE |
| **US-RES-02** | Manage Menu Categories | Restaurant | UC-RES-01 | FR-RES-02 | — | — | BASELINE |
| **US-RES-03** | Manage Food Items | Restaurant | UC-RES-01 | FR-RES-03 | — | — | BASELINE |
| **US-RES-04** | Process Incoming Order | Restaurant | UC-RES-02 | FR-RES-04, FR-RES-05 | BR-PARTNER-01 | ST-02, "Đang lấy món" | BASELINE |
| **US-RES-05** | View Revenue & Order History | Restaurant | UC-RES-03 | FR-RES-06 | — | — | BASELINE |
| **US-RES-06** | View Customer Reviews | Restaurant | UC-RES-03 | FR-RES-07 | — | — | BASELINE |
| **US-SHP-01** | View Available Deliveries | Shipper | UC-SHP-01 | FR-SHP-01 | BR-PARTNER-01 | Non-state condition: Unassigned | BASELINE |
| **US-SHP-02** | Accept Delivery Assignment | Shipper | UC-SHP-02 | FR-SHP-02 | BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01 | "Đang lấy món" | BASELINE |
| **US-SHP-03** | Execute Delivery | Shipper | UC-SHP-03 | FR-SHP-03 | BR-PARTNER-01 | ST-03, ST-04, "Đang giao", "Hoàn thành" | BASELINE |
| **US-SHP-04** | View Delivery History & Income | Shipper | UC-SHP-04 | FR-SHP-04 | — | — | BASELINE |
| **US-SHP-05** | Manage Profile & Account Information | Shipper | UC-SHP-05 | FR-SHP-05 | — | — | BASELINE |
| **US-ADM-01** | Manage User Accounts | Administrator | UC-ADM-01 | FR-ADM-01 | — | — | BASELINE |
| **US-ADM-02** | Approve Partner Registrations | Administrator | UC-ADM-02 | FR-ADM-02 | BR-PARTNER-01 | — | BASELINE |
| **US-ADM-03** | View System Statistics | Administrator | UC-ADM-03 | FR-ADM-03 | — | — | BASELINE |
| **US-ADM-04** | Export Revenue Statistics | Administrator | UC-ADM-03 | FR-ADM-04 | — | — | BASELINE |

## 3. Cross-Cutting Authentication & Access Acceptance Conditions

**FR-AUTH-01 — Registration**
- Given a Guest initiates registration,
- When they complete the registration process,
- Then an account may be registered under the chosen role: Customer, Restaurant, or Shipper.

**FR-AUTH-02 — Authentication**
- Given a registered user supplies their username and password,
- When the System authenticates the supplied credentials,
- Then on successful authentication, the user receives access to / is redirected to the appropriate role-based module.

*(Detailed authentication failure behaviour is NOT EVIDENCED / REQUIRES CLARIFICATION.)*

**BR-PARTNER-01 — Core Partner Operational Access**
For the core operational capabilities explicitly mapped to BR-PARTNER-01 in the approved Detailed Use Cases:
- Given a Restaurant or Shipper account has not received Administrator approval, When the user attempts a mapped normal operational capability, Then that operational capability is not available.
- Given the account has received Administrator approval, When the user accesses a mapped authorized operational capability, Then the approval rule does not prevent access.

*(Exact wider "normal operation" capability boundary: NOT EVIDENCED / REQUIRES CLARIFICATION.)*

## 4. Functional Requirement Coverage

| FR ID | Mapped User Story / Cross-Cutting Section | Acceptance Criteria Coverage | Coverage Type | Notes |
| :--- | :--- | :--- | :--- | :--- |
| FR-AUTH-01 | Section 3 | Cross-Cutting Registration | Cross-cutting | — |
| FR-AUTH-02 | Section 3 | Cross-Cutting Authentication | Cross-cutting | — |
| FR-CUS-01 | US-CUS-01 | AC-US-CUS-01-01 to AC-US-CUS-01-03 | Direct | — |
| FR-CUS-02 | US-CUS-02 | AC-US-CUS-02-01 | Direct | — |
| FR-CUS-03 | US-CUS-03 | AC-US-CUS-03-01 to AC-US-CUS-03-03 | Direct | — |
| FR-CUS-04 | US-CUS-04 | AC-US-CUS-04-01 to AC-US-CUS-04-03 | Direct | — |
| FR-CUS-05 | US-CUS-04 | AC-US-CUS-04-04 to AC-US-CUS-04-08 | Direct | — |
| FR-CUS-06 | US-CUS-04 | AC-US-CUS-04-09 | Direct | — |
| FR-CUS-07 | US-CUS-05 | AC-US-CUS-05-01, AC-US-CUS-05-02 | Direct | — |
| FR-CUS-08 | US-CUS-07 | AC-US-CUS-07-01, AC-US-CUS-07-02 | Direct | — |
| FR-CUS-09 | US-CUS-06 | AC-US-CUS-06-01 to AC-US-CUS-06-03 | Direct | — |
| FR-RES-01 | US-RES-01 | AC-US-RES-01-01 | Direct | — |
| FR-RES-02 | US-RES-02 | AC-US-RES-02-01 | Direct | — |
| FR-RES-03 | US-RES-03 | AC-US-RES-03-01 to AC-US-RES-03-03 | Direct | — |
| FR-RES-04 | US-RES-04 | AC-US-RES-04-01 | Direct | — |
| FR-RES-05 | US-RES-04 | AC-US-RES-04-02 | Direct | — |
| FR-RES-06 | US-RES-05 | AC-US-RES-05-01, AC-US-RES-05-02 | Direct | — |
| FR-RES-07 | US-RES-06 | AC-US-RES-06-01 | Direct | — |
| FR-SHP-01 | US-SHP-01 | AC-US-SHP-01-01 | Direct | — |
| FR-SHP-02 | US-SHP-02 | AC-US-SHP-02-01 to AC-US-SHP-02-04 | Direct | — |
| FR-SHP-03 | US-SHP-03 | AC-US-SHP-03-01, AC-US-SHP-03-02 | Direct | AC-US-SHP-03-03 captures an approved process/use-case exception and is not direct FR-SHP-03 behaviour. |
| FR-SHP-04 | US-SHP-04 | AC-US-SHP-04-01, AC-US-SHP-04-02 | Direct | — |
| FR-SHP-05 | US-SHP-05 | AC-US-SHP-05-01, AC-US-SHP-05-02 | Direct | — |
| FR-ADM-01 | US-ADM-01 | AC-US-ADM-01-01 | Direct | — |
| FR-ADM-02 | US-ADM-02 | AC-US-ADM-02-01 | Direct | — |
| FR-ADM-03 | US-ADM-03 | AC-US-ADM-03-01, AC-US-ADM-03-02 | Direct | — |
| FR-ADM-04 | US-ADM-04 | AC-US-ADM-04-01 | Direct | — |

## 5. Business Rule Coverage

| BR ID | Mapped Story / Stories | Related ACs | Coverage | Open Issue |
| :--- | :--- | :--- | :--- | :--- |
| BR-ORDER-01 | US-CUS-07 | AC-US-CUS-07-01, AC-US-CUS-07-02 | Covered | Review cardinality/editability. |
| BR-SHIP-01 | US-SHP-02 | AC-US-SHP-02-04 | Covered | Exact active delivery definition. |
| BR-SHIP-02 | US-SHP-02 | AC-US-SHP-02-01, AC-US-SHP-02-02, AC-US-SHP-02-03 | Covered | — |
| BR-DEL-01 | US-CUS-04 | AC-US-CUS-04-02, AC-US-CUS-04-03 | Covered | — |
| BR-FEE-01 | US-CUS-04 | AC-US-CUS-04-04, AC-US-CUS-04-05 | Covered | Fractional-km rounding. |
| BR-FEE-02 | US-CUS-04 | AC-US-CUS-04-06, AC-US-CUS-04-07 | Covered | Authoritative timestamp. |
| BR-PARTNER-01 | US-RES-04, US-SHP-01, US-SHP-02, US-SHP-03, US-ADM-02 | Section 3 — BR-PARTNER-01 Cross-Cutting Conditions, AC-US-ADM-02-01 | Covered | "Normal operation" capability boundary. Exact approval-state vocabulary. |

## 6. State Transition Coverage

| Transition | Mapped User Story | Related ACs |
| :--- | :--- | :--- |
| ST-01: Initial → "Chờ xác nhận" | US-CUS-04 | AC-US-CUS-04-09 |
| ST-02: "Chờ xác nhận" → "Đang lấy món" | US-RES-04 | AC-US-RES-04-02 |
| ST-03: "Đang lấy món" → "Đang giao" | US-SHP-03 | AC-US-SHP-03-01 |
| ST-04: "Đang giao" → "Hoàn thành" | US-SHP-03 | AC-US-SHP-03-02 |

## 7. Story-to-Use-Case Traceability

| User Story ID | Source Use Case | Functional Requirements | Business Rules | State / Transition | Acceptance Criteria IDs |
| :--- | :--- | :--- | :--- | :--- | :--- |
| US-CUS-01 | UC-CUS-01 | FR-CUS-01 | — | — | AC-US-CUS-01-01 to 03 |
| US-CUS-02 | UC-CUS-02 | FR-CUS-02 | — | — | AC-US-CUS-02-01 |
| US-CUS-03 | UC-CUS-02 | FR-CUS-03 | — | — | AC-US-CUS-03-01 to 03 |
| US-CUS-04 | UC-CUS-03 | FR-CUS-04, FR-CUS-05, FR-CUS-06 | BR-DEL-01, BR-FEE-01, BR-FEE-02 | ST-01, "Chờ xác nhận" | AC-US-CUS-04-01 to 09 |
| US-CUS-05 | UC-CUS-04 | FR-CUS-07 | — | Current status | AC-US-CUS-05-01, 02 |
| US-CUS-06 | UC-CUS-05 | FR-CUS-09 | — | — | AC-US-CUS-06-01 to 03 |
| US-CUS-07 | UC-CUS-06 | FR-CUS-08 | BR-ORDER-01 | "Hoàn thành" | AC-US-CUS-07-01, 02 |
| US-RES-01 | UC-RES-01 | FR-RES-01 | — | — | AC-US-RES-01-01 |
| US-RES-02 | UC-RES-01 | FR-RES-02 | — | — | AC-US-RES-02-01 |
| US-RES-03 | UC-RES-01 | FR-RES-03 | — | — | AC-US-RES-03-01 to 03 |
| US-RES-04 | UC-RES-02 | FR-RES-04, FR-RES-05 | BR-PARTNER-01 | ST-02, "Đang lấy món" | AC-US-RES-04-01, 02 |
| US-RES-05 | UC-RES-03 | FR-RES-06 | — | — | AC-US-RES-05-01, 02 |
| US-RES-06 | UC-RES-03 | FR-RES-07 | — | — | AC-US-RES-06-01 |
| US-SHP-01 | UC-SHP-01 | FR-SHP-01 | BR-PARTNER-01 | Unassigned condition | AC-US-SHP-01-01 |
| US-SHP-02 | UC-SHP-02 | FR-SHP-02 | BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01 | "Đang lấy món" | AC-US-SHP-02-01 to 04 |
| US-SHP-03 | UC-SHP-03 | FR-SHP-03 | BR-PARTNER-01 | ST-03, ST-04, "Đang giao", "Hoàn thành" | AC-US-SHP-03-01 to 03 |
| US-SHP-04 | UC-SHP-04 | FR-SHP-04 | — | — | AC-US-SHP-04-01, 02 |
| US-SHP-05 | UC-SHP-05 | FR-SHP-05 | — | — | AC-US-SHP-05-01, 02 |
| US-ADM-01 | UC-ADM-01 | FR-ADM-01 | — | — | AC-US-ADM-01-01 |
| US-ADM-02 | UC-ADM-02 | FR-ADM-02 | BR-PARTNER-01 | — | AC-US-ADM-02-01 |
| US-ADM-03 | UC-ADM-03 | FR-ADM-03 | — | — | AC-US-ADM-03-01, 02 |
| US-ADM-04 | UC-ADM-03 | FR-ADM-04 | — | — | AC-US-ADM-04-01 |

## 8. Cross-Story Open Questions / Deferred Acceptance Criteria

1. Exact Restaurant confirmation/intermediate-state semantics between "Chờ xác nhận" and "Đang lấy món" are NOT EVIDENCED / REQUIRES CLARIFICATION.
2. Exact post-Shipper-cancellation Order.Status transition remains NOT EVIDENCED / REQUIRES CLARIFICATION.
3. Exact state/attribute definition of "active delivery" under BR-SHIP-01 is NOT EVIDENCED / REQUIRES CLARIFICATION.
4. Fractional-kilometre rounding behaviour under BR-FEE-01 is NOT EVIDENCED / REQUIRES CLARIFICATION.
5. Authoritative timestamp for the service fee calculation under BR-FEE-02 is NOT EVIDENCED / REQUIRES CLARIFICATION.
6. Exact approval-state vocabulary and rejection workflows under BR-PARTNER-01 are NOT EVIDENCED / REQUIRES CLARIFICATION.
7. Review cardinality (e.g., one-review-per-order) and editability rules under BR-ORDER-01 are NOT EVIDENCED / REQUIRES CLARIFICATION.
8. Whether authentication is required for browsing restaurants and menus is NOT EVIDENCED / REQUIRES CLARIFICATION.
9. Input-validation rules for Customer profile/account updates are NOT EVIDENCED / REQUIRES CLARIFICATION.
10. Tracking coordinate refresh frequency and notification-channel behaviour are NOT EVIDENCED / REQUIRES CLARIFICATION.
11. BR-PARTNER-01 applicability boundary regarding "normal operation" for non-core capabilities (US-RES-01, US-RES-02, US-RES-03, US-RES-05, US-RES-06, US-SHP-04, US-SHP-05) is NOT EVIDENCED / REQUIRES CLARIFICATION.
12. Detailed authentication failure behaviour is NOT EVIDENCED / REQUIRES CLARIFICATION.
13. Exact supported menu-category management operations are NOT EVIDENCED / REQUIRES CLARIFICATION.
14. Exact supported Administrator user-account management actions are NOT EVIDENCED / REQUIRES CLARIFICATION.

## 9. Detailed User Stories & Acceptance Criteria

### US-CUS-01 — Manage Personal Profile & Password

**User Story**
As a Customer,
I want to view and update my personal profile information
and change my account password,
so that my account details remain accurate.

**Source Use Case:** UC-CUS-01
**Related Functional Requirements:** FR-CUS-01
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-CUS-01-01 — View Profile:** Given the Customer accesses their profile settings, When the System displays the profile, Then the current personal profile and account information is shown.
- **AC-US-CUS-01-02 — Update Profile:** Given the Customer views their profile, When the Customer submits updated profile information, Then the System processes and saves the supported changes.
- **AC-US-CUS-01-03 — Change Password:** Given the Customer accesses account settings, When the Customer submits a new password, Then the System processes and saves the changed password.

**Open Questions / Deferred Criteria:**
- Input-validation rules for Customer profile/account updates: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-CUS-02 — Browse Restaurants & Menus

**User Story**
As a Customer,
I want to browse active restaurants and their associated menus,
so that I can find food items to order.

**Source Use Case:** UC-CUS-02
**Related Functional Requirements:** FR-CUS-02
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-CUS-02-01 — Browse Restaurants and Menus:** Given the Customer navigates to the restaurant listing, When they select an active Restaurant, Then the System displays the Restaurant's associated menu.

**Open Questions / Deferred Criteria:**
- Whether authentication is required for browsing restaurants and menus: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-CUS-03 — Manage Shopping Cart

**User Story**
As a Customer,
I want to manage items in my shopping cart,
so that I can prepare my desired order for checkout.

**Source Use Case:** UC-CUS-02
**Related Functional Requirements:** FR-CUS-03
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-CUS-03-01 — Add Items:** Given the Customer is viewing a menu, When they add selected food items to their cart, Then the System updates the cart contents.
- **AC-US-CUS-03-02 — Remove Items:** Given the Customer has items in their cart, When they remove an item, Then the System removes the item from the cart.
- **AC-US-CUS-03-03 — Update Quantity:** Given the Customer has an item in their cart, When they adjust the item's quantity, Then the System updates the cart contents to reflect the new quantity.

**Open Questions / Deferred Criteria:** —

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-CUS-04 — Checkout & Place Order

**User Story**
As a Customer,
I want to finalize my cart, validate delivery details, and submit my order using COD or QR Payment Simulation,
so that my order is placed with the Restaurant.

**Source Use Case:** UC-CUS-03
**Related Functional Requirements:** FR-CUS-04, FR-CUS-05, FR-CUS-06
**Related Business Rules:** BR-DEL-01, BR-FEE-01, BR-FEE-02
**Related States / Transitions:** ST-01, "Chờ xác nhận"

**Acceptance Criteria**
- **AC-US-CUS-04-01 — Validate Address & Calculate Distance:** Given the Customer provides delivery details during checkout, When the System evaluates the delivery location, Then the System validates the delivery address and calculates the Restaurant-to-Customer delivery distance using the supported Map / Routing capability.
- **AC-US-CUS-04-02 — Delivery Distance Within Limit:** Given the calculated Restaurant-to-Customer delivery distance is <= 30 km, When the System evaluates BR-DEL-01, Then the delivery-distance validation passes and BR-DEL-01 does not reject the checkout. *(DERIVED from >30km threshold)*
- **AC-US-CUS-04-03 — Delivery Distance Exceeds Limit:** Given the calculated delivery distance is > 30 km, When the Customer proceeds with checkout, Then the System rejects the checkout attempt.
- **AC-US-CUS-04-04 — Delivery Fee (Base Distance):** Given the calculated delivery distance is 3 km, When the delivery fee is calculated, Then the delivery fee is VND 15,000.
- **AC-US-CUS-04-05 — Delivery Fee (Additional Distance):** Given the calculated delivery distance is 4 km, When the delivery fee is calculated, Then the delivery fee is VND 18,000. *(DERIVED arithmetic example from BR-FEE-01)*
- **AC-US-CUS-04-06 — Service Fee (Before 19:00):** Given the applicable order time is before 19:00, When the service fee is calculated, Then the service fee is VND 16,000.
- **AC-US-CUS-04-07 — Service Fee (From 19:00):** Given the applicable order time is 19:00 or later, When the service fee is calculated, Then the service fee is VND 20,000.
- **AC-US-CUS-04-08 — Calculate Total Before Confirmation:** Given the applicable order components and fees have been determined, When checkout is prepared for Customer confirmation, Then the System calculates and presents the total order amount before the Customer confirms the order.
- **AC-US-CUS-04-09 — Order Creation:** Given checkout requirements are satisfied and the Customer selects COD or QR Payment Simulation, When the Customer confirms and submits the order, Then the System creates the Order with status "Chờ xác nhận".

**Open Questions / Deferred Criteria:**
- Fractional-kilometre rounding under BR-FEE-01: NOT EVIDENCED / REQUIRES CLARIFICATION.
- Authoritative timestamp under BR-FEE-02: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; Order_State_Diagram.md

---

### US-CUS-05 — Track Active Order

**User Story**
As a Customer,
I want to view the status and routing of my active order,
so that I am informed of its progress.

**Source Use Case:** UC-CUS-04
**Related Functional Requirements:** FR-CUS-07
**Related Business Rules:** —
**Related States / Transitions:** Current Order.Status as applicable.

**Acceptance Criteria**
- **AC-US-CUS-05-01 — View Active Status:** Given the Customer has an active order, When they track the order, Then the System displays the current Order.Status.
- **AC-US-CUS-05-02 — View Routing Information:** Given the Customer has an active order and Shipper location/routing information is available, When they track the order, Then the System displays the available Shipper location and/or delivery routing information.

**Open Questions / Deferred Criteria:**
- Tracking coordinate refresh frequency and notification-channel behaviour: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-CUS-06 — View Orders, History & Details

**User Story**
As a Customer,
I want to view my current orders, completed order history, and detailed information for selected orders,
so that I can monitor my activity.

**Source Use Case:** UC-CUS-05
**Related Functional Requirements:** FR-CUS-09
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-CUS-06-01 — View Current Orders:** Given the Customer has current orders, When they request to view their orders, Then the System displays the current orders.
- **AC-US-CUS-06-02 — View Order History:** Given the Customer has completed orders, When they request to view their orders, Then the System displays the completed order history.
- **AC-US-CUS-06-03 — View Order Details:** Given the Customer views their order list, When they select a specific order, Then the System displays the available details for that order.

**Open Questions / Deferred Criteria:** —

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-CUS-07 — Review Completed Order

**User Story**
As a Customer,
I want to submit ratings and reviews for the Restaurant and Shipper of a completed order,
so that I can provide feedback on my experience.

**Source Use Case:** UC-CUS-06
**Related Functional Requirements:** FR-CUS-08
**Related Business Rules:** BR-ORDER-01
**Related States / Transitions:** "Hoàn thành"

**Acceptance Criteria**
- **AC-US-CUS-07-01 — Successful Review:** Given an Order has status "Hoàn thành", When the Customer submits ratings and reviews for the Restaurant and Shipper, Then the System permits and records the review.
- **AC-US-CUS-07-02 — Rejected Review:** Given an Order has a status other than "Hoàn thành", When the Customer attempts to submit a review, Then the System rejects the review attempt.

**Open Questions / Deferred Criteria:**
- Review cardinality and editability rules under BR-ORDER-01: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-RES-01 — Update Store Information

**User Story**
As a Restaurant,
I want to update my store information,
so that my store profile remains accurate.

**Source Use Case:** UC-RES-01
**Related Functional Requirements:** FR-RES-01
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-RES-01-01 — Update Store Information:** Given the Restaurant accesses store management, When they submit updated store information, Then the System persists the requested changes.

**Open Questions / Deferred Criteria:**
- BR-PARTNER-01 applicability boundary regarding "normal operation" for this capability: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-RES-02 — Manage Menu Categories

**User Story**
As a Restaurant,
I want to manage my menu categories,
so that I can organize my food offerings.

**Source Use Case:** UC-RES-01
**Related Functional Requirements:** FR-RES-02
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-RES-02-01 — Manage Categories:** Given the Restaurant accesses menu management, When they manage menu categories, Then the System persists the requested changes.

**Open Questions / Deferred Criteria:**
- Exact supported menu-category management operations are NOT EVIDENCED / REQUIRES CLARIFICATION.
- BR-PARTNER-01 applicability boundary regarding "normal operation" for this capability: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-RES-03 — Manage Food Items

**User Story**
As a Restaurant,
I want to create, update, and remove food items,
so that my menu reflects my current offerings.

**Source Use Case:** UC-RES-01
**Related Functional Requirements:** FR-RES-03
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-RES-03-01 — Create Food Item:** Given the Restaurant accesses menu management, When they submit a new food item, Then the System persists the creation.
- **AC-US-RES-03-02 — Update Food Item:** Given the Restaurant accesses menu management, When they submit updates to an existing food item, Then the System persists the updates.
- **AC-US-RES-03-03 — Remove Food Item:** Given the Restaurant accesses menu management, When they remove an existing food item, Then the System persists the removal.

**Open Questions / Deferred Criteria:**
- BR-PARTNER-01 applicability boundary regarding "normal operation" for this capability: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-RES-04 — Process Incoming Order

**User Story**
As a Restaurant,
I want to view incoming orders and mark them as ready when preparation is complete,
so that the order becomes available for Shipper pickup.

**Source Use Case:** UC-RES-02
**Related Functional Requirements:** FR-RES-04, FR-RES-05
**Related Business Rules:** BR-PARTNER-01
**Related States / Transitions:** "Chờ xác nhận", ST-02, "Đang lấy món"

**Acceptance Criteria**
- **AC-US-RES-04-01 — View Order:** Given an Order has status "Chờ xác nhận", When the Restaurant views incoming orders, Then the System displays the order list and details.
- **AC-US-RES-04-02 — Mark Ready (ST-02):** Given the Order has status "Chờ xác nhận" and the Restaurant has completed preparation of the physical order, When the Restaurant selects "Làm xong", Then the System records the Order.Status as "Đang lấy món".

**Open Questions / Deferred Criteria:**
- Exact Restaurant confirmation/intermediate-state semantics between "Chờ xác nhận" and "Đang lấy món": NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; Order_State_Diagram.md

---

### US-RES-05 — View Revenue & Order History

**User Story**
As a Restaurant,
I want to view my revenue statistics and order history,
so that I can track my business performance.

**Source Use Case:** UC-RES-03
**Related Functional Requirements:** FR-RES-06
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-RES-05-01 — View Revenue:** Given the Restaurant requests to view statistics, When the System compiles the data, Then the System displays the revenue statistics.
- **AC-US-RES-05-02 — View Order History:** Given the Restaurant requests to view statistics, When the System compiles the data, Then the System displays the historical orders.

**Open Questions / Deferred Criteria:**
- BR-PARTNER-01 applicability boundary regarding "normal operation" for this capability: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-RES-06 — View Customer Reviews

**User Story**
As a Restaurant,
I want to view customer ratings and reviews associated with completed orders,
so that I can monitor customer feedback.

**Source Use Case:** UC-RES-03
**Related Functional Requirements:** FR-RES-07
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-RES-06-01 — View Reviews:** Given the Restaurant requests to view reviews, When the System compiles the data, Then the System displays the customer ratings and reviews.

**Open Questions / Deferred Criteria:**
- BR-PARTNER-01 applicability boundary regarding "normal operation" for this capability: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-SHP-01 — View Available Deliveries

**User Story**
As a Shipper,
I want to view available and unassigned delivery orders,
so that I can select an eligible delivery assignment.

**Source Use Case:** UC-SHP-01
**Related Functional Requirements:** FR-SHP-01
**Related Business Rules:** BR-PARTNER-01
**Related States / Transitions:** Non-state condition: Unassigned

**Acceptance Criteria**
- **AC-US-SHP-01-01 — View Available Deliveries:** Given an Order is available for delivery and has no Shipper assignment, When the Shipper requests available deliveries, Then the System displays that Order.

**Open Questions / Deferred Criteria:** —

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; TO_BE_Cross_Role_Process.md

---

### US-SHP-02 — Accept Delivery Assignment

**User Story**
As a Shipper,
I want to claim an available delivery order,
so that I am officially assigned to execute the delivery.

**Source Use Case:** UC-SHP-02
**Related Functional Requirements:** FR-SHP-02
**Related Business Rules:** BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01
**Related States / Transitions:** "Đang lấy món"

**Acceptance Criteria**
- **AC-US-SHP-02-01 — Successful Acceptance:** Given the Order is unassigned, and Order.Status is "Đang lấy món", and the Shipper has no conflicting active delivery, When the Shipper confirms acceptance, Then the System records the Shipper assignment to the Order.
- **AC-US-SHP-02-02 — Rejection (Wrong Status):** Given the Order.Status is NOT "Đang lấy món", When the Shipper attempts to accept the assignment, Then the System rejects the attempt.
- **AC-US-SHP-02-03 — Rejection (Already Assigned):** Given the Order is already assigned to a Shipper, When another Shipper attempts to accept the assignment, Then the System rejects the attempt.
- **AC-US-SHP-02-04 — Rejection (Active Limit Exceeded):** Given the Shipper already holds a conflicting active delivery under BR-SHIP-01, When the Shipper attempts to accept the assignment, Then the System rejects the attempt.

**Open Questions / Deferred Criteria:**
- Exact state/attribute definition of "active delivery" under BR-SHIP-01: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; Business_Rules_Catalogue.md

---

### US-SHP-03 — Execute Delivery

**User Story**
As a Shipper,
I want to update the Order lifecycle as I collect and complete a delivery,
so that the delivery progress is recorded.

**Source Use Case:** UC-SHP-03
**Related Functional Requirements:** FR-SHP-03
**Related Business Rules:** BR-PARTNER-01
**Related States / Transitions:** ST-03, "Đang giao", ST-04, "Hoàn thành"

**Acceptance Criteria**
- **AC-US-SHP-03-01 — Initiate Delivery (ST-03):** Given the Shipper is assigned to the Order and Order.Status is "Đang lấy món" and the Shipper collects the physical order, When the Shipper initiates delivery / updates the order to "Đang giao", Then the System records the Order.Status as "Đang giao".
- **AC-US-SHP-03-02 — Complete Delivery (ST-04):** Given the Order.Status is "Đang giao" and the Shipper completes physical delivery, When the Shipper updates the order status to "Hoàn thành", Then the System records the Order.Status as "Hoàn thành".
- **AC-US-SHP-03-03 — Assignment Cancellation:** Given a Shipper has an assigned delivery and the delivery has not been completed, When the supported assignment-cancellation action occurs, Then the System clears the Shipper association and returns the Order to the delivery pool.

**Open Questions / Deferred Criteria:**
- Exact post-Shipper-cancellation Order.Status transition: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; TO_BE_Cross_Role_Process.md; Order_State_Diagram.md

---

### US-SHP-04 — View Delivery History & Income

**User Story**
As a Shipper,
I want to view my completed deliveries and income statistics,
so that I can track my earnings and activity.

**Source Use Case:** UC-SHP-04
**Related Functional Requirements:** FR-SHP-04
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-SHP-04-01 — View Completed Deliveries:** Given the Shipper requests to view delivery history, When the System retrieves the data, Then the System displays the completed deliveries.
- **AC-US-SHP-04-02 — View Income Statistics:** Given the Shipper requests to view income statistics, When the System retrieves the data, Then the System displays the Shipper's income statistics.

**Open Questions / Deferred Criteria:**
- BR-PARTNER-01 applicability boundary regarding "normal operation" for this capability: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-SHP-05 — Manage Profile & Account Information

**User Story**
As a Shipper,
I want to view and update my personal profile and account information,
so that my details remain current.

**Source Use Case:** UC-SHP-05
**Related Functional Requirements:** FR-SHP-05
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-SHP-05-01 — View Profile/Account:** Given the Shipper requests to view their profile, When the System displays the details, Then the current profile and account information is shown.
- **AC-US-SHP-05-02 — Update Profile/Account:** Given the Shipper views their profile, When the Shipper submits new information, Then the System processes and saves the profile updates.

**Open Questions / Deferred Criteria:**
- BR-PARTNER-01 applicability boundary regarding "normal operation" for this capability: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-ADM-01 — Manage User Accounts

**User Story**
As an Administrator,
I want to manage system user accounts,
so that supported account administration can be performed.

**Source Use Case:** UC-ADM-01
**Related Functional Requirements:** FR-ADM-01
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-ADM-01-01 — Manage Users:** Given the Administrator accesses user management, When they perform supported account management actions, Then the System processes and records the changes.

**Open Questions / Deferred Criteria:**
- Exact supported Administrator user-account management actions are NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-ADM-02 — Approve Partner Registrations

**User Story**
As an Administrator,
I want to approve new Restaurant and Shipper registrations,
so that approved Restaurant and Shipper accounts can proceed to normal operation.

**Source Use Case:** UC-ADM-02
**Related Functional Requirements:** FR-ADM-02
**Related Business Rules:** BR-PARTNER-01
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-ADM-02-01 — Approve Partner:** Given a Restaurant or Shipper registration exists requiring approval, When the Administrator approves the registration, Then the System records the approval status permitting normal operation.

**Open Questions / Deferred Criteria:**
- Exact approval-state vocabulary and rejection workflows under BR-PARTNER-01: NOT EVIDENCED / REQUIRES CLARIFICATION.

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD; Business_Rules_Catalogue.md

---

### US-ADM-03 — View System Statistics

**User Story**
As an Administrator,
I want to view system-wide operational and revenue statistics,
so that I can review system-wide operational and revenue information.

**Source Use Case:** UC-ADM-03
**Related Functional Requirements:** FR-ADM-03
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-ADM-03-01 — View Operational Statistics:** Given the Administrator requests system-wide statistics, When the System compiles the data, Then the System presents operational statistics.
- **AC-US-ADM-03-02 — View Revenue Statistics:** Given the Administrator requests system-wide statistics, When the System compiles the data, Then the System presents revenue statistics.

**Open Questions / Deferred Criteria:** —

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD

---

### US-ADM-04 — Export Revenue Statistics

**User Story**
As an Administrator,
I want to export revenue statistics to Excel,
so that revenue statistics are available in Excel format for downstream use.

**Source Use Case:** UC-ADM-03
**Related Functional Requirements:** FR-ADM-04
**Related Business Rules:** —
**Related States / Transitions:** —

**Acceptance Criteria**
- **AC-US-ADM-04-01 — Export Revenue:** Given the Administrator requests to export revenue statistics, When the System generates the export, Then the System provides a downloadable Excel file containing the revenue data.

**Open Questions / Deferred Criteria:** —

**Evidence Classification:** BASELINE
**Source:** S1 — Validated Portfolio BRD
