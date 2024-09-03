using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Registrations;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Registration;

public sealed class Period : ValueObject
{
    public DateTime From { get; }
    public DateTime? To { get; }

    public Period(DateTime from, DateTime? to)
    {
        if (to is null)
        {
            From = from;
            return;
        }
        
        if (from > to.Value)
        {
            throw new PeriodTimeToBeforeTimeFromException(from, to.Value);
        }
        From = from;
        To = to;
    }

    public Period(DateTime from)
        => From = from;
    

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return From;
        yield return To;
    }
}