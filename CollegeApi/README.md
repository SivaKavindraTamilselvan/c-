## Objective

Create a small RESTful API that manages a resource (e.g., Products, Orders, or Books) using [ASP.NET](http://ASP.NET) Core.

## 📋 Requirements

- [x]  Set up a new [ASP.NET](http://ASP.NET) Core Web API project with routing and controllers
- [x]  Implement a service layer and register services using [ASP.NET](http://ASP.NET) Core's dependency injection
- [x]  Use Entity Framework Core with an in-memory database (or SQLite) to perform CRUD operations
- [x]  Use `async`/`await` in controller actions to handle database operations
- [x]  Implement middleware or filters for global exception handling
- [ ]  Integrate basic logging to record actions and errors
- [ ]  Write unit tests for your controllers and services
- [ ]  Document the API endpoints using Swagger
- [ ]  (Optional) Implement the Repository and Unit of Work patterns
- [ ]  (Optional) Add custom middleware for request/response logging or authentication

## steps

create the student data model

Creates your database class
: DbContext means it inherits all EF Core database powers
Think of it as the bridge between C# and the database

Constructor — receives database settings
options contains which database to use (in-memory, SQLite, etc.)
: base(options) passes settings up to EF Core's own constructor
Program.cs provides these options automatically via DI

Add db context "Hey, I have a database class called CollegeDb — please manage it for me. Create it when needed, inject it where needed, and destroy it when done."
Take the options I received and pass them up to my parent class DbContext - base options
DbSet - make the database

Program.cs sets options (UseInMemoryDatabase)

AppDbContext receives options in constructor

DbSet<Student> Students = the actual table

Repository queries _context.Students

await database.Students.ToListAsync();ToListAsync() means:

"Go to the Students table, fetch ALL rows, and put them into a List"

Services.AddScoped<IStudentRepository, StudentRepository>();
This tells ASP.NET:

"When anyone asks for IStudentRepository, give them a StudentRepository object. Create ONE per request and destroy it when request is done."