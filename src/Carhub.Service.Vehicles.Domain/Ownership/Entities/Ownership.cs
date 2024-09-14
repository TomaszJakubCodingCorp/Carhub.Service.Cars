using Carhub.Lib.SharedKernel.SharedKernel;

namespace Carhub.Service.Vehicles.Domain.Ownership.Entities;

public sealed class Ownership : AggregateRoot
{
    private readonly List<EntityId> _users = new List<EntityId>();
    private readonly List<ConfirmationDocument> _confirmationDocuments = new List<ConfirmationDocument>();
    public EntityId CarId { get; private set; }
    public IReadOnlyList<EntityId> Users => _users;
    public IReadOnlyList<ConfirmationDocument> ConfirmationDocuments => _confirmationDocuments;
    
    private Ownership(AggregateId id, EntityId carId) : base(id)
    {
        CarId = carId;
    }

    public static Ownership Create(Guid id, Guid carId)
        => new Ownership(id, carId);

}