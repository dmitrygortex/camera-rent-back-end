using Doomsday4.Application.Equipment;
using Doomsday4.Application.User.Command;
using Doomsday4.Domain;
using MediatR;

namespace Doomsday4.Api.Endpoints;

public static class EquipmentEndpoints
{
    public static WebApplication AddEquipmentEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup("/equipment");

        endpoints.MapPost("/add", async (IMediator mediator, Equipment equipment) =>
        {
            var result = await mediator.Send(new AddNewEquipment(equipment.Name, equipment.Description, 
                equipment.Price, equipment.Category, equipment.Status));
            return Results.Ok(result);
        });
        
        endpoints.MapPost("/update", async (IMediator mediator, UpdateEquipment equipment) =>
        {
            var result = await mediator.Send(new UpdateEquipment(equipment.LastEquipmentGuid, equipment.Name, 
                equipment.Description, equipment.Price, equipment.Status));
            
            return Results.Ok(result);
        });
        
        endpoints.MapPost("/find-by-id/{id}", async (IMediator mediator, FindEquipmentById equipment) =>
        {
            var result = await mediator.Send(new FindEquipmentById(equipment.Id));
            
            return Results.Ok(result);
        });
        
        return app;
    }
}