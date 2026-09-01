# Software Requirements Specification — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Software Requirements Specification (SRS)

Source Baseline:
S1 Controlled Portfolio BRD;
Approved Functional Requirements Specification;
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
Functional_Requirements_Specification.md;
Business_Rules_Catalogue.md;
Detailed_Use_Cases.md;
User_Stories_Acceptance_Criteria.md;
Order_State_Diagram.md;
Data_Dictionary.md;
Logical_ERD.md;
Requirement_Gap_Analysis.md

## 1. Document Purpose
This Software Requirements Specification (SRS) describes the system-level software requirements, constraints, interfaces, quality requirements, data expectations, and cross-cutting behaviours that the Online Food Delivery System must satisfy. It serves as the system-level specification derived from the business context of the BRD and references the detailed functional behaviours specified in the Functional Requirements Specification (FRS).

## 2. Scope
This specification covers the software system requirements for the Online Food Delivery System, a role-based responsive web solution supporting Customers, Restaurants, Shippers, and Administrators. Guest interaction is supported for registration/login where evidenced; public browsing behaviour remains subject to Clarification #9. The document details functional summaries, business rules, system states, external interfaces, non-functional constraints, and current implementation gaps.

## 3. Source & Authority Basis
The authoritative baseline for TARGET requirements is the latest owner-approved Controlled Portfolio BRD. The approved Functional Requirements Specification (FRS) provides the detailed operational behaviour. Approved Business Rules, State Model, Use Cases, User Stories, and Acceptance Criteria provide controlled supporting behavioural detail. The approved Gap Analysis provides controlled open clarifications and verified CURRENT implementation gaps. S3 source code and S4 database observations serve as CURRENT persistence and implementation evidence only and do not redefine TARGET requirements.

## 4. Product Perspective
The system is a role-based responsive web solution supporting the Online Food Delivery business flow. It provides role-specific web interfaces across the following high-level functional areas:
- Authentication
- Customer Web
- Restaurant Portal
- Shipper Portal
- Administrator Portal

Guests interact with the system as unauthenticated actors where supported by approved evidence. Native mobile application functionality and real production payment gateway integration are outside the approved TARGET scope.

## 5. System Context
The system interacts with human actors and approved external interfaces:
- **Human Actors:** Guest, Customer, Restaurant, Shipper, Administrator.
- **External Interaction:** Map API interaction for delivery address validation and delivery distance calculation.
- **Payment Scope:** Supports Cash on Delivery (COD) and QR Payment Simulation.

## 6. User Classes and Role Boundaries
- **Guest:** Unauthenticated user. Can register for an account. Browsing authentication remains subject to Clarification #9.
- **Customer:** Authenticated buyer responsible for managing profiles, browsing food items, adding to cart, placing orders, tracking, and submitting reviews.
- **Restaurant:** Authenticated supplier responsible for managing store information, menus, processing orders belonging to the Restaurant, and viewing reports. Partner non-core capability boundary remains subject to Clarification #12.
- **Shipper:** Authenticated deliverer responsible for accepting unassigned delivery orders, updating order status during delivery, and viewing income statistics. Partner non-core capability boundary remains subject to Clarification #12.
- **Administrator:** Authenticated manager providing platform oversight, including account management, partner approval, and global statistics reporting. Administrator account-management actions remain subject to Clarification #15.

## 7. Functional Requirements Overview
The system must satisfy the 27 approved Functional Requirements, grouped into their respective functional areas:

| FR ID | Functional Area | Primary Actor | System Capability | Detailed Specification |
| :--- | :--- | :--- | :--- | :--- |
| FR-AUTH-01 | Authentication | Guest | Register an account under an available role | [FRS Section 5](Functional_Requirements_Specification.md) |
| FR-AUTH-02 | Authentication | Cross-role | Authenticate using credentials and redirect | [FRS Section 5](Functional_Requirements_Specification.md) |
| FR-CUS-01 | Customer | Customer | View/update profile and change password | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-CUS-02 | Customer | Customer | Browse active restaurants and associated menus | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-CUS-03 | Customer | Customer | Add, remove, update items in shopping cart | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-CUS-04 | Customer | System | Validate delivery address and calculate distance | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-CUS-05 | Customer | System | Calculate delivery fee and total amount | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-CUS-06 | Customer | Customer | Submit order using available payment method | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-CUS-07 | Customer | Customer | Track active order status and routing info | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-CUS-08 | Customer | Customer | Submit ratings/reviews for Restaurant and Shipper | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-CUS-09 | Customer | Customer | View current, completed orders and details | [FRS Section 6](Functional_Requirements_Specification.md) |
| FR-RES-01 | Restaurant | Restaurant | Update store information | [FRS Section 7](Functional_Requirements_Specification.md) |
| FR-RES-02 | Restaurant | Restaurant | Manage menu categories | [FRS Section 7](Functional_Requirements_Specification.md) |
| FR-RES-03 | Restaurant | Restaurant | Create, update, remove food items | [FRS Section 7](Functional_Requirements_Specification.md) |
| FR-RES-04 | Restaurant | Restaurant | View order lists and order details | [FRS Section 7](Functional_Requirements_Specification.md) |
| FR-RES-05 | Restaurant | Restaurant | Mark order as ready for pickup ("Làm xong") | [FRS Section 7](Functional_Requirements_Specification.md) |
| FR-RES-06 | Restaurant | Restaurant | View revenue statistics and order history | [FRS Section 7](Functional_Requirements_Specification.md) |
| FR-RES-07 | Restaurant | Restaurant | View customer ratings and reviews | [FRS Section 7](Functional_Requirements_Specification.md) |
| FR-SHP-01 | Shipper | Shipper | View list of available/unassigned delivery orders | [FRS Section 8](Functional_Requirements_Specification.md) |
| FR-SHP-02 | Shipper | Shipper | Accept a delivery assignment | [FRS Section 8](Functional_Requirements_Specification.md) |
| FR-SHP-03 | Shipper | Shipper | Update order status ("Đang giao", "Hoàn thành") | [FRS Section 8](Functional_Requirements_Specification.md) |
| FR-SHP-04 | Shipper | Shipper | View completed deliveries and income statistics | [FRS Section 8](Functional_Requirements_Specification.md) |
| FR-SHP-05 | Shipper | Shipper | View/update personal profile and account | [FRS Section 8](Functional_Requirements_Specification.md) |
| FR-ADM-01 | Administrator | Administrator | Manage user accounts | [FRS Section 9](Functional_Requirements_Specification.md) |
| FR-ADM-02 | Administrator | Administrator | Approve new Restaurant/Shipper registrations | [FRS Section 9](Functional_Requirements_Specification.md) |
| FR-ADM-03 | Administrator | Administrator | View system-wide operational/revenue statistics | [FRS Section 9](Functional_Requirements_Specification.md) |
| FR-ADM-04 | Administrator | Administrator | Export revenue statistics to an Excel file | [FRS Section 9](Functional_Requirements_Specification.md) |

## 8. Cross-Role Order Lifecycle Requirements
The system adheres to the approved TARGET Order State Model. The approved `Order.Status` values are exclusively:
- "Chờ xác nhận"
- "Đang lấy món"
- "Đang giao"
- "Hoàn thành"

**Approved State Transitions:**
- **ST-01:** Order creation transitions to "Chờ xác nhận".
- **ST-02:** Restaurant marks "Làm xong", transitioning to "Đang lấy món".
- **ST-03:** Shipper starts delivery, transitioning to "Đang giao".
- **ST-04:** Shipper completes delivery, transitioning to "Hoàn thành".

**Shipper Assignment & Cancellation:**
- Shipper acceptance changes the assignment but does not change `Order.Status`. Unassigned is an assignment condition, not a status value.
- Post-cancellation `Order.Status` remains unresolved (Clarification #3). 

## 9. Business Rule Constraints
The system logic is constrained by the following controlled Business Rules:

| BR ID | System Constraint | Related FRs | Open Clarification |
| :--- | :--- | :--- | :--- |
| BR-ORDER-01 | Only completed Orders ("Hoàn thành") may be reviewed. | FR-CUS-08 | Clarification #8 |
| BR-SHIP-01 | A Shipper may have only one active delivery. Exact active delivery definition remains TBD. | FR-SHP-02 | Clarification #4 |
| BR-SHIP-02 | Shipper acceptance requires Order is unassigned AND Order.Status = "Đang lấy món", plus approved eligibility. | FR-SHP-02 | None (GAP-01) |
| BR-DEL-01 | Order must be rejected/prevented if delivery distance > 30 km. | FR-CUS-04 | None |
| BR-FEE-01 | Delivery fee is 15,000 VND for first 3 km + 3,000 VND per additional km. | FR-CUS-05 | Clarification #5 |
| BR-FEE-02 | Service fee is 16,000 VND before 19:00, and 20,000 VND from 19:00. | FR-CUS-05 | Clarification #6 |
| BR-PARTNER-01 | Administrator approval is required before mapped normal operational capabilities for Restaurant/Shipper. | FR-AUTH-01, FR-RES-04, FR-RES-05, FR-SHP-01, FR-SHP-02, FR-SHP-03, FR-ADM-02 | Clarification #7, #12 |

## 10. Non-Functional Requirements
The system must satisfy the following approved non-functional requirements (NFRs):

| NFR ID | Requirement Area | System-Level Effect | Gap / Clarification |
| :--- | :--- | :--- | :--- |
| NFR-PER-01 | Performance | Response-time requirement applies; quantitative threshold remains TBD. | Clarification #1 |
| NFR-SEC-01 | Security | Role-based access control | None |
| NFR-SEC-02 | Security | Secure password hashing | GAP-02 |
| NFR-COMP-01 | Compatibility | Cross-browser support | None |

## 11. External Interface Requirements

### 11.1 User Interface
The system provides responsive web interfaces supporting the approved interactions of each user class. A native mobile application is strictly OUT OF SCOPE.

### 11.2 Map / Location Interface
The system requires Map API interaction to support delivery address validation and delivery distance calculation. Specific provider and contract remain Not Evidenced.

### 11.3 Payment Interaction
The approved TARGET payment scope is limited to COD and QR Payment Simulation. Real production payment-gateway behaviour is outside the approved scope; additional settlement, refund, or bank-API behaviours are Not Evidenced.

### 11.4 Data/Persistence Interface Context
Data persistence and database interaction map to the logical entities specified in the Data Requirements section. Specific implementations are environmental context, not TARGET requirements.

## 12. Data Requirements
The system persists data mapping to 10 approved logical entities:
1. Account
2. Customer
3. Restaurant
4. Shipper
5. Menu Category
6. Food Item
7. Order
8. Order Detail
9. Restaurant Review
10. Shipper Review

**Key Mappings:**
- `Order.Status` maps to `DonHang.TrangThai`.
- Shipper Assignment maps to `DonHang.MaShipper`.
- Order Total maps to `DonHang.TongTien`.
- Aggregated charge maps to `DonHang.ShipFee`.
- Delivery Distance is a computed concept; no dedicated persisted field has been verified.
- Payment Method is a logical input; no dedicated persisted field has been verified.
- Delivery Fee and Service Fee are separate TARGET concepts; separate physical persistence is not verified.

## 13. Security & Access Requirements
- Role-based access control (RBAC) dictates module availability per NFR-SEC-01.
- Administrator approval dictates partner operational access per BR-PARTNER-01.
- Secure password hashing is the TARGET standard per NFR-SEC-02. Note GAP-02 identifies a deviation in the CURRENT implementation.

## 14. System Constraints and Implementation Context
- **TARGET Constraints:** Responsive web scope, COD / QR Payment Simulation, approved order lifecycle logic, role-based access, and logical data expectations.
- **CURRENT Implementation Context:** The prototype environment utilizes ASP.NET MVC5, .NET Framework 4.7.2, SQL Server, Entity Framework 6 (Database First / EDMX), Razor, Bootstrap, and jQuery. These are CURRENT implementation context and do not redefine TARGET system requirements.

## 15. Assumptions and Dependencies
- Expected functionality assumes adherence to the approved BRD and underlying business rules.
- Resolution of the open TARGET clarifications is required to fully specify the affected behaviours.
- No assumptions are made regarding production rollout, SLA achievement, live customers, or real business revenue.

## 16. Out-of-Scope Boundaries
- Native mobile application.
- Real production payment gateway integration.

## 17. Open Requirements and Clarifications
The following 15 open TARGET clarifications remain unresolved:
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

## 18. Known CURRENT Implementation Gaps
Verified implementation gaps:
- **GAP-01:** Shipper acceptance TARGET guard vs CURRENT implementation.
- **GAP-02:** TARGET password hashing vs CURRENT plaintext implementation.

## 19. System-Level Traceability Summary

| Requirement Area | Controlled IDs | Detailed Artefact | Downstream Evidence / Validation |
| :--- | :--- | :--- | :--- |
| Functional Requirements | 27 FRs | FRS | RTM / UAT |
| Business Rules | 7 BRs | Business Rules Catalogue | RTM / UAT |
| Lifecycle | ST-01..ST-04 | Order State Diagram | RTM / UAT |
| Data | 10 Entities | Logical ERD / Data Dictionary | Persistence evidence |
| Non-Functional | NFR-PER-01, NFR-SEC-01, NFR-SEC-02, NFR-COMP-01 | BRD / SRS | Downstream validation where evidenced |

## 20. Validation Summary
- The SRS references all 27 controlled Functional Requirements.
- It covers the 4 controlled NFRs.
- It preserves all 7 Business Rules.
- It aligns with the approved Order State Model.
- It aligns with approved logical data artefacts.
- It preserves 15 open TARGET clarifications.
- It references GAP-01 and GAP-02 as CURRENT implementation gaps.
- No new requirement was introduced.
