using Doomsday4.Common.Domain;

namespace Doomsday4.Domain.Models;

public class Order : Entity<Guid>
{
    private Order()
    {
    }

    public Order(Guid userId, DateTime startDateTime, DateTime endDateTime, decimal cost, OrderStatus orderStatus)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Сost = cost;
        OrderStatus = orderStatus;
    }
    // public Order(DateTime startDateTime, DateTime endDateTime, double сost, StatusEnum status)
    // {
    //     Id = Guid.NewGuid();
    //     StartDateTime = startDateTime;
    //     EndDateTime = endDateTime;
    //     Сost = сost;
    //     Status = status;
    // }

    public User User { get; private set;}
    public Guid UserId { get; private set;}
    public DateTime StartDateTime { get; private set;}
    public DateTime EndDateTime { get; private set;}
    public decimal Сost { get; private set; } 
    public OrderStatus OrderStatus { get; private set;}
    public virtual ICollection<EquipmentUnit> EquipmentUnits { get; private set; }= new List<EquipmentUnit>();
}