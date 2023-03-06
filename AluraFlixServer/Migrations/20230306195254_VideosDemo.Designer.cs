﻿// <auto-generated />
using System;
using AluraFlixServer.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AluraFlixServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230306195254_VideosDemo")]
    partial class VideosDemo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AluraFlixServer.Models.Video", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cba0e571-f2dd-4abb-91aa-cea6bdb82598"),
                            Description = "O anime mais injustiçado da temporada (na minha humilde opinião haha) voltou! Nier Automata 1.1a ep. 4 comentado em detalhes aqui pra vocês.",
                            Title = "QUE BATALHA EMOCIONANTE!! ELE VOLTOU!",
                            Url = "https://www.youtube.com/watch?v=zZvRCSlkH18"
                        },
                        new
                        {
                            Id = new Guid("1ef44de0-57cc-4002-9323-5d0362e8e3de"),
                            Description = "2V2  @prohooper4533    Nosso SEGUNDO desafio do grupo de racha, as próximas semanas, vou fazer um vídeo explicando o intuito dos novos desafio aqui do canal e do PRO HOOPER, espero que vocês gostem e até o próximo video familina, tmj!",
                            Title = "ARREMESSEI IGUAL O STEPHEN CURRY E ACABEI COM O JOGO!!!",
                            Url = "https://www.youtube.com/watch?v=GIYtwPu5Heo&t=166s"
                        },
                        new
                        {
                            Id = new Guid("2fa6ea31-d3c1-4ebb-8589-50a1f4978b6b"),
                            Description = "Depoimento Ange Emanuelle na Alura",
                            Title = "Dev Front-end: a trajetória de uma programadora e Alura Star | Angela Emanuelle",
                            Url = "https://www.youtube.com/watch?v=ODEgEk83PLA"
                        },
                        new
                        {
                            Id = new Guid("e4bf1d7b-11c8-4a35-9a8e-64aece75336f"),
                            Description = "Kang VS THANOS, EINERD explicação com Peter JORDAN",
                            Title = "DEFINITIVO! KANG VS THANOS, QUEM É O PIOR E MAIS CRUEL?",
                            Url = "https://www.youtube.com/watch?v=umTFii323Lg"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
