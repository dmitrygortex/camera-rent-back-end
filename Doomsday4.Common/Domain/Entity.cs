using MediatR;

namespace Example.Project.Common.Domain;

public abstract class Entity<T>
{
    int? _requestedHashCode;
    T _id;

    public virtual T Id
    {
        get { return _id; }
        protected set { _id = value; }
    }

    private List<INotification> _domainEvents = new List<INotification>();
    public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(INotification eventItem)
    {
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        _domainEvents.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    public bool IsTransient()
    {
        return Equals(Id, default(T));
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Entity<T>))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        Entity<T> item = (Entity<T>)obj;

        if (IsTransient() || item.IsTransient())
            return false;
        else
            return item.Id.Equals(Id);
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id.GetHashCode() ^ 31; // XOR for random distribution

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();
    }

    public static bool operator ==(Entity<T> left, Entity<T> right)
    {
        if (ReferenceEquals(left, null))
            return ReferenceEquals(right, null);
        else
            return left.Equals(right);
    }

    public static bool operator !=(Entity<T> left, Entity<T> right)
    {
        return !(left == right);
    }
}