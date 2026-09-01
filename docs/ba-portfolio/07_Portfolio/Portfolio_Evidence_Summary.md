# Portfolio Evidence Summary — Online Food Delivery System

Status: APPROVED
Version: 1.0
Project: Online Food Delivery System
Artefact Type: Portfolio Evidence Summary
Source Baseline: S1 — Validated Portfolio BRD + APPROVED S5 artefacts
Depends On:
- 00_README_BA_Evidence_Pack.md
- AS_IS_Process.md
- TO_BE_Cross_Role_Process.md
- Business_Rules_Catalogue.md
- Order_State_Diagram.md
- Detailed_Use_Cases.md
- User_Stories_Acceptance_Criteria.md
- Functional_Requirements_Specification.md
- Requirement_Gap_Analysis.md
- Data_Dictionary.md
- Requirements_Traceability_Matrix.csv — APPROVED v1.1
- UAT_Test_Cases.csv — APPROVED v1.0
Last Reviewed: —

## 1. Executive Portfolio Snapshot

A structured BA case study of a multi-role Online Food Delivery System involving Customer, Restaurant, Shipper, and Administrator workflows. The portfolio places emphasis on process analysis, requirements modelling, business rules, order lifecycle control, data analysis, traceability, CURRENT-vs-TARGET validation, and rigorous UAT design.

This evidence pack demonstrates professional Business Analysis discipline by reconstructing a validated target requirement baseline and separating intended business logic from actual implementation behaviour. It acts as a defensible portfolio piece providing evidence of end-to-end analytical capability, traceability management, and business UAT design.

## 2. Project Context & Analysis Objective

The system context centers on a multi-role food delivery workflow, covering system-mediated cross-role handoffs. The flow begins with the Customer checkout, transitions to Restaurant preparation, triggers Shipper assignment and delivery execution, supports active tracking, and concludes with post-completion reviews. Administrator supporting capabilities govern the overarching partner operations and statistics.

The analysis objective for this portfolio was to convert the project into a controlled, traceable BA evidence pack that rigorously separates intended TARGET requirements from current physical implementation behaviour (CURRENT), establishing a professional standard of evidence for business rules, lifecycle state, and validation boundaries.

## 3. Scope

### In Scope
The approved scope of the Responsive Web Application covers:
- Account registration, authentication, and role-based access
- Customer profile, restaurant/menu browsing, and shopping cart
- Checkout processes including address/distance validation and delivery/service fee calculation
- Order lifecycle control through Restaurant processing, Shipper assignment, and delivery execution
- Payment options: COD and QR Payment Simulation
- Customer tracking and post-completion reviews
- Administrator capabilities including user-account management, partner approval, system statistics, and revenue-statistics export, with exact user-account management actions retained as TBD where unresolved.

### Out of Scope / Not Claimed
This analysis explicitly excludes:
- Native mobile applications
- Real production payment gateway integrations (QR Payment is a simulation)
- Production-scale performance validation and production adoption metrics
- Unresolved functionality not formally established in the approved TARGET baseline

## 4. Actors & Cross-Role Workflow

The controlled actors within the system are **Customer**, **Restaurant**, **Shipper**, **Administrator**, and the **System** itself. 

The core TO-BE value flow progresses sequentially across these roles:
Customer browses / selects items → checkout → address/distance validation → delivery/service fee calculation → COD or QR Payment Simulation → order creation → "Chờ xác nhận" → Restaurant preparation → "Làm xong" → "Đang lấy món" → eligible unassigned Shipper → Shipper accepts → "Đang giao" → Customer tracking → "Hoàn thành" → Customer review.

## 5. BA Artefact Map

| Analysis Area | Approved Artefact | What It Demonstrates |
| :--- | :--- | :--- |
| **AS-IS Process** | AS_IS_Process.md | Ability to frame fragmented process issues and establish an analytical baseline |
| **TO-BE Process** | TO_BE_Cross_Role_Process.md | Ability to design system-mediated, multi-role process handoffs |
| **Business Rules** | Business_Rules_Catalogue.md | Ability to isolate policy and rule constraints from implementation mechanics |
| **Order Lifecycle** | Order_State_Diagram.md | Ability to control lifecycle states and transitions predictably |
| **Detailed Requirements** | Detailed_Use_Cases.md | Ability to structure functional boundaries around specific actors and goals |
| **Agile Decomposition** | User_Stories_Acceptance_Criteria.md | Ability to decompose behaviour into testable criteria |
| **Validation Analysis** | Requirement_Gap_Analysis.md | Ability to identify gaps between target design and current code behaviour |
| **Data Analysis** | Data_Dictionary.md | Ability to distinguish logical business concepts from physical persistence |
| **Traceability** | Requirements_Traceability_Matrix.csv | End-to-end requirement traceability management |
| **Testing Design** | UAT_Test_Cases.csv | Ability to derive executable acceptance validation from requirements and AC |

## 6. Process Analysis Highlights

The AS-IS model was used as an analytical case-study baseline to frame process fragmentation (e.g., manual handoffs and untracked statuses) and establish a comparison point. 

The TO-BE process structures multi-role coordination through a system-mediated workflow. Key highlights include the traceable lifecycle progression from order preparation directly to delivery assignment, defining exactly when business rules constrain the workflow (e.g., distance checks during checkout, and approval gates before partners can access normal operations).

## 7. Key Business Rules

The system is governed by seven controlled target rules:

- **BR-ORDER-01 (Completed Order Review Eligibility)**: Constrains review submission exclusively to orders in the "Hoàn thành" state. (Review cardinality and editability remain unresolved).
- **BR-SHIP-01 (Single Active Delivery Constraint)**: Rejects delivery acceptance if the Shipper already has a conflicting active delivery. (Exact definition of "active delivery" remains an open target clarification).
- **BR-SHIP-02 (Delivery Acceptance Eligibility)**: Restricts Shipper acceptance to unassigned orders explicitly in the "Đang lấy món" state.
- **BR-DEL-01 (Maximum Delivery Distance)**: Rejects checkout if the calculated route distance exceeds 30 km. 
- **BR-FEE-01 (Distance-Based Delivery Fee)**: Applies tiered delivery pricing based on distance bounds. (Fractional-km rounding remains unresolved).
- **BR-FEE-02 (Time-Based Service Fee)**: Applies the applicable service fee before 19:00 and from 19:00 onward. (The authoritative timestamp for this check remains an open target clarification).
- **BR-PARTNER-01 (Partner Approval Requirement)**: Prevents Restaurants and Shippers from accessing their mapped normal operational capabilities until explicitly approved by an Administrator.

## 8. Order Lifecycle & State Control

The order lifecycle is strictly controlled through four approved target status values and transitions:
- **ST-01**: Initial → "Chờ xác nhận"
- **ST-02**: "Chờ xác nhận" → "Đang lấy món"
- **ST-03**: "Đang lấy món" → "Đang giao"
- **ST-04**: "Đang giao" → "Hoàn thành"

"Hoàn thành" serves as the confirmed successful terminal state. The state "Unassigned" is a non-state assignment condition (not an Order.Status). Assignment cancellation exists as an approved process exception, though the exact post-cancellation Order.Status remains unresolved.

## 9. Requirements Decomposition

The portfolio demonstrates a controlled decomposition approach mapping Functional Requirements → Use Cases → User Stories → Acceptance Criteria → UAT. 

The analysis produced 27 Functional Requirements, 4 Non-functional Requirements, and 7 Business Rules, organized into 38 controlled RTM rows. Not every requirement possesses every artefact relationship; traceability is semantic. Notably, assignment cancellation (AC-US-SHP-03-03) is treated as an intentional process/use-case exception without a direct requirement-level RTM row.

## 10. Data Analysis Highlights

The Data Dictionary separates logical business concepts from physical persistence. Major logical entities include Account, Customer, Restaurant, Shipper, Food Item, Menu Category, Order, Order Detail, Restaurant Review, and Shipper Review.

The analysis distinguishes persisted data from derived or transient concepts. In CURRENT persistence evidence, Order.Status, Shipper Assignment, and Total Order Amount are mapped to persisted fields. Delivery Distance is calculated through the Map / Routing flow, but no persisted Order field for that value has been verified. Delivery Fee and Service Fee remain logically distinct TARGET concepts; separate persistence for each was not verified, while CURRENT evidence shows their applicable aggregate stored through `DonHang.ShipFee`. Delivery Routing Information is also treated as dynamic/transient with physical persistence not verified.

## 11. TARGET vs CURRENT Validation

A core discipline demonstrated in this portfolio is the strict separation between TARGET (the approved intended business/system behaviour) and CURRENT (the behaviour actually evidenced in the existing prototype/code). Implementation must not silently redefine the intended business requirement.

Two implementation gaps were verified from the reviewed evidence:
- **GAP-01 (Shipper Acceptance Status Enforcement)**: The TARGET requires orders to be unassigned AND in the "Đang lấy món" status. The CURRENT evidence checks the assignment condition but fails to fully enforce the status prerequisite.
- **GAP-02 (Credential Protection)**: The TARGET requires credentials to be protected via an approved hashing mechanism. The CURRENT evidence demonstrated plaintext password handling/storage.

## 12. Implementation Validation Summary

The approved Requirement Gap Analysis clarifies that while some features align with the target, many requirements remain NOT VERIFIED because sufficient source/runtime evidence was not reviewed. 

Verified ALIGNED examples include registration/authentication functional flows, checkout total calculation, unassigned Shipper order visibility, Shipper delivery-status update capability, Shipper completed-delivery/history and income capability, the 30 km delivery-radius rule, distance-based delivery-fee calculation, and the implemented time-based service-fee switch. Many other requirements remain NOT VERIFIED because sufficient source/runtime evidence was not reviewed. Absence of evidence was not treated as evidence of a gap.

## 13. UAT Design & Validation Strategy

UAT design was derived from approved Acceptance Criteria, Business Rules, State transitions, Use Case exceptions, the TO-BE workflow, and RTM traceability. UAT validates TARGET behaviour and does not redefine requirements according to CURRENT code.

The approved UAT catalogue contains **60 test cases**, all of which remain **NOT EXECUTED**. The final test-readiness distribution is:

* **53 READY** — executable UAT designs derived from approved target behaviour.
* **6 BLOCKED — TARGET CLARIFICATION REQUIRED** — executable expectations cannot yet be finalized because part of the TARGET remains unresolved.
* **1 NON-UAT TECHNICAL VALIDATION REQUIRED** — password-hashing validation (`NFR-SEC-02`), which requires technical/security verification rather than normal business UAT.

These figures represent **test-design readiness, not execution results**. No PASS/FAIL outcome is claimed.

## 14. Traceability Approach

A conceptual, end-to-end traceability chain is maintained: Business Context → AS-IS → TO-BE → Business Rule → Functional Requirement → Use Case / User Story → Acceptance Criteria → Data → Implementation Evidence → Gap Finding → UAT.

The Requirements Traceability Matrix enforces this backward and forward mapping across 38 RTM rows. Following backward UAT traceability, the 38 controlled RTM rows comprise **30 READY design-coverage rows, 3 PARTIAL rows, 4 BLOCKED rows, and 1 NON-UAT TECHNICAL VALIDATION row**. The PARTIAL rows preserve cases where executable coverage exists but a material target clarification still blocks part of the requirement or rule. These statuses describe UAT design coverage only and remain separate from CURRENT implementation assessments such as ALIGNED, PARTIALLY ALIGNED, GAP, or NOT VERIFIED.

## 15. Open Clarifications & Known Limitations

To demonstrate controlled BA reasoning, unresolved semantics were explicitly retained rather than silently fabricated. Material unresolved items include:

* Exact Administrator user-account management actions and menu-category operations.
* Customer profile/account input-validation rules and whether authentication is required for browsing.
* Detailed authentication-failure behaviour.
* Tracking refresh frequency and notification behaviour.
* Authoritative timestamp for BR-FEE-02 and fractional-kilometre rounding.
* Exact definition of a conflicting “active delivery” for BR-SHIP-01.
* Exact post-Shipper-cancellation Order.Status.
* Restaurant intermediate confirmation semantics.
* Partner approval-state vocabulary, rejection logic, and the exact non-core capability boundary governed by BR-PARTNER-01.
* Review cardinality and editability.
* Quantitative performance targets.

These items remain **TBD / NOT EVIDENCED / REQUIRES CLARIFICATION** as applicable and are not silently resolved within the portfolio summary.

## 16. BA Competencies Demonstrated

| BA Competency | Evidence in This Case Study |
| :--- | :--- |
| **Business process analysis** | AS-IS & TO-BE models isolating fragmentation and multi-role handoffs |
| **Requirements analysis** | 38 structured FR/NFR/BR definitions avoiding implementation bias |
| **Business rule modelling** | 7 controlled rules decoupled from functional narratives |
| **State/lifecycle modelling** | Order state diagram with 4 strict statuses and transition triggers |
| **Functional decomposition** | Hierarchical breakdown of Use Cases → User Stories → Acceptance Criteria |
| **Data analysis** | Data Dictionary isolating transient vs. persisted concepts |
| **Requirement traceability** | RTM linking rules, criteria, gaps, and UAT coverage |
| **Current-vs-target validation** | Gap Analysis distinguishing intended design from existing code |
| **UAT design** | 60-case validation catalogue covering positive, negative, boundary, state-transition, role/access, compatibility, clarification-blocked, and technical-validation scenarios |

## 17. Interview-Defensible Highlights

### 1. Separating logical TARGET data concepts from CURRENT physical persistence
- **Challenge / Question**: How should discrepancies between physical database schemas and logical business concepts be documented?
- **BA Reasoning**: Evaluated logical concepts like Delivery Distance separately from physical persistence, ensuring business needs are captured even if not permanently stored.
- **Evidence**: Data Dictionary.
- **Defensible Takeaway**: Demonstrates data analysis maturity by distinguishing logical concepts from physical implementation.

### 2. Identifying GAP-01 without rewriting the target to match code
- **Challenge / Question**: What should happen when CURRENT assignment logic permits behaviour that conflicts with the approved Shipper-acceptance rule?
- **BA Reasoning**: Maintained the approved TARGET baseline rather than allowing CURRENT implementation behaviour to redefine the intended requirement. Recorded the implementation mismatch as GAP-01.
- **Evidence**: Business Rules Catalogue and Requirement Gap Analysis.
- **Defensible Takeaway**: Demonstrates requirement integrity and controlled gap analysis.

### 3. Handling unresolved active-delivery semantics without inventing a definition
- **Challenge / Question**: How should UAT and traceability reflect a business rule where the core conditional definition remains undefined?
- **BA Reasoning**: Blocked UAT-040 and marked BR-SHIP-01 coverage as PARTIAL because "active delivery" remains undefined, rather than guessing the policy.
- **Evidence**: UAT Test Cases and Requirements Traceability Matrix.
- **Defensible Takeaway**: Proves maturity in managing ambiguity and target clarifications without fabricating requirements.

### 4. Distinguishing business UAT from technical validation
- **Challenge / Question**: How should underlying security requirements, such as password hashing, be validated in a business testing context?
- **BA Reasoning**: Classified password hashing (NFR-SEC-02) as a Non-UAT Technical Validation requirement, acknowledging business UI testing cannot verify cryptographic persistence.
- **Evidence**: UAT Test Cases (UAT-057).
- **Defensible Takeaway**: Demonstrates deep understanding of testing boundaries and non-functional validation.

### 5. Building backward traceability from UAT to RTM
- **Challenge / Question**: How can test coverage be reliably proven without exaggerating readiness or relying on manual assertions?
- **BA Reasoning**: Mechanically linked UAT IDs back into the RTM based on exact explicit references, dynamically deriving coverage statuses (READY, PARTIAL, BLOCKED).
- **Evidence**: Requirements Traceability Matrix v1.1.
- **Defensible Takeaway**: Shows strong capability in managing test coverage and maintaining traceability integrity.

## 18. Portfolio Publication Guidance

### Suitable for Public Portfolio
- Sanitized TO-BE process diagrams
- Business Rules Catalogue summary
- Order State Diagram
- Functional Requirements Specification
- Selected excerpts of User Stories, Acceptance Criteria, RTM, and UAT cases
- This Portfolio Evidence Summary

### Better as Interview / Supporting Evidence
- Full Data Dictionary
- Full Requirements Traceability Matrix
- Full UAT Catalogue
- Detailed Requirement Gap Analysis
- Detailed Use Cases / Acceptance Criteria where deeper discussion is needed

### Do Not Publish Raw Without Review
- Raw source code or internal confidential project reports
- Original raw implementation evidence
- Credentials, connection strings, secrets, sensitive environment/configuration details

## 19. Recommended Claim Language

| Avoid | Prefer |
| :--- | :--- |
| "Designed a production food-delivery platform" | "Analysed and documented a multi-role Online Food Delivery System case study." |
| "Implemented complete secure authentication" | "Validated the existing authentication flow and identified a credential-security gap involving plaintext password handling." |
| "Improved system efficiency" | "Modelled the TO-BE workflow and documented requirement, business-rule, and traceability evidence." |
| "Conducted stakeholder interviews" | "Reconstructed and validated requirements from the approved project baseline, report, and implementation evidence." |
| "Requirements validated through successful UAT" | "Executable UAT design coverage was derived from approved Acceptance Criteria." |

## 20. Evidence Index

| Evidence Area | Primary Artefact | Supporting Artefact(s) |
| :--- | :--- | :--- |
| **Business Context / Target Baseline** | Validated Portfolio BRD | Original Major Project Report |
| **AS-IS Analysis** | AS_IS_Process.md | Validated Portfolio BRD |
| **TO-BE Workflow** | TO_BE_Cross_Role_Process.md | Business_Rules_Catalogue.md |
| **Business Rules** | Business_Rules_Catalogue.md | User_Stories_Acceptance_Criteria.md |
| **Order Lifecycle** | Order_State_Diagram.md | TO_BE_Cross_Role_Process.md |
| **Detailed Functional Behaviour** | Detailed_Use_Cases.md | Validated Portfolio BRD |
| **System Functional Spec** | Functional_Requirements_Specification.md | All Upstream BA Artefacts |
| **User Stories / AC** | User_Stories_Acceptance_Criteria.md | Detailed_Use_Cases.md |
| **Data Analysis** | Data_Dictionary.md | Current persistence evidence |
| **CURRENT Validation** | Requirement_Gap_Analysis.md | Source-code evidence |
| **Gap Findings** | Requirement_Gap_Analysis.md | Requirements_Traceability_Matrix.csv |
| **Traceability** | Requirements_Traceability_Matrix.csv | UAT_Test_Cases.csv |
| **Acceptance Validation** | UAT_Test_Cases.csv | User Stories / AC |

## 21. Portfolio Summary

The Online Food Delivery System case study provides robust evidence of the ability to structure ambiguous system behaviour into a controlled, testable framework. The portfolio highlights capabilities in modelling cross-role workflows, translating precise business rules into testable boundaries, and maintaining strict lifecycle state consistency. 

By comparing target requirements against current implementation evidence, the analysis identifies gaps without fabricating missing information or altering the baseline. The end-to-end traceability and rigorous UAT design underscore a professional, interview-defensible BA competency capable of managing complex dependencies and unresolved clarifications.
