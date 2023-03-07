using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AutoMapper;

namespace AluraFlixServer.Profiles;

public class VideoProfile : Profile
{
    public VideoProfile()
    {
        CreateMap<VideoRequest, Video>();
        CreateMap<Video, VideoResponse>();
        CreateMap<Video, VideoRequest>();
    }
}