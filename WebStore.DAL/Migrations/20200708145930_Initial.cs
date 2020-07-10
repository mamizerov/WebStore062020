using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStore.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TProductBrands",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TProductSections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProductSections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProductSections_TProductSections_ParentId",
                        column: x => x.ParentId,
                        principalTable: "TProductSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Order = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TProducts_TProductBrands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "TProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TProducts_TProductSections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "TProductSections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TProducts_BrandId",
                table: "TProducts",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_TProducts_SectionId",
                table: "TProducts",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TProductSections_ParentId",
                table: "TProductSections",
                column: "ParentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TProducts");

            migrationBuilder.DropTable(
                name: "TProductBrands");

            migrationBuilder.DropTable(
                name: "TProductSections");
        }
    }
}
