using Microsoft.EntityFrameworkCore.Migrations;

namespace PracticeDapper.Migrations
{
    public partial class StoreProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                    CREATE PROC use_GetCompanies
                    AS
                    BEGIN
                    SELECT * FORM Companies 
                    END
                    GO");

            migrationBuilder.Sql(@"
                    CREATE PROC use_GetCompany
                    @CompanyId int 
                    AS
                    BEGIN
                    SELECT * FORM Companies 
                    WHERE CompanyId = @CompanyId
                    END
                    GO");

            migrationBuilder.Sql(@"
                    CREATE PROC use_AddCompany
                    @CompanyName
                    @CompanyCity
                    AS
                    BEGIN
                    INSERT INTO Companies (CompanyName,CompanyCity) 
                    VALUES (@CompanyName,@CompanyCity)
                    END
                    GO");

            migrationBuilder.Sql(@"
                    CREATE PROC use_UpdateCompany
                    @CompanyName
                    @CompanyCity
                    AS
                    BEGIN
                    UPDATE Companies SET
                    CompanyName = @CompanyName, CompanyCity = @CompanyCity
                    Where CompanyId = @CompanyId
                    END
                    GO");

            migrationBuilder.Sql(@"
                    CREATE PROC use_DeleteCompany
                    @Id
                    AS
                    BEGIN
                    DELETE FROM Companies WHERE CompanyId = @Id
                    END
                    GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
