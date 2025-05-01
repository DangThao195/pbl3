using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PBL3_HK4.Migrations
{
    /// <inheritdoc />
    public partial class Mi4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ResetPasswordTokenExpiry",
                table: "Users",
                newName: "VerificationCodeExpiry");

            migrationBuilder.RenameColumn(
                name: "ResetPasswordToken",
                table: "Users",
                newName: "VerificationCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerificationCodeExpiry",
                table: "Users",
                newName: "ResetPasswordTokenExpiry");

            migrationBuilder.RenameColumn(
                name: "VerificationCode",
                table: "Users",
                newName: "ResetPasswordToken");
        }
    }
}
