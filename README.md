# 📄 Profile Management API

An API for managing profiles and their parameters, with automatic updates every 5 minutes.

---

## 🚀 Technologies

- .NET 8
- ASP.NET Core Web API
- Swagger / OpenAPI
- BackgroundService (.NET Worker)
- Dependency Injection
- Logger (Microsoft.Extensions.Logging)

---

## 📦 Features

- ✅ List all profiles
- ✅ Retrieve a specific profile
- ✅ Add a new profile
- ✅ Update a profile's parameters
- ✅ Delete a profile
- ✅ Automatically update the `CanEdit` parameter every 5 minutes via BackgroundService

---

## 🛠️ How to Run the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/ProfileManagement.git
   
---

## 📚 Endpoints
Method | Route | Description
GET | /api/profile | Get all profiles
GET | /api/profile/{profileName} | Get a profile by name
POST | /api/profile | Create a new profile
PUT | /api/profile/{profileName} | Update profile parameters
DELETE | /api/profile/{profileName} | Delete a profile

---

## 🧠 About the BackgroundService
The background service (ProfileBackgroundService) runs every 5 minutes and updates the CanEdit parameter of each registered profile by toggling its value between true and false.

Key logs:

BackgroundService start

Each parameter update

End of each update cycle

📝 Example Log Output
plaintext
Copiar
Editar
info: ProfileBackgroundService[0]
      ProfileBackgroundService started.
info: ProfileBackgroundService[0]
      Profile Admin: CanEdit changed to False.
info: ProfileBackgroundService[0]
      ProfileBackgroundService completed update at 2025-04-26T14:23:45.234Z

---

## 🔥 Future Improvements
- Persist profiles in a database
- Implement authentication and authorization for API endpoints
- Allow configuring the BackgroundService update interval
- Add unit and integration tests
