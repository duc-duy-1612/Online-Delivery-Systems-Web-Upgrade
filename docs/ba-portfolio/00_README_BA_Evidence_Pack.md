# Online Food Delivery System — BA Evidence Pack

## Document Control
Status: APPROVED
Version: 1.2
Project: Online Food Delivery System
Artefact Type: Governance, Source-of-Truth, Traceability and Documentation Standard
Source Baseline: Controlled Portfolio BRD, Original Major Project Report, Source Code / Prototype, Data Model / Persistence Evidence
Depends On: None
Last Reviewed: 16 Aug 2026

## Revision Note — v1.2

This governance revision registers the Problem Statement as the first controlled analytical artefact in the BA Evidence Pack and updates the controlled artefact sequence. The Problem Statement represents an analytical case-study problem baseline; it does not claim formal stakeholder elicitation, does not contain validated production KPIs, and does not represent a stakeholder-approved production business case.

No TARGET requirement, Business Rule, implementation assessment, or Gap Finding is changed by this revision. Source-authority wording is clarified for consistency without changing the established precedence semantics.


## 1. Purpose
This README acts as the **Governance, Source-of-Truth, Traceability and Documentation Standard** for every BA artefact created in this Evidence Pack. Its purpose is to prevent:
* inconsistent requirements
* terminology drift
* unsupported assumptions
* hallucinated stakeholder information
* accidental rewriting of business requirements based on source code
* contradictions between BRD, project report and implementation
* downstream artefacts inheriting unreviewed errors

All future BA documents must strictly follow the rules defined in this README.

## 2. Project Context
The Online Food Delivery System is an academic software project that will be used as the primary Business Analyst case study in the candidate's CV and portfolio. The documentation structure established here allows for a controlled, step-by-step reconstruction and validation of business analysis artefacts.

## 3. Evidence Pack Scope
The rules and standards outlined in this document apply to all derived BA artefacts located within the `docs/ba-portfolio/` directory.

## 4. Source Register & Citation Convention
The following project evidence sources exist within the repository and serve as foundational inputs:

*   **S1 — Controlled Portfolio BRD:** `BRD_FoodDeliveryDB.md` and `BRD_FoodDeliverySystem_Portfolio_Final.pdf`
    > **S1 internal precedence:** The Markdown (`.md`) is the canonical editable source. Only an owner-approved BRD revision may be treated as the active TARGET requirement baseline. The PDF is the rendered public snapshot of the latest approved BRD and must remain content-equivalent with that approved baseline.
*   **S2 — Original Major Project Report:** `Báo Cáo Đồ Án Chuyên Ngành Tiếng Anh .pdf` (and `.docx`)
*   **S3 — Source Code / Current Prototype:** ASP.NET MVC 5 application codebase in the `ĐACN/` directory
*   **S4 — Data Model / Persistence Evidence:** SQL Server + Entity Framework 6 Database-First mappings represented through EDMX and implementation code.
*   **S5 — Approved BA Evidence Pack Artefacts:** Only derived documents within `docs/ba-portfolio/` whose current status is explicitly `APPROVED`. Draft, In Review and Not Started artefacts are not part of S5 authority.

**Citation Rule:** When a derived artefact makes a material business or implementation claim, reference the supporting source where practical. For example:
```text
Source: S1 — BR-SHIP-02
Source: S1 — FR-SHP-02
Implementation Evidence: S3 — <actual file / method>
Supporting Diagram: S2 — <section/page>
```

## 5. Source Authority & Precedence
The project contains multiple evidence layers. Authority depends on the type of claim being made. The conceptual model is:

```text
TARGET BUSINESS / REQUIREMENT BASELINE
Controlled Portfolio BRD (S1)
        ↓
SUPPORTING PROJECT EVIDENCE
Original Major Project Report (S2)
        ↓
CURRENT IMPLEMENTATION EVIDENCE
Source Code / Prototype (S3)
+
Data Model / Persistence Evidence (S4)
        ↓
DERIVED BA ARTEFACTS
Approved docs/ba-portfolio/* (S5)
```

### A. Intended Business Requirements
**Primary authority: Latest owner-approved Controlled Portfolio BRD (S1)**
Use the BRD as the current portfolio baseline for: project scope, functional requirements, non-functional requirements, target business rules, AS-IS assumptions, TO-BE target process, business drivers, requirement gaps, assumptions, and constraints.
If the original Major Project Report conflicts with the latest owner-approved Controlled Portfolio BRD on an intended requirement, use the latest owner-approved Controlled Portfolio BRD unless the contradiction requires explicit review.

### B. Implemented System Behaviour
**Primary authority: Source Code / Current Prototype (S3)**
Use source code and implemented UI to determine: what the prototype actually does, which conditions are enforced, actual state transitions, actual validation logic, implemented calculations, current data structures, implemented role permissions, and actual technical integration behaviour.

> **IMPORTANT:** Source code is authoritative for implemented behaviour, but it must NOT silently redefine the intended business requirement. 

If implementation differs from the target requirement (`Target Requirement ≠ Implemented Behaviour`), record the difference as a **Requirement Gap / Validation Finding**. Do NOT rewrite the requirement to match the code.

### C. Data Model / Persistence Evidence
**Primary authority: SQL Server / EF6 Database-First / EDMX (S4)**

Use S4 to determine verified persisted entities, fields, relationships, keys and physical mappings.

Do not infer persistence solely from target business concepts.

### D. Historical / Supporting Project Evidence
**Primary authority: Original Major Project Report (S2)**
Use the Original Major Project Report for supporting evidence such as original project analysis, actor/use-case diagrams, activity diagrams, sequence diagrams, ERD, screen specifications, original implementation descriptions, and academic project context. The original report is supporting evidence, but may contain outdated statements, inconsistent technical descriptions, broader historical scope, translation problems, or implementation claims that differ from the validated portfolio baseline. Therefore it must not automatically override the latest owner-approved Controlled Portfolio BRD.

### E. Approved BA Artefacts
Files under `docs/ba-portfolio/` become controlled derived artefacts only after review. An artefact marked `Status: APPROVED` may be used as an input to downstream artefacts. A `DRAFT` artefact must not be treated as authoritative. An approved derived artefact must also NOT override the latest owner-approved Controlled Portfolio BRD without an explicit upstream review.

## 6. Conflict Resolution Rules
*   **Case 1: Controlled Portfolio BRD vs Original Report:** For target requirements/scope, the latest owner-approved Controlled Portfolio BRD normally takes precedence.
*   **Case 2: Controlled Portfolio BRD vs Source Code:** Do NOT change the approved BRD automatically. Interpret the difference as `Target Requirement vs Current Implementation` and create or reference a Gap Finding if materially different.
*   **Case 3: Original Report vs Source Code:** For current implemented behaviour, Source code / current prototype takes precedence. The report remains historical evidence.
*   **Case 4: Approved BA Artefact vs Newly discovered stronger evidence:** Do NOT silently edit downstream documents. Instead: Reopen the affected upstream artefact, change status to IN REVIEW, correct it, and revalidate dependent artefacts.
*   **Case 5: No source supports a claim:** Use `TBD` or `Not Evidenced`. Do NOT invent a solution.

## 7. Evidence & Assumption Policy
Future BA artefacts **MUST NOT** invent:
*   stakeholder interviews, stakeholder workshops, elicitation sessions that did not occur
*   customer quotes, production usage, production deployment, production KPIs
*   adoption metrics, revenue impact, ROI, time savings, defect reduction percentages
*   performance thresholds that were never defined
*   API capabilities not supported by evidence
*   business rules not supported by the sources
*   system states not supported by evidence

If required information is unavailable, use `TBD`, `Not Evidenced`, or `Assumption — Requires Validation` depending on context. Never silently fill gaps with plausible information.

### Evidence Classification Markers
To explicitly communicate the nature of a claim, the following markers should be used where helpful:
*   `BASELINE` — explicitly defined by the latest owner-approved Controlled Portfolio BRD
*   `IMPLEMENTED` — verified in source code/prototype
*   `DERIVED` — analysis logically derived from approved evidence
*   `ASSUMPTION` — analytical assumption requiring disclosure
*   `NOT EVIDENCED` — no reliable source currently available

## 8. Known Portfolio Baseline Decisions
Based on the validated project sources, document the following baseline decisions if confirmed by repository evidence:
*   **Platform Scope:** Responsive Web Application. Native mobile application is **Out of Scope**.
*   **Payment:** Current supported scope is **COD + QR Payment Simulation**. Do NOT describe QR Payment Simulation as real VNPAY integration unless actual validated implementation evidence proves otherwise. Real payment-gateway integration should be treated as Future / Out of current scope.
*   **Data / Technical Stack:** ASP.NET MVC 5, .NET Framework 4.7.2, SQL Server, Entity Framework 6 (Database First / EDMX where applicable), Razor, Bootstrap, jQuery / AJAX.
*   **AS-IS Status:** The AS-IS process and business drivers are **Case-study assumptions created for analysis**. They were NOT validated through formal stakeholder interviews. This fact must be preserved in every downstream document that relies on AS-IS.

## 9. Terminology Standard
Use these preferred public/project terms consistently:
*   `Customer`
*   `Restaurant`
*   `Shipper`
*   `Administrator`
*   `Guest`: an unauthenticated visitor who may browse permitted public content and initiate registration/login. Guest is a supporting actor, not a registered operational role.

Avoid switching unnecessarily between Restaurant, Shop Owner, Store Owner, or Supplier. Use **Restaurant** as the preferred normalized term.

Use standardized terms:
*   `Ready for Pickup ("Đang lấy món")`
*   `Delivering ("Đang giao")`
*   `Completed ("Hoàn thành")`
*   `Unassigned Order` — an assignment condition indicating that no Shipper is currently assigned; it is NOT an `Order.Status`.
*   `COD`
*   `QR Payment Simulation`
*   `AS-IS`
*   `TO-BE`
*   `Functional Requirement`
*   `Non-functional Requirement`
*   `Business Rule`
*   `Acceptance Criteria`
*   `UAT`
*   `Requirement Gap`

## 10. Artefact & Requirement ID Conventions
Preserve existing BRD IDs (e.g., `FR-AUTH-01`, `NFR-PER-01`, `BR-ORDER-01`, `GAP-01`). Do not renumber established BRD IDs.
For new portfolio artefacts, use:
*   `UC-CUS-01`, `UC-RES-01`, `UC-SHP-01`, `UC-ADM-01`
*   `US-CUS-01`, `US-RES-01`, `US-SHP-01`, `US-ADM-01`
For UAT cases, use sequential controlled identifiers:
*   `UAT-001`
*   `UAT-002`
...
*   `UAT-nnn`
Actor / role ownership is represented separately in the UAT catalogue through Primary_Actor and traceability fields and does not need to be encoded in the UAT identifier.
If Acceptance Criteria require identifiers, use `AC-US-CUS-01-01`. Do not create AC IDs unless they are useful for traceability.

## 11. Traceability Principle
Define the intended traceability chain as:
```text
Problem Statement / Business Context / Assumption
        ↓
AS-IS
        ↓
TO-BE
        ↓
Business Rule
        ↓
Functional / Non-functional Requirement
        ↓
Use Case / User Story
        ↓
Acceptance Criteria
        ↓
Data / UI / System Behaviour
        ↓
Implementation Evidence
        ↓
Gap Finding
        ↓
Requirements Traceability Matrix
        ↓
UAT Design
```
Not every requirement needs every relationship. Do not fabricate a relationship merely to fill the RTM. Traceability should exist only where supported.

## 12. Document Lifecycle & Approval Authority
Allowed statuses:
*   **NOT STARTED:** Placeholder only.
*   **DRAFT:** Initial generated/edited content that has not yet been validated.
*   **IN REVIEW:** Currently being compared against project evidence.
*   **APPROVED:** Reviewed and accepted as the current baseline for downstream artefacts.
*   **SUPERSEDED:** Replaced by a newer approved version.

**Approval Authority:** AI agents may create and revise DRAFT artefacts, but must never mark an artefact APPROVED autonomously. APPROVED status requires explicit manual review and approval by the portfolio owner after source validation. If a material contradiction remains unresolved, the artefact must remain `IN REVIEW`.

## 13. Standard Artefact Header
Standard metadata block for future Markdown artefacts:
```markdown
Status: DRAFT
Version: 0.1
Project: Online Food Delivery System
Artefact Type: <type>
Source Baseline: <sources>
Depends On: <approved artefacts or None>
Last Reviewed: —
```
**Initial approval:** When a new artefact is manually approved for the first time, normally change it to `Status: APPROVED` and `Version: 1.0`.

**Subsequent controlled revisions:** Preserve or increment the controlled revision version (for example, `1.1`) and change the artefact back to `APPROVED` only after manual review. Do not reset a revised artefact to `Version: 1.0`.

Do not fabricate a review date.

## 14. Controlled Artefact Development Sequence
Use this sequence:
```text
00_README_BA_Evidence_Pack.md
        ↓
Problem_Statement.md
        ↓
AS_IS_Process.md
        ↓
AS_IS_Process.mmd
        ↓
TO_BE_Cross_Role_Process.md
        ↓
TO_BE_Cross_Role_Process.mmd
        ↓
Business_Rules_Catalogue.md
        ↓
Order_State_Diagram.md
        ↓
Order_State_Diagram.mmd
        ↓
Detailed_Use_Cases.md
        ↓
User_Stories_Acceptance_Criteria.md
        ↓
Requirement_Gap_Analysis.md
        ↓
Data_Dictionary.md
        ↓
Requirements_Traceability_Matrix.csv
        ↓
UAT_Test_Cases.csv
        ↓
Portfolio_Evidence_Summary.md
```
**Important rule:** Each analytical document must be reviewed and APPROVED before a dependent downstream artefact is treated as final. For diagram pairs (`Analysis .md` → `Review / Approval` → `Diagram .mmd`), do not generate the diagram as authoritative before the corresponding analysis has been validated.

## 15. Artefact Register
| Artefact | Purpose | Depends On | Current Status | Version |
| :--- | :--- | :--- | :--- | :--- |
| `00_README_BA_Evidence_Pack.md` | Governance standard | None | IN REVIEW | 1.2 |
| `00_Context/Problem_Statement.md` | Defines the assumed business problem, affected actors, qualitative operational impacts, analysis objectives, scope boundaries, evidence limitations, and its relationship to downstream BA artefacts. | `00_README_BA_Evidence_Pack.md` | APPROVED | 1.0 |
| `01_Process_Analysis/AS_IS_Process.md` | AS-IS documentation | `00_README_BA_Evidence_Pack.md`, `00_Context/Problem_Statement.md` | APPROVED | 1.0 |
| `01_Process_Analysis/AS_IS_Process.mmd` | AS-IS visualisation | `AS_IS_Process.md` | APPROVED | 1.0 |
| `01_Process_Analysis/TO_BE_Cross_Role_Process.md` | TO-BE documentation | `00_README_BA_Evidence_Pack.md`, `AS_IS_Process.md` | APPROVED | 1.0 |
| `01_Process_Analysis/TO_BE_Cross_Role_Process.mmd` | TO-BE visualisation | `TO_BE_Cross_Role_Process.md` | APPROVED | 1.0 |
| `03_Requirements/Business_Rules_Catalogue.md` | Business rules | `00_README_BA_Evidence_Pack.md`, `TO_BE_Cross_Role_Process.md` | APPROVED | 1.0 |
| `02_System_Behaviour/Order_State_Diagram.md` | Order state definitions | `00_README_BA_Evidence_Pack.md`, `TO_BE_Cross_Role_Process.md`, `Business_Rules_Catalogue.md` | APPROVED | 1.0 |
| `02_System_Behaviour/Order_State_Diagram.mmd` | Order state visualisation | `Order_State_Diagram.md` | APPROVED | 1.0 |
| `03_Requirements/Detailed_Use_Cases.md` | Detailed use cases | `00_README_BA_Evidence_Pack.md`, `TO_BE_Cross_Role_Process.md`, `Business_Rules_Catalogue.md`, `Order_State_Diagram.md` | APPROVED | 1.0 |
| `03_Requirements/User_Stories_Acceptance_Criteria.md` | Stories & criteria | `Business_Rules_Catalogue.md`, `Order_State_Diagram.md`, `Detailed_Use_Cases.md` | APPROVED | 1.0 |
| `03_Requirements/Functional_Requirements_Specification.md` | System functional specifications | `00_README_BA_Evidence_Pack.md`, All Upstream BA Artefacts | APPROVED | 1.0 |
| `04_Traceability/Requirement_Gap_Analysis.md` | Gap analysis | `Business_Rules_Catalogue.md`, `Order_State_Diagram.md`, `Detailed_Use_Cases.md`, `User_Stories_Acceptance_Criteria.md` | APPROVED | 1.0 |
| `06_Data/Data_Dictionary.md` | Data attributes | `Requirement_Gap_Analysis.md`, `User_Stories_Acceptance_Criteria.md`, `Detailed_Use_Cases.md`, `Business_Rules_Catalogue.md`, `Order_State_Diagram.md` | APPROVED | 1.0 |
| `04_Traceability/Requirements_Traceability_Matrix.csv` | Traceability matrix | All upstream analytical artefacts | APPROVED | 1.1 |
| `05_Validation/UAT_Test_Cases.csv` | UAT scenarios | `Requirements_Traceability_Matrix.csv`, Approved Requirements | APPROVED | 1.0 |
| `07_Portfolio/Portfolio_Evidence_Summary.md` | Executive summary | All approved S5 artefacts | APPROVED | 1.0 |

## 16. Portfolio Publication Rules
Raw source documents should not automatically be exposed publicly. Internal/raw project evidence may contain student IDs, lecturer information, teammate information, internal academic metadata, implementation details, credentials or sensitive data, and legacy inconsistencies. 
Public portfolio content should use sanitised excerpts, recreated diagrams, reviewed BA summaries, and approved portfolio-safe artefacts. Do not expose sensitive/private values merely because they exist in the repository.

## 17. Team Project vs Individual Portfolio Analysis
The original academic project contains multiple student contributors. It is necessary to distinguish between a **Project/team artefact** and an **Individual portfolio analysis**. Do not automatically claim sole authorship of historical team deliverables unless supported. New BA portfolio artefacts created in `docs/ba-portfolio/` may represent the candidate's current reconstructed/validated BA analysis, but must clearly distinguish original team project evidence from later portfolio refinement / analysis.

## 18. Governance Rules for Future AI-Assisted Documentation
Any AI agent working on future artefacts must:
1. Read this README first.
2. Inspect relevant approved upstream artefacts.
3. Inspect primary source evidence.
4. Distinguish intended requirement from implemented behaviour.
5. Cite/reference source evidence internally when practical.
6. Mark unsupported information as TBD / Not Evidenced.
7. Never invent stakeholder evidence.
8. Never modify an approved upstream artefact silently.
9. Never generate dependent artefacts as final if their upstream dependency is still DRAFT.
10. Stop and report material contradictions rather than arbitrarily resolving them.
