using Doomsday4.Common.Domain;

namespace Doomsday4.Domain;

public class User : Entity<Guid>
{
    private User()
    {
    }

    public User(string phoneNumber, string password, string email, string lastName, string firstName, UserRole userRole)
    {
        Id = Guid.NewGuid();
        PhoneNumber = phoneNumber;
        Password = password;
        Email = email;
        LastName = lastName;
        FirstName = firstName;
        UserRole = userRole;
    }

    public string PhoneNumber { get; }
    public string Password { get; }
    public string Email { get; }
    public string LastName { get; }
    public string FirstName { get; }
    public UserRole UserRole { get; }
}