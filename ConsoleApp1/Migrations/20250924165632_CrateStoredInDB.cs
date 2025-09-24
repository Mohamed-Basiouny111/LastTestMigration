using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp1.Migrations
{
    /// <inheritdoc />
    public partial class CrateStoredInDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Create Stored in DB 
            string str = @"SET ANSI_NULLS ON
                              GO
                              SET QUOTED_IDENTIFIER ON
                              GO
                              CREATE PROCEDURE LoadDepartment
                              AS
                              BEGIN
                              	SET NOCOUNT ON;
                              	Select * from Departments
                              END
                              GO";

            migrationBuilder.Sql(str);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
