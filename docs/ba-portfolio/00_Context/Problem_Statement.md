# Problem Statement — Online Food Delivery System

## Document Control
Status: APPROVED
Version: 1.0
Owner: Phạm Đức Duy
Role: Business Analyst — Portfolio Reconstruction & Validation

## 1. Purpose
This artefact defines the assumed business problem analysed by the Online Food Delivery System Business Analysis case study. It establishes the foundational operational context required before conducting the subsequent AS-IS process analysis, defining the TO-BE cross-role process, and specifying the target business rules, functional requirements, and testing coverage. This document serves as the conceptual starting point for the portfolio's requirements traceability lifecycle.

## 2. Business Context
The available project documentation establishes a multi-role operational environment involving Customers, Restaurants, and Shippers. In the assumed pre-platform state, the coordination of food ordering and delivery relies on disjointed manual communication channels such as phone calls, personal messaging, and informal chat groups. 

Because information flows through unstructured methods, restaurants must manually record orders and independently solicit available freelance shippers to complete deliveries. This decentralised approach creates a fragmented operational landscape in which core operational information—such as order status, delivery-related information and historical records—is not centrally consolidated, complicating fulfilment visibility and reporting.

## 3. Problem Statement
The case study models an assumed current-state environment in which food ordering and delivery fulfilment rely primarily on fragmented manual and unstructured communication between Customers, Restaurants and Shippers. This creates fragmented information flows, high manual coordination effort for dispatching orders, and limited end-to-end visibility into delivery progress. Therefore, the case study analyses how the end-to-end ordering and fulfilment workflow can be structured into a controlled, multi-role digital process to centralise operational data, enforce controlled delivery-assignment eligibility, and improve order lifecycle visibility.

### Problem Breakdown
*   **PS-01: Fragmented Ordering Information**
    *   **Affected Actor(s):** Customer, Restaurant
    *   **Operational Implication:** Order information is captured through fragmented manual communication and records, increasing the risk of inconsistency and preventing centralised tracking.
*   **PS-02: Manual Shipper Coordination**
    *   **Affected Actor(s):** Restaurant, Shipper
    *   **Operational Implication:** Finding an available Shipper requires direct calls or informal group messages, increasing coordination effort and making delivery assignment less structured.
*   **PS-03: Limited Delivery Visibility**
    *   **Affected Actor(s):** Customer
    *   **Operational Implication:** The Customer has limited visibility into delivery progress and cannot reliably track the order through the fulfilment lifecycle.
*   **PS-04: Fragmented Operational Data**
    *   **Affected Actor(s):** Restaurant, Shipper
    *   **Operational Implication:** Operational and historical information is not centrally consolidated, limiting consistent reporting and cross-role visibility.

## 4. Actors in Analysis

| Actor | Problem / Analysis Relevance |
| :--- | :--- |
| **Customer** | Experiences limited visibility into order status and relies on manual contact to place orders. |
| **Restaurant** | Bears the high manual coordination effort required to record orders and secure freelance shippers. |
| **Shipper** | Lacks a centralised mechanism to view available deliveries, relying on informal outreach to find work. |
| **Administrator** | Supporting governance/reporting actor in the target operating model rather than a directly evidenced AS-IS participant. |

## 5. Operational Impact
The assumed baseline constraints create several qualitative operational impacts:
*   Fragmented information flows across the primary operational roles.
*   Manual and disconnected coordination required for delivery assignment.
*   Limited visibility into order progress during the fulfilment phase.
*   Difficulty maintaining a consistent, traceable end-to-end operational workflow.

**Note:** No validated quantitative baseline or production KPI is available for this academic case study. 

## 6. Analysis Objective
The primary objective of this BA portfolio case study is to:
*   Understand and structure the end-to-end multi-role workflow from order placement to delivery completion.
*   Model the AS-IS baseline and design the TO-BE cross-role process.
*   Define controlled target requirements, business rules, and a strict order lifecycle (state model).
*   Separate TARGET requirements from CURRENT implementation behaviour to identify verifiable gaps.
*   Establish controlled backward and forward traceability between requirements and validation artefacts.

## 7. Scope Boundary

| Scope Area | IN SCOPE | OUT OF SCOPE |
| :--- | :--- | :--- |
| **Primary Platforms** | Responsive Web Application (Customer, Restaurant, Shipper and Administrator portals) | Native mobile applications (iOS/Android) |
| **Payment Methods** | Cash on Delivery (COD), QR Payment Simulation | Real production banking integration / Payment Gateways |
| **Business Roles** | Customer, Restaurant, Shipper, Administrator | Additional external operational roles are not modelled in the controlled case-study baseline |

## 8. Assumptions & Evidence Limitations
*   **Analytical Baseline:** The AS-IS process described is an analytical case-study baseline derived for requirements analysis.
*   **No Formal Elicitation:** The problem context was not validated through formal stakeholder interviews, workshops, or direct observation.
*   **No Production KPIs:** There is no empirical production KPI baseline claimed (e.g., specific cancellation rates, time savings, or revenue impact).
*   **Clarification Constraints:** Unresolved target semantics (such as exact rounding rules or cancellation boundary states) remain explicit clarifications rather than assumed facts.
*   **Not a Business Case:** This document establishes analytical context and must not be interpreted as a stakeholder-validated production business case.

## 9. Downstream BA Artefacts
This problem statement analytically traces to the following controlled evidence pack artefacts:

Problem Statement
↓
AS-IS Process
↓
TO-BE Cross-Role Process
↓
Business Rules + Functional / Non-Functional Requirements
↓
Detailed Use Cases
↓
User Stories & Acceptance Criteria
↓
Order State & Data Analysis
↓
TARGET vs CURRENT Gap Analysis
↓
Requirements Traceability Matrix
↓
UAT Design

**This sequence represents the analytical relationship between artefacts; it does not imply that every requirement has a mandatory one-to-one relationship with every downstream artefact.**
