using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AutoMapper;

namespace AluraFlixServer.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserRequest, User>();
    }
}
