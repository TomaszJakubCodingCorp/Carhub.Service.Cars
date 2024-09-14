using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Ownership.ValueObjects.ConfirmationDocument;

namespace Carhub.Service.Vehicles.Domain.Ownership.Entities;

public sealed class ConfirmationDocument 
{
    public EntityId Id { get; }
    public Guid AttachmentId { get; set; }
    public CreatedAt CreatedAt { get; set; }
    public string Status { get; set; }
    
}