NileRoutes 🌍
A .NET Web API for managing routes and regions across Egypt

NileRoutes is a backend application built with ASP.NET Core Web API that enables CRUD operations on regions and routes in Egypt, with authentication, image uploads, advanced querying, and a clean, maintainable architecture.

🚀 Features
Domain Models & EF Core – Code-first approach with DbContext

Repository Pattern – Decoupled data access

AutoMapper & DTOs – Clean data transfer

Data Validation – Built-in & custom validation attributes

Advanced Querying – Filtering, Sorting, Pagination

Authentication & Authorization – JWT with role-based access

Identity Integration – IdentityDbContext for user and role management

Secure API Testing – Authorization integrated with Swagger

Static File Serving – Image uploads directly from the API

Logging – Serilog for structured logging

API Versioning – Support for multiple API versions

DDD Principles – Cleaner, more maintainable architecture

MVC Client – Example MVC app consuming the API

🛠 Tech Stack
.NET 8

ASP.NET Core Web API

Entity Framework Core (Code-First)

SQL Server

AutoMapper

JWT Authentication & Identity

Serilog

⚡ Getting Started
1️⃣ Clone the repository
bash
Copy
Edit
git clone https://github.com/hishamwajeeh/NileRoutes.git
cd NileRoutes
2️⃣ Update database connection
Edit appsettings.json with your SQL Server connection string:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=NileRoutesDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
3️⃣ Apply migrations & seed data
bash
Copy
Edit
dotnet ef database update
4️⃣ Run the API
bash
Copy
Edit
dotnet run
🔐 Authentication
JWT Bearer Authentication

Supports Role-Based Authorization (e.g., Admin, User)

Swagger UI includes a lock icon 🔒 to authorize requests

📷 Image Uploads
Static files are served via the Web API, allowing route/region images to be uploaded and accessed.

📄 License
This project is licensed under the MIT License.


