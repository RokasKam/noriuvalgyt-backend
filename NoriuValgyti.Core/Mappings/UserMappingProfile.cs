using AutoMapper;
using NoriuValgyti.Core.Requests.User;
using NoriuValgyti.Core.Responses.User;
using NoriuValgyti.Domain.Entities;

namespace NoriuValgyti.Core.Mappings;

public class UserMappingProfile: Profile
{
    public UserMappingProfile()
    {
        CreateMap<User, UserResponse>();
        CreateMap<RegisterRequest, User>();
        CreateMap<LoginRequest, User>();
    }
}