# 🎮 GameZone

![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core_MVC-.NET_8-blue)
![C#](https://img.shields.io/badge/C%23-Programming-purple)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-ORM-green)
![SQL Server](https://img.shields.io/badge/SQL_Server-Database-red)
![Bootstrap](https://img.shields.io/badge/Bootstrap-5-blueviolet)

## 📌 Project Description

GameZone is a web application built with ASP.NET Core MVC (.NET 8) that allows users to browse and manage video games. The project follows the MVC design pattern and implements a Service Layer to separate business logic from controllers, resulting in a clean and maintainable architecture.

The application supports full CRUD operations, image uploads, category management, and device assignments, all within a responsive and user-friendly interface.

---

## ✨ Features

* Display all available games.
* View detailed information for each game.
* Add new games with cover image upload.
* Edit existing game information.
* Delete games with SweetAlert2 confirmation dialogs.
* Assign categories and supported devices to games.
* Responsive UI using Bootstrap 5.
* Enhanced dropdowns using Select2.
* Server-side validation using Data Annotations.

---

## 🛠️ Technologies Used

* ASP.NET Core MVC (.NET 8)
* C#
* Entity Framework Core
* SQL Server
* Razor Views
* Bootstrap 5
* jQuery
* SweetAlert2
* Select2

---

## 🏗️ Architecture

The project follows the MVC (Model-View-Controller) design pattern and utilizes:

* Service Layer
* ViewModels
* Entity Framework Core
* Repository-like separation of concerns

This structure improves maintainability, scalability, and code readability.

---

## 📂 Project Structure

```text
GameZone
│
├── Controllers/
├── Models/
├── ViewModels/
├── Services/
├── Data/
├── Views/
├── wwwroot/
│   ├── Images/
│   ├── CSS/
│   └── JS/
├── Migrations/
└── Program.cs
```

---

## 🚀 Getting Started

### Prerequisites

Before running the project, make sure you have:

* .NET 8 SDK
* SQL Server
* Visual Studio 2022
* Git

### Clone the Repository

```bash
git clone https://github.com/YourUsername/GameZone.git
cd GameZone
```

### Restore Dependencies

```bash
dotnet restore
```

### Build the Project

```bash
dotnet build
```

### Run the Application

```bash
dotnet run
```

The application will be available at:

```text
https://localhost:{port}
```

---

## 🗄️ Database Setup

Update your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=GameZone;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### Create Migration

```powershell
Add-Migration InitialCreate
```

### Apply Migration

```powershell
Update-Database
```

---

## 📸 Screenshots

### Home Page

<img width="1920" height="1818" alt="home_page" src="https://github.com/user-attachments/assets/a71f20a1-d8ef-4e13-a062-6f2eb138215d" />

### Games Page

<img width="1920" height="1120" alt="games_page" src="https://github.com/user-attachments/assets/992e139a-84d1-49bd-b071-46b803cbb028" />

### Game Details

<img width="1920" height="979" alt="DetailsPage" src="https://github.com/user-attachments/assets/cf8c7cd1-2c29-4a56-a147-abf06995d792" />

### Create Game

<img width="1920" height="1108" alt="CreateGame" src="https://github.com/user-attachments/assets/dd22c0d3-07a7-477d-b5e0-ab98d25c2d13" />

### Edit Game

<img width="1920" height="1117" alt="editPage" src="https://github.com/user-attachments/assets/9282c89f-f2fa-4d66-bdb8-9c3fb6016425" />

## 🎥 Demo Video

Watch the GameZone demo here:

[Watch Demo Video]([ضع_رابط_الفيديو_هنا](https://drive.google.com/drive/u/0/my-drive?sort=13&direction=a))










---

## 🎯 Key Functionalities

* Full CRUD Operations.
* Image Upload Support.
* Many-to-Many Relationship (Games & Devices).
* Entity Framework Core Integration.
* Category Management.
* Service Layer Implementation.
* Data Validation.
* SweetAlert2 Integration.
* Select2 Dropdown Enhancements.

---

## 🔮 Future Improvements

* Authentication & Authorization.
* Search and Filtering.
* Pagination.
* User Reviews & Ratings.
* REST API Integration.
* Dark Mode.
* Dashboard & Analytics.

---

## 👨‍💻 Author

**Moataz Mohamed**

* Full Stack .NET Developer
* Passionate about ASP.NET Core and Software Engineering.
* Currently learning advanced .NET technologies and building scalable web applications.

---

## ⭐ Support

If you found this project useful, please consider giving it a star on GitHub!
