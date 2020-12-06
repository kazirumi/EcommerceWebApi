using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Migrations
{
    public partial class ProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    price = table.Column<decimal>(nullable: false),
                    QuantityTypeID = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    IsAvailable = table.Column<bool>(nullable: false),
                    ProductColor = table.Column<string>(nullable: false),
                    ProductTypeId = table.Column<int>(nullable: false),
                    SpecialTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_QuantityType_QuantityTypeID",
                        column: x => x.QuantityTypeID,
                        principalTable: "QuantityType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_SpecialTag_SpecialTagId",
                        column: x => x.SpecialTagId,
                        principalTable: "SpecialTag",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeId",
                table: "Product",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_QuantityTypeID",
                table: "Product",
                column: "QuantityTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SpecialTagId",
                table: "Product",
                column: "SpecialTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
