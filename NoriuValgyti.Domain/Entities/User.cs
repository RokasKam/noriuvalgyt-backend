namespace NoriuValgyti.Domain.Entities;

public class User : BaseEntity
{
    public string Nickname { get; set; }

    public string Email { get; set; }

    public byte[] PasswordHash { get; set; }

    public byte[] PasswordSalt { get; set; }
}