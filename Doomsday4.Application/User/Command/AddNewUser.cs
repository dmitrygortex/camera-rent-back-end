using Doomsday4.Domain;
using MediatR;

namespace Doomsday4.Application.User.Command;

public class AddNewUser : IRequest<Guid> //Это void. А IRequest<object> - public object Name() {}
{
    public AddNewUser(string phoneNumber, string password, string email, string lastName, string firstName, UserRole userRole)
    {
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