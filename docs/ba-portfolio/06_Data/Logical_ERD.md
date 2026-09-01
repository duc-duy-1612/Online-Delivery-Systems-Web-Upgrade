# Logical ERD Analysis — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Logical Data Model / ERD Analysis

Source Baseline:
S1 Controlled Portfolio BRD;
S2 Original Major Project Report;
S4 Data Model / Persistence Evidence;
Approved Data Dictionary

Depends On:
00_README_BA_Evidence_Pack.md;
Data_Dictionary.md;
Business_Rules_Catalogue.md;
Detailed_Use_Cases.md;
User_Stories_Acceptance_Criteria.md;
Order_State_Diagram.md

## 1. Purpose
This Logical ERD Analysis defines the verified logical data model for the Online Food Delivery System. It bridges the gap between TARGET business requirements and CURRENT physical implementation by documenting verified entities, relationships, and data mappings. It serves as the analytical foundation for the visual ERD, ensuring the diagram represents structurally sound, evidenced reality rather than speculative database design.

## 2. Modelling Scope
The portfolio-level logical data model focuses on the core business domains: Authentication (Account), Actors (Customer, Restaurant, Shipper), Catalogue Management (Food Item, Menu Category), Fulfillment (Order, Order Detail), and Feedback (Reviews). 

Only entities strictly supported by S4 evidence and business-relevant to the S1 TARGET baseline are modelled. Extraneous implementation structures (such as the physical `LichSuGioHang` cart history or `DanhGia` tables, which are physically present but excluded from the approved portfolio logical model) are omitted to maintain BA readability.

## 3. Evidence Basis
- **Primary Persistence Authority:** S4 (SQL Server / EF6 EDMX) is the definitive source for physical tables, primary keys, foreign keys, and column mappings.
- **Business Semantics Authority:** S1 (Controlled Portfolio BRD) dictates target business meaning.
- **Pre-validated Mapping:** The approved Data Dictionary (S5) is used to map TARGET business concepts to CURRENT physical constraints.

## 4. Entity Inventory

| Logical Entity | Physical Entity/Table | Business Purpose | Persistence Evidence | Classification |
| :--- | :--- | :--- | :--- | :--- |
| Account | `TaiKhoan` | Authentication & Role mapping | S4 | PERSISTED |
| Customer | `KhachHang` | Profile & Location data | S4 | PERSISTED |
| Restaurant | `NhaHang` | Partner profile & Origin coordinates | S4 | PERSISTED |
| Shipper | `Shipper` | Delivery profile & Tracking coordinates | S4 | PERSISTED |
| Menu Category | `LoaiMonAn` | Menu classification grouping | S4 | PERSISTED |
| Food Item | `MonAn` | Individual menu items and prices | S4 | PERSISTED |
| Order | `DonHang` | Central transactional delivery request | S4 | PERSISTED |
| Order Detail | `ChiTietDonHang` | Line-item cart contents | S4 | PERSISTED |
| Restaurant Review | `DanhGiaNhaHang` | Quality rating by Customer | S4 | PERSISTED |
| Shipper Review | `DanhGiaShipper` | Service rating by Customer | S4 | PERSISTED |

## 5. Entity Definitions

### Account
- **Business Definition:** System authentication credentials and role/access mapping.
- **Key Identifier:** Account ID (`MaTK`)
- **Important Business Attributes:** Username (`TenDangNhap`), Role (`VaiTro`), Account Status (`TrangThai`).
- **Physical Mapping:** `TaiKhoan`
- **Evidence:** S1, S4, Data Dictionary (DE-001).

### Customer
- **Business Definition:** Registered user profile for placing delivery orders.
- **Key Identifier:** Customer ID (`MaKH`)
- **Important Business Attributes:** Name, Delivery Coordinates.
- **Physical Mapping:** `KhachHang`
- **Evidence:** S1, S4, Data Dictionary (DE-002).

### Restaurant
- **Business Definition:** Partner offering food items and fulfilling preparation.
- **Key Identifier:** Restaurant ID (`MaNH`)
- **Important Business Attributes:** Operation Status, Origin Coordinates.
- **Physical Mapping:** `NhaHang`
- **Evidence:** S1, S4, Data Dictionary (DE-003).

### Shipper
- **Business Definition:** Delivery partner responsible for order transport.
- **Key Identifier:** Shipper ID (`MaShipper`)
- **Important Business Attributes:** Vehicle Details, Shipper Location, Accumulated Income.
- **Physical Mapping:** `Shipper`
- **Evidence:** S1, S4, Data Dictionary (DE-004).

### Menu Category
- **Business Definition:** Logical category used to classify Food Items.
- **Key Identifier:** Category ID (`MaLoai`)
- **Important Business Attributes:** Category Name.
- **Physical Mapping:** `LoaiMonAn`
- **Evidence:** S1, S4, Data Dictionary (DE-006).

### Food Item
- **Business Definition:** Individual purchasable menu item.
- **Key Identifier:** Food ID (`MaMon`)
- **Important Business Attributes:** Base Price.
- **Physical Mapping:** `MonAn`
- **Evidence:** S1, S4, Data Dictionary (DE-005).

### Order
- **Business Definition:** A Customer's food purchase request and associated delivery lifecycle.
- **Key Identifier:** Order ID (`MaDon`)
- **Important Business Attributes:** Order Status, Total Amount, Shipper Assignment, Shipping Fee.
- **Physical Mapping:** `DonHang`
- **Evidence:** S1, S4, Data Dictionary (DE-007).

### Order Detail
- **Business Definition:** Specific line-item quantities tied to a parent Order.
- **Key Identifier:** Detail ID (`MaChiTiet`)
- **Important Business Attributes:** Quantity, Line Item Price.
- **Physical Mapping:** `ChiTietDonHang`
- **Evidence:** S1, S4, Data Dictionary (DE-008).

### Restaurant Review
- **Business Definition:** Customer evaluation of a Restaurant associated with a completed Order.
- **Key Identifier:** Review ID (`MaDGNH`)
- **Important Business Attributes:** Rating Score.
- **Physical Mapping:** `DanhGiaNhaHang`
- **Evidence:** S1, S4, Data Dictionary (DE-009).

### Shipper Review
- **Business Definition:** Evaluation of delivery service tied to a completed Order.
- **Key Identifier:** Review ID (`MaDG`)
- **Important Business Attributes:** Rating Score.
- **Physical Mapping:** `DanhGiaShipper`
- **Evidence:** S1, S4, Data Dictionary (DE-010).

## 6. Relationship Inventory

| Relationship ID | From | Physical Cardinality | To | Business Meaning | Physical Evidence | Confidence |
| :--- | :--- | :--- | :--- | :--- | :--- | :--- |
| REL-01 | Customer | 1:N | Order | Places | FK `DonHang.MaKH` | VERIFIED |
| REL-02 | Restaurant | 1:N | Order | Receives | FK `DonHang.MaNH` | VERIFIED |
| REL-03 | Shipper | 1 : 0..N | Order | May be assigned to deliver | FK `DonHang.MaShipper` (Nullable) | VERIFIED |
| REL-04 | Order | 1:N | Order Detail | Contains | FK `ChiTietDonHang.MaDon` | VERIFIED |
| REL-05 | Restaurant | 1:N | Food Item | Offers | FK `MonAn.MaNH` | VERIFIED |
| REL-06 | Menu Category | 1:N | Food Item | Classifies | FK `MonAn.MaLoai` | VERIFIED |
| REL-07 | Food Item | 1:N | Order Detail | Referenced in | FK `ChiTietDonHang.MaMon` | VERIFIED |
| REL-08 | Order | 1:N (EDMX) | Restaurant Review | Has / is associated with | FK `DanhGiaNhaHang.MaDon` | VERIFIED |
| REL-09 | Customer | 1:N (EDMX) | Restaurant Review | Written by | FK `DanhGiaNhaHang.MaKH` | VERIFIED |
| REL-10 | Restaurant | 1:N (EDMX) | Restaurant Review | Receives / is subject of | FK `DanhGiaNhaHang.MaNH` | VERIFIED |
| REL-11 | Order | 1:N (EDMX) | Shipper Review | Has / is associated with | FK `DanhGiaShipper.MaDon` | VERIFIED |
| REL-12 | Customer | 1:N (EDMX) | Shipper Review | Written by | FK `DanhGiaShipper.MaKH` | VERIFIED |
| REL-13 | Shipper | 1:N (EDMX) | Shipper Review | Receives / is subject of | FK `DanhGiaShipper.MaShipper` | VERIFIED |
| REL-14 | Account | 1:N | Customer | Authenticates | FK `KhachHang.MaTK` | VERIFIED |
| REL-15 | Account | 1:N | Restaurant | Authenticates | FK `NhaHang.MaTK` | VERIFIED |
| REL-16 | Account | 1:N | Shipper | Authenticates | FK `Shipper.MaTK` | VERIFIED |

*Note: Each individual Order has 0..1 assigned Shipper at the physical persistence level because `DonHang.MaShipper` is nullable and stores a single Shipper reference.*

*Note: Physical Cardinality reflects the structural constraints verified in EDMX. Target business constraints (e.g. whether a user is allowed to write multiple reviews per order) remain explicitly unclarified as a TARGET behavior.*

## 7. Key Business Data Mappings

| Business Concept | Logical Entity | Physical Mapping | Persistence Status | Evidence |
| :--- | :--- | :--- | :--- | :--- |
| Order.Status | Order | `DonHang.TrangThai` | VERIFIED | S4 |
| Shipper Assignment | Order | `DonHang.MaShipper` (FK) | VERIFIED | S4 |
| Order Total | Order | `DonHang.TongTien` | VERIFIED | S4 |
| Delivery Fee | N/A | Aggregated in `DonHang.ShipFee` | NOT VERIFIED (Separate) | S4 + Data Dictionary |
| Service Fee | N/A | Aggregated in `DonHang.ShipFee` | NOT VERIFIED (Separate) | S4 + Data Dictionary |
| Delivery Distance | N/A | No dedicated persisted field verified | NOT VERIFIED | S4 |
| Payment Method | N/A | No dedicated persisted field verified | NOT VERIFIED | S4 |
| Review | Rest. Review, Ship. Review | `DanhGiaNhaHang`, `DanhGiaShipper` | VERIFIED | S4 |
| Restaurant ownership | Food Item | `MonAn.MaNH` (FK) | VERIFIED | S4 |

## 8. Derived / Computed Concepts

| Concept | Calculation / Source Logic | Persistence Status | Related Requirement / Rule | Evidence |
| :--- | :--- | :--- | :--- | :--- |
| Delivery Distance | Computed via Map APIs from Origin and Delivery Coordinates. | NOT VERIFIED (Transient) | FR-CUS-04, BR-DEL-01 | Data Dictionary, S4 |
| Delivery Fee | Logical fee based on distance. | NOT VERIFIED (Aggregated) | BR-FEE-01 | Data Dictionary, S4 |
| Service Fee | Logical fee based on time. | NOT VERIFIED (Aggregated) | BR-FEE-02 | Data Dictionary, S4 |
| Aggregated Ship Charge | Aggregated `ShipFee` combining delivery and service components. | PERSISTENCE VERIFIED (`DonHang.ShipFee`) | BR-FEE-01, BR-FEE-02 | S4 (Persistence) + Data Dictionary (Mapping logic) |
| Total Order Amount | Derived during checkout according to controlled order-pricing logic. | PERSISTENCE VERIFIED (`DonHang.TongTien`) | FR-CUS-05 | S1 + S4 |
| Shipper Income / Income Statistics | Income-related concept used for Shipper statistics; exact calculation/update mechanism is not established by S4 alone. | PERSISTENCE VERIFIED (`Shipper.ThuNhap`) | FR-SHP-04 | S1 + S4 |

## 9. TARGET vs CURRENT Persistence Notes

- **Shipper Assignment vs Status:** The TARGET "Unassigned Order" condition is represented in CURRENT persistence through the nullable foreign key `DonHang.MaShipper`; a null value represents the absence of an assigned Shipper. It is not persisted as a fifth `Order.Status` value. The model strictly limits TARGET `Order.Status` to the four controlled baseline states ("Chờ xác nhận", "Đang lấy món", "Đang giao", "Hoàn thành").
- **Delivery and Service Fees:** The TARGET logic defines distinct Delivery and Service fees. S4 verifies the physical column `DonHang.ShipFee` exists, and the Approved Data Dictionary confirms the logical mapping of aggregated fees into this field. No fictional fee columns will be modelled.
- **Delivery Distance:** Used functionally in TARGET constraints (BR-DEL-01) but possesses no verified physical persistence mapping. It remains a computed/transient concept.
- **Payment Method:** The TARGET supports COD and QR Payment Simulation, but S4 lacks an explicit `PaymentMethod` column on `DonHang`. Therefore, payment methodology persistence is explicitly mapped as NOT VERIFIED. The implementation mechanism must not be inferred from column absence alone.

## 10. ERD Layout Specification

The future visual Mermaid diagram (to be generated after review) should adhere to this topological guidance for optimal portfolio readability:

- **Central Hub:** `Order` (`DonHang`) should be centrally positioned, directly attached to `Order Detail` (`ChiTietDonHang`).
- **Core Actors:** `Customer` (`KhachHang`), `Restaurant` (`NhaHang`), and `Shipper` (`Shipper`) should surround the Order hub to clearly display their respective FK relationships (`REL-01`, `REL-02`, `REL-03`).
- **Identity Outer Layer:** `Account` (`TaiKhoan`) should sit on the periphery, linking to the actor entities to show structural authentication ownership without cluttering transactional paths.
- **Catalogue Nodes:** `Food Item` should connect directly to `Restaurant` and `Menu Category`. `Menu Category` must not be shown as directly owned by `Restaurant` unless a verified relationship exists.
- **Review Nodes:** `Restaurant Review` and `Shipper Review` should connect to the related Order, the Customer author, and the reviewed Restaurant or Shipper according to the verified relationships in Section 6.
- **Attribute Detailing:** Display primary keys and vital business foreign keys (e.g., `MaShipper`). Exclude non-essential technical metadata. Exclude fictional computed columns. Include logical and physical entity names together.

## 11. Assumptions, Limitations & Open Items
- **Review Cardinality Constraint:** S4 EDMX structural multiplicities may permit 1:N relations physically. However, the exact TARGET business constraint (e.g. whether a single order can only have one review) remains TBD.
- **Payment Field Absence:** TARGET supports COD and QR Payment Simulation; however, no dedicated physical persistence mapping has been verified in S4. The implementation mechanism must not be inferred from column absence alone.
- **LichSuGioHang & DanhGia:** These tables are physically present in S4 but are excluded from the approved portfolio logical model for BA readability and target relevance.

## 12. Downstream Diagram Guidance
- Do NOT generate physical implementation tables that lack target relevance (e.g., migration histories).
- Use proper crows-foot notation to indicate the 1:N multiplicities documented in Section 6.
- Visually annotate `DonHang.MaShipper` as a structurally defining FK for Shipper assignment.

## 13. Validation Summary

- [x] Every entity has source evidence
- [x] Every definite relationship has evidence
- [x] Every cardinality has evidence or is explicitly TBD
- [x] No fictional table was added
- [x] No fictional column was added
- [x] No fictional FK was added
- [x] No payment table was invented
- [x] No assignment table was invented unless physically verified
- [x] Delivery Distance persistence was not invented
- [x] Delivery Fee / Service Fee remain logically distinct
- [x] Aggregated persistence is disclosed if applicable
- [x] Payment Method persistence is marked NOT VERIFIED if not evidenced
- [x] Unassigned is not represented as Order.Status
- [x] Only four controlled target Order.Status values are used
- [x] No post-cancellation state was invented
- [x] No new GAP was created
- [x] No approved artefact was modified
- [x] Logical model remains BA-readable

## 14. Source Traceability

| Model Element | Evidence Source | Evidence Classification |
| :--- | :--- | :--- |
| Logical Business Entities (10 instances) | S1, Approved Data Dictionary | Target: BASELINE / DERIVED |
| Entity Physical Mappings (10 instances) | S4 (EDMX) | Current: PERSISTENCE VERIFIED |
| Logical Target Relationships | S1, Approved Data Dictionary | Target: BASELINE / DERIVED |
| Physical FK Mappings | S4 (EDMX) | Current: PERSISTENCE VERIFIED |
| Shipper Assignment Nullability | S4 (`DonHang.MaShipper`) | Current: PERSISTENCE VERIFIED |
| Aggregated ShipFee | S4 (`DonHang.ShipFee`), Approved Data Dictionary | Current: PERSISTENCE VERIFIED |
| Transient Delivery Distance | S1, Approved Data Dictionary | Current: NOT VERIFIED (Persistence) |
| Target Review Cardinality | Approved Data Dictionary (TBD clarification) | Target: NOT EVIDENCED / REQUIRES CLARIFICATION |
