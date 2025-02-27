using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class AddUsersUpdateLoginhistoryTable1stoptest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO LoginHistory (date, UserName, ip,recaptchascore,response,jwttokenexpirydate,online)" +
                " VALUES (getdate(), 'JohnDoe','123','0','Ok' ,getdate(),1)");
            

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users WHERE Id IN (10, 11)");
        }
    }
}
