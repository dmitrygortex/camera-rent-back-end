using Doomsday4.Common.Domain;

namespace Doomsday4.Domain;

public class Order : Entity<Guid>
{
    public Order()
    {
    }

    // public Order(string userId, DateTime startDateTime, DateTime endDateTime, double cost, StatusEnum status)
    // {
    //     Id = Guid.NewGuid();
    //     // UserId = userId;
    //     StartDateTime = startDateTime;
    //     EndDateTime = endDateTime;
    //     Сost = cost;
    //     Status = status;
    // }
    public Order(DateTime startDateTime, DateTime endDateTime, double сost, StatusEnum status)
    {
        Id = Guid.NewGuid();
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Сost = сost;
        Status = status;
    }

    // public User User { get; private set;} //зачем прописывать ещё это поле TODO спросить про связи
    // public string UserId { get; private set;}
    public DateTime StartDateTime { get; private set;}
    public DateTime EndDateTime { get; private set;}
    public double Сost { get; private set; }
    public StatusEnum Status { get; private set;}
    // public List<Equipment> Equipments { get; private set; }= new List<Equipment>();
}