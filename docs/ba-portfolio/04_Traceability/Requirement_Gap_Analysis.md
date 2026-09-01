# Requirement Gap Analysis — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Target-vs-Implementation Gap Analysis
Target Baseline: S1 — Validated Portfolio BRD + approved S5 artefacts
Implementation Baseline: S3 — Reviewed Current Prototype; S4 where applicable
Depends On: Business_Rules_Catalogue.md — APPROVED v1.0; Order_State_Diagram.md — APPROVED v1.0; Detailed_Use_Cases.md — APPROVED v1.0; User_Stories_Acceptance_Criteria.md — APPROVED v1.0
Last Reviewed: 15 Aug 2026

## 1. Purpose

This artefact compares the approved TARGET requirements against the CURRENT prototype implementation behaviour. It identifies verified implementation mismatches to distinguish full alignment, partial alignment, gaps, and unverified behaviour. By separating target from current, it prevents implementation behaviour from redefining requirements, preserves unresolved target semantics as clarification items rather than fake gaps, and creates a controlled input for downstream Requirements Traceability Matrix (RTM) and User Acceptance Testing (UAT) planning.

## 2. Assessment Method

The comparison model is structured as follows:

**TARGET:**
S1 — Validated Portfolio BRD + approved S5 BA Evidence Pack artefacts.

**CURRENT:**
S3 — Reviewed application source code + S4 — Data/persistence layer.

**COMPARISON:**
Target requirement → implementation evidence → assessment result → impact → recommendation.

All implementation statements are backed by evidence, primarily utilizing repository-relative file paths and relevant method/function symbols.

## 3. Gap Summary

| Gap ID | Gap Title | Target Requirement / Rule | Current Behaviour | Assessment | Gap Type | Evidence Classification | Recommended Action |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| GAP-01 | Shipper Acceptance Eligibility Not Fully Enforced | BR-SHIP-02, FR-SHP-02 | Implementation verifies unassigned condition but does not enforce the "Đang lấy món" status condition before acceptance. | GAP | Business Rule Enforcement | DERIVED | Align acceptance logic with BR-SHIP-02 to enforce both unassigned and Ready-for-Pickup status. |
| GAP-02 | Credential Protection Does Not Meet Target Security Requirement | NFR-SEC-02 | Authentication and registration store/compare passwords in plain text. | GAP | Security / NFR | DERIVED | Use a modern password-hashing mechanism with per-user salt. |

*No additional verified implementation gaps were created. This does not assert that no other implementation gaps exist; requirements classified as NOT VERIFIED require additional implementation or runtime evidence before an alignment or gap conclusion can be made.*

## 4. Functional Requirement Alignment

| FR ID | Target Requirement Summary | Current Implementation Evidence | Assessment Result | Related Gap | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- |
| FR-AUTH-01 | Registration under chosen roles | `AccountController.cs` (`Register` method) | ALIGNED | GAP-02 | Registration logic is functional but credential protection fails NFR-SEC-02. |
| FR-AUTH-02 | Authentication & role routing | `AccountController.cs` (`Login` method) | ALIGNED | GAP-02 | Authentication logic is functional but credential protection fails NFR-SEC-02. |
| FR-CUS-01 | Manage personal profile | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `KhachHangController.cs` |
| FR-CUS-02 | Browse restaurants & menus | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `KhachHangController.cs` / `HomeController.cs` |
| FR-CUS-03 | Manage shopping cart | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `KhachHangController.cs` |
| FR-CUS-04 | Validate delivery address & calculate delivery distance via Map APIs | Not established in this review pass | NOT VERIFIED | — | Implementation not explicitly reviewed. |
| FR-CUS-05 | Calculate total (cart + fees) | `KhachHangController.cs` (`TongThanhToan` logic) | ALIGNED | — | Fees and cart totals are calculated during checkout. |
| FR-CUS-06 | Checkout via COD / QR | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `KhachHangController.cs` |
| FR-CUS-07 | Track active order status/route | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `KhachHangController.cs` |
| FR-CUS-08 | Review completed order | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `KhachHangController.cs` |
| FR-CUS-09 | View orders & history | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `KhachHangController.cs` |
| FR-RES-01 | Update store information | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `NhaHangController.cs` |
| FR-RES-02 | Manage menu categories | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `NhaHangController.cs` |
| FR-RES-03 | Manage food items | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `NhaHangController.cs` |
| FR-RES-04 | View incoming orders | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `NhaHangController.cs` |
| FR-RES-05 | Update order status to ready | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `NhaHangController.cs` |
| FR-RES-06 | View revenue/order history | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `NhaHangController.cs` |
| FR-RES-07 | View customer reviews | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `NhaHangController.cs` |
| FR-SHP-01 | View available deliveries | `ShipperController.cs` (`Index` method) | ALIGNED | — | Shows orders where `MaShipper` is null. |
| FR-SHP-02 | Accept delivery assignment | `ShipperController.cs` (`Accept` method) | PARTIALLY ALIGNED | GAP-01 | Fails to enforce required `Order.Status` before assignment. |
| FR-SHP-03 | Update order delivery status | `ShipperController.cs` (`UpdateStatus` method) | ALIGNED | — | Supports updating Order status to "Đang giao" and "Hoàn thành". |
| FR-SHP-04 | View delivery history & income | `ShipperController.cs` (`Accepted` & statistics) | ALIGNED | — | Shipper can view completed deliveries and income statistics. |
| FR-SHP-05 | Manage Shipper profile | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `ShipperController.cs` |
| FR-ADM-01 | Manage user accounts | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `AdminController.cs` |
| FR-ADM-02 | Approve partner registrations | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `AdminController.cs` |
| FR-ADM-03 | View system statistics | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `AdminController.cs` |
| FR-ADM-04 | Export revenue statistics | Not established in this review pass | NOT VERIFIED | — | Potential implementation area: `AdminController.cs` |

## 5. Business Rule Alignment

| BR ID | Target Rule Summary | Current Implementation Evidence | Assessment Result | Related Gap | Target Clarification |
| :--- | :--- | :--- | :--- | :--- | :--- |
| BR-ORDER-01 | Completed order review | Not established in this review pass | NOT VERIFIED | — | Review cardinality/editability. |
| BR-SHIP-01 | One active delivery limit | `ShipperController.cs` (`Accept` active limit check) | ALIGNED | — | Exact active delivery definition. |
| BR-SHIP-02 | Shipper assignment conditions | `ShipperController.cs` (`Accept` method) | GAP | GAP-01 | — |
| BR-DEL-01 | 30km delivery radius limit | `KhachHangController.cs` (`MAX_DELIVERY_RADIUS = 30.0`) | ALIGNED | — | — |
| BR-FEE-01 | Base fee + distance fee | `KhachHangController.cs` (Distance calculations `extraKm * 3000`) | ALIGNED | — | Fractional-km rounding. |
| BR-FEE-02 | Time-based service fee | `KhachHangController.cs` (`TinhPhiDichVu` checks `Hour >= 19`) | ALIGNED | — | Authoritative timestamp. |
| BR-PARTNER-01 | Partner approval before operation | `AccountController.cs` | NOT VERIFIED | — | Registration establishes an unapproved state, but enforcement of Administrator approval before mapped normal operational capabilities has not been sufficiently verified. |

## 6. Order Lifecycle Alignment

| Transition | Target Behaviour | Current Implementation Evidence | Assessment | Related Gap / Note |
| :--- | :--- | :--- | :--- | :--- |
| ST-01 | Initial → "Chờ xác nhận" | Not established in this review pass | NOT VERIFIED | Expected functional, not explicitly checked. |
| ST-02 | "Chờ xác nhận" → "Đang lấy món" | `ShipperController.cs` (`Accept`) assigns status directly | NOT VERIFIED | Shipper Accept also assigns "Đang lấy món", which supports GAP-01, but Restaurant-triggered ST-02 implementation has not yet been independently verified. |
| ST-03 | "Đang lấy món" → "Đang giao" | `ShipperController.cs` (`UpdateStatus`) | NOT VERIFIED | `UpdateStatus` supports generic updates, but enforcement from the specific source state "Đang lấy món" has not been verified. |
| ST-04 | "Đang giao" → "Hoàn thành" | `ShipperController.cs` (`UpdateStatus`) | NOT VERIFIED | `UpdateStatus` reaches "Hoàn thành", but specific source/trigger verification is insufficient in this pass. |

## 7. Non-Functional Requirement Alignment

| NFR ID | Target Requirement | Available Evidence | Assessment Result | Related Gap | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- |
| NFR-PER-01 | Core customer operations shall meet an agreed response-time target under expected project load; quantitative target remains TBD. | No performance-test evidence reviewed. | TARGET CLARIFICATION REQUIRED | — | Quantitative response-time threshold remains TBD. Runtime performance is also NOT VERIFIED. |
| NFR-SEC-01 | Functions shall be restricted strictly according to authenticated user roles. | Role/authorization implementation not sufficiently reviewed. | NOT VERIFIED | — | Requires RBAC/authorization review. |
| NFR-SEC-02 | Approved password hashing | `AccountController.cs` stores plaintext passwords | GAP | GAP-02 | — |
| NFR-COMP-01 | Cross-browser compatibility | No cross-browser UI testing evidence | NOT VERIFIED | — | Cross-browser verification belongs to testing evidence. |

## 8. Detailed Gap Analysis

### GAP-01 — Shipper Acceptance Eligibility Not Fully Enforced

**Gap Type**
Business Rule Enforcement

**Target Requirement**
BR-SHIP-02, FR-SHP-02, UC-SHP-02, US-SHP-02

**Target Behaviour**
A Shipper may accept an Order only when the Order has no Shipper assignment AND the `Order.Status` = "Đang lấy món" (Ready for Pickup).

**Current Implementation**
The implementation checks if the order is unassigned, but does not enforce the "Đang lấy món" status condition before allowing the assignment. Instead, it blindly updates the order status to "Đang lấy món" upon assignment acceptance.

**Implementation Evidence**
`ĐACN/Controllers/ShipperController.cs` (`Accept` method, line ~629).
`if (don != null && string.IsNullOrEmpty(don.MaShipper))` ... `donCheck.MaShipper = shipper.MaShipper; donCheck.TrangThai = "Đang lấy món";`

**Assessment**
GAP

**Mismatch**
Target expects Shipper acceptance to be conditional on the Restaurant having completed preparation ("Đang lấy món").
Implementation performs the assignment if it is merely unassigned, without validating the Ready-for-Pickup status, effectively assuming the Shipper drives the state change rather than responding to it.
Therefore the assignment prerequisite logic is not satisfied.

**Impact**
The prototype may allow a Shipper to accept an Order before the target Ready-for-Pickup condition is satisfied.

**Recommendation**
Align acceptance eligibility with BR-SHIP-02 by enforcing that the Order has no Shipper assignment AND `Order.Status` = "Đang lấy món" before acceptance is permitted.

**Evidence Classification**
Target: BASELINE
Current: IMPLEMENTED
Gap conclusion: DERIVED

**Downstream Traceability**
Related to FR-SHP-02, BR-SHIP-02, UC-SHP-02, US-SHP-02. AC-US-SHP-02-01, AC-US-SHP-02-02, AC-US-SHP-02-03.

---

### GAP-02 — Credential Protection Does Not Meet Target Security Requirement

**Gap Type**
Security / NFR

**Target Requirement**
NFR-SEC-02

**Target Behaviour**
User credentials shall be protected using an approved password-hashing mechanism.

**Current Implementation**
Authentication compares the supplied password directly against the persisted password field without an approved hashing step, and registration persists supplied passwords directly in plain text.

**Implementation Evidence**
`ĐACN/Controllers/AccountController.cs` 
- Login: direct password equality comparison: `var tk = db.TaiKhoans.FirstOrDefault(x => x.TenDangNhap == username && x.MatKhau == password);`
- Register: supplied password persisted directly: `MatKhau = password`

**Assessment**
GAP

**Mismatch**
Target expects modern credential protection and password hashing.
Implementation performs plaintext storage and direct equality comparison for passwords.
Therefore the credential-protection target is not satisfied.

**Impact**
The current credential handling does not satisfy the approved target credential-protection requirement.

**Recommendation**
Use a modern password-hashing mechanism with per-user salt. Migrate existing credentials before production use.

**Evidence Classification**
Target: BASELINE
Current: IMPLEMENTED
Gap conclusion: DERIVED

**Downstream Traceability**
Related to NFR-SEC-02. Note: Affects FR-AUTH-02 execution quality, but functional capability is present.

## 9. Target Clarifications Excluded from Gap Classification

| Target Item | Related Requirement / Story | Status | Why Not a Gap |
| :--- | :--- | :--- | :--- |
| Quantitative response-time target | NFR-PER-01 | TARGET CLARIFICATION REQUIRED | The quantitative performance threshold remains TBD; there is no confirmed numeric target against which runtime performance can currently be assessed. |
| Restaurant intermediate confirmation semantics | ST-01 / ST-02 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Exact post-Shipper-cancellation status | US-SHP-03 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Exact "active delivery" definition | BR-SHIP-01 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Fractional-km rounding | BR-FEE-01 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Authoritative timestamp for service fee | BR-FEE-02 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Approval-state vocabulary & rejection logic | BR-PARTNER-01 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Review cardinality & editability | BR-ORDER-01 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Browsing authentication requirement | US-CUS-02 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Customer profile input-validation | US-CUS-01 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Tracking refresh & notification behaviour | US-CUS-05 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Non-core capability boundary for approval | BR-PARTNER-01 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Detailed authentication failure behaviour | FR-AUTH-02 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Exact menu-category management operations | US-RES-02 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |
| Exact Admin user-management actions | US-ADM-01 | TARGET CLARIFICATION REQUIRED | Not explicitly evidenced in target baseline. |

## 10. Implementation-Only Observations

*No major implementation-only observations asserted in this review pass.*

## 11. Source Mapping

| Analysis Item | Target Source | Current Source | Assessment | Evidence Classification | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- |
| GAP-01 | S1, BR-SHIP-02, S5 (US-SHP-02) | S3 (`ShipperController.cs`) | GAP | DERIVED | Shipper assignment ignores Ready-for-Pickup status requirement. |
| GAP-02 | S1, NFR-SEC-02 | S3 (`AccountController.cs`) | GAP | DERIVED | Credentials stored and compared in plaintext. |
| BR-DEL-01 | S1, BR-DEL-01 | S3 (`KhachHangController.cs`) | ALIGNED | IMPLEMENTED | Distance max radius verified explicitly in code (30km limit). |
| BR-FEE-01 | S1, BR-FEE-01 | S3 (`KhachHangController.cs`) | ALIGNED | IMPLEMENTED | Base 15000 + extra 3000/km logic verified in code. |
| BR-FEE-02 | S1, BR-FEE-02 | S3 (`KhachHangController.cs`) | ALIGNED | IMPLEMENTED | Time-based service fee switch (hour >= 19) verified in code. |
| NFR-PER-01 | S1 | No performance-test evidence reviewed | TARGET CLARIFICATION REQUIRED | Target: BASELINE; Current: NOT EVIDENCED | Quantitative target remains TBD; runtime performance not verified. |
| NFR-SEC-01 | S1 | S3 authorization/RBAC evidence not sufficiently reviewed | NOT VERIFIED | Target: BASELINE; Current: NOT EVIDENCED | Requires authorization/RBAC verification. |
| NFR-COMP-01 | S1 | No cross-browser execution evidence reviewed | NOT VERIFIED | Target: BASELINE; Current: NOT EVIDENCED | Requires cross-browser testing. |

## 12. Downstream Traceability Impact

This Gap Analysis provides a controlled input for the forthcoming Requirements Traceability Matrix (`Requirements_Traceability_Matrix.csv`) and User Acceptance Testing (`UAT_Test_Cases.csv`). 

- Verified target requirements remain traceable regardless of whether the current implementation satisfies them.
- Gap IDs (GAP-01, GAP-02) will be linked in the RTM where the implementation currently deviates.
- UAT test cases will be written to validate the TARGET behaviour (not to preserve known defects).
- Unresolved target requirements (Target Clarifications) will not receive fabricated executable UAT expectations, ensuring downstream testing remains evidence-based.

## 13. Analysis Summary

- **Functional Requirements Assessed:** 27
  - ALIGNED: 6
  - PARTIALLY ALIGNED: 1
  - GAP: 0 (Direct gaps managed under NFR/BR sections, except for PARTIALLY ALIGNED FR-SHP-02 mapped to GAP-01)
  - NOT VERIFIED: 20
  - TARGET CLARIFICATION REQUIRED: 0 (Directly on FR level; deferrals tracked in Section 9)
- **Target Clarification Register:**
  - 15 unresolved target items tracked in Section 9.
  - These items are deliberately excluded from implementation-gap classification.
- **Business Rules Reviewed:** 7
- **NFRs Reviewed:** 4
- **Verified Gap IDs:** GAP-01, GAP-02
- **GAP-01 Status:** Remains OPEN (Implementation verified).
- **GAP-02 Status:** Remains OPEN (Implementation verified).
