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
    public class CompanyRepsoitoryDapper : ICompanyRepository
    {
        IDbConnection db;

        public CompanyRepsoitoryDapper(IConfiguration configuration)
        {
            db = new SqlConnection(configuration.GetConnectionString("SqlServer"));
        }

        public void Add(Company company)
        {
            var query = "INSERT INTO Companies (CompanyName,CompanyCity) " +
                "VALUES (@CompanyName,@CompanyCity) ";
            db.Query(query, new
            {
                company.CompanyName,
                company.CompanyCity
            });
        }
        public void Delete(Company company)
        {
            string query = "DELETE FROM Companies WHERE CompanyId = @Id";
            db.Execute(query, new { @id = company.CompanyId });
        }

        public List<Company> GetAll()
        {
            var query = "SELECT * FROM Companies";
            return db.Query<Company>(query).ToList();
        }

        public Company GetById(int id)
        {
            var query = "SELECT * FROM Companies WHERE CompanyId=@id";
            return db.Query<Company>(query, new { @id = id }).SingleOrDefault();
        }

        public void Update(Company company)
        {
            string query = "UPDATE Companies SET" +
                " CompanyName = @CompanyName, CompanyCity = @CompanyCity " +
                "Where CompanyId = @CompanyId";
            db.Execute(query, new
            {
                @CompanyId = company.CompanyId,
                @CompanyName = company.CompanyName,
                @CompanyCity = company.CompanyCity,
            });
        }
    }
}
