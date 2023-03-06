using AluraFlixServer.Models;
using Microsoft.EntityFrameworkCore;

namespace AluraFlixServer.Data;

public static class ModelBuilderExtensions
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Video>().HasData(
            new Video() { 
                Title = "QUE BATALHA EMOCIONANTE!! ELE VOLTOU!", 
                Description = "O anime mais injustiçado da temporada (na minha humilde opinião haha) voltou! Nier Automata 1.1a ep. 4 comentado em detalhes aqui pra vocês.", 
                Url = "https://www.youtube.com/watch?v=zZvRCSlkH18"
                
            },
            
            new Video()
            {
                Title= "ARREMESSEI IGUAL O STEPHEN CURRY E ACABEI COM O JOGO!!!",
                Description = "2V2  @prohooper4533    Nosso SEGUNDO desafio do grupo de racha, as próximas semanas, vou fazer um vídeo explicando o intuito dos novos desafio aqui do canal e do PRO HOOPER, espero que vocês gostem e até o próximo video familina, tmj!",
                Url = "https://www.youtube.com/watch?v=GIYtwPu5Heo&t=166s"
            },
            
            new Video()
            {
                Title = "Dev Front-end: a trajetória de uma programadora e Alura Star | Angela Emanuelle",
                Description = "Depoimento Ange Emanuelle na Alura",
                Url = "https://www.youtube.com/watch?v=ODEgEk83PLA"
            },
            new Video()
            {
                Title  = "DEFINITIVO! KANG VS THANOS, QUEM É O PIOR E MAIS CRUEL?",
                Description = "Kang VS THANOS, EINERD explicação com Peter JORDAN",
                Url = "https://www.youtube.com/watch?v=umTFii323Lg"
            }
        );
    }
}
