using Carhub.Lib.SharedKernel.SharedKernel;

namespace Carhub.Service.Vehicles.Domain.Ownerships.ValueObjects.ConfirmationDocument;

public class CreatedAt : ValueObject
{
    public DateTime Value { get; }

    public CreatedAt(DateTime value)
        => Value = value;

    public static implicit operator DateTime(CreatedAt createdAt)
        => createdAt.Value;

    public static implicit operator CreatedAt(DateTime value)
        => new CreatedAt(value);
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}