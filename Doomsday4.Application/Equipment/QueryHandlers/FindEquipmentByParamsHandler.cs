using Doomsday4.Application.Equipment.Models;
using Doomsday4.Application.Equipment.Query;
using Doomsday4.Domain.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Doomsday4.Application.Equipment.QueryHandlers;

public class FindEquipmentByParamsHandler(RentDbContext context) : IRequestHandler<FindEquipmentByParams, EquipmentInfo>
{
    public async Task<EquipmentInfo?> Handle(FindEquipmentByParams command, CancellationToken cancellationToken)
    {
        var equipment = await context.Equipments.FirstOrDefaultAsync(u => (u.Description == command.Description) && (u.Name == command.Name) && (u.Category == command.Category) , cancellationToken: cancellationToken);
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