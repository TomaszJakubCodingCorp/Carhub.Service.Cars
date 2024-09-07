using Carhub.Service.Vehicles.Tests.Shared.Domain.Vehicles;
using Shouldly;

namespace Carhub.Service.Vehicles.Domain.Tests.Vehicles;

public sealed class VehicleTests
{
    public void AppendRegistration_GivenRegistrationArguments_ShouldFinishedPreviousRegistrationAndAddNew()
    {
        //arrange
        var vehicle = VehicleFactory.Get();
        var oldRegistrationId = Guid.NewGuid();
        vehicle.AppendRegistration(oldRegistrationId, DateOnly.FromDateTime(DateTime.Now.AddYears(-1)), null, "test_number",
            "test_issuer_name", "test_issuer_address", "test_owner_full_name",
            "test_owner_identity_number", "test_owner_address");
        var registrationId = Guid.NewGuid();
        var registrationPeriodFrom = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));
        var registrationNumber = "new_test_number";
        var registrationIssuerName = "new_issuer_name";
        var registrationIssuerAddress = "new_issuer_address";
        var registrationOwnerFullName = "new_owner_full_name";
        var registrationOwnerIdentityNumber = "new_owner_identity_number";
        var registrationOwnerAddress = "new_owner_address";
        
        //act
        vehicle.AppendRegistration(registrationId, registrationPeriodFrom, null, registrationNumber, registrationIssuerName,
            registrationIssuerAddress, registrationOwnerFullName, registrationOwnerIdentityNumber, registrationOwnerAddress);
        
        //assert
        var oldRegistration = vehicle.Registrations.Single(x => x.Id.Value == oldRegistrationId);
        oldRegistration.Period.To!.Value.ShouldBe(registrationPeriodFrom.AddDays(-1));

        var newRegistration = vehicle.Registrations.Single(x => x.Id.Value == registrationId);
        newRegistration.Period.From.ShouldBe(registrationPeriodFrom);
        newRegistration.Period.To.ShouldBeNull();
        newRegistration.Number.Value.ShouldBe(registrationNumber);
        newRegistration.Issuer.Name.ShouldBe(registrationIssuerName);
        newRegistration.Issuer.Address.ShouldBe(registrationIssuerAddress);
        newRegistration.OwnerData.FullName.ShouldBe(registrationOwnerFullName);
        newRegistration.OwnerData.Address.ShouldBe(registrationOwnerAddress);
        newRegistration.OwnerData.IdentityNumber.ShouldBe(registrationOwnerIdentityNumber);

    }
}