using Carhub.Lib.SharedKernel;

namespace Carhub.Service.Cars.Domain.Vehicles.ValueObjects;

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