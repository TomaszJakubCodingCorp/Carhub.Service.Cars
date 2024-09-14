using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Ownership.Exceptions;

namespace Carhub.Service.Vehicles.Domain.Ownership.ValueObjects.ConfirmationDocument;

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

    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}