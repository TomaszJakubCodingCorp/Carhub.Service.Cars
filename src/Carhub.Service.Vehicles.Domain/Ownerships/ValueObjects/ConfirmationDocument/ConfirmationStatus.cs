using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Ownerships.Exceptions;

namespace Carhub.Service.Vehicles.Domain.Ownerships.ValueObjects.ConfirmationDocument;

public class ConfirmationStatus : ValueObject
{
    private readonly List<string> _availableStatuses = ["new", "accepted", "rejected"];
    public string Value { get; }

    public ConfirmationStatus(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new EmptyConfirmationStatusException();
        }

        if (!_availableStatuses.Contains(value))
        {
            throw new UnavailableConfirmationStatusException(value);
        }
        Value = value;
    }

    public static implicit operator string(ConfirmationStatus confirmationStatus)
        => confirmationStatus.Value;

    public static implicit operator ConfirmationStatus(string value)
        => new ConfirmationStatus(value);

    public static ConfirmationStatus New()
        => new ConfirmationStatus("new");
    
    public static ConfirmationStatus Accepted()
        => new ConfirmationStatus("accepted");
    
    public static ConfirmationStatus Rejected()
        => new ConfirmationStatus("rejected");

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}