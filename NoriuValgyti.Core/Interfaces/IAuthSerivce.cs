

using NoriuValgyti.Core.Requests.User;
using NoriuValgyti.Core.Responses.User;

namespace NoriuValgyti.Core.Interfaces;
public record HashPasswordResponse(byte[] PasswordHash, byte[] PasswordSalt);

public interface IAuthService
{
    HashPasswordResponse HashPassword(string password);

    UserResponse Login(LoginRequest login);

    RegistrationResponse Register(RegisterRequest register);
    
}