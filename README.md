# EF Core Assignment (day 1)
1. Create a Web API project.
2. Install EF core into the project using SQL Server
3. Create model:
- Departments(Id, Name)
- Projects(Id, Name)
- Employees (Id, Name, DepartmentId, JoinedDate)
- Project_Employee (ProjectId, EmployeeId, Enable)
- Salaries(Id, EmployeeId, Salary)
4. Create relationships.
- Create one-one relationship Employees and Salaries
- Create one-many relationship: Department – Employee
- Create many-many relationship : Project - Employee
5. Use Fluent API/Data annotation to add some constraints. (Required, MaxLength)
6. Migrations
7. Seeding data for Departments table
- Software Development
- Finance
- Accountant
- HR

# On the solution
1. You should have SQL Server and .NET 8.0 SDK installed on your pc
2. In the project WebAPI appsettings.json, replace the connection string with your own, then open terminal and run
```bash
dotnet ef database update
```
