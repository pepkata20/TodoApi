# TodoApi

A simple ASP.NET Core Web API for managing todo items. This application demonstrates a RESTful API with CRUD operations using Entity Framework Core and MySQL (or in-memory database for testing).

## Features

- Create, read, update, and delete todo items
- Entity Framework Core with MySQL support
- Swagger UI for API exploration
- Unit tests with xUnit and in-memory database

## Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/mysql/) (for production use)
- (Optional) Visual Studio 2022 or later

## Getting Started

### 1. Clone the Repository

### 2. Configure the Database

Update the `DefaultConnection` string in `appsettings.json` with your MySQL server details:
"ConnectionStrings": { "DefaultConnection": "server=localhost;database=TodoDb;user=root;password=yourPassword;" }

### 3. Create the database
In Package Manager Console:  
  Add-Migration InitialCreate  
  Update-Database  


### 4. Run the Application


The API will be available at `https://localhost:7041` (or the port shown in the console).

### 5. Explore the API

Navigate to `https://localhost:7041/swagger/index.html` to view and test the API endpoints using Swagger UI.

## Running Tests

Unit tests are located in the `TodoApi.Tests` project. To run tests:  
dotnet test

## API Endpoints

- `GET /api/todo` - List all todo items
- `GET /api/todo/{id}` - Get a specific todo item
- `POST /api/todo` - Create a new todo item
- `PUT /api/todo/{id}` - Update an existing todo item
- `DELETE /api/todo/{id}` - Delete a todo item

## Project Structure

- `Controllers/` - API controllers
- `Models/` - Data models
- `Data/` - Entity Framework Core context
- `Migrations/` - Database migrations
- `TodoApi.Tests/` - Unit tests

## License

This project is licensed under the MIT License.

## AI Feedback  
### Was it easy to complete the task using AI?  
Overall yes.
### How long did task take you to complete?  
2-3 hours.
### Was the code ready to run after generation?  
Yes.
### What did you have to change to make it usable?
Just the connection string for the DB in the .json, the code seems to be working.
### Which challenges did you face during completion of the task?
Getting the initial outline of the project, i had to prompt a bunch of times with some tweaks to get something I liked. I also had some trouble setting up mysql and the connection.
### Which specific prompts you learned as a good practice to complete the task?  
"Help me with this task: "Create a RESTful API to manage a simple todo list application using ASP.NET Core, EF and MySQL. The application should allow users to create, read, update, and delete todo items. Each item should have a title and a description. Use EF.Core to persist the items in the database." "Acceptance Criteria:  There are all the required codes and configs in the repository to run the application.  There is a readme.md file with the application description and instructions on how to run it.  Code is of good quality and easy to read and understand.  There are unit tests in place, coverage >80%  There are quality checks (coverage, complexity, check style)  "
I will use visual studio"


