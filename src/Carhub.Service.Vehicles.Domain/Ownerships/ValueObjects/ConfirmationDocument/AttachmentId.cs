using Carhub.Lib.SharedKernel.SharedKernel;
using Carhub.Service.Vehicles.Domain.Ownerships.Exceptions;

namespace Carhub.Service.Vehicles.Domain.Ownerships.ValueObjects.ConfirmationDocument;

public sealed class AttachmentId : ValueObject
{
    public Guid Value { get; }

    public AttachmentId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new EmptyAttachmentIdException();
        }
        Value = value;
    }

    public static implicit operator Guid(AttachmentId attachmentId)
        => attachmentId.Value;

    public static implicit operator AttachmentId(Guid value)
        => new AttachmentId(value);
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        throw new NotImplementedException();
    }
}