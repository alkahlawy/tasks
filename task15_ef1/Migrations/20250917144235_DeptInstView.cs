using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task15_ef1.Migrations
{
    /// <inheritdoc />
    public partial class DeptInstView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW DepartmentAndInstructors
                WITH Encryption, SCHEMABINDING
                AS
                SELECT 
                    d.ID AS 'Department ID',
                    d.Name AS 'Department Name',
                    i.Name AS 'Instructor Name'
                FROM 
                    dbo.Department d
                LEFT OUTER JOIN 
                    dbo.Instructor i ON d.ID = i.Dept_ID");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS DepartmentAndInstructors");
        }
    }
}
