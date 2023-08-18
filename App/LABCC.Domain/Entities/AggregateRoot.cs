using LABCC.Domain.Enums;
using LABCC.Domain.ValueObjects;

namespace LABCC.Domain.Entities;

public abstract class AggregateRoot
{
    public Identifier Id { get; }
    public DateTimeOffset UpdatedAt { get; }
    public DateTimeOffset CreatedAt { get; }
    public StatusEnum Status { get; }
 
    protected AggregateRoot()
    {
        Id = Identifier.From(Guid.NewGuid());
        UpdatedAt = DateTimeOffset.Now;
        CreatedAt = DateTimeOffset.Now;
        Status = StatusEnum.ACTIVE;
    }
    
}