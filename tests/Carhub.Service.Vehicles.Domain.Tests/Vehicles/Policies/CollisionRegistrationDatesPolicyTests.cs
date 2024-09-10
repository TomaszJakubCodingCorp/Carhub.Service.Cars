using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Internals;
using Carhub.Service.Vehicles.Tests.Shared.Domain.Vehicles;
using Shouldly;
using Xunit;

namespace Carhub.Service.Vehicles.Domain.Tests.Vehicles.Policies;

public sealed class CollisionRegistrationDatesPolicyTests
{
    [Theory]
    [MemberData(nameof(GetNegativeTestsDate))]
    public void Validate_GivenVehicleWithCollisionPeriod_ShouldThrowCollisionRegistrationDatesException(DateOnly periodFrom, DateOnly periodTo)
    {
        //arrange
        var vehicle = VehicleFactory.Get();
        
        vehicle.AppendRegistration(Guid.NewGuid(), new DateOnly(2022, 1, 1), new DateOnly(2022,12,31),
            "test_number1", "test_issuer_name1", "test_issuer_address1", 
            "test_owner_full_name1", "test_owner_identity_number1", "test_owner_address1");
        
        
        vehicle.AppendRegistration(Guid.NewGuid(), new DateOnly(2024, 1, 1), new DateOnly(2024, 12, 31),
            "test_number2", "test_issuer_name2", "test_issuer_address2", 
            "test_owner_full_name2", "test_owner_identity_number2", "test_owner_address2");
        
        //act
        var exception = Record.Exception(() => _policy.Validate(vehicle, periodFrom, periodTo));
        
        //assert
        exception.ShouldNotBeNull();
        exception.ShouldBeOfType<CollisionRegistrationDatesException>();
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
    
    [Theory]
    [MemberData(nameof(GetPositiveTestsDate))]
    public void Validate_GivenVehicleWithoutCollisionPeriod_ShouldNotThrowAnyException(DateOnly periodFrom, DateOnly periodTo)
    {
        //arrange
        var vehicle = VehicleFactory.Get();
        
        vehicle.AppendRegistration(Guid.NewGuid(), new DateOnly(2022, 1, 1), new DateOnly(2022,12,31),
            "test_number1", "test_issuer_name1", "test_issuer_address1", 
            "test_owner_full_name1", "test_owner_identity_number1", "test_owner_address1");
        
        
        vehicle.AppendRegistration(Guid.NewGuid(), new DateOnly(2024, 1, 1), null,
            "test_number2", "test_issuer_name2", "test_issuer_address2", 
            "test_owner_full_name2", "test_owner_identity_number2", "test_owner_address2");
        
        //act
        var exception = Record.Exception(() => _policy.Validate(vehicle, periodFrom, periodTo));
        
        //assert
        exception.ShouldBeNull();
    }

    public static IEnumerable<object[]> GetPositiveTestsDate()
    {
        yield return new object[]
        {
            new DateOnly(2021, 1, 1), new DateOnly(2021, 12, 31)
        };
        
        yield return new object[]
        {
            new DateOnly(2023, 1, 1), new DateOnly(2023, 12, 31)
        };
    }
    
    #region arrange

    private IRegistrationDatesPolicy _policy;

    public CollisionRegistrationDatesPolicyTests()
        => _policy = new CollisionRegistrationDatesPolicy();

    #endregion
}