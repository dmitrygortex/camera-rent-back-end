using Doomsday4.Domain;
using Doomsday4.Domain.Models;

namespace Doomsday4.Application.User.UserDto;

public class UserDto
{
    public UserDto(Guid userId, string phoneNumber, string password, string email, string lastName, string firstName, UserRole userRole)
    {
        UserId = userId;
        PhoneNumber = phoneNumber;
        Password = password;
        Email = email;
        LastName = lastName;
        FirstName = firstName;
        UserRole = userRole;
    }

    public Guid UserId { get; private set; }
    public string PhoneNumber { get; private set;}
    public string Password { get; private set;}
    public string Email { get; private set;}
    public string LastName { get; private set;}
    public string FirstName { get; private set;}
    public List<Domain.Models.Order> Orders { get; private set;} = new List<Domain.Models.Order>();
    public UserRole UserRole { get; private set;}
}