# TO-BE Cross-Role Process Analysis — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: TO-BE Cross-Role Business Process Analysis
Source Baseline: S1 — Validated Portfolio BRD
Depends On: 00_README_BA_Evidence_Pack.md — APPROVED v1.0; AS_IS_Process.md — APPROVED v1.0
Last Reviewed: 15 Aug 2026

## 1. Purpose
This artefact documents the intended future-state cross-role process for the Online Food Delivery System. Its objectives are to define the end-to-end target order-fulfilment workflow, identify role handoffs, and identify key system-mediated process points. It establishes the target process baseline for later business-rule, state-model, use-case, and acceptance-criteria artefacts, while demonstrating how the future-state process addresses the main limitations identified in the approved AS-IS baseline.

## 2. TO-BE Process Scope
This target process focuses on the core order and delivery lifecycle involving the Customer, Restaurant, Shipper, and the Online Food Delivery System. Administrator activities, such as partner account approval, are upstream prerequisites and are not part of the active, core order-fulfilment flow.

The core scope covers:
*   Customer ordering (browsing, cart)
*   Checkout (validation, fee calculation, payment method selection)
*   Order confirmation / pending confirmation
*   Restaurant preparation
*   Ready for Pickup
*   Shipper availability / acceptance
*   Pickup
*   Delivery
*   Customer tracking
*   Completion
*   Review
*   Shipper cancellation exception

## 3. TO-BE Participants & Responsibilities

### Customer
Responsible for browsing restaurants and items, adding items to the cart, proceeding through checkout, confirming the order, tracking delivery progress, and submitting post-completion reviews.

### Restaurant
Responsible for viewing incoming orders, processing/preparing the food, and updating the order readiness status once preparation is complete.

### Shipper
Responsible for viewing available unassigned delivery orders, accepting an eligible delivery, travelling to collect the order, executing the physical delivery, and completing the delivery within the system.

### Online Food Delivery System
Responsible for mediating the entire workflow. Explicit responsibilities include presenting restaurant/menu information, capturing the checkout intent, validating the delivery address and determining route/distance via Map APIs, then calculating delivery fees according to defined business rules, creating the order and maintaining its status, exposing eligible orders to Shippers, supporting status/location tracking, and recording lifecycle updates.

## 4. TO-BE Process Narrative
The target end-to-end process is coordinated through the Online Food Delivery System at its key business handoffs and lifecycle checkpoints. It begins with the Customer browsing menus and submitting an order via checkout, where the System automatically validates the address, calculates delivery fees, and captures the payment choice (COD or QR Payment Simulation). Upon confirmation, the System records the order and makes the new order available to the Restaurant. The Restaurant processes the order and, once prepared, triggers a status update indicating the food is ready for pickup. 

The System then exposes this ready, unassigned order to eligible Shippers. A Shipper accepts the order, claims the assignment, and travels to the Restaurant. Upon collection, the Shipper updates the System to indicate the delivery is actively in progress. Throughout this phase, the Customer uses the System to track the order status and Shipper routing. Finally, the Shipper completes the delivery, updating the System to the terminal success state, which then unlocks the Customer's ability to submit ratings and reviews for both the Restaurant and Shipper.

## 5. TO-BE Process Steps

| Step | Primary Participant | Activity | System / Cross-role Handoff | Result / Process State | Evidence Classification | Source |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| 1 | Customer | Browses restaurants, selects menu items, and adds to cart. | Interacts with System | Cart populated | BASELINE | S1 |
| 2 | Customer | Proceeds to checkout. | Submits intent to System | Checkout initiated | BASELINE | S1 |
| 3 | System | Validates delivery address, determines coordinates/routes, calculates delivery cost. | System automation | Validation complete | BASELINE | S1 |
| 4 | Customer | Selects COD or QR Payment Simulation and confirms the order. | Customer → System | Order submitted | BASELINE | S1 |
| 5 | System | Creates the order and makes it available to the Restaurant for handling. | System → Restaurant | "Chờ xác nhận" | BASELINE | S1 |
| 6 | Restaurant | Views the new order and prepares the food. | Reads order from System | Preparation active | BASELINE | S1 |
| 7 | Restaurant | Selects "Làm xong" when preparation is completed. | Restaurant → System | "Đang lấy món" (Ready for Pickup) | BASELINE | S1 |
| 8 | System | Exposes the unassigned order to eligible Shippers. | System → Shipper | Order available for assignment | BASELINE | S1 |
| 9 | Shipper | Views available unassigned orders and accepts a delivery. | Shipper → System | Order assigned to Shipper | BASELINE | S1 |
| 10 | Shipper | Travels to restaurant, collects the order, and updates status. | Shipper → System | "Đang giao" (Delivering) | BASELINE | S1 |
| 11 | Customer | Tracks order status and Shipper location/route through web interface. | System → Customer | Visibility provided | BASELINE | S1 |
| 12 | Shipper | Completes the physical delivery and updates the order status. | Shipper → System | "Hoàn thành" (Completed) | BASELINE | S1 |
| 13 | Customer | Submits ratings/reviews for the Restaurant and Shipper. | Customer → System | Reviews recorded | BASELINE | S1 |

## 6. Process-State Checkpoints

*   **Chờ xác nhận (Pending Confirmation)**
    *   **Trigger:** Customer confirms/submits the checkout.
    *   **State-setting responsibility:** System creates the order with status "Chờ xác nhận".
    *   **Next Actor:** Restaurant can view and process the order.
*   **Đang lấy món (Ready for Pickup)**
    *   **Trigger:** Restaurant marks the food preparation as complete ("Làm xong").
    *   **Ownership:** Initiated by Restaurant.
    *   **Next Actor:** System exposes the order; Shipper is now able to accept it.
*   **Đang giao (Delivering)**
    *   **Trigger:** Shipper collects the order and indicates departure.
    *   **Ownership:** Initiated by Shipper.
    *   **Next Actor:** Shipper controls the delivery progression; Customer gains active transit visibility.
*   **Hoàn thành (Completed)**
    *   **Trigger:** Shipper successfully finishes the delivery.
    *   **Ownership:** Initiated by Shipper.
    *   **Next Actor:** Customer is now able to submit reviews.

## 7. Cross-Role Handoffs

*   **Customer → System (Confirmed Checkout)**
    *   **Information:** Order submission, address, selected payment method.
    *   **Result:** System generates the formal order record.
    *   **Classification:** BASELINE
*   **System → Restaurant (Order Availability)**
    *   **Information:** New order details.
    *   **Result:** Restaurant begins preparation.
    *   **Classification:** BASELINE
*   **Restaurant → System (Readiness Update)**
    *   **Information:** Food preparation completed.
    *   **Result:** Order state updates to "Đang lấy món", making it eligible for Shipper acceptance.
    *   **Classification:** BASELINE
*   **System → Shipper (Delivery Opportunity)**
    *   **Information:** Unassigned, ready-for-pickup delivery order.
    *   **Result:** Shipper evaluates and accepts the delivery.
    *   **Classification:** BASELINE
*   **Shipper → System (Delivery Acceptance & Updates)**
    *   **Information:** Assignment acceptance, delivery-status update after collection, and completion update.
    *   **Result:** System records assignment and lifecycle-status updates; delivery tracking information is made available to the Customer as defined by the target requirements.
    *   **Classification:** BASELINE
*   **System → Customer (Tracking & Status)**
    *   **Information:** Order progress and Shipper location.
    *   **Result:** Customer gains visibility into active order status and delivery routing information.
    *   **Classification:** BASELINE

## 8. Exception Flow — Shipper Cancels Accepted Delivery
If a Shipper cancels an assigned delivery, the Shipper assignment is cleared and the order returns to the available delivery pool as defined by S1. The exact post-cancellation order-status transition required to make the order eligible for re-acceptance is not explicitly defined in the current baseline and requires clarification against BR-SHIP-02.

## 9. Business-Rule Touchpoints
The target process intersects with underlying business rules at the following key points:
*   **Delivery Feasibility:** The System must validate the delivery distance and calculate fees before allowing checkout confirmation (touches BR-DEL-01, BR-FEE-01, BR-FEE-02).
*   **Shipper Eligibility / Assignment:** A Shipper may only accept an order when it is unassigned and marked as ready for pickup (touches BR-SHIP-02). A Shipper cannot hold multiple active delivery orders simultaneously (touches BR-SHIP-01).
*   **Post-Completion Review:** The Customer is only permitted to review an order after it has reached the completed state (touches BR-ORDER-01).

## 10. AS-IS to TO-BE Process Improvements

| AS-IS Limitation | TO-BE Process Change | Expected Process Improvement | Classification |
| :--- | :--- | :--- | :--- |
| Manual Order Recording | Structured digital order capture via checkout | Replaces assumed manual capture with structured platform-based order capture | BASELINE change / DERIVED improvement |
| Manual Shipper Coordination | Platform-mediated visibility and acceptance | Replaces direct manual Restaurant-to-Shipper coordination with platform-mediated assignment flow | BASELINE change / DERIVED improvement |
| Limited Delivery Visibility | Order-status and routing tracking | Provides structured delivery-progress visibility through the platform | BASELINE change / DERIVED improvement |
| Fragmented Operational Data | Platform-based lifecycle and history recording | Centralizes key lifecycle information and reduces information fragmentation | BASELINE change / DERIVED improvement |

## 11. System Responsibility Boundary

**System-supported:**
*   Displaying restaurant and menu data.
*   Validating delivery address and determining route/distance via Map APIs; calculating delivery fees and order totals according to defined business rules.
*   Generating the order record and persisting status changes.
*   Exposing eligible unassigned orders to Shippers.
*   Facilitating Customer tracking of order status and Shipper location.
*   Recording lifecycle events and capturing post-delivery reviews.

**Human/Business actions:**
*   **Customer:** Browses, adds items, selects payment, confirms checkout, and writes reviews.
*   **Restaurant:** Prepares the physical order and triggers the readiness update in the portal.
*   **Shipper:** Evaluates/accepts assignments, travels to the restaurant, collects the physical order, executes the delivery, and triggers the completion update.

## 12. Source Mapping

| Process Element | Source | Evidence Classification | Notes |
| :--- | :--- | :--- | :--- |
| Checkout validation, fee calculation, payment selection | S1 | BASELINE | Defined in validated BRD |
| "Chờ xác nhận" state on creation | S1 | BASELINE | Target lifecycle checkpoint |
| "Đang lấy món" triggered by Restaurant | S1 | BASELINE | Target lifecycle checkpoint |
| Shipper acceptance and "Đang giao" update | S1 | BASELINE | Target lifecycle checkpoint |
| Customer tracking via web interface | S1 | BASELINE | Target customer capability |
| "Hoàn thành" and post-delivery review | S1 | BASELINE | Target lifecycle checkpoint |
| Shipper cancellation return-to-availability flow | S1 | BASELINE | Exception defined by validated process |

*Note: S2 (Original Major Project Report) was reviewed for compatible supporting context but was not materially relied upon for the TO-BE baseline, as S1 provides the definitive target requirement.*

## 13. Open Questions & Not Evidenced
The following target-process details cannot currently be established from the approved evidence:
*   **Post-cancellation status transition:** whether an order cancelled after reaching "Đang giao" must transition back to "Đang lấy món" before becoming eligible for another Shipper — **NOT EVIDENCED / REQUIRES CLARIFICATION**.
*   **Restaurant confirmation semantics:** whether "Chờ xác nhận" requires a distinct Restaurant confirmation action and whether a separate intermediate status exists before "Đang lấy món" — **NOT EVIDENCED / REQUIRES CLARIFICATION**.
*   precise timing SLA or timeout for Restaurant confirmation — NOT EVIDENCED
*   automated reassignment timing or Shipper response timeout — NOT EVIDENCED
*   notification channel details (e.g., push notifications vs. manual refresh) — NOT EVIDENCED (S1 lists push notifications as Future Scope)
*   exact tracking coordinate refresh frequency — NOT EVIDENCED
*   cancellation penalty policy for Shippers — NOT EVIDENCED

## 14. Analysis Summary
The TO-BE target process replaces fragmented, manual coordination with a structured, platform-mediated order lifecycle connecting the Customer, Restaurant, and Shipper. Through structured digital order capture, rule-constrained lifecycle progression, platform-mediated delivery acceptance, and integrated tracking, the target process is intended to replace the manual cross-role coordination identified in the AS-IS baseline.

This approved TO-BE process serves as an upstream baseline for `Business_Rules_Catalogue.md` and subsequent system-behaviour and requirements artefacts.
