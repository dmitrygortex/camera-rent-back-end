using Doomsday4.Application.Equipment.Command;
using Doomsday4.Domain.Data;
using Doomsday4.Domain.Models;
using FluentValidation;
using MediatR;

namespace Doomsday4.Application.Equipment.CommandHandlers;

public class UpdateEquipmentHandler(RentDbContext context, 
    IValidator<(string OldName, string NewName)> nameValidator,
    IValidator<(string OldDescription, string NewDescription)> descriptionValidator,
    IValidator<(double OldPrice, double NewPrice)> priceValidator,
    IValidator<(EquipmentStatus OldStatus, EquipmentStatus NewStatus)> statusValidator) : IRequestHandler<UpdateEquipment, Guid>
{
    
    
    public async Task<Guid> Handle(UpdateEquipment command, CancellationToken cancellationToken)
    {
        var equipmentToEdit = await context.Equipments.FindAsync(command.LastEquipmentGuid, cancellationToken);
        
        var nameValidationResult = nameValidator.Validate((equipmentToEdit.Name, command.Name));
        if (!nameValidationResult.IsValid)
        {
            throw new ValidationException(nameValidationResult.Errors);
        }
        equipmentToEdit.Rename(command.Name);
        
        var descriptionValidationResult = descriptionValidator.Validate((equipmentToEdit.Description, command.Description));
        if (!descriptionValidationResult.IsValid)
        {
            throw new ValidationException(descriptionValidationResult.Errors);
        }
        equipmentToEdit.ChangeDescription(command.Description);
        
        var priceValidationResult = priceValidator.Validate((equipmentToEdit.Price, command.Price));
        if (!priceValidationResult.IsValid)
        {
            throw new ValidationException(priceValidationResult.Errors);
        }
        equipmentToEdit.ChangePrice(command.Price);
        
        var statusValidationResult = statusValidator.Validate((equipmentToEdit.Status, command.Status));
        if (!statusValidationResult.IsValid)
        {
            throw new ValidationException(statusValidationResult.Errors);
        }
        equipmentToEdit.ChangeStatus(command.Status);
        
        await context.SaveChangesAsync(cancellationToken);
        return equipmentToEdit.Id;
    }
}