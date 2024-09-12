using Carhub.Service.Vehicles.Domain.Vehicles.Exceptions.Vehicles;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Internals;
using Carhub.Service.Vehicles.Tests.Shared.Domain.Vehicles;
using Shouldly;
using Xunit;

namespace Carhub.Service.Vehicles.Domain.Tests.Vehicles.Policies;

public sealed class NotFinishedRegistrationDatesPolicyTests
{
    [Fact]
    public void Validate_GivenVehicleWithPerdiodWithToAsNullAndGivenFromDateBefore_ShouldThrowNotFinishedRegistrationException()
    {
        //arrange
        var vehicle = VehicleFactory.Get();
        
        vehicle.AppendRegistration(Guid.NewGuid(), new DateOnly(2022, 1, 1), null,
            "test_number1", "test_issuer_name1", "test_issuer_address1", 
            "test_owner_full_name1", "test_owner_identity_number1", "test_owner_address1");
        
        //act
        var exception = Record.Exception(() => _policy.Validate(vehicle, new DateOnly(2021, 1, 1), null));
        
        //assert
        exception.ShouldBeOfType<NotFinishedRegistrationException>();
    }

    [Fact]
    public void Validate_GivenVehicleWithPerdiodWithToAsNullAndGivenFromDateAfter_ShouldNotThrowAnyException()
    {
        //arrange
        var vehicle = VehicleFactory.Get();
        
        vehicle.AppendRegistration(Guid.NewGuid(), new DateOnly(2022, 1, 1), null,
            "test_number1", "test_issuer_name1", "test_issuer_address1", 
            "test_owner_full_name1", "test_owner_identity_number1", "test_owner_address1");
        
        //act
        var exception = Record.Exception(() => _policy.Validate(vehicle, new DateOnly(2023, 1, 1), null));
        
        //assert
        exception.ShouldBeNull();
    }
    
    
    #region arrange
    private readonly IRegistrationDatesPolicy _policy;

    public NotFinishedRegistrationDatesPolicyTests()
        => _policy = new NotFinishedRegistrationDatesPolicy();
    #endregion
}