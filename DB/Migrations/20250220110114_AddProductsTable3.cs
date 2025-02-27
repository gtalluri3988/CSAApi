using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DB.Migrations
{
    /// <inheritdoc />
    public partial class AddProductsTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO LoginHistory (date, UserName, ip,recaptchascore,response,jwttokenexpirydate,online)" +
               " VALUES (getdate(), 'JohnDoe1','123','0','Ok' ,getdate(),1)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from LoginHistory where ID=15");
        }
    }
}
