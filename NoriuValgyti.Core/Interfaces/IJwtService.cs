using NoriuValgyti.Core.Responses.User;

namespace NoriuValgyti.Core.Interfaces;

public interface IJwtService
{
    public JwtResponse BuildJwt(UserResponse user);
}