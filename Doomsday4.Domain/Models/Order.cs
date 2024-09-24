using Doomsday4.Common.Domain;

namespace Doomsday4.Domain;

public class Order : Entity<Guid>
{
    public Order()
    {
    }

    public Order(string userId, DateTime startDateTime, DateTime endDateTime, double cost, StatusEnum status)
    {
        Id = Guid.NewGuid();
        UserId = userId;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        this.cost = cost;
        Status = status;
    }

    public User User { get; } //зачем прописывать ещё это поле
    public string UserId { get; }
    public DateTime StartDateTime { get; }
    public DateTime EndDateTime { get; }
    public double cost { get; }
    public StatusEnum Status { get; }
    public List<Equipment> Equipments = new List<Equipment>();
}