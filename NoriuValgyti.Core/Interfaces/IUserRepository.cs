using NoriuValgyti.Domain.Entities;

namespace NoriuValgyti.Core.Interfaces;

public interface IUserRepository
{
    User GetById(Guid id);
    User PostUser(User user);
    User? GetByEmailOrDefault(string email);
}