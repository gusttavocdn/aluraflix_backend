using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AluraFlixServer.Migrations
{
    public partial class CreateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("1eddffeb-990b-4126-9bd4-f5be76b92212"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("967bc22d-1b2e-43a5-a418-0f9f77451ac5"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("9adef798-a5fe-4a53-89a7-aaad27ba1554"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("c6de1e62-0b2b-4647-87cb-4eca4b6d8234"));

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Categories",
                newName: "Color");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "CategoryId", "Description", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("4edc4fc9-8da8-4494-8d96-d283541f73f3"), 1, "O anime mais injustiçado da temporada (na minha humilde opinião haha) voltou! Nier Automata 1.1a ep. 4 comentado em detalhes aqui pra vocês.", "QUE BATALHA EMOCIONANTE!! ELE VOLTOU!", "https://www.youtube.com/watch?v=zZvRCSlkH18" },
                    { new Guid("6ab33bb2-cbd4-4446-81d4-c3efd739f2e1"), 1, "Depoimento Ange Emanuelle na Alura", "Dev Front-end: a trajetória de uma programadora e Alura Star | Angela Emanuelle", "https://www.youtube.com/watch?v=ODEgEk83PLA" },
                    { new Guid("a266184a-afbb-4446-a1f5-361785f9af45"), 1, "2V2  @prohooper4533    Nosso SEGUNDO desafio do grupo de racha, as próximas semanas, vou fazer um vídeo explicando o intuito dos novos desafio aqui do canal e do PRO HOOPER, espero que vocês gostem e até o próximo video familina, tmj!", "ARREMESSEI IGUAL O STEPHEN CURRY E ACABEI COM O JOGO!!!", "https://www.youtube.com/watch?v=GIYtwPu5Heo&t=166s" },
                    { new Guid("c7384eb0-4876-4ec6-84c3-f12b324abaa6"), 1, "Kang VS THANOS, EINERD explicação com Peter JORDAN", "DEFINITIVO! KANG VS THANOS, QUEM É O PIOR E MAIS CRUEL?", "https://www.youtube.com/watch?v=umTFii323Lg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("4edc4fc9-8da8-4494-8d96-d283541f73f3"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("6ab33bb2-cbd4-4446-81d4-c3efd739f2e1"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("a266184a-afbb-4446-a1f5-361785f9af45"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("c7384eb0-4876-4ec6-84c3-f12b324abaa6"));

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Categories",
                newName: "color");

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
        }
    }
}
