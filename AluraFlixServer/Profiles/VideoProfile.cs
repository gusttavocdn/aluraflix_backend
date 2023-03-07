using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AutoMapper;

namespace AluraFlixServer.Profiles;

public class VideoProfile : Profile
{
    public VideoProfile()
    {
        CreateMap<VideoDTO, Video>();
        CreateMap<Video, ReadVideoDTO>();
        CreateMap<Video, VideoDTO>();
    }
}
