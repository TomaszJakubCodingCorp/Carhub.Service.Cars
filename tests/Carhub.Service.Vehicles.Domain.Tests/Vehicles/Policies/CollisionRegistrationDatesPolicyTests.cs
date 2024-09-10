using Carhub.Service.Vehicles.Tests.Shared.Domain.Vehicles;
using Xunit;

namespace Carhub.Service.Vehicles.Domain.Tests.Vehicles.Policies;

public sealed class CollisionRegistrationDatesPolicyTests
{
    [Theory]
    [MemberData(nameof(GetNegativeTestsDate))]
    public void Validate_GivenVehicleWithCollisionPeriod_ShouldThrowCollisionRegistrationDatesException(DateOnly periodFrom, DateOnly periodTo)
    {
        var vehicle = VehicleFactory.Get();
        
        vehicle.AppendRegistration(Guid.NewGuid(), new DateOnly(2022, 1, 1), new DateOnly(2022,12,31),
            "test_number1", "test_issuer_name1", "test_issuer_address1", 
            "test_owner_full_name1", "test_owner_identity_number1", "test_owner_address1");
        
        
        vehicle.AppendRegistration(Guid.NewGuid(), new DateOnly(2024, 1, 1), null,
            "test_number2", "test_issuer_name2", "test_issuer_address2", 
            "test_owner_full_name2", "test_owner_identity_number2", "test_owner_address2");
        
        var exception = Record.Exception(() => vehicle.AppendRegistration(Guid.NewGuid(), periodFrom, periodTo,
            "test_number3", "test_issuer_name3", "test_issuer_address3", 
            "test_owner_full_name3", "test_owner_identity_number3", "test_owner_address3"));
    }

    public static IEnumerable<object[]> GetNegativeTestsDate()
    {
        yield return new object[]
        {
            new DateOnly(2021, 1, 1), new DateOnly(2023, 1, 1)
        };
        
        yield return new object[]
        {
            new DateOnly(2022, 1, 1), new DateOnly(2023, 1, 1)
        };
        
        yield return new object[]
        {
            new DateOnly(2022, 1, 2), new DateOnly(2024, 1, 1)
        };
    }
}