using Doomsday4.Application.User.Command;
using Doomsday4.Domain;
using Doomsday4.Domain.Data;
using MediatR;

namespace Doomsday4.Application.User.CommandHandlers;

public class AddNewUserHandler(RentDbContext context) : IRequestHandler<AddNewUser, Guid>
{
    public async Task<Guid> Handle(AddNewUser command, CancellationToken cancellationToken)
    {
        var newUser = await context.Users.AddAsync(new Domain.Models.User(command.PhoneNumber, command.Password, command.Email,
            command.LastName, command.FirstName, command.UserRole));
        await context.SaveChangesAsync();
        
        //Найти пользователя: По определеному телефона
        // var user = context.Users.FirstOrDefault(u => u.PhoneNumber == "89515521042");
        // var admins = context.Users.Where(u => u.UserRole == UserRole.Admin);
        // var fullNames = context.Users.Select(u => $"{u.FirstName} {u.LastName}");
        
        return newUser.Entity.Id;
    }
}