namespace DavinoComputers.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedCategoryServiceAndPcBuildEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PcBuildId",
                table: "Images",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PcBuildId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PcBuilds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcBuilds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PcBuildProduct",
                columns: table => new
                {
                    PcBuildsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PcBuildProduct", x => new { x.PcBuildsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_PcBuildProduct_PcBuilds_PcBuildsId",
                        column: x => x.PcBuildsId,
                        principalTable: "PcBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PcBuildProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_PcBuildId",
                table: "Images",
                column: "PcBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PcBuildId",
                table: "Comments",
                column: "PcBuildId");

            migrationBuilder.CreateIndex(
                name: "IX_PcBuildProduct_ProductsId",
                table: "PcBuildProduct",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_PcBuilds_IsDeleted",
                table: "PcBuilds",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_PcBuilds_PcBuildId",
                table: "Comments",
                column: "PcBuildId",
                principalTable: "PcBuilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Images_PcBuilds_PcBuildId",
                table: "Images",
                column: "PcBuildId",
                principalTable: "PcBuilds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_PcBuilds_PcBuildId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_PcBuilds_PcBuildId",
                table: "Images");

            migrationBuilder.DropTable(
                name: "PcBuildProduct");

            migrationBuilder.DropTable(
                name: "PcBuilds");

            migrationBuilder.DropIndex(
                name: "IX_Images_PcBuildId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Comments_PcBuildId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "PcBuildId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "PcBuildId",
                table: "Comments");
        }
    }
}
