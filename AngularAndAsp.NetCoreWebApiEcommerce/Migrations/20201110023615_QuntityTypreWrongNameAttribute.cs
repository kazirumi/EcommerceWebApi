using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Migrations
{
    public partial class QuntityTypreWrongNameAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpecialTagName",
                table: "QuantityType",
                newName: "QuantityTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "QuantityTypeName",
                table: "QuantityType",
                newName: "SpecialTagName");
        }
    }
}
