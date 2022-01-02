using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using PracticeDapper.Contracts;
using PracticeDapper.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PracticeDapper.Repository
{
    public class EmployeeRepositoryDapper : IEmployeeRepository
    {
        IDbConnection db;

        public EmployeeRepositoryDapper(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("SqlServer"));
        }

        public void Add(Employee employee)
        {
            var query = "INSERT INTO Employees (Name,Age,CompanyId) " +
                "VALUES (@Name,@Age,@CompanyId) ";
            db.Query(query, new
            {
                employee.Name,
                employee.Age,
                employee.CompanyId
            });
        }

        public void Delete(Employee employee)
        {
            string query = "DELETE FROM Employees WHERE EmployeeId = @Id";
            db.Execute(query, new { @id = employee.EmployeeId });
        }

        public List<Employee> GetAll()
        {
            var query = "SELECT * FROM Employees";
            return db.Query<Employee>(query).ToList();
        }

        public Employee GetById(int id)
        {
            var query = "SELECT * FROM Employees WHERE EmployeeId=@id";
            return db.Query<Employee>(query, new { @id = id }).SingleOrDefault();
        }

        public void Update(Employee employee)
        {
            string query = "UPDATE Employees SET" +
                " Name = @Name, Age = @Age , CompanyId = @CompanyId  " +
                "Where EmployeeId = @EmployeeId";
            db.Execute(query, new
            {
                @EmployeeId = employee.EmployeeId,
                @Name = employee.Name,
                @Age = employee.Age,
                @CompanyId = employee.CompanyId
            });
        }
    }
}
