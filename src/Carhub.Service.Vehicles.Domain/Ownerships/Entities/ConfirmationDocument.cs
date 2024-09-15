using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Ownerships.ValueObjects.ConfirmationDocument;

namespace Carhub.Service.Vehicles.Domain.Ownerships.Entities;

public sealed class ConfirmationDocument 
{
    public EntityId Id { get; }
    public AttachmentId AttachmentId { get; set; }
    public CreatedAt CreatedAt { get; set; }
    public ConfirmationStatus Status { get; set; }

    private ConfirmationDocument(EntityId id, AttachmentId attachmentId, 
        CreatedAt createdAt)
    {
        Id = id;
        AttachmentId = attachmentId;
        CreatedAt = createdAt;
    }

    internal static ConfirmationDocument Create(Guid id, Guid attachmentId, DateTime createdTime)
    {
        var confirmationDocument = new ConfirmationDocument(id, attachmentId,
            createdTime);
        confirmationDocument.AssignAsNew();
        return confirmationDocument;
    }

    private void AssignAsNew()
        => Status = ConfirmationStatus.New();
}