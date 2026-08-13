# DevBoard

DevBoard is a mobile application designed for software developers to track, analyze, and improve their programming activity.

The application will provide a centralized dashboard where users can connect their development activity, define personal goals, and visualize their progress through statistics and achievements.

## 🎯 Project Goals

- Track and visualize programming activity.
- Connect development data from external platforms such as GitHub.
- Set and monitor personal development goals.
- Display statistics and progress over time.
- Provide a mobile-first experience.
- Build a scalable backend following modern software development practices.

## 🏗️ Architecture

The project will follow a client-server architecture:

```text
Mobile App
    │
    │ REST API
    ▼
ASP.NET Core Backend
    │
    ├── Entity Framework Core
    │
    ▼
MySQL Database