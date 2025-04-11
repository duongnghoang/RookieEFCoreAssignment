using System.Reflection;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Employee_StoredProcedures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var storedProcedures = new[]
            {
                """
                CREATE PROCEDURE [dbo].[GetAllEmployeesDepartmentName]
                AS
                BEGIN
                	SELECT 
                		[e].[Id], 
                		[e].[Name], 
                		[e].[JoinedDate], 
                		[d].[Name] AS [DepartmentName] 
                	FROM 
                		[dbo].[Employees] [e]
                	INNER JOIN 
                		[dbo].[Departments] [d] 
                	ON
                		[e].[DepartmentId] = [d].[Id]
                END
                """,

                "CREATE PROCEDURE GetEmployeeById @Id INT AS SELECT * FROM Employees WHERE Id = @Id",
                "CREATE PROCEDURE AddEmployee @Name NVARCHAR(100), @DepartmentId INT AS INSERT INTO Employees (Name, DepartmentId) VALUES (@Name, @DepartmentId)",
                "CREATE PROCEDURE UpdateEmployee @Id INT, @Name NVARCHAR(100), @DepartmentId INT AS UPDATE Employees SET Name = @Name, DepartmentId = @DepartmentId WHERE Id = @Id",
                "CREATE PROCEDURE DeleteEmployee @Id INT AS DELETE FROM Employees WHERE Id = @Id"
            };

            foreach (var procedure in storedProcedures)
            {
                migrationBuilder.Sql(procedure);
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var storedProcedures = new[]
            {
                "DROP PROCEDURE IF EXISTS GetAllEmployees",
                "DROP PROCEDURE IF EXISTS GetEmployeeById",
                "DROP PROCEDURE IF EXISTS AddEmployee",
                "DROP PROCEDURE IF EXISTS UpdateEmployee",
                "DROP PROCEDURE IF EXISTS DeleteEmployee"
            };
            foreach (var procedure in storedProcedures)
            {
                migrationBuilder.Sql(procedure);
            }
        }
    }
}
