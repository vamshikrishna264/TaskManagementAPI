# TaskManagementAPI

A simple ASP.NET Core Web API for managing tasks, users, and task comments with JWT authentication and role-based authorization.

---

##  Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger (OpenAPI)
- LINQ
## Setup Instructions
•	1. I Added the repository from Visual Studio and push the code to the created repository

•	2. Update your SQL Server connection string in appsettings.json for connection of string

•	3. Apply migrations and create the database from package manager console
•	   Add-Migration  SeedInitial   //to add the seed data
•	   update-database

•	4. Run the application
•	   run

•	5. Access Swagger UI at localhost
Features
•	Create a new task (Admin only)
•	View task details by ID
•	Get all tasks assigned to a specific user
•	Automatically adds a user if they don’t exist when assigning a task
•	Adds a task comment associated with a user and task
•	Handles circular references using ReferenceHandler.Preserve for JSON Serialization

Authentication
•	JWT-based authentication is used.
•	Pass token in the Authorization header:
•	Authorization: Bearer {your_token}

Roles:
•	- Admin: Can create tasks
•	- User: Can view their assigned tasks
Sample Payload
•	POST /api/task (Admin Only)
•	{
•	  "Taskname": "Fix Login Bug",
•	  "Assigned_Userid": 1,
•	  "Username": "Alice",
•	  "TaskComment": "Investigate login issue on Chrome"
•	}
Notes
•	The API uses auto-incrementing primary keys.
•	EF Core relationships are modeled with navigation properties and foreign keys.
•	If the user with Assigned_Userid does not exist, it will attempt to create a new user with the provided Usernam
