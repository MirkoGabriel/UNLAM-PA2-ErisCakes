using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ErisCakesWebApi.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BakeryRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kind = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ingredients = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryRecipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BakeryRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimateDeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstimatedPrice = table.Column<double>(type: "float", nullable: false),
                    AdditionalComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobScore = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BakeryRequest_Client",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BakeryRequestRecipes",
                columns: table => new
                {
                    BakeryRequestId = table.Column<int>(type: "int", nullable: false),
                    BakeryRecipeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BakeryRequestRecipes", x => new { x.BakeryRequestId, x.BakeryRecipeId });
                    table.ForeignKey(
                        name: "FK_BakeryRequestRecipe_BakeryRecipe",
                        column: x => x.BakeryRecipeId,
                        principalTable: "BakeryRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BakeryRequestRecipe_BakeryRequest",
                        column: x => x.BakeryRequestId,
                        principalTable: "BakeryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BakeryRequestRecipes_BakeryRecipeId",
                table: "BakeryRequestRecipes",
                column: "BakeryRecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_BakeryRequests_ClientId",
                table: "BakeryRequests",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BakeryRequestRecipes");

            migrationBuilder.DropTable(
                name: "BakeryRecipes");

            migrationBuilder.DropTable(
                name: "BakeryRequests");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
