# CampusLink 🎓🔗

CampusLink is an open-source platform built to connect tech students on campus and across universities — starting at Federal University Dutsinma (FUD) — while also solving everyday campus problems through a growing set of utilities.

## 🌍 Vision

University tech communities are often fragmented — students don't know who else on campus is into software, hardware, or design, and everyday problems (lost items, buying/selling used items) rely on scattered WhatsApp groups and physical notice boards. CampusLink brings this into one open, student-built platform.

## ✨ Features

### Live / In Progress
- 🔐 **Student Authentication** — Secure sign-up/login for students
- 🧑‍💻 **Tech Student Directory** — Discover and connect with tech students at your campus by skills and interests
- 🔍 **Lost & Found Board** — Post and search lost/found items on campus

### Planned (v2+)
- 🛒 **Campus Marketplace** — Buy, sell, and trade items within your campus community
- 🏫 **Campus Hubs** — Organize by university/campus for campus-specific discussions
- 🌍 **Global Hub** — Connect across universities, share projects and updates
- 👥 **Custom Communities** — Create and join communities by state, region, interest, or topic
- 🔒 **Private Communities** — Admins can create invite-only communities
- 💬 **Messaging** — Direct messaging between students
- 🔔 **Notifications** — Stay updated on posts, messages, and community activity

## 🛠️ Tech Stack

- **Frontend/Backend:** Blazor Server (.NET 8)
- **Database:** SQL Server / Azure SQL
- **Hosting:** Microsoft Azure
- **Version Control:** Git & GitHub

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB is fine for development) or an Azure SQL instance
- Visual Studio 2022 or VS Code with the C# extension

### Setup

```bash
# Clone the repo
git clone https://github.com/<your-username>/CampusLink.git
cd CampusLink

# Restore dependencies
dotnet restore

# Update the connection string in appsettings.json to point to your SQL instance

# Apply database migrations
dotnet ef database update

# Run the app
dotnet run
```

The app will be available at `https://localhost:5001` (or the port shown in your terminal).

## 🗺️ Roadmap

**MVP (v1.0)** — Campus Tech Connection
- [x] Project scaffolding & repo setup
- [x] User authentication with ASP.NET Identity
- [x] Tech Student Directory (campus-based, search by skills/interests)
- [x] Lost & Found board
- [ ] Deploy to Azure

**v2.0** — Campus Hub + Marketplace
- [ ] Campus marketplace (buy/sell/trade)
- [ ] Improved profile search and filtering
- [ ] Messaging system between students

**v3.0** — Global & Communities
- [ ] Campus hub feature (organize by university)
- [ ] Global hub (cross-campus updates and projects)
- [ ] Custom communities (state, region, interest-based)
- [ ] Admin controls for community privacy

## 🤝 Contributing

CampusLink is open source and welcomes contributions from students and developers anywhere! See [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines on how to get involved.

## 📄 License

This project is licensed under the MIT License — see the [LICENSE](LICENSE) file for details.

## 👤 Author

Built by Gidado, Software Engineering student at Federal University Dutsinma (FUD).
