using Carhub.Lib.Exceptions.Abstractions;

namespace Carhub.Service.Vehicles.Domain.Ownerships.Exceptions;

public sealed class EmptyAttachmentIdException()
    : CarhubDomainException("Attachment ID can not be empty");