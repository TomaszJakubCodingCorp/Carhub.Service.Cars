using Carhub.Service.Vehicles.Domain.Ownerships.Entities;
using Shouldly;
using Xunit;

namespace Carhub.Service.Vehicles.Domain.Tests.Ownerships;

public sealed class OwnershipCreateTests
{
    [Fact]
    public void Create_GivenArguments_ShouldReturnOwnership()
    {
        //arrange
        var id = Guid.NewGuid();
        var carId = Guid.NewGuid();
        
        //act
        var result = Ownership.Create(id, carId);
        
        //assert
        result.Id.Value.ShouldBe(id);
        result.CarId.Value.ShouldBe(carId);
    }
}