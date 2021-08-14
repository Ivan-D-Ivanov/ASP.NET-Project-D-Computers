using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DavinoComputers.Data.Migrations
{
    public partial class AddedShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCart_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PcBuildShoppingCart",
                columns: table => new
                {
                    PcBuildsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcBuildShoppingCart", x => new { x.PcBuildsId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_PcBuildShoppingCart_PcBuilds_PcBuildsId",
                        column: x => x.PcBuildsId,
                        principalTable: "PcBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PcBuildShoppingCart_ShoppingCart_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductShoppingCart",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    ShoppingCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShoppingCart", x => new { x.ProductsId, x.ShoppingCartsId });
                    table.ForeignKey(
                        name: "FK_ProductShoppingCart_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductShoppingCart_ShoppingCart_ShoppingCartsId",
                        column: x => x.ShoppingCartsId,
                        principalTable: "ShoppingCart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PcBuildShoppingCart_ShoppingCartsId",
                table: "PcBuildShoppingCart",
                column: "ShoppingCartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShoppingCart_ShoppingCartsId",
                table: "ProductShoppingCart",
                column: "ShoppingCartsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_ApplicationUserId",
                table: "ShoppingCart",
                column: "ApplicationUserId",
                unique: true,
                filter: "[ApplicationUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCart_IsDeleted",
                table: "ShoppingCart",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PcBuildShoppingCart");

            migrationBuilder.DropTable(
                name: "ProductShoppingCart");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "AspNetUsers");
        }
    }
}
