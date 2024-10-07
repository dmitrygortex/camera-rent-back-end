using Doomsday4.Application.Equipment.Models;
using Doomsday4.Application.User.Command;
using Doomsday4.Domain;
using Doomsday4.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Doomsday4.Application.Equipment;

public class FindEquipmentByIdHandler(RentDbContext context) : IRequestHandler<FindEquipmentById, EquipmentInfo>
{
    public async Task<EquipmentInfo?> Handle(FindEquipmentById command, CancellationToken cancellationToken)
    {
        var equipment = await context.Equipments.FirstOrDefaultAsync(u => u.Id == command.Id, cancellationToken: cancellationToken);
        if (equipment is null)
        {
            return null;
        }
        else
        {
            return new EquipmentInfo
            {
                Name = equipment.Name,
                Description = equipment.Description,
                Price = equipment.Price,
                Category = equipment.Category,
                Status = equipment.Status
            };
        }
    }
}