using Doomsday4.Domain;
using Doomsday4.Domain.Models;

namespace Doomsday4.Application.Order.OrderDto;

public class OrderDto
{
    public OrderDto(Guid orderId, Guid userId, DateTime startDateTime, DateTime endDateTime, decimal сost, OrderStatus orderStatus)
    {
        OrderId = orderId;
        UserId = userId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Сost = сost;
        OrderStatus = orderStatus;
    }

    public Guid OrderId { get; private set;}
    public Guid UserId { get; set;}
    public DateTime StartDateTime { get; set;}
    public DateTime EndDateTime { get; private set;}
    public decimal Сost { get; private set; } 
    public OrderStatus OrderStatus { get; private set;}
}