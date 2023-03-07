using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AluraFlixServer.Migrations
{
    /// <inheritdoc />
    public partial class CreateCategoryAndVideos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    color = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Videos_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title", "color" },
                values: new object[] { 1, "LIVRE", "#FFFFFF" });

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "Description", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("1eddffeb-990b-4126-9bd4-f5be76b92212"), 1, "O anime mais injustiçado da temporada (na minha humilde opinião haha) voltou! Nier Automata 1.1a ep. 4 comentado em detalhes aqui pra vocês.", "QUE BATALHA EMOCIONANTE!! ELE VOLTOU!", "https://www.youtube.com/watch?v=zZvRCSlkH18" },
                    { new Guid("967bc22d-1b2e-43a5-a418-0f9f77451ac5"), 1, "Depoimento Ange Emanuelle na Alura", "Dev Front-end: a trajetória de uma programadora e Alura Star | Angela Emanuelle", "https://www.youtube.com/watch?v=ODEgEk83PLA" },
                    { new Guid("9adef798-a5fe-4a53-89a7-aaad27ba1554"), 1, "Kang VS THANOS, EINERD explicação com Peter JORDAN", "DEFINITIVO! KANG VS THANOS, QUEM É O PIOR E MAIS CRUEL?", "https://www.youtube.com/watch?v=umTFii323Lg" },
                    { new Guid("c6de1e62-0b2b-4647-87cb-4eca4b6d8234"), 1, "2V2  @prohooper4533    Nosso SEGUNDO desafio do grupo de racha, as próximas semanas, vou fazer um vídeo explicando o intuito dos novos desafio aqui do canal e do PRO HOOPER, espero que vocês gostem e até o próximo video familina, tmj!", "ARREMESSEI IGUAL O STEPHEN CURRY E ACABEI COM O JOGO!!!", "https://www.youtube.com/watch?v=GIYtwPu5Heo&t=166s" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Videos_CategoryId",
                table: "Videos",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
