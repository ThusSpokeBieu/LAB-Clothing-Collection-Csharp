using ValueOf;

namespace LABCC.Domain.ValueObjects;

public sealed class Identifier : ValueOf<Guid, Identifier>
{
    protected override void Validate()
    {
      if (Value == Guid.Empty)
        throw new ArgumentException($"Identifier should not be empty", nameof(Identifier));
    }
}