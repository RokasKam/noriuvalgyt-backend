
using NoriuValgyti.Core.Responses.User;

namespace NoriuValgyti.Core.Interfaces;

public interface IUserService
{
    UserResponse GetById(Guid id);
}