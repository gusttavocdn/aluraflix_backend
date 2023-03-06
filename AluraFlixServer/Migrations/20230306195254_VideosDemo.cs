using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AluraFlixServer.Migrations
{
    /// <inheritdoc />
    public partial class VideosDemo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Videos",
                columns: new[] { "Id", "Description", "Title", "Url" },
                values: new object[,]
                {
                    { new Guid("1ef44de0-57cc-4002-9323-5d0362e8e3de"), "2V2  @prohooper4533    Nosso SEGUNDO desafio do grupo de racha, as próximas semanas, vou fazer um vídeo explicando o intuito dos novos desafio aqui do canal e do PRO HOOPER, espero que vocês gostem e até o próximo video familina, tmj!", "ARREMESSEI IGUAL O STEPHEN CURRY E ACABEI COM O JOGO!!!", "https://www.youtube.com/watch?v=GIYtwPu5Heo&t=166s" },
                    { new Guid("2fa6ea31-d3c1-4ebb-8589-50a1f4978b6b"), "Depoimento Ange Emanuelle na Alura", "Dev Front-end: a trajetória de uma programadora e Alura Star | Angela Emanuelle", "https://www.youtube.com/watch?v=ODEgEk83PLA" },
                    { new Guid("cba0e571-f2dd-4abb-91aa-cea6bdb82598"), "O anime mais injustiçado da temporada (na minha humilde opinião haha) voltou! Nier Automata 1.1a ep. 4 comentado em detalhes aqui pra vocês.", "QUE BATALHA EMOCIONANTE!! ELE VOLTOU!", "https://www.youtube.com/watch?v=zZvRCSlkH18" },
                    { new Guid("e4bf1d7b-11c8-4a35-9a8e-64aece75336f"), "Kang VS THANOS, EINERD explicação com Peter JORDAN", "DEFINITIVO! KANG VS THANOS, QUEM É O PIOR E MAIS CRUEL?", "https://www.youtube.com/watch?v=umTFii323Lg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("1ef44de0-57cc-4002-9323-5d0362e8e3de"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("2fa6ea31-d3c1-4ebb-8589-50a1f4978b6b"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("cba0e571-f2dd-4abb-91aa-cea6bdb82598"));

            migrationBuilder.DeleteData(
                table: "Videos",
                keyColumn: "Id",
                keyValue: new Guid("e4bf1d7b-11c8-4a35-9a8e-64aece75336f"));
        }
    }
}
