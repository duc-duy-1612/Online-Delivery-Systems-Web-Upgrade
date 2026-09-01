# Business Rules Catalogue — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Business Rules Catalogue
Source Baseline: S1 — Validated Portfolio BRD
Depends On: 00_README_BA_Evidence_Pack.md — APPROVED v1.0; TO_BE_Cross_Role_Process.md — APPROVED v1.0
Last Reviewed: 15 Aug 2026
## 1. Purpose

This Business Rules Catalogue consolidates target business rules for the Online Food Delivery System. Its purpose is to define rule conditions, triggers, and outcomes, clarifying exactly which process points each rule constrains. By separating business policy from implementation behaviour, it provides a controlled upstream baseline for Order State modelling, Use Cases, User Stories, Acceptance Criteria, Requirements Traceability Matrix (RTM), and User Acceptance Testing (UAT).

## 2. Rule Scope & Governance

This document exclusively lists TARGET rules authorized by the Validated Portfolio BRD (S1). Current implementation behavior (S3) was reviewed separately for implementation validation; implementation findings are maintained outside this target-rule catalogue. Implementation validation reference: external project-validation pass; formal findings are carried forward to Requirement_Gap_Analysis.md. Implementation code does not redefine target rules. Any discovered mismatch is reported externally and must undergo formal Gap Analysis.

## 3. Business Rules Summary

| Rule ID | Rule Name | Rule Category | Primary Actor / Domain | Process Touchpoint | Evidence Classification | Source |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| BR-ORDER-01 | Completed Order Review Eligibility | Order | Customer | Post-completion Review | BASELINE | S1 |
| BR-SHIP-01 | Single Active Delivery Constraint | Shipper / Assignment | Shipper | Shipper Acceptance | BASELINE | S1 |
| BR-SHIP-02 | Delivery Acceptance Eligibility | Shipper / Assignment | Shipper | Shipper Acceptance | BASELINE | S1 |
| BR-DEL-01 | Maximum Delivery Distance | Delivery | System | Checkout Feasibility | BASELINE | S1 |
| BR-FEE-01 | Distance-Based Delivery Fee | Fee / Pricing | System | Checkout Calculation | BASELINE | S1 |
| BR-FEE-02 | Time-Based Service Fee | Fee / Pricing | System | Checkout Calculation | BASELINE | S1 |
| BR-PARTNER-01 | Partner Approval Requirement | Partner / Access | Restaurant & Shipper | Normal Operation Access | BASELINE | S1 |

## 4. Detailed Business Rules

### BR-ORDER-01 — Completed Order Review Eligibility

**Rule Statement**
Only completed orders can be reviewed.

**Business Rationale — DERIVED**
Derived rationale: to restrict review eligibility to orders that have reached the Completed lifecycle checkpoint.

**Trigger**
Customer attempts to submit a review for an order.

**Conditions**
Order status = "Hoàn thành" / Completed.

**Outcome**
Review is permitted.

**Failure / Rejection Behaviour**
If the order is not Completed, the review must not be permitted.

**Applies To**
Customer capability.

**TO-BE Process Touchpoint**
Submit post-completion review.

**Related Requirements**
FR-CUS-08

**Evidence Classification**
BASELINE

**Source**
S1 — Validated Portfolio BRD

**Open Questions / Clarifications**
Whether review cardinality/editability is defined — NOT EVIDENCED / REQUIRES CLARIFICATION.


### BR-SHIP-01 — Single Active Delivery Constraint

**Rule Statement**
A Shipper cannot hold multiple active delivery orders simultaneously.

**Business Rationale — DERIVED**
Derived rationale: to prevent a Shipper from holding concurrent active delivery assignments, consistent with the target assignment constraint.

**Trigger**
Shipper attempts to accept another delivery.

**Conditions**
Whether the Shipper already holds an active delivery order.

**Outcome**
If no conflicting active delivery exists, acceptance may proceed subject to other eligibility rules.

**Failure / Rejection Behaviour**
If a conflicting active delivery exists, acceptance must be rejected / prevented.

**Applies To**
Shipper capability.

**TO-BE Process Touchpoint**
Accept delivery.

**Related Requirements**
FR-SHP-02

**Evidence Classification**
BASELINE

**Source**
S1 — Validated Portfolio BRD

**Open Questions / Clarifications**
Definition of "active delivery" by exact order status — NOT EVIDENCED / REQUIRES CLARIFICATION.


### BR-SHIP-02 — Delivery Acceptance Eligibility

**Rule Statement**
A Shipper may accept an order only when the order is unassigned AND the status is "Đang lấy món" (Ready for Pickup).

**Business Rationale — DERIVED**
Derived rationale: to prevent delivery acceptance before the order is Ready for Pickup and to prevent multiple Shippers from claiming the same order.

**Trigger**
Shipper attempts to accept a delivery.

**Conditions**
AssignedShipper = none / unassigned
AND
Order.Status = "Đang lấy món" (Ready for Pickup)

**Outcome**
Acceptance may proceed. The System records the Shipper assignment.

**Failure / Rejection Behaviour**
If either condition fails, acceptance must not proceed.

**Applies To**
Shipper capability.

**TO-BE Process Touchpoint**
Expose eligible, unassigned order to Shippers / Accept delivery.

**Related Requirements**
FR-SHP-01, FR-SHP-02 (Upstream dependency: FR-RES-05)

**Evidence Classification**
BASELINE 

**Source**
S1 — Validated Portfolio BRD

**Open Questions / Clarifications**
What exact status applies after a Shipper cancellation before re-acceptance? — NOT EVIDENCED / REQUIRES CLARIFICATION.


### BR-DEL-01 — Maximum Delivery Distance

**Rule Statement**
The System shall reject checkout when calculated Restaurant-to-Customer delivery distance exceeds 30 km.

**Business Rationale — DERIVED**
Derived rationale: to enforce the maximum delivery-distance boundary defined for checkout eligibility.

**Trigger**
Checkout delivery-feasibility validation.

**Conditions**
Calculated Restaurant-to-Customer delivery distance.

**Outcome**
If distance <= 30 km, delivery-distance validation passes, subject to other checkout rules.

**Failure / Rejection Behaviour**
If distance > 30 km, checkout is rejected.

**Applies To**
System checkout logic.

**TO-BE Process Touchpoint**
Validate address / route / distance.

**Related Requirements**
FR-CUS-04

**Evidence Classification**
BASELINE

**Source**
S1 — Validated Portfolio BRD

**Open Questions / Clarifications**
N/A


### BR-FEE-01 — Distance-Based Delivery Fee

**Rule Statement**
Delivery fee is VND 15,000 for the first 3 km. For distance exceeding 3 km, an additional VND 3,000 per additional kilometre applies, based on calculated delivery distance.

**Business Rationale — DERIVED**
Derived rationale: to apply the distance-based delivery-fee schedule defined by the target pricing policy.

**Trigger**
Delivery fee calculation during checkout.

**Conditions**
Calculated delivery distance.

**Outcome**
System calculates and outputs the delivery fee based on the distance tiers.

**Failure / Rejection Behaviour**
NOT EVIDENCED.

**Applies To**
System checkout logic.

**TO-BE Process Touchpoint**
Calculate delivery fees.

**Related Requirements**
FR-CUS-05

**Evidence Classification**
BASELINE

**Source**
S1 — Validated Portfolio BRD

**Open Questions / Clarifications**
Additional-kilometre rounding / fractional precision method — NOT EVIDENCED / REQUIRES CLARIFICATION.


### BR-FEE-02 — Time-Based Service Fee

**Rule Statement**
Service fee based on order time: Before 19:00, the fee is VND 16,000. From 19:00 onward, the fee is VND 20,000.

**Business Rationale — DERIVED**
Derived rationale: to apply the time-based service-fee schedule defined by the target pricing policy.

**Trigger**
Service-fee calculation during checkout/order confirmation.

**Conditions**
Order timestamp compared against the 19:00 boundary.

**Outcome**
System calculates and outputs the applicable service fee.

**Failure / Rejection Behaviour**
NOT EVIDENCED.

**Applies To**
System checkout logic.

**TO-BE Process Touchpoint**
Checkout fee calculation / Calculate service fee.

**Related Requirements**
FR-CUS-05

**Evidence Classification**
BASELINE

**Source**
S1 — Validated Portfolio BRD

**Open Questions / Clarifications**
Authoritative order-time timestamp (e.g., checkout initiation vs server time) for fee evaluation — NOT EVIDENCED / REQUIRES CLARIFICATION.


### BR-PARTNER-01 — Partner Approval Requirement

**Rule Statement**
Restaurant and Shipper accounts require Administrator approval before normal operation.

**Business Rationale — DERIVED**
Derived rationale: to ensure Restaurant and Shipper accounts receive Administrator approval before accessing normal operational capabilities.

**Trigger**
Restaurant/Shipper attempts normal operational access after registration.

**Conditions**
Partner account approval state.

**Outcome**
Approved account may perform authorized operational functions.

**Failure / Rejection Behaviour**
If not approved, normal partner operations must not be available.

**Applies To**
Restaurant & Shipper accounts.

**TO-BE Process Touchpoint**
Upstream prerequisite for process participation.

**Related Requirements**
FR-ADM-02

**Evidence Classification**
BASELINE

**Source**
S1 — Validated Portfolio BRD

**Open Questions / Clarifications**
Partner approval-state model and exact values — NOT EVIDENCED / REQUIRES CLARIFICATION.

## 5. Cross-Rule Dependencies

* **BR-SHIP-01 and BR-SHIP-02** jointly constrain Shipper acceptance. A Shipper can accept only when the order eligibility is valid (unassigned + Ready for Pickup) AND the Shipper eligibility is valid (no conflicting active deliveries).
* **BR-DEL-01, BR-FEE-01 and BR-FEE-02** interact during checkout. Delivery distance is validated against BR-DEL-01 and provides the input to BR-FEE-01, while BR-FEE-02 independently determines the service fee from the applicable order-time boundary.
* **BR-ORDER-01** depends strictly on the order reaching the completed lifecycle state.

## 6. TO-BE Process Traceability

| Rule ID | TO-BE Process Stage | Triggering Actor | Relevant Lifecycle Checkpoint | Process Effect |
| :--- | :--- | :--- | :--- | :--- |
| BR-ORDER-01 | Post-completion Review | Customer | "Hoàn thành" | Controls review eligibility |
| BR-SHIP-01 | Shipper Acceptance | Shipper | N/A | Prevents concurrent active deliveries |
| BR-SHIP-02 | Shipper Acceptance | Shipper | "Đang lấy món" | Prevents invalid acceptance |
| BR-DEL-01 | Checkout Validation | System | N/A | Enforces feasibility boundary |
| BR-FEE-01 | Checkout Calculation | System | N/A | Computes delivery cost |
| BR-FEE-02 | Checkout fee calculation / Calculate service fee | System | N/A | Computes service cost |
| BR-PARTNER-01 | N/A (Upstream) | Restaurant & Shipper | N/A | Gates operational capabilities |

## 7. Rule Ambiguities & Open Questions

* **BR-SHIP-01:** What exact statuses count as an "active delivery"? (NOT EVIDENCED / REQUIRES CLARIFICATION)
* **BR-SHIP-02 / Post-cancellation transition:** If a Shipper cancels after the order reached "Đang giao", it is not established what status applies (e.g., whether it must return to "Đang lấy món") before another Shipper may accept. (NOT EVIDENCED / REQUIRES CLARIFICATION)
* **BR-FEE-01:** How are fractional additional kilometres rounded? (NOT EVIDENCED / REQUIRES CLARIFICATION)
* **BR-FEE-02:** Which timestamp is authoritative for the 19:00 boundary? (NOT EVIDENCED / REQUIRES CLARIFICATION)
* **BR-PARTNER-01:** What exact approval-state values exist in the target business model? (NOT EVIDENCED / REQUIRES CLARIFICATION)
* **BR-ORDER-01:** Whether review cardinality/editability is defined. (NOT EVIDENCED / REQUIRES CLARIFICATION)
* **Restaurant confirmation semantics:** It is not established whether "Chờ xác nhận" requires a distinct Restaurant confirmation action or separate intermediate state before "Đang lấy món". (NOT EVIDENCED / REQUIRES CLARIFICATION)

## 8. Source Mapping

| Rule ID | Primary Source | Supporting Source | Evidence Classification | Notes |
| :--- | :--- | :--- | :--- | :--- |
| BR-ORDER-01 | S1 | S2 | BASELINE | S2 conceptually supports review capability |
| BR-SHIP-01 | S1 | — / Not materially relied upon | BASELINE | |
| BR-SHIP-02 | S1 | — / Not materially relied upon | BASELINE | Known implementation mismatch exists (GAP-01) |
| BR-DEL-01 | S1 | — / Not materially relied upon | BASELINE | |
| BR-FEE-01 | S1 | — / Not materially relied upon | BASELINE | |
| BR-FEE-02 | S1 | — / Not materially relied upon | BASELINE | |
| BR-PARTNER-01 | S1 | — / Not materially relied upon | BASELINE | |

## 9. Analysis Summary

Seven controlled target business rules were identified from the S1 Validated Portfolio BRD. These rules formally constrain order reviews, Shipper assignments, delivery distance feasibility, fee calculations, and partner operational access. While the high-level policy is clear, several semantic details (such as rounding logic, authoritative timestamps, exact state definitions for active deliveries, and post-cancellation status semantics) remain unresolved and are explicitly retained as NOT EVIDENCED. This catalogue establishes the authoritative business-rule baseline for downstream Order State modelling, Use Cases, User Stories, and Acceptance Criteria traceability.
