using LABCC.Domain.Enums;
using LABCC.Domain.ValueObjects;

namespace LABCC.Domain.Entities;

public abstract class AggregateRoot
{
    public Identifier Id { get; protected set; }
    public DateTimeOffset UpdatedAt { get; protected set;  }
    public DateTimeOffset CreatedAt { get; protected set;  }
    public StatusEnum Status { get; protected set; }
 
    protected AggregateRoot()
    {
        Id = Identifier.From(Guid.NewGuid());
        UpdatedAt = DateTimeOffset.Now;
        CreatedAt = DateTimeOffset.Now;
        Status = StatusEnum.ACTIVE;
    }
    
}