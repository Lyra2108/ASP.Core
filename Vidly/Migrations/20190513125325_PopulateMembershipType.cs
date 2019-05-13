using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Migrations
{
    public partial class PopulateMembershipType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO MembershipType (Id, SignUpFee, DurationInMonth, DiscountRate) VALUES (1, 0, 0, 0)");
            migrationBuilder.Sql(
                "INSERT INTO MembershipType (Id, SignUpFee, DurationInMonth, DiscountRate) VALUES (2, 30, 1, 10)");
            migrationBuilder.Sql(
                "INSERT INTO MembershipType (Id, SignUpFee, DurationInMonth, DiscountRate) VALUES (3, 90, 3, 15)");
            migrationBuilder.Sql(
                "INSERT INTO MembershipType (Id, SignUpFee, DurationInMonth, DiscountRate) VALUES (4, 300, 12, 20)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
