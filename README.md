CampusLink

Campus Resource Exchange & Recovery System

---

Overview

CampusLink is a unified digital platform designed to improve trust, communication, and resource exchange within university campuses.

It provides a structured system for:

- Reporting and recovering lost items
- Posting found items
- Enabling safe student-to-student marketplace exchange

The system is designed to scale beyond a single institution, supporting multiple universities and evolving into a broader campus infrastructure platform.

---

Problem Statement

On university campuses, students face several recurring challenges:

- Frequent loss of personal items such as phones, ID cards, books, and chargers
- No centralized system for reporting or recovering lost items
- Heavy reliance on unstructured WhatsApp groups
- Lack of trust in informal student marketplaces
- Difficulty in locating or verifying items and sellers

These challenges lead to loss of time, money, and trust within student communities.

---

Solution

CampusLink provides a structured digital ecosystem that connects students through two core systems:

1. Lost & Found System

A structured recovery system that allows students to:

- Report lost items with images and details
- Report found items with location and description
- Automatically match lost and found reports
- Track item recovery status

2. Student Marketplace System

A safe and structured platform for student exchange:

- List items for sale with images and descriptions
- Browse and search available items
- Filter by category and price
- Manage listings through a personal dashboard

---

Key Features

Lost & Found

- Report lost items
- Report found items
- Image and description upload
- Smart matching system (rule-based in MVP)
- Status tracking (Active / Resolved)

Marketplace

- Product listings with images
- Category-based filtering
- Search functionality
- Simple buyer-seller interaction model

Platform Features

- Unified user dashboard
- Item search system
- Admin moderation (planned)
- Notification system (planned)
- Scalable multi-campus architecture

---

System Architecture

Frontend

- Responsive web application
- Mobile-friendly UI
- Core pages:
  - Home
  - Lost & Found
  - Marketplace
  - Post Item
  - Dashboard

Backend

- ASP.NET Core Web API
- RESTful architecture
- Modular service structure

Database

- Relational database (SQL Server / PostgreSQL)
- Core entities:
  - Users
  - Lost Items
  - Found Items
  - Marketplace Items
  - Match Records

Core Logic

- Matching engine based on:
  - Keywords
  - Categories
  - Time and location similarity

---

System Workflow

Lost Item Flow

1. User reports a lost item
2. System stores the report
3. Matching engine checks for similar found items
4. Possible matches are suggested
5. Users are notified for verification and recovery

Found Item Flow

1. User reports a found item
2. System searches for matching lost reports
3. Potential owner matches are identified
4. Confirmation completes recovery process

Marketplace Flow

1. User lists an item for sale
2. Item becomes visible to all users
3. Students browse and search listings
4. Buyers contact sellers for exchange

---

Tech Stack

- Backend: ASP.NET Core Web API
- ORM: Entity Framework Core
- Database: SQL Server / PostgreSQL
- Frontend: Blazor / Razor Pages / React (planned)
- Version Control: Git & GitHub

---

Vision

CampusLink is not just a student application—it is a foundation for campus digital infrastructure.

Long-term goals include:

- Expanding to multiple universities
- Introducing AI-powered item matching
- Implementing student verification systems
- Adding trust and reputation systems
- Supporting full campus digital ecosystems across regions
- Contributing to a broader technology ecosystem under Gid_Paragon

---

Future Improvements

- AI-based image recognition for item matching
- Real-time chat between users
- QR code tagging for physical items
- Mobile application (Android/iOS)
- Student verification via institutional email
- Reputation and trust scoring system
- Cross-campus network support

---

Project Status

Early development / Planning phase

---

Author

Mukhtar Gidado
Software Engineering Student | Tech Founder | Community Builder

Building scalable software systems that empower students and strengthen technology ecosystems in FUDMA and beyond.

---

Contact

GitHub: https://github.com/gidadomukhtar
Email: mukhtargidado49@gmail.com

---
