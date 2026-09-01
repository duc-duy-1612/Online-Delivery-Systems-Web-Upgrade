# Functional Requirements Specification — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Functional Requirements Specification (FRS)

Source Baseline:
S1 Controlled Portfolio BRD;
Approved Business Rules Catalogue;
Approved Detailed Use Cases;
Approved User Stories & Acceptance Criteria;
Approved Order State Model;
Approved Data Dictionary;
Approved Logical ERD;
Approved Requirement Gap Analysis

Depends On:
00_README_BA_Evidence_Pack.md;
BRD_FoodDeliveryDB.md;
Business_Rules_Catalogue.md;
Detailed_Use_Cases.md;
User_Stories_Acceptance_Criteria.md;
Order_State_Diagram.md;
Data_Dictionary.md;
Logical_ERD.md;
Requirement_Gap_Analysis.md

## 1. Document Purpose
The FRS defines the operational and detailed functional behaviour of the Online Food Delivery System. It translates the approved business requirements into detailed, testable system functions, supporting controlled traceability from the BRD through functional behaviour and acceptance criteria into the downstream RTM and UAT design. It documents the TARGET behaviour, distinct from the CURRENT implemented prototype.

## 2. Functional Scope
The functional scope covers the four registered operational roles (Customer, Restaurant, Shipper, Administrator) and Guest interaction for registration/login. Public browsing behaviour remains subject to Clarification #9.

## 3. Source & Authority Basis
This FRS relies on the latest owner-approved Controlled Portfolio BRD as the authoritative source for TARGET requirements. Downstream artefacts (Use Cases, User Stories, State Models, Business Rules, Data Dictionary, ERD) add detail. Reviewed source code (S3) serves as evidence for CURRENT implemented behaviour only, not for TARGET behaviour.

## 4. Functional Architecture Overview
The system is divided into functional domains based on the authorized roles:
- **Authentication:** Registration and role-based login.
- **Customer Web:** Browsing restaurants, shopping cart, checkout, order tracking, and review.
- **Restaurant Portal:** Menu management, food item management, order receipt, and preparation tracking.
- **Shipper Portal:** Finding unassigned orders, accepting delivery assignments, and delivery status updates.
- **Admin Portal:** User account management, partner approval, and revenue reporting.

## 5. Authentication Functions

### FR-AUTH-01 — Users shall be able to register an account under an available role (Customer, Restaurant, Shipper).
**Primary Actor:** Guest
**Functional Objective:** Allow new individuals or businesses to create credentials and associate them with a specific system role.
**Trigger:** User navigates to the registration page and submits the registration form.
**Preconditions:** None.
**Inputs:** Username, password, requested role, profile data.
**Detailed System Behaviour:**
1. The system captures the user's registration details.
2. The system validates the inputs against general account constraints.
3. The system assigns the requested role.
4. For Restaurant and Shipper roles, the account requires Administrator approval before accessing operational capabilities.
**Validation / Business Rules:** Not Evidenced / requires validation (e.g. Username uniqueness). Partner accounts are subject to BR-PARTNER-01.
**Outputs / Result:** A new user account is created.
**State Impact:** N/A.
**Data Read:** Account.
**Data Created / Updated:** Account, Customer / Restaurant / Shipper profile.
**Exception / Alternative Behaviour:** Detailed failure behaviour remains TBD.
**Related Use Case:** Not Evidenced
**Related User Story / Acceptance Criteria:** AC Section 3 — Cross-Cutting Registration
**Related Business Rules:** BR-PARTNER-01.
**Related Data Elements / Entities:** Account.
**Related Gap / Clarification:** Clarification #13 (Detailed authentication failure behaviour); Clarification #7 (Approval-state vocabulary).

### FR-AUTH-02 — Registered users shall be able to authenticate using their username and password and be redirected to the appropriate role-based module.
**Primary Actor:** Cross-role (Customer, Restaurant, Shipper, Administrator)
**Functional Objective:** Verify user identity and restrict access to role-authorized functions.
**Trigger:** User submits login credentials.
**Preconditions:** User has a registered account.
**Inputs:** Username, Password.
**Detailed System Behaviour:**
1. The system verifies the provided username and password against stored credentials.
2. The system checks the account role.
3. If valid, the system redirects the user to the corresponding role dashboard.
**Validation / Business Rules:** Must match stored credentials.
**Outputs / Result:** Authenticated session, redirection.
**State Impact:** N/A.
**Data Read:** Account.
**Data Created / Updated:** N/A.
**Exception / Alternative Behaviour:** Detailed authentication failure behaviour is TBD.
**Related Use Case:** Not Evidenced
**Related User Story / Acceptance Criteria:** AC Section 3 — Cross-Cutting Authentication
**Related Business Rules:** None.
**Related Data Elements / Entities:** Account.
**Related Gap / Clarification:** Clarification #13 (Detailed authentication failure behaviour).
**Implementation Note:** See GAP-02 regarding TARGET password hashing vs CURRENT plaintext implementation.

## 6. Customer Functions

### FR-CUS-01 — Customer shall be able to view and update personal profile information and change account password.
**Primary Actor:** Customer
**Functional Objective:** Allow customers to maintain their contact details and secure their account.
**Trigger:** Customer accesses profile settings and saves changes.
**Preconditions:** Authenticated as Customer.
**Inputs:** Name, phone, address, new password.
**Detailed System Behaviour:**
1. System presents current profile information.
2. System accepts updated values.
3. System persists the new profile data or password.
**Validation / Business Rules:** Input validation rules are TBD.
**Outputs / Result:** Updated profile or password.
**State Impact:** N/A.
**Data Read:** Customer, Account.
**Data Created / Updated:** Customer, Account.
**Exception / Alternative Behaviour:** TBD.
**Related Use Case:** UC-CUS-01
**Related User Story / Acceptance Criteria:** US-CUS-01 / AC-US-CUS-01-01–AC-US-CUS-01-03
**Related Business Rules:** None.
**Related Data Elements / Entities:** Customer, Account.
**Related Gap / Clarification:** Clarification #10 (Customer profile input-validation rules).

### FR-CUS-02 — Customer shall be able to browse active restaurants and their associated menus.
**Primary Actor:** Customer
**Functional Objective:** Display available options for food ordering.
**Trigger:** User navigates to the restaurant or menu page.
**Preconditions:** None (Browsing authentication requirement is TBD).
**Inputs:** Category filters, search terms.
**Detailed System Behaviour:**
1. System queries and displays active restaurants.
2. System displays menu categories and food items associated with a selected restaurant.
**Validation / Business Rules:** Not Evidenced / requires validation (e.g. active-item display rules).
**Outputs / Result:** List of restaurants, list of food items.
**State Impact:** N/A.
**Data Read:** Restaurant, Menu Category, Food Item.
**Data Created / Updated:** None.
**Related Use Case:** UC-CUS-02
**Related User Story / Acceptance Criteria:** US-CUS-02 / AC-US-CUS-02-01
**Related Business Rules:** None.
**Related Data Elements / Entities:** Restaurant, Menu Category, Food Item.
**Related Gap / Clarification:** Clarification #9 (Browsing authentication requirement).

### FR-CUS-03 — Customer shall be able to add, remove, and update items in the shopping cart.
**Primary Actor:** Customer
**Functional Objective:** Enable accumulation of desired food items before checkout.
**Trigger:** Customer selects "Add to Cart" or modifies cart quantities.
**Preconditions:** Valid food items selected.
**Inputs:** Food Item ID, Quantity.
**Detailed System Behaviour:**
1. System adds the selected item to the cart or updates its quantity.
2. System calculates running line item totals.
**Validation / Business Rules:** TBD.
**Outputs / Result:** Updated cart state.
**State Impact:** N/A.
**Data Read:** Food Item.
**Data Created / Updated:** N/A.
**Related Use Case:** UC-CUS-02
**Related User Story / Acceptance Criteria:** US-CUS-03 / AC-US-CUS-03-01–AC-US-CUS-03-03
**Related Business Rules:** None.
**Related Data Elements / Entities:** Food Item.
**Related Gap / Clarification:** None.

### FR-CUS-04 — System shall validate the delivery address and calculate delivery distance via Map APIs.
**Primary Actor:** System
**Functional Objective:** Ensure delivery feasibility and quantify distance for fee calculation.
**Trigger:** Checkout process initiated.
**Preconditions:** Cart has items, Customer provides delivery address.
**Inputs:** Delivery Address.
**Detailed System Behaviour:**
1. System queries map API to validate the address and determine distance from the Restaurant.
2. System evaluates the distance against the delivery limit.
**Validation / Business Rules:** BR-DEL-01.
**Outputs / Result:** Computed distance, validation pass/fail.
**State Impact:** N/A.
**Data Read:** Restaurant (location).
**Data Created / Updated:** None.
**Exception / Alternative Behaviour:** If distance > 30km, system prevents checkout.
**Related Use Case:** UC-CUS-03
**Related User Story / Acceptance Criteria:** US-CUS-04 / AC-US-CUS-04-01–AC-US-CUS-04-03
**Related Business Rules:** BR-DEL-01.
**Related Data Elements / Entities:** None.
**Related Gap / Clarification:** None.

### FR-CUS-05 — System shall calculate delivery fee and total order amount before checkout confirmation.
**Primary Actor:** System
**Functional Objective:** Provide accurate pricing to the customer before commitment.
**Trigger:** Address validation successful during checkout.
**Preconditions:** Distance computed.
**Inputs:** Cart items, computed distance, fee-evaluation timestamp — authoritative event TBD.
**Detailed System Behaviour:**
1. System computes cart total.
2. System calculates Delivery Fee based on distance (15,000 VND for first 3 km + 3,000 VND per additional km).
3. System calculates Service Fee based on time (16,000 VND before 19:00, 20,000 VND from 19:00).
4. System calculates final Total Amount.
**Validation / Business Rules:** BR-FEE-01, BR-FEE-02.
**Outputs / Result:** Delivery Fee, Service Fee, Total Amount displayed.
**State Impact:** N/A.
**Data Read:** None.
**Data Created / Updated:** None.
**Related Use Case:** UC-CUS-03
**Related User Story / Acceptance Criteria:** US-CUS-04 / AC-US-CUS-04-04–AC-US-CUS-04-08
**Related Business Rules:** BR-FEE-01, BR-FEE-02.
**Related Data Elements / Entities:** None.
**Related Gap / Clarification:** Clarification #5 (Fractional-km rounding); Clarification #6 (Authoritative timestamp for service fee).

### FR-CUS-06 — Customer shall be able to submit an order using an available payment method (COD, QR Payment Simulation).
**Primary Actor:** Customer
**Functional Objective:** Finalize the order placement.
**Trigger:** Customer confirms checkout and selects payment method.
**Preconditions:** Cart valid, distance <= 30km, total calculated.
**Inputs:** Payment Method.
**Detailed System Behaviour:**
1. System accepts the order submission.
2. System generates an Order record with status "Chờ xác nhận".
3. System generates Order Detail records.
4. System sets Shipper Assignment to unassigned.
**Validation / Business Rules:** Must have valid payment method selected.
**Outputs / Result:** Order confirmed message.
**State Impact:** Order enters "Chờ xác nhận" state.
**Data Read:** Customer, Restaurant, Food Item.
**Data Created / Updated:** Order, Order Detail.
**Related Use Case:** UC-CUS-03
**Related User Story / Acceptance Criteria:** US-CUS-04 / AC-US-CUS-04-09
**Related Business Rules:** None.
**Related Data Elements / Entities:** Order, Order Detail.
**Related Gap / Clarification:** None.

### FR-CUS-07 — Customer shall be able to track active order status and delivery routing information.
**Primary Actor:** Customer
**Functional Objective:** Provide visibility into order fulfillment progress.
**Trigger:** Customer accesses active order view.
**Preconditions:** Order exists.
**Inputs:** Order ID.
**Detailed System Behaviour:**
1. System retrieves current Order.Status and Shipper location/routing if applicable.
2. System displays status and map routing to the Customer.
**Validation / Business Rules:** None.
**Outputs / Result:** Status and tracking information.
**State Impact:** N/A.
**Data Read:** Order, Shipper.
**Data Created / Updated:** None.
**Related Use Case:** UC-CUS-04
**Related User Story / Acceptance Criteria:** US-CUS-05 / AC-US-CUS-05-01; AC-US-CUS-05-02
**Related Business Rules:** None.
**Related Data Elements / Entities:** Order, Shipper.
**Related Gap / Clarification:** Clarification #11 (Tracking refresh & notification behaviour).

### FR-CUS-08 — Customer shall be able to submit ratings/reviews for the Restaurant and Shipper upon order completion.
**Primary Actor:** Customer
**Functional Objective:** Capture customer feedback for service quality evaluation.
**Trigger:** Customer selects to review a completed order.
**Preconditions:** Order.Status = "Hoàn thành".
**Inputs:** Rating score, comments for Restaurant; Rating score, comments for Shipper.
**Detailed System Behaviour:**
1. System accepts the review submissions.
2. System links the reviews to the Order, Customer, and respective subject (Restaurant or Shipper).
**Validation / Business Rules:** BR-ORDER-01.
**Outputs / Result:** Reviews saved.
**State Impact:** N/A.
**Data Read:** Order.
**Data Created / Updated:** Restaurant Review, Shipper Review.
**Related Use Case:** UC-CUS-06
**Related User Story / Acceptance Criteria:** US-CUS-07 / AC-US-CUS-07-01; AC-US-CUS-07-02
**Related Business Rules:** BR-ORDER-01.
**Related Data Elements / Entities:** Restaurant Review, Shipper Review.
**Related Gap / Clarification:** Clarification #8 (Review cardinality / editability).

### FR-CUS-09 — Customer shall be able to view current orders, completed order history, and order details.
**Primary Actor:** Customer
**Functional Objective:** Allow review of past and present purchasing activity.
**Trigger:** Customer accesses order history.
**Preconditions:** Authenticated as Customer.
**Inputs:** None.
**Detailed System Behaviour:**
1. System retrieves and displays list of orders belonging to the Customer.
2. Customer can view details of any specific order.
**Validation / Business Rules:** Orders must belong to the authenticated Customer.
**Outputs / Result:** Order list, Order detail view.
**State Impact:** N/A.
**Data Read:** Order, Order Detail.
**Data Created / Updated:** None.
**Related Use Case:** UC-CUS-05
**Related User Story / Acceptance Criteria:** US-CUS-06 / AC-US-CUS-06-01–AC-US-CUS-06-03
**Related Business Rules:** None.
**Related Data Elements / Entities:** Order, Order Detail.
**Related Gap / Clarification:** None.

## 7. Restaurant Functions

### FR-RES-01 — Restaurant shall be able to update store information.
**Primary Actor:** Restaurant
**Functional Objective:** Allow Restaurant to manage public-facing details.
**Trigger:** Restaurant updates profile.
**Preconditions:** Authenticated as Restaurant.
**Inputs:** Store name, address, phone, etc.
**Detailed System Behaviour:**
1. System presents current store information.
2. System accepts and persists updates.
**Validation / Business Rules:** TBD.
**Outputs / Result:** Updated Restaurant profile.
**State Impact:** N/A.
**Data Read:** Restaurant.
**Data Created / Updated:** Restaurant.
**Related Use Case:** UC-RES-01
**Related User Story / Acceptance Criteria:** US-RES-01 / AC-US-RES-01-01
**Related Business Rules:** None.
**Related Data Elements / Entities:** Restaurant.
**Related Gap / Clarification:** None.

### FR-RES-02 — Restaurant shall be able to manage menu categories.
**Primary Actor:** Restaurant
**Functional Objective:** Allow organization of the food catalogue.
**Trigger:** Restaurant initiates a menu-category management action.
**Preconditions:** Authenticated as Restaurant.
**Inputs:** Category details.
**Detailed System Behaviour:**
1. System supports menu-category management according to the approved operation set.
**Validation / Business Rules:** TBD — Exact supported category operations require clarification.
**Outputs / Result:** Category updated.
**State Impact:** N/A.
**Data Read:** Menu Category.
**Data Created / Updated:** Menu Category.
**Related Use Case:** UC-RES-01
**Related User Story / Acceptance Criteria:** US-RES-02 / AC-US-RES-02-01
**Related Business Rules:** None.
**Related Data Elements / Entities:** Menu Category.
**Related Gap / Clarification:** Clarification #14 (Detailed menu-category operations).

### FR-RES-03 — Restaurant shall be able to create, update, and remove food items.
**Primary Actor:** Restaurant
**Functional Objective:** Maintain the active menu.
**Trigger:** Restaurant modifies food items.
**Preconditions:** Authenticated as Restaurant.
**Inputs:** Food Item details.
**Detailed System Behaviour:**
1. System accepts and persists food item changes.
**Validation / Business Rules:** Must link to a valid Menu Category.
**Outputs / Result:** Food Item updated.
**State Impact:** N/A.
**Data Read:** Menu Category.
**Data Created / Updated:** Food Item.
**Related Use Case:** UC-RES-01
**Related User Story / Acceptance Criteria:** US-RES-03 / AC-US-RES-03-01–AC-US-RES-03-03
**Related Business Rules:** None.
**Related Data Elements / Entities:** Food Item, Menu Category.
**Related Gap / Clarification:** None.

### FR-RES-04 — Restaurant shall be able to view order lists and order details.
**Primary Actor:** Restaurant
**Functional Objective:** Provide visibility into incoming and historical orders.
**Trigger:** Restaurant accesses order management dashboard.
**Preconditions:** Authenticated as Restaurant. Partner approval granted for this mapped operational capability.
**Inputs:** None.
**Detailed System Behaviour:**
1. System retrieves orders belonging to the Restaurant.
2. System displays order list and detailed items for fulfilling.
**Validation / Business Rules:** Orders must belong to the authenticated Restaurant.
**Outputs / Result:** Order list displayed.
**State Impact:** N/A.
**Data Read:** Order, Order Detail.
**Data Created / Updated:** None.
**Related Use Case:** UC-RES-02
**Related User Story / Acceptance Criteria:** US-RES-04 / AC-US-RES-04-01
**Related Business Rules:** BR-PARTNER-01.
**Related Data Elements / Entities:** Order, Order Detail.
**Related Gap / Clarification:** None.

### FR-RES-05 — Restaurant shall be able to mark an order as ready for pickup ("Làm xong").
**Primary Actor:** Restaurant
**Functional Objective:** Signal that food preparation is complete and ready for Shipper collection.
**Trigger:** Restaurant updates order status.
**Preconditions:** Order.Status = "Chờ xác nhận". Authenticated as Restaurant. Partner approval granted for this mapped operational capability.
**Inputs:** Order ID.
**Detailed System Behaviour:**
1. System transitions the Order.Status to "Đang lấy món".
**Validation / Business Rules:** Order must belong to the Restaurant.
**Outputs / Result:** Status updated.
**State Impact:** Order enters "Đang lấy món" state.
**Data Read:** Order.
**Data Created / Updated:** Order.
**Related Use Case:** UC-RES-02
**Related User Story / Acceptance Criteria:** US-RES-04 / AC-US-RES-04-02
**Related Business Rules:** BR-PARTNER-01.
**Related Data Elements / Entities:** Order.
**Related Gap / Clarification:** Clarification #2 (Restaurant intermediate confirmation semantics).

### FR-RES-06 — Restaurant shall be able to view revenue statistics and order history.
**Primary Actor:** Restaurant
**Functional Objective:** Provide financial and operational reporting.
**Trigger:** Restaurant accesses statistics dashboard.
**Preconditions:** Authenticated as Restaurant.
**Inputs:** Date ranges.
**Detailed System Behaviour:**
1. System retrieves the Restaurant's order data relevant to the requested reporting scope.
2. System calculates and displays revenue statistics and order history according to the approved reporting rules.
**Validation / Business Rules:** Not Evidenced / requires validation regarding which Order.Status values contribute to revenue statistics.
**Outputs / Result:** Statistics displayed.
**State Impact:** N/A.
**Data Read:** Order.
**Data Created / Updated:** None.
**Related Use Case:** UC-RES-03
**Related User Story / Acceptance Criteria:** US-RES-05 / AC-US-RES-05-01; AC-US-RES-05-02
**Related Business Rules:** None.
**Related Data Elements / Entities:** Order.
**Related Gap / Clarification:** None.

### FR-RES-07 — Restaurant shall be able to view customer ratings and reviews associated with its completed orders.
**Primary Actor:** Restaurant
**Functional Objective:** Allow quality monitoring via customer feedback.
**Trigger:** Restaurant accesses review section.
**Preconditions:** Authenticated as Restaurant.
**Inputs:** None.
**Detailed System Behaviour:**
1. System queries and displays reviews written for the Restaurant.
**Validation / Business Rules:** Reviews must belong to the Restaurant.
**Outputs / Result:** Reviews displayed.
**State Impact:** N/A.
**Data Read:** Restaurant Review.
**Data Created / Updated:** None.
**Related Use Case:** UC-RES-03
**Related User Story / Acceptance Criteria:** US-RES-06 / AC-US-RES-06-01
**Related Business Rules:** None.
**Related Data Elements / Entities:** Restaurant Review.
**Related Gap / Clarification:** None.

## 8. Shipper Functions

### FR-SHP-01 — Shipper shall be able to view a list of available/unassigned delivery orders.
**Primary Actor:** Shipper
**Functional Objective:** Present opportunities for work.
**Trigger:** Shipper accesses the available orders view.
**Preconditions:** Authenticated as Shipper. Partner approval granted for this mapped operational capability.
**Inputs:** None.
**Detailed System Behaviour:**
1. System retrieves Orders where:
   - no Shipper is assigned; and
   - Order.Status = "Đang lấy món";
   - plus any other approved eligibility conditions.
2. System displays the list.
**Validation / Business Rules:** BR-PARTNER-01. BR-SHIP-02.
**Outputs / Result:** List of unassigned orders.
**State Impact:** N/A.
**Data Read:** Order.
**Data Created / Updated:** None.
**Related Use Case:** UC-SHP-01
**Related User Story / Acceptance Criteria:** US-SHP-01 / AC-US-SHP-01-01
**Related Business Rules:** BR-PARTNER-01, BR-SHIP-02.
**Related Data Elements / Entities:** Order.
**Related Gap / Clarification:** None.

### FR-SHP-02 — Shipper shall be able to accept a delivery assignment.
**Primary Actor:** Shipper
**Functional Objective:** Claim an order for delivery.
**Trigger:** Shipper clicks accept on an unassigned order.
**Preconditions:** Order is unassigned. Order.Status = "Đang lấy món". Shipper has no active delivery. Authenticated as Shipper. Partner approval granted for this mapped operational capability.
**Inputs:** Order ID.
**Detailed System Behaviour:**
1. System verifies Shipper has no other active delivery.
2. System verifies Order is still unassigned and in "Đang lấy món" state.
3. System assigns the Order to the Shipper.
**Validation / Business Rules:** BR-SHIP-01, BR-SHIP-02.
**Outputs / Result:** Order assigned to Shipper.
**State Impact:** N/A — assignment change only.
**Data Read:** Order, Shipper.
**Data Created / Updated:** Order.
**Related Use Case:** UC-SHP-02
**Related User Story / Acceptance Criteria:** US-SHP-02 / AC-US-SHP-02-01–AC-US-SHP-02-04
**Related Business Rules:** BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01.
**Related Data Elements / Entities:** Order.
**Related Gap / Clarification:** Clarification #4 (Active delivery definition); GAP-01.

### FR-SHP-03 — Shipper shall be able to update order status ("Đang giao", "Hoàn thành").
**Primary Actor:** Shipper
**Functional Objective:** Track fulfillment progress to completion.
**Trigger:** Shipper updates order status.
**Preconditions:** Order assigned to the Shipper. Authenticated as Shipper. Partner approval granted for this mapped operational capability.
**Inputs:** Order ID, New Status.
**Detailed System Behaviour:**
1. Shipper collects food and changes status to "Đang giao" (ST-03: Đang lấy món → Đang giao).
2. Shipper delivers food and changes status to "Hoàn thành" (ST-04: Đang giao → Hoàn thành).
**Validation / Business Rules:** Order must be assigned to the executing Shipper.
**Outputs / Result:** Status updated.
**State Impact:** Order enters "Đang giao" or "Hoàn thành".
**Data Read:** Order.
**Data Created / Updated:** Order.
**Related Use Case:** UC-SHP-03
**Related User Story / Acceptance Criteria:** US-SHP-03 / AC-US-SHP-03-01; AC-US-SHP-03-02
**Related Business Rules:** BR-PARTNER-01.
**Related Data Elements / Entities:** Order.
**Related Gap / Clarification:** Clarification #3 (Post-Shipper-cancellation Order.Status).

### FR-SHP-04 — Shipper shall be able to view completed deliveries and income statistics.
**Primary Actor:** Shipper
**Functional Objective:** Provide financial and operational reporting.
**Trigger:** Shipper accesses statistics.
**Preconditions:** Authenticated as Shipper.
**Inputs:** Date range.
**Detailed System Behaviour:**
1. System queries completed orders assigned to the Shipper.
2. System calculates and displays income statistics.
**Validation / Business Rules:** Not Evidenced / requires validation (e.g. only completed orders count).
**Outputs / Result:** Statistics displayed.
**State Impact:** N/A.
**Data Read:** Order.
**Data Created / Updated:** None.
**Related Use Case:** UC-SHP-04
**Related User Story / Acceptance Criteria:** US-SHP-04 / AC-US-SHP-04-01; AC-US-SHP-04-02
**Related Business Rules:** None.
**Related Data Elements / Entities:** Order, Shipper.
**Related Gap / Clarification:** None.

### FR-SHP-05 — Shipper shall be able to view and update personal profile and account information.
**Primary Actor:** Shipper
**Functional Objective:** Maintain personal and operational details.
**Trigger:** Shipper accesses profile.
**Preconditions:** Authenticated as Shipper.
**Inputs:** Profile data.
**Detailed System Behaviour:**
1. System accepts and persists profile updates.
**Validation / Business Rules:** TBD.
**Outputs / Result:** Profile updated.
**State Impact:** N/A.
**Data Read:** Shipper.
**Data Created / Updated:** Shipper.
**Related Use Case:** UC-SHP-05
**Related User Story / Acceptance Criteria:** US-SHP-05 / AC-US-SHP-05-01; AC-US-SHP-05-02
**Related Business Rules:** None.
**Related Data Elements / Entities:** Shipper.
**Related Gap / Clarification:** None.

## 9. Administrator Functions

### FR-ADM-01 — Admin shall be able to manage user accounts.
**Primary Actor:** Administrator
**Functional Objective:** Maintain platform integrity and assist users.
**Trigger:** Admin accesses user management console.
**Preconditions:** Authenticated as Administrator.
**Inputs:** User ID, management actions.
**Detailed System Behaviour:**
1. System provides Administrator account-management capabilities according to the approved management-action set.
**Validation / Business Rules:** TBD.
**Outputs / Result:** Account updated.
**State Impact:** N/A.
**Data Read:** Account.
**Data Created / Updated:** Account.
**Exact supported actions:** TBD — Clarification #15.
**Related Use Case:** UC-ADM-01
**Related User Story / Acceptance Criteria:** US-ADM-01 / AC-US-ADM-01-01
**Related Business Rules:** None.
**Related Data Elements / Entities:** Account.
**Related Gap / Clarification:** Clarification #15 (Detailed Administrator user-account management actions).

### FR-ADM-02 — Admin shall be able to approve new Restaurant/Shipper registrations.
**Primary Actor:** Administrator
**Functional Objective:** Gatekeeping for operational platform partners.
**Trigger:** Administrator reviews a Restaurant/Shipper registration awaiting an administrative decision.
**Preconditions:** A Restaurant/Shipper registration requiring Administrator approval exists.
**Inputs:** Account ID, approval action.
**Detailed System Behaviour:**
1. Administrator records an approval decision for the partner.
2. After approval is granted, the partner becomes eligible for mapped normal operational capabilities.
**Validation / Business Rules:** BR-PARTNER-01.
**Outputs / Result:** Account updated.
**State Impact:** Partner approval condition becomes satisfied.
**Exact persisted approval-state vocabulary:** TBD — Clarification #7.
**Data Read:** Account.
**Data Created / Updated:** Account.
**Related Use Case:** UC-ADM-02
**Related User Story / Acceptance Criteria:** US-ADM-02 / AC-US-ADM-02-01
**Related Business Rules:** BR-PARTNER-01.
**Related Data Elements / Entities:** Account.
**Related Gap / Clarification:** Clarification #7, Clarification #12.

### FR-ADM-03 — Admin shall be able to view system-wide operational and revenue statistics.
**Primary Actor:** Administrator
**Functional Objective:** Provide platform-level oversight.
**Trigger:** Admin accesses global dashboard.
**Preconditions:** Authenticated as Administrator.
**Inputs:** Date ranges.
**Detailed System Behaviour:**
1. System queries global order and revenue data.
2. System displays aggregated statistics.
**Validation / Business Rules:** None.
**Outputs / Result:** Dashboard displayed.
**State Impact:** N/A.
**Data Read:** Order.
**Data Created / Updated:** None.
**Related Use Case:** UC-ADM-03
**Related User Story / Acceptance Criteria:** US-ADM-03 / AC-US-ADM-03-01; AC-US-ADM-03-02
**Related Business Rules:** None.
**Related Data Elements / Entities:** Order.
**Related Gap / Clarification:** None.

### FR-ADM-04 — Admin shall be able to export revenue statistics to an Excel file.
**Primary Actor:** Administrator
**Functional Objective:** Enable offline analysis and reporting.
**Trigger:** Admin clicks export.
**Preconditions:** Statistics generated.
**Inputs:** Filter parameters.
**Detailed System Behaviour:**
1. System generates an Excel file containing the statistical data.
2. System provides the file for download.
**Validation / Business Rules:** None.
**Outputs / Result:** Excel file downloaded.
**State Impact:** N/A.
**Data Read:** Order.
**Data Created / Updated:** None.
**Related Use Case:** UC-ADM-03
**Related User Story / Acceptance Criteria:** US-ADM-04 / AC-US-ADM-04-01
**Related Business Rules:** None.
**Related Data Elements / Entities:** Order.
**Related Gap / Clarification:** None.

## 10. Cross-Role Order Lifecycle Behaviour
The TARGET Order.Status transitions are strictly mapped from the Order State Model:

| Transition ID | Trigger / Actor | From | To | Related FR |
| :--- | :--- | :--- | :--- | :--- |
| **ST-01** | Customer places order | N/A — Order creation | Chờ xác nhận | FR-CUS-06 |
| **ST-02** | Restaurant marks "Làm xong" | Chờ xác nhận | Đang lấy món | FR-RES-05 |
| **ST-03** | Shipper starts delivery | Đang lấy món | Đang giao | FR-SHP-03 |
| **ST-04** | Shipper completes delivery | Đang giao | Hoàn thành | FR-SHP-03 |

**Note:** Shipper acceptance (FR-SHP-02) changes the Shipper Assignment (\`MaShipper\`), not the \`Order.Status\`. "Unassigned" is determined by a null Shipper assignment, not a dedicated status value.

## 11. Business Rule Application Matrix

| Business Rule | Applied Functional Requirements | Functional Effect | Open Clarification |
| :--- | :--- | :--- | :--- |
| **BR-ORDER-01** | FR-CUS-08 | Restricts review creation to "Hoàn thành" orders. | Clarification #8 |
| **BR-SHIP-01** | FR-SHP-02 | Prevents a Shipper from having more than one active delivery; the exact active-delivery definition remains TBD. | Clarification #4 |
| **BR-SHIP-02** | FR-SHP-02 | Restricts acceptance to unassigned + "Đang lấy món" orders. | None (Gap-01 exists) |
| **BR-DEL-01** | FR-CUS-04 | Rejects checkout if delivery distance > 30 km. | None |
| **BR-FEE-01** | FR-CUS-05 | Computes Delivery Fee using distance tiers. | Clarification #5 |
| **BR-FEE-02** | FR-CUS-05 | Computes Service Fee using time boundary (19:00). | Clarification #6 |
| **BR-PARTNER-01** | FR-AUTH-01, FR-RES-04, FR-RES-05, FR-SHP-01, FR-SHP-02, FR-SHP-03, FR-ADM-02 | Gates access to core operational functions. | Clarification #7, #12 |

## 12. Validation & Exception Behaviour
- **Delivery Distance Rejection:** System prevents checkout completion for distances exceeding 30 km (FR-CUS-04).
- **Shipper Eligibility:** Assignment is blocked if the Shipper has an active delivery (FR-SHP-02).
- **Unassigned Order Requirement:** Shipper can only accept orders where \`MaShipper\` IS NULL and status is "Đang lấy món" (TARGET behaviour, FR-SHP-02).
- **Completed Order Restriction:** Reviews can only be submitted against orders in "Hoàn thành" status (FR-CUS-08).
- **Role Authorization & Partner Gate:** Functions are restricted by RBAC (NFR-SEC-01). Partners must be approved (BR-PARTNER-01) to access core features.
- Unresolved validation details (e.g. Customer profile input constraints) are noted as TBD.

## 13. Data Interaction & Persistence Notes
- **Order.Status:** Mapped to \`DonHang.TrangThai\`.
- **Shipper Assignment:** Represented by \`DonHang.MaShipper\` (Nullable).
- **Order Total:** Mapped to \`DonHang.TongTien\`.
- **Aggregated charge:** Mapped to \`DonHang.ShipFee\`.
- **Delivery Distance:** Computed concept; no dedicated persisted field verified.
- **Payment Method:** Logical input; no dedicated persisted field verified.
- **Delivery Fee and Service Fee:** Separate TARGET functional concepts; separate physical persistence is not verified in S4.

## 14. Role & Access Behaviour
- **Guest:** Unauthenticated role. Can register accounts. Browsing authentication requirement is TBD.
- **Customer:** Authenticated buyer. Can manage profile, checkout, track orders, and write reviews.
- **Restaurant:** Authenticated supplier. Administrator approval is required before mapped normal operational capabilities. Can manage restaurant/menu information and participate in order fulfilment subject to the controlled approval boundary; non-core capability boundaries remain subject to Clarification #12.
- **Shipper:** Authenticated deliverer. Administrator approval is required before mapped normal operational capabilities. Can accept eligible delivery assignments and update delivery progress; non-core capability boundaries remain subject to Clarification #12.
- **Administrator:** Authenticated manager. Controls user accounts, partner approval, and views global statistics.

## 15. Functional Traceability Summary

| FR ID | Primary Actor | UC | US | AC IDs | Business Rule | State Transition | Logical Entity | Gap / Clarification |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| FR-AUTH-01 | Guest | — | — | Section 3 Registration | BR-PARTNER-01 | N/A | Account | #7, #13 |
| FR-AUTH-02 | Cross-role | — | — | Section 3 Authentication | None | N/A | Account | #13, GAP-02 |
| FR-CUS-01 | Customer | UC-CUS-01 | US-CUS-01 | AC-US-CUS-01-01–AC-US-CUS-01-03 | None | N/A | Customer, Account | #10 |
| FR-CUS-02 | Customer | UC-CUS-02 | US-CUS-02 | AC-US-CUS-02-01 | None | N/A | Restaurant, Food Item | #9 |
| FR-CUS-03 | Customer | UC-CUS-02 | US-CUS-03 | AC-US-CUS-03-01–AC-US-CUS-03-03 | None | N/A | Food Item | None |
| FR-CUS-04 | System | UC-CUS-03 | US-CUS-04 | AC-US-CUS-04-01–AC-US-CUS-04-03 | BR-DEL-01 | N/A | None | None |
| FR-CUS-05 | System | UC-CUS-03 | US-CUS-04 | AC-US-CUS-04-04–AC-US-CUS-04-08 | BR-FEE-01, BR-FEE-02 | N/A | None | #5, #6 |
| FR-CUS-06 | Customer | UC-CUS-03 | US-CUS-04 | AC-US-CUS-04-09 | None | ST-01 | Order | None |
| FR-CUS-07 | Customer | UC-CUS-04 | US-CUS-05 | AC-US-CUS-05-01; AC-US-CUS-05-02 | None | N/A | Order, Shipper | #11 |
| FR-CUS-08 | Customer | UC-CUS-06 | US-CUS-07 | AC-US-CUS-07-01; AC-US-CUS-07-02 | BR-ORDER-01 | N/A | Review | #8 |
| FR-CUS-09 | Customer | UC-CUS-05 | US-CUS-06 | AC-US-CUS-06-01–AC-US-CUS-06-03 | None | N/A | Order | None |
| FR-RES-01 | Restaurant | UC-RES-01 | US-RES-01 | AC-US-RES-01-01 | None | N/A | Restaurant | None |
| FR-RES-02 | Restaurant | UC-RES-01 | US-RES-02 | AC-US-RES-02-01 | None | N/A | Menu Category | #14 |
| FR-RES-03 | Restaurant | UC-RES-01 | US-RES-03 | AC-US-RES-03-01–AC-US-RES-03-03 | None | N/A | Food Item | None |
| FR-RES-04 | Restaurant | UC-RES-02 | US-RES-04 | AC-US-RES-04-01 | BR-PARTNER-01 | N/A | Order | None |
| FR-RES-05 | Restaurant | UC-RES-02 | US-RES-04 | AC-US-RES-04-02 | BR-PARTNER-01 | ST-02 | Order | #2 |
| FR-RES-06 | Restaurant | UC-RES-03 | US-RES-05 | AC-US-RES-05-01; AC-US-RES-05-02 | None | N/A | Order | None |
| FR-RES-07 | Restaurant | UC-RES-03 | US-RES-06 | AC-US-RES-06-01 | None | N/A | Review | None |
| FR-SHP-01 | Shipper | UC-SHP-01 | US-SHP-01 | AC-US-SHP-01-01 | BR-PARTNER-01 | N/A | Order | None |
| FR-SHP-02 | Shipper | UC-SHP-02 | US-SHP-02 | AC-US-SHP-02-01–AC-US-SHP-02-04 | BR-SHIP-01, BR-SHIP-02, BR-PARTNER-01 | N/A — assignment change only | Order | #4, GAP-01 |
| FR-SHP-03 | Shipper | UC-SHP-03 | US-SHP-03 | AC-US-SHP-03-01; AC-US-SHP-03-02 | BR-PARTNER-01 | ST-03, ST-04 | Order | #3 |
| FR-SHP-04 | Shipper | UC-SHP-04 | US-SHP-04 | AC-US-SHP-04-01; AC-US-SHP-04-02 | None | N/A | Order, Shipper | None |
| FR-SHP-05 | Shipper | UC-SHP-05 | US-SHP-05 | AC-US-SHP-05-01; AC-US-SHP-05-02 | None | N/A | Shipper | None |
| FR-ADM-01 | Admin | UC-ADM-01 | US-ADM-01 | AC-US-ADM-01-01 | None | N/A | Account | #15 |
| FR-ADM-02 | Admin | UC-ADM-02 | US-ADM-02 | AC-US-ADM-02-01 | BR-PARTNER-01 | N/A | Account | #7, #12 |
| FR-ADM-03 | Admin | UC-ADM-03 | US-ADM-03 | AC-US-ADM-03-01; AC-US-ADM-03-02 | None | N/A | Order | None |
| FR-ADM-04 | Admin | UC-ADM-03 | US-ADM-04 | AC-US-ADM-04-01 | None | N/A | Order | None |

## 16. Open Functional Clarifications
The following 15 open TARGET clarifications remain unresolved (per the approved Requirement Gap Analysis):
1. Quantitative response-time / performance target
2. Restaurant intermediate confirmation semantics
3. Post-Shipper-cancellation Order.Status
4. Active delivery definition
5. Fractional-km rounding
6. Authoritative timestamp for service fee
7. Approval-state vocabulary & rejection logic
8. Review cardinality / editability
9. Browsing authentication requirement
10. Customer profile input validation
11. Tracking refresh & notification behaviour
12. Partner non-core capability boundary
13. Detailed authentication failure behaviour
14. Menu-category operations
15. Admin user-account management actions

## 17. Known Implementation Gaps
Verified implementation gaps identified from reviewed evidence:
- **GAP-01:** Shipper acceptance TARGET guard vs CURRENT implementation.
- **GAP-02:** TARGET password hashing vs CURRENT plaintext implementation.

## 18. Assumptions & Limitations
- Functional specifications describe TARGET behaviour.
- CURRENT implementation deviations are referenced as implementation gaps only where they are registered in the approved Gap Analysis. Physical persistence mappings and limitations may be documented separately from S4 without being classified as gaps.
- Related NFR Constraints: Functional behaviour is bounded by NFR-PER-01 (performance), NFR-SEC-01 (role restrictions), NFR-SEC-02 (password hashing), and NFR-COMP-01 (cross-browser support).

## 19. Validation Summary
This specification covers 27 approved Functional Requirements, 7 Business Rules, and aligns with the approved Logical ERD, Data Dictionary, and Order State Model. No new requirements were invented.
