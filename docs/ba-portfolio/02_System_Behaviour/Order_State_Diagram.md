# Order State Model Analysis — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Order Lifecycle / State Model Analysis
Source Baseline: S1 — Validated Portfolio BRD
Depends On: 00_README_BA_Evidence_Pack.md — APPROVED v1.0; TO_BE_Cross_Role_Process.md — APPROVED v1.0; Business_Rules_Catalogue.md — APPROVED v1.0
Last Reviewed: 15 Aug 2026

## 1. Purpose

This artefact defines the controlled target lifecycle of an Order. Its objectives are to:
- identify confirmed order states
- identify source-supported transition events
- identify transition owners
- identify applicable business-rule guards
- distinguish Order.Status from other attributes such as Shipper assignment
- expose unresolved lifecycle semantics
- establish the approved textual baseline for the later Mermaid state diagram
- provide upstream state evidence for Use Cases, User Stories, Acceptance Criteria, RTM and UAT

## 2. State Modelling Boundary

The target state model distinguishes explicitly between formal **Order lifecycle state** and supporting **attributes / eligibility conditions**.

Concepts such as Unassigned, Assigned, Has Shipper, No Shipper, Available order, Eligible for acceptance, Restaurant confirmed, Reviewable, Payment selected, COD, and QR Payment Simulation are NOT formal Order states unless explicitly supported by S1.
- "Unassigned" and "Assigned" represent the relationship/attribute (e.g., `AssignedShipper`), not the `Order.Status`.
- Shipper assignment is an event that modifies an attribute, and does not automatically trigger an `Order.Status` transition unless evidenced.
- Pre-order concepts such as Cart and Checkout fall outside the Order lifecycle. Payment-related concepts such as Payment Pending are not established as Order.Status values by S1.

The confirmed happy-path state backbone is:
Order creation → "Chờ xác nhận"
Restaurant completes preparation / selects "Làm xong" → "Đang lấy món"
Shipper collects order and updates delivery progression → "Đang giao"
Shipper completes delivery → "Hoàn thành"

## 3. Confirmed Order States

| State | English Meaning | Entry Trigger | Triggering Actor | Exit Trigger | Evidence Classification | Source |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| "Chờ xác nhận" | Pending Confirmation | Customer confirms checkout; System creates Order | System | Confirmed exit endpoint: Restaurant completes preparation / selects "Làm xong"; exact intermediate semantics NOT EVIDENCED | BASELINE | S1 |
| "Đang lấy món" | Ready for Pickup | Restaurant completes preparation / selects "Làm xong" | Restaurant | Shipper collects order | BASELINE | S1 |
| "Đang giao" | Delivering | Shipper collects the order and indicates delivery is in progress | Shipper | Shipper completes the physical delivery | BASELINE | S1 |
| "Hoàn thành" | Completed | Shipper completes the physical delivery and updates the order | Shipper | N/A (Terminal state) | BASELINE | S1 |

## 4. Supporting Attributes & Conditions

| Concept | Type | Meaning | Why It Is Not Modelled as Order State | Related Rule / Requirement |
| :--- | :--- | :--- | :--- | :--- |
| Unassigned / Assigned | Attribute | Indicates whether a Shipper has claimed the order | Represents an entity relationship (`AssignedShipper`), not the core lifecycle state | BR-SHIP-02 |
| Shipper eligibility | Condition | Whether a Shipper is allowed to accept orders | Property of the Shipper, evaluated dynamically | BR-SHIP-01 |
| Active delivery | Business condition | Indicates whether a Shipper currently holds an active delivery | Not a distinct Order.Status; the exact status/attribute derivation is NOT EVIDENCED | BR-SHIP-01 |
| Payment method | Attribute | COD or QR Payment Simulation | Collected during checkout before the Order lifecycle begins | Checkout FRs |
| Review eligibility | Condition | Whether a Customer can review an order | A capability unlocked when Order.Status reaches "Hoàn thành" | BR-ORDER-01 |

## 5. Confirmed State Transitions

| Transition ID | From State | Trigger / Event | Triggering Actor | Guard / Rule | To State | Evidence Classification | Source |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| ST-01 | Initial | System creates Order after Customer confirms/submits checkout | System | — (checkout constraints apply upstream) | "Chờ xác nhận" | BASELINE | S1 |
| ST-02 | "Chờ xác nhận" | Restaurant completes preparation / selects "Làm xong" | Restaurant | — | "Đang lấy món" | BASELINE endpoints; intermediate semantics NOT EVIDENCED | S1 |
| ST-03 | "Đang lấy món" | Shipper collects the order and initiates delivery | Shipper | — (Shipper assignment occurs upstream in the approved TO-BE process) | "Đang giao" | BASELINE | S1 |
| ST-04 | "Đang giao" | Shipper completes delivery | Shipper | — | "Hoàn thành" | BASELINE | S1 |

## 6. Transition Guards & Rule Constraints

Business rules from the approved catalogue enforce constraints on state transitions and process eligibility. Do not force every BR into a state transition.
- **BR-SHIP-02:** Applies before Shipper acceptance. Guard: `Order.Status = "Đang lấy món"` AND order is `unassigned`. This controls assignment eligibility; it does not necessarily trigger a state transition.
- **BR-SHIP-01:** Controls Shipper eligibility (active delivery limit). It does not define a direct Order state transition.
- **BR-ORDER-01:** Controls review eligibility after Completed. It does not transition Order.Status.
- **BR-DEL-01 / BR-FEE-01 / BR-FEE-02:** Operate before Order creation / during checkout. They are outside the Order lifecycle state machine.
- **BR-PARTNER-01:** Upstream access prerequisite. Not an Order state transition.

## 7. State-Related Invariants

- When `Order.Status = "Đang lấy món"`: Shipper acceptance is allowed only if the order is also unassigned and Shipper eligibility rules are satisfied.
- When `Order.Status = "Hoàn thành"`: Customer review becomes permitted.

## 8. Terminal / Post-State Behaviour

"Hoàn thành" is the only confirmed terminal successful state in the current baseline. No additional terminal Order.Status values (e.g., Cancelled, Rejected) are confirmed by the current approved baseline.

## 9. Unresolved State Semantics

* **Restaurant confirmation semantics:** Exact intermediate semantics between "Chờ xác nhận" and "Đang lấy món" (e.g., explicit confirmation action, Confirmed state, Preparing state) are NOT EVIDENCED / REQUIRES CLARIFICATION.
* **Post-Shipper-cancellation state:** If Shipper cancellation occurs after "Đang giao", the target assignment is cleared, but exact Order.Status rollback / transition is NOT EVIDENCED / REQUIRES CLARIFICATION.
* **Active delivery definition:** Exact status membership of an "active delivery" for BR-SHIP-01 is NOT EVIDENCED / REQUIRES CLARIFICATION.

## 10. States Not Confirmed by Current Baseline

The following concepts MUST NOT be treated as confirmed Order states without additional evidence:
- **Cart / Checkout:** pre-order concepts; not established as Order.Status.
- **Payment Pending / Paid:** payment-related concepts; not established as Order.Status by S1.
- **Submitted / Confirmed / Preparing:** Intermediate states not established as an Order.Status by S1.
- **Assigned / Unassigned / Available / Reassigned:** Assignment attributes/conditions; not established as an Order.Status by S1.
- **Cancelled:** Order cancellation is not established as an Order.Status by S1 (distinct from Shipper assignment cancellation).
- **Reviewed:** Domain capability, not established as an Order.Status by S1.

## 11. TO-BE Process Traceability

| State / Transition | TO-BE Process Stage | Triggering Role | Related FR | Related BR | Evidence Classification |
| :--- | :--- | :--- | :--- | :--- | :--- |
| "Chờ xác nhận" / ST-01 | Order creation after confirmed checkout | Customer / System | FR-CUS-06 | — | BASELINE |
| "Đang lấy món" / ST-02 | Restaurant readiness | Restaurant | FR-RES-05 | BR-SHIP-02 | BASELINE endpoints; intermediate semantics NOT EVIDENCED |
| "Đang giao" / ST-03 | Delivery begins after collection | Shipper | FR-SHP-03 | — | BASELINE |
| "Hoàn thành" / ST-04 | Delivery completion | Shipper | FR-SHP-03 | BR-ORDER-01 | BASELINE |

## 12. Source Mapping

| State / Transition / Constraint | Primary Source | Approved Upstream Artefact | Evidence Classification | Notes |
| :--- | :--- | :--- | :--- | :--- |
| "Chờ xác nhận" | S1 | TO-BE Process | BASELINE | Confirmed initial state |
| "Đang lấy món" | S1 | TO-BE Process | BASELINE | |
| "Đang giao" | S1 | TO-BE Process | BASELINE | |
| "Hoàn thành" | S1 | TO-BE Process | BASELINE | |
| ST-01 | S1 | TO-BE Process | BASELINE | Order creation → Chờ xác nhận |
| ST-02 | S1 | TO-BE Process | BASELINE endpoints | Intermediate semantics NOT EVIDENCED |
| ST-03 | S1 | TO-BE Process | BASELINE | Ready for Pickup → Delivering |
| ST-04 | S1 | TO-BE Process | BASELINE | Delivering → Completed |

## 13. Analysis Summary

The current approved baseline confirms the happy-path lifecycle checkpoints (4 states: "Chờ xác nhận", "Đang lấy món", "Đang giao", "Hoàn thành") but does not provide sufficient evidence for a complete exhaustive state machine. The model explicitly distinguishes between core lifecycle states and assignment/eligibility attributes (e.g., Unassigned). Key business rule dependencies (BR-SHIP-02, BR-ORDER-01) operate as transition guards and state invariants rather than initiating state transitions. Unresolved semantics regarding Restaurant confirmation, post-cancellation status, and active delivery definitions are intentionally preserved. This approved textual state model serves as the controlled baseline for Order_State_Diagram.mmd and subsequent Use Case, User Story, Acceptance Criteria, RTM and UAT artefacts.
