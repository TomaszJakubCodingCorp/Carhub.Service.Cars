using Carhub.Lib.SharedKernel.SharedKernel;

namespace Carhub.Service.Vehicles.Domain.Vehicles.ValueObjects.Vehicle;

public sealed class Weight : ValueObject
{
    public double Gross { get; }
    public double Curb { get; }

    public Weight(double gross, double curb)
    {
        Gross = gross;
        Curb = curb;
    }
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Gross;
        yield return Curb;
    }
}