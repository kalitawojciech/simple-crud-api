# Simple CRUD API
## Simple CRUD application created with ASP.NET Core 3.1<br/><br/>


# Running appliacation
1. Open Package Menager Console with default project: **CRUD.DAL**
2. Run command: **update-database**
3. Run application on **IIS Express**

<br/>

# Entities
* Book
* Author
* Category

<br/>![DB Diagram](docs\db_diagram.png)

<br/>

# Architecture
1. **CRUD.API** - web api
2. **CRUD.Services** - this layer is responsible for business logic
3. **CRUD.DAL** - this layer is responsible for accessing external resources like database