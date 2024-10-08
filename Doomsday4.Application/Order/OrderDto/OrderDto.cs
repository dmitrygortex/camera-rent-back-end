using Doomsday4.Domain;
using Doomsday4.Domain.Models;

namespace Doomsday4.Application.Order.OrderDto;

public class OrderDto
{
    public OrderDto(Guid orderId, Guid userId, DateTime startDateTime, DateTime endDateTime, decimal сost, StatusEnum status)
    {
        OrderId = orderId;
        UserId = userId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Сost = сost;
        Status = status;
    }

    public Guid OrderId { get; private set;}
    public Guid UserId { get; set;}
    public DateTime StartDateTime { get; set;}
    public DateTime EndDateTime { get; private set;}
    public decimal Сost { get; private set; } 
    public StatusEnum Status { get; private set;}
}