using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Abstractions;
using Carhub.Service.Vehicles.Domain.Vehicles.Policies.Internals;
using Shouldly;
using Xunit;

namespace Carhub.Service.Vehicles.Domain.Tests.Vehicles.Policies;

public sealed class RegistrationDatesPolicyFactoryTests
{
    [Fact]
    public void Create_GivenIsDateToIsNullAsTrue_ShouldReturnNotFinishedRegistrationDatesPolicy()
    {
        //act
        var result = _factory.Create(true);
        
        //assert
        result.ShouldBeOfType<NotFinishedRegistrationDatesPolicy>();
    }
    
    [Fact]
    public void Create_GivenIsDateToIsNullAsFalse_ShouldReturnCollisionRegistrationDatesPolicy()
    {
        //act
        var result = _factory.Create(false);
        
        //assert
        result.ShouldBeOfType<CollisionRegistrationDatesPolicy>();
    }
    
    #region arrange
    private readonly IRegistrationDatesPolicyFactory _factory;

    public RegistrationDatesPolicyFactoryTests()
        => _factory = RegistrationDatesPolicyFactory.GetInstance();
    #endregion
}