using NoriuValgyti.Core.Interfaces;
using NoriuValgyti.Domain.Entities;
using NoriuValgyti.Infrastructure.Data;

namespace NoriuValgyti.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly NoriuValgytiDataContext _dbContext;

    public UserRepository(NoriuValgytiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public User GetById(Guid id)
    {
        var user = _dbContext.Users.First(u => u.Id == id);

        return user;    }

    public User PostUser(User user)
    {
        user.Id = Guid.NewGuid();
        _dbContext.Users.Add(user); 
        _dbContext.SaveChanges();
        return user;
    }

    public User? GetByEmailOrDefault(string email)
    {
        var user =  _dbContext.Users.FirstOrDefault(u => u.Email == email);
        return user;
        
    }
}