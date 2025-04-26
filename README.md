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

The `ProfileBackgroundService` is responsible for periodically updating profile parameters without user intervention.

- Runs **every 5 minutes**.
- Toggles the `CanEdit` parameter between `"true"` and `"false"`.
- Logs the start, each profile update, and completion of each cycle.
- Uses `IServiceScopeFactory` to resolve services inside the background task safely.

**Summary**: It simulates a real-time update environment for profile data by automatically modifying profile attributes over time.

---

## 📝 Example Log Output

```plaintext
info: ProfileBackgroundService[0]
      ProfileBackgroundService started.
info: ProfileBackgroundService[0]
      Profile Admin: CanEdit changed to False.
info: ProfileBackgroundService[0]
      Profile User: CanEdit changed to True.
info: ProfileBackgroundService[0]
      ProfileBackgroundService completed update at 2025-04-26T14:23:45.234Z
```

---

## 🔥 Future Improvements

- 💾 **Persistence**: Store profiles in a database (e.g., SQL Server, MongoDB).
- 🔐 **Security**: Add authentication and authorization to protect endpoints.
- 🛠️ **Configuration**: Make the update interval configurable via `appsettings.json`.
- 🧪 **Testing**: Add unit tests and integration tests for services and controllers.
- 📈 **Metrics**: Integrate monitoring for BackgroundService execution.
- 🌐 **Docker Support**: Create a Dockerfile to containerize the application.
