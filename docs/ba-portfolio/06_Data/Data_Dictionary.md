# Data Dictionary — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Business / Logical / Physical Data Dictionary
Target Baseline: S1 — Validated Portfolio BRD + approved S5 artefacts
Implementation Baseline: S4 — Current Data Model / Persistence; S3 where required
Depends On: Requirement_Gap_Analysis.md — APPROVED v1.0; User_Stories_Acceptance_Criteria.md — APPROVED v1.0; Detailed_Use_Cases.md — APPROVED v1.0; Business_Rules_Catalogue.md — APPROVED v1.0; Order_State_Diagram.md — APPROVED v1.0
Last Reviewed: 15 Aug 2026

## 1. Purpose

The Data Dictionary defines the controlled vocabulary for major business data concepts and documents verified physical data structures where implementation evidence exists. It maps logical business data to current persistence structures, strictly distinguishing TARGET meaning from CURRENT implementation. 

It records primary keys (PK), foreign keys (FK), data types, and nullability only where physically verified. This provides foundational data mappings to support downstream Requirements Traceability Matrix (RTM) and User Acceptance Testing (UAT) traceability while preventing physical schema assumptions from becoming invented requirements.

## 2. Scope

This dictionary covers data relevant to the approved system scope, including where evidenced:
- Authentication / account data
- Customer data
- Restaurant data
- Shipper data
- Menu / food data
- Order data
- Order detail / line-item data
- Delivery / Shipper assignment data
- Review / rating data
- Partner approval data
- Computed revenue/income data

It focuses on persisting major business concepts. Computed or transient data (e.g. active delivery status or distance values passed transiently) are explicitly stated as computed rather than persisted.

## 3. Data Entity Inventory

| Entity ID | Business Entity | Business Definition | Primary Actor / Owner Context | Current Physical Mapping | Persistence Status | Key Related Requirements | Evidence Classification | Source |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| DE-001 | Account | System authentication credentials and access role mapping. | Administrator / All | `TaiKhoan` | IMPLEMENTED | FR-AUTH-01, FR-AUTH-02 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-002 | Customer | Registered customer profile and location details. | Customer | `KhachHang` | IMPLEMENTED | FR-CUS-01 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-003 | Restaurant | Partner restaurant profile, address, and operation status. | Restaurant | `NhaHang` | IMPLEMENTED | FR-RES-01 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-004 | Shipper | Delivery partner profile, vehicle information, and location tracking. | Shipper | `Shipper` | IMPLEMENTED | FR-SHP-05 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-005 | Food Item | Individual menu item offered by a Restaurant. | Restaurant | `MonAn` | IMPLEMENTED | FR-RES-03 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-006 | Menu Category | Classification grouping for Food Items. | Restaurant | `LoaiMonAn` | IMPLEMENTED | FR-RES-02 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-007 | Order | A Customer's submitted food purchase request and its associated delivery lifecycle. | Customer | `DonHang` | IMPLEMENTED | FR-CUS-05, BR-ORDER-01 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-008 | Order Detail | Line-item quantities and specific food items within an Order. | Customer | `ChiTietDonHang` | IMPLEMENTED | FR-CUS-05 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-009 | Restaurant Review | Customer evaluation of a completed Order's restaurant quality. | Customer | `DanhGiaNhaHang` | IMPLEMENTED | BR-ORDER-01 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |
| DE-010 | Shipper Review | Customer evaluation of a completed Order's delivery quality. | Customer | `DanhGiaShipper` | IMPLEMENTED | BR-ORDER-01 | Target: BASELINE; Current: IMPLEMENTED | S1, S4 |

## 4. Data Element Dictionary

*Note: "Target: BASELINE" classification on a data element refers to the logical business concept where supported; it does not imply that the exact physical field name, type, or storage mechanism is prescribed by the target baseline.*

| Data Element ID | Business Entity | Business / Logical Name | Business Definition | Physical Mapping | Data Type | Key Type | Nullability | Allowed / Known Values | Source / Derivation | Related Requirements / Rules | Evidence Classification | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| DE-ACC-001 | Account | Username | Identifier supplied by a registered user for authentication. | `TaiKhoan.TenDangNhap` | string (EF) | — | NOT VERIFIED | — | Registration input | FR-AUTH-01 | Target: BASELINE; Current: IMPLEMENTED | Target states authentication by username/password; uniqueness constraint not verified in code here. |
| DE-ACC-002 | Account | Credential Secret | Sensitive authentication data. | `TaiKhoan.MatKhau` | string (EF) | — | Required | — | Registration input | NFR-SEC-02, GAP-02 | Target: BASELINE; Current: IMPLEMENTED | Stored without approved password hashing — linked to GAP-02. |
| DE-ACC-003 | Account | Role | Access control classification. | `TaiKhoan.VaiTro` | string (EF) | — | NOT VERIFIED | — | Registration context | FR-AUTH-02 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-ACC-004 | Account | Partner Approval Status | Flag indicating Administrator approval for normal operation. | `TaiKhoan.TrangThai` | bool? (EF) | — | Optional | — | Administrator review | BR-PARTNER-01 | Target: BASELINE; Current: IMPLEMENTED | Approval workflow vocabulary and normal-operation gating remain target clarifications. |
| DE-CUS-001 | Customer | Customer Identifier | Unique structural identifier for a customer profile. | `KhachHang.MaKH` | string (EF) | PK | Required | — | System generated | FR-CUS-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-CUS-002 | Customer | Account Reference | Association to authentication credentials. | `KhachHang.MaTK` | string (EF) | FK | Optional | — | System registration | FR-AUTH-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-CUS-003 | Customer | Name | Customer's profile name. | `KhachHang.TenKH` | string (EF) | — | Optional | — | Profile input | FR-CUS-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-CUS-004 | Customer | Delivery Coordinates | Structural location tracking data for the Customer. | `KhachHang.Latitude` / `Longitude` | double? (EF) | — | Optional | — | Address lookup / GPS | FR-CUS-01, FR-CUS-04 | Target: BASELINE; Current: IMPLEMENTED | Persisted fields verified on KhachHang entity. |
| DE-RES-001 | Restaurant | Restaurant Identifier | Unique structural identifier for a restaurant profile. | `NhaHang.MaNH` | string (EF) | PK | Required | — | System generated | FR-RES-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-RES-002 | Restaurant | Account Reference | Association to authentication credentials. | `NhaHang.MaTK` | string (EF) | FK | Optional | — | System registration | FR-AUTH-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-RES-003 | Restaurant | Operation Status | Indicator of current restaurant active/open status. | `NhaHang.TrangThai` | string (EF) | — | Optional | — | Restaurant control | FR-RES-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-RES-004 | Restaurant | Origin Coordinates | Structural location data for the Restaurant. | `NhaHang.Latitude` / `Longitude` | double? (EF) | — | Optional | — | Address lookup / GPS | FR-RES-01, FR-CUS-04 | Target: BASELINE; Current: IMPLEMENTED | Persisted fields verified on NhaHang entity. |
| DE-SHP-001 | Shipper | Shipper Identifier | Unique structural identifier for a shipper profile. | `Shipper.MaShipper` | string (EF) | PK | Required | — | System generated | FR-SHP-05 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-SHP-002 | Shipper | Account Reference | Association to authentication credentials. | `Shipper.MaTK` | string (EF) | FK | Optional | — | System registration | FR-AUTH-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-SHP-003 | Shipper | Vehicle Details | Vehicle registration or physical vehicle information. | `Shipper.BienSoXe` | string (EF) | — | Optional | — | Profile input | FR-SHP-05 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-SHP-004 | Shipper | Accumulated Income | Total derived or persisted earnings for the shipper. | `Shipper.ThuNhap` | decimal? (EF) | — | Optional | — | Aggregated completions | FR-SHP-04 | Target: BASELINE; Current: IMPLEMENTED | Computed statistics field persisted in schema. |
| DE-SHP-005 | Shipper | Shipper Location | Current structural location tracking data for the Shipper. | `Shipper.Latitude` / `Longitude` | double? (EF) | — | Optional | — | Tracking updates | FR-CUS-07 | Target: BASELINE; Current: IMPLEMENTED | Persisted fields verified on Shipper entity. |
| DE-FOO-001 | Food Item | Food Identifier | Unique structural identifier for a menu item. | `MonAn.MaMon` | string (EF) | PK | Required | — | System generated | FR-RES-03 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-FOO-002 | Food Item | Restaurant Reference | Association to the owning restaurant. | `MonAn.MaNH` | string (EF) | FK | Optional | — | Structural association | FR-RES-03 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-FOO-003 | Food Item | Category Reference | Association to the logical menu category. | `MonAn.MaLoai` | string (EF) | FK | Optional | — | Structural association | FR-RES-03 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-FOO-004 | Food Item | Base Price | Configured monetary cost of the item. | `MonAn.Gia` | decimal? (EF) | — | Optional | — | Menu configuration | FR-RES-03 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-CAT-001 | Menu Category | Category Identifier | Unique structural identifier for a category. | `LoaiMonAn.MaLoai` | string (EF) | PK | Required | — | System generated | FR-RES-02 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-CAT-002 | Menu Category | Category Name | Display label for the menu category. | `LoaiMonAn.TenLoai` | string (EF) | — | Optional | — | Category configuration | FR-RES-02 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-DTL-001 | Order Detail | Detail Identifier | Unique structural identifier for a line item. | `ChiTietDonHang.MaChiTiet` | int (EF) | PK | Required | — | System generated | FR-CUS-05 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-DTL-002 | Order Detail | Order Reference | Association to the parent order. | `ChiTietDonHang.MaDon` | string (EF) | FK | Optional | — | Structural association | FR-CUS-05 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-DTL-003 | Order Detail | Food Reference | Association to the purchased food item. | `ChiTietDonHang.MaMon` | string (EF) | FK | Optional | — | Structural association | FR-CUS-05 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-DTL-004 | Order Detail | Quantity | Number of units purchased for this line item. | `ChiTietDonHang.SoLuong` | int? (EF) | — | Optional | — | Cart entry | FR-CUS-05 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-DTL-005 | Order Detail | Line Item Price | Captured historical price of the item at purchase time. | `ChiTietDonHang.DonGia` | decimal? (EF) | — | Optional | — | Cart entry | FR-CUS-05 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-REV-001 | Restaurant Review | Review Identifier | Unique structural identifier for a restaurant review. | `DanhGiaNhaHang.MaDGNH` | string (EF) | PK | Required | — | System generated | BR-ORDER-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-REV-002 | Restaurant Review | Order Reference | Association to the completed order. | `DanhGiaNhaHang.MaDon` | string (EF) | FK | Optional | — | Structural association | BR-ORDER-01 | Target: BASELINE; Current: IMPLEMENTED | Target restricts to completed orders. |
| DE-REV-003 | Restaurant Review | Rating Score | Quantitative evaluation rating. | `DanhGiaNhaHang.SoSao` | int? (EF) | — | Optional | — | Customer input | FR-CUS-08 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-REV-004 | Shipper Review | Review Identifier | Unique structural identifier for a shipper review. | `DanhGiaShipper.MaDG` | string (EF) | PK | Required | — | System generated | BR-ORDER-01 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-REV-005 | Shipper Review | Order Reference | Association to the completed order. | `DanhGiaShipper.MaDon` | string (EF) | FK | Optional | — | Structural association | BR-ORDER-01 | Target: BASELINE; Current: IMPLEMENTED | Target restricts to completed orders. |
| DE-REV-006 | Shipper Review | Rating Score | Quantitative evaluation rating. | `DanhGiaShipper.SoSao` | int? (EF) | — | Optional | — | Customer input | FR-CUS-08 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-ORD-001 | Order | Order Identifier | Unique system reference for an order. | `DonHang.MaDon` | string (EF) | PK | Required | — | System generated | — | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-ORD-002 | Order | Order Status | The current stage in the target delivery lifecycle. | `DonHang.TrangThai` | string (EF) | — | Optional | TARGET: "Chờ xác nhận", "Đang lấy món", "Đang giao", "Hoàn thành" | System / Actor triggered | ST-01, ST-02, ST-03, ST-04 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-ORD-003 | Order | Shipper Assignment | Reference to the Shipper fulfilling the delivery. | `DonHang.MaShipper` | string (EF) | FK | Optional | — | Assignment action | BR-SHIP-02, GAP-01 | Target: BASELINE; Current: IMPLEMENTED | Linked to GAP-01 where Shipper assignment ignores Ready for Pickup status requirement. |
| DE-ORD-004 | Order | Total Amount | The final calculated cost including cart items and all fees. | `DonHang.TongTien` | decimal? (EF) | — | Optional | — | Computed during checkout | FR-CUS-05 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-ORD-005 | Order | Delivery Fee | Distance-based delivery charge. | No separate persisted field verified; contributes to aggregated `DonHang.ShipFee`. | NOT VERIFIED | — | NOT VERIFIED | — | Computed based on distance | BR-FEE-01 | Target: BASELINE; Current computation: IMPLEMENTED; Current persistence: NOT VERIFIED | Target explicitly separates distance fee from time fee. |
| DE-ORD-006 | Order | Service Fee | Time-based service charge. | No separate persisted field verified; contributes to aggregated `DonHang.ShipFee`. | NOT VERIFIED | — | NOT VERIFIED | TARGET: VND 16,000 before 19:00; VND 20,000 from 19:00 onward. | Computed based on time | BR-FEE-02 | Target: BASELINE; Current computation: IMPLEMENTED; Current persistence: NOT VERIFIED | — |
| DE-ORD-007 | Order | Payment Method | Selected method of payment (COD or QR Payment Simulation). | NOT VERIFIED | NOT VERIFIED | — | NOT VERIFIED | TARGET: COD, QR Payment Simulation | Customer selection | FR-CUS-06 | Target: BASELINE; Current: NOT VERIFIED | Explicit target payment method field not identified in `DonHang` schema. |
| DE-ORD-008 | Order | Delivery Distance | Calculated route distance from Restaurant to Customer. | No persisted field verified; computed/transient value. | NOT VERIFIED | N/A — transient/computed | NOT VERIFIED | — | Computed via Map APIs | FR-CUS-04, BR-DEL-01 | Target: BASELINE; Current computation: IMPLEMENTED; Current persistence: NOT VERIFIED | Delivery-distance computation is implemented through the verified Map/routing flow, but no persisted Order field has been verified. |
| DE-ORD-009 | Order | Customer Reference | Association to the owning customer. | `DonHang.MaKH` | string (EF) | FK | Optional | — | Structural association | FR-CUS-09 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-ORD-010 | Order | Restaurant Reference | Association to the fulfilling restaurant. | `DonHang.MaNH` | string (EF) | FK | Optional | — | Structural association | FR-RES-04 | Target: BASELINE; Current: IMPLEMENTED | — |
| DE-ORD-011 | Order | Delivery Routing Information | Dynamic route tracking details. | NOT VERIFIED | NOT VERIFIED | — | NOT VERIFIED | — | Routing API | FR-CUS-07 | Target: BASELINE; Current: NOT VERIFIED | Transient data; mapping not verified. |

## 5. Entity Relationship Summary

| Relationship ID | From Business Entity | Relationship | To Business Entity | Current Physical Evidence | Cardinality | Target Relevance | Evidence Classification | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| REL-001 | Customer | Places | Order | `KhachHang` → `DonHang` | NOT VERIFIED | Essential order ownership | Target: BASELINE; Current: IMPLEMENTED | Mapped physically via `DonHang.MaKH` FK. |
| REL-002 | Restaurant | Receives | Order | `NhaHang` → `DonHang` | NOT VERIFIED | Essential fulfillment | Target: BASELINE; Current: IMPLEMENTED | Mapped physically via `DonHang.MaNH` FK. |
| REL-003 | Shipper | Delivers | Order | `Shipper` → `DonHang` | NOT VERIFIED | Assignment mapping | Target: BASELINE; Current: IMPLEMENTED | Mapped physically via `DonHang.MaShipper` FK (Nullable). |
| REL-004 | Order | Contains | Order Detail | `DonHang` → `ChiTietDonHang` | NOT VERIFIED | Cart conversion | Target: BASELINE; Current: IMPLEMENTED | Mapped physically via `ChiTietDonHang.MaDon` FK. |
| REL-005 | Restaurant | Offers | Food Item | `NhaHang` → `MonAn` | NOT VERIFIED | Menu ownership | Target: BASELINE; Current: IMPLEMENTED | Mapped physically via `MonAn.MaNH` FK. |
| REL-006 | Menu Category | Classifies | Food Item | `LoaiMonAn` → `MonAn` | NOT VERIFIED | Product grouping | Target: BASELINE; Current: IMPLEMENTED | Mapped physically via `MonAn.MaLoai` FK. |
| REL-007 | Food Item | Referenced in | Order Detail | `MonAn` → `ChiTietDonHang` | NOT VERIFIED | Purchase reference | Target: BASELINE; Current: IMPLEMENTED | Mapped physically via `ChiTietDonHang.MaMon` FK. |
| REL-008 | Order | Rated by | Restaurant Review | `DonHang` → `DanhGiaNhaHang` | NOT VERIFIED | Quality evaluation | Target: BASELINE; Current: IMPLEMENTED | Target requires BR-ORDER-01 (completed orders only). |
| REL-009 | Order | Rated by | Shipper Review | `DonHang` → `DanhGiaShipper` | NOT VERIFIED | Service evaluation | Target: BASELINE; Current: IMPLEMENTED | Target requires BR-ORDER-01 (completed orders only). |

## 6. Derived & Computed Data

| Data Item | Business Meaning | Source Inputs | Current Computation Evidence | Persisted? | Related FR / BR | Target Clarification | Evidence Classification |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| Delivery Distance | Distance between store and customer. | Restaurant delivery-origin location (`NhaHang.Latitude`/`Longitude`), Customer delivery location (`KhachHang.Latitude`/`Longitude`) | Map APIs | No persisted field verified | FR-CUS-04, BR-DEL-01 | — | Target: BASELINE; Current computation: IMPLEMENTED; Current persistence: NOT VERIFIED |
| Delivery Fee (Logical) | Base shipping distance fee. | Distance | See Aggregated Charge below. | No separate field verified | BR-FEE-01 | Fractional-km rounding | Target: BASELINE; Current computation: IMPLEMENTED; Current persistence: NOT VERIFIED |
| Service Fee (Logical) | Time-based surcharge. | Current time | See Aggregated Charge below. | No separate field verified | BR-FEE-02 | Authoritative timestamp | Target: BASELINE; Current computation: IMPLEMENTED; Current persistence: NOT VERIFIED |
| Aggregated Shipping/Service Charge | Current implementation aggregate of applicable delivery and service-fee components. | Distance, current time | Delivery component: VND 15,000 for the first 3 km + VND 3,000 per additional km. Service component: VND 16,000 before 19:00; implementation applies an additional VND 4,000 from 19:00, resulting in VND 20,000. | Yes (`DonHang.ShipFee`) | BR-FEE-01, BR-FEE-02 | — | Target: BASELINE; Current: IMPLEMENTED (Note: This physical aggregation does not merge BR-FEE-01 and BR-FEE-02 into one TARGET business rule) |
| Total Order Amount | Total cost to customer. | Cart items + fees | Cart total + ShipFee | Yes (`TongTien`) | FR-CUS-05 | — | Target: BASELINE; Current: IMPLEMENTED |
| Shipper Income Stats | Total derived earnings for a Shipper. | Order deliveries and fees | Summed periodically | Yes (`ThuNhap`) | FR-SHP-04 | — | Target: BASELINE; Current: IMPLEMENTED |

## 7. Data Validation & Constraint Notes

**TARGET BUSINESS CONSTRAINTS**
- **BR-DEL-01:** Delivery distance > 30 km is rejected.
- **BR-ORDER-01:** Only completed Orders may be reviewed.
- **BR-SHIP-02:** Shipper assignment requires Order unassigned AND `Order.Status` = "Đang lấy món".

**CURRENT TECHNICAL CONSTRAINTS**
- Verified EF/EDMX mappings define physical data types and nullability where documented in this dictionary; exact string-length constraints are not asserted unless separately verified.
- `DonHang.MaShipper` is nullable, representing the unassigned state structurally.

## 8. Open Data Questions / Clarifications

The following data-related semantics remain unresolved and are excluded from formal gap assertions:
- **Active Delivery Definition:** Exact state membership defining "active delivery" for BR-SHIP-01 limits.
- **Post-Cancellation Order.Status:** Exact Order.Status after cancellation.
- **Fractional-km Rounding:** Logic for computing distance-based fees.
- **Authoritative Timestamp:** The authoritative time metric used to evaluate BR-FEE-02 service fees.
- **Partner Approval Vocabulary:** Exact approved/pending/rejected vocabulary and workflows (BR-PARTNER-01).
- **Partner Approval Capability Boundary:** Precise "normal operation" capability gating boundary (BR-PARTNER-01).
- **Review Cardinality & Editability:** Number of reviews permitted and modification rules (BR-ORDER-01).
- **Menu-Category Operations:** Exact permitted administrative actions for categories (FR-RES-02).
- **Admin Account Management:** Exact target capabilities (FR-ADM-01).
- **Customer Profile / Account Input Validation:** Exact validation rules for Customer profile/account data remain NOT EVIDENCED / REQUIRES CLARIFICATION.

STATUS: **NOT EVIDENCED / REQUIRES CLARIFICATION**.

## 9. Current Physical Model Observations

- **Assignment Structure:** Shipper assignment is represented by a nullable Foreign Key (`MaShipper`), not as an Order Status, aligning structurally with business modeling needs.
- **Payment Method Storage:** No explicit `Payment Method` field was identified on the `DonHang` physical entity.
- **Extraneous Status Values:** Additional implementation `Order.Status` values were observed in verified S3 sources (e.g., `ShipperController.cs`) outside the approved four-state TARGET lifecycle. These values are implementation-only and are not promoted to TARGET.

CLASSIFICATION: **IMPLEMENTED** (Observations only).

## 10. Requirement-to-Data Traceability

> **Interpretation note:** "Physical Mapping Status" indicates only whether data structures relevant to the requirement/rule have been mapped in the current implementation. It does NOT represent functional requirement alignment. Functional implementation status remains governed by the approved Requirement Gap Analysis.

| Requirement / Rule ID | Business Data Entity | Key Data Element(s) | Data Usage | Physical Mapping Status | Relevant Gap / Clarification | Notes |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| FR-AUTH-01 | Account | Username, Credential Secret, Role | Registration | IMPLEMENTED | GAP-02 | Physical data mapping is IMPLEMENTED. Credential protection lacks approved hashing. |
| FR-AUTH-02 | Account | Username, Credential Secret, Role | Authentication | IMPLEMENTED | GAP-02 | Physical data mapping is IMPLEMENTED. Identity matching functional but plaintext. |
| FR-CUS-04 | Order | Delivery Distance | Calculation | NOT VERIFIED | — | Distance evaluated transiently. |
| FR-CUS-05 | Order | Total Amount | Calculation | IMPLEMENTED | — | Total cost persisted. |
| FR-CUS-06 | Order | Payment Method | Association | NOT VERIFIED | — | Explicit field not mapped. |
| FR-CUS-07 | Order, Shipper | Order Status, Shipper Location, Delivery Routing Information | Tracking | PARTIAL — Order Status and Shipper Location IMPLEMENTED; Delivery Routing Information NOT VERIFIED | — | Physical tracking data mapped. Behavioural requirement enforcement remains NOT VERIFIED. |
| FR-CUS-08 | Restaurant Review, Shipper Review | Rating Score | Creation | IMPLEMENTED | Review Cardinality | Covers DE-REV-003 and DE-REV-006. |
| FR-CUS-09 | Order | Order Identifier, Order Status, Order Detail, Customer Reference | History view | IMPLEMENTED | — | Physical data mapping exists. |
| FR-RES-03 | Food Item | Food Item fields | Management | IMPLEMENTED | — | — |
| FR-RES-04 | Order | Order Identifier, Order Detail, Restaurant Reference | Order list / order-detail presentation | IMPLEMENTED | — | Physical data mapping exists. |
| FR-RES-05 | Order | Order Status | Update state | IMPLEMENTED | — | Physical state mapping exists. Restaurant capability enforcement NOT VERIFIED. |
| FR-RES-06 | Order | Total Amount | Revenue stats | IMPLEMENTED | — | Physical mapping exists. |
| FR-RES-07 | Restaurant Review | Rating Score | Review reading | IMPLEMENTED | — | Physical mapping exists. |
| FR-SHP-01 | Order | Shipper Assignment | Viewing | IMPLEMENTED | — | Checked for null `MaShipper`. |
| FR-SHP-02 | Order | Shipper Assignment | Modification | IMPLEMENTED | GAP-01 | Physical data mapping exists. Fails target status prerequisite constraint. |
| FR-SHP-03 | Order | Order Status | Update state | IMPLEMENTED | — | Shipper lifecycle updates mapping exists. |
| FR-SHP-04 | Shipper | Accumulated Income, Order Identifier | Stats viewing | IMPLEMENTED | — | Persisted income aggregation exists. |
| FR-ADM-02 | Account | Partner Approval Status | Modification | IMPLEMENTED | Approval Vocabulary | Physical mapping exists. Enforcement boundary NOT VERIFIED. |
| FR-ADM-03 | Order | Total Amount, Fees | Statistics | NOT VERIFIED | — | Reporting models not verified. |
| FR-ADM-04 | Order | Total Amount, Fees | Export | NOT VERIFIED | — | Export reporting models not verified. |
| BR-ORDER-01 | Restaurant Review, Shipper Review | Order Reference | Evaluation logic | IMPLEMENTED | Review Cardinality | Physical data mapping exists. Only complete orders valid for review. |
| BR-SHIP-01 | Order | Order Status, Shipper Assignment | Enforcement | IMPLEMENTED | Active Delivery Definition | Physical data mapping exists. Current implementation applies an active-delivery limit using its own status/assignment logic. Exact TARGET definition of "active delivery" remains NOT EVIDENCED / REQUIRES CLARIFICATION. |
| BR-SHIP-02 | Order | Shipper Assignment | Pre-condition | IMPLEMENTED | GAP-01 | Physical data mapping exists. Enforcement gap identified. |
| BR-DEL-01 | Order | Delivery Distance | Enforcement | NOT VERIFIED | — | No persisted Delivery Distance mapping verified; the 30 km runtime enforcement is verified separately as implementation behaviour in S3. |
| BR-FEE-01 | Order | Delivery Fee | Formula | PARTIAL — computation IMPLEMENTED; separate persistence NOT VERIFIED | Fractional-km rounding | Distance-based fee contributes to aggregated `ShipFee`; no separate persisted target fee field verified. |
| BR-FEE-02 | Order | Service Fee | Formula | PARTIAL — computation IMPLEMENTED; separate persistence NOT VERIFIED | Authoritative Timestamp | Time-based fee contributes to aggregated `ShipFee`; no separate persisted target fee field verified. |
| BR-PARTNER-01 | Account | Partner Approval Status | Enforcement | IMPLEMENTED | Capability Boundary | Physical data mapping is IMPLEMENTED. Requirement behaviour enforcement remains NOT VERIFIED per approved Requirement Gap Analysis. |
| NFR-SEC-02 | Account | Credential Secret | Storage | IMPLEMENTED | GAP-02 | Gap exists in implementation strategy. |

## 11. Source Mapping

| Data Area | Target Source | Current Source | Evidence Classification | Notes |
| :--- | :--- | :--- | :--- | :--- |
| Account / Authentication | S1 | S4 (`TaiKhoan.cs`), S3 | Target: BASELINE; Current: IMPLEMENTED | Foundational identity entity. |
| Customer | S1 | S4 (`KhachHang.cs`) | Target: BASELINE; Current: IMPLEMENTED | Foundational actor entity. |
| Restaurant | S1 | S4 (`NhaHang.cs`) | Target: BASELINE; Current: IMPLEMENTED | Foundational actor entity. |
| Shipper | S1 | S4 (`Shipper.cs`) | Target: BASELINE; Current: IMPLEMENTED | Foundational actor entity. |
| Menu / Food | S1 | S4 (`MonAn.cs`, `LoaiMonAn.cs`) | Target: BASELINE; Current: IMPLEMENTED | Foundational product entities. |
| Order / Assignment | S1, S5 | S4 (`DonHang.cs`) | Target: BASELINE; Current: IMPLEMENTED | Central lifecycle entity. |
| Reviews | S1 | S4 (`DanhGiaNhaHang.cs`, `DanhGiaShipper.cs`) | Target: BASELINE; Current: IMPLEMENTED | Quality tracking entities. |
| Checkout Distance / Fees | S1, BR-DEL-01, BR-FEE-01, BR-FEE-02 | S3 (`KhachHangController.cs` — verified checkout/distance/fee logic) | Target: BASELINE; Current: IMPLEMENTED | Runtime computation evidence. |
| Shipper Assignment / Eligibility | S1, BR-SHIP-01, BR-SHIP-02 | S3 (`ShipperController.cs` — `Accept`) + S4 (`DonHang.cs`) | Target: BASELINE; Current: IMPLEMENTED | GAP-01 applies to Ready-for-Pickup enforcement. |
| Shipper Income | S1, FR-SHP-04 | S3 (`ShipperController.cs` — `Income`) + S4 (`Shipper.ThuNhap`) | Target: BASELINE; Current: IMPLEMENTED | Income data / computation evidence. |
| Order Status Implementation | S1, approved State Model | S3 (`ShipperController.cs` — `UpdateStatus` and others) + S4 (`DonHang.TrangThai`) | Target: BASELINE; Current: IMPLEMENTED | Implementation values do not redefine target lifecycle. |

## 12. Analysis Summary

- **Verified Entity Physical Mappings:** 10
- **Material Data Elements Documented:** 45
- **Verified Data-Element Physical Mappings:** 40
- **Data-Element Physical Mappings NOT VERIFIED:** 5
- **Relationships Documented:** 9
- **Computed/Derived Data Items Documented:** 6
- **Open Data Clarifications:** 10
- **GAP-01 Data Linkage:** Identified on `DE-ORD-003` (Shipper Assignment)
- **GAP-02 Data Linkage:** Identified on `DE-ACC-002` (Credential Secret)

This artefact establishes the BA-relevant controlled data subset for the target and current systems.
