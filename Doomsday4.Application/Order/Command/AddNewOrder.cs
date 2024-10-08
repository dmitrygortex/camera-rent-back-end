using Doomsday4.Application.User.Command;
using Doomsday4.Domain;
using Doomsday4.Domain.Models;
using MediatR;

namespace Doomsday4.Application.Order.Command;

public class AddNewOrder : IRequest<Guid>
{
    public AddNewOrder(Guid userId, DateTime startDateTime, DateTime endDateTime, decimal сost, StatusEnum status)
    {
        UserId = userId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Сost = сost;
        Status = status;
    }
    public Guid UserId { get; private set;}
    public DateTime StartDateTime { get; private set;}
    public DateTime EndDateTime { get; private set;}
    public decimal Сost { get; private set; } 
    public StatusEnum Status { get; private set;}
}