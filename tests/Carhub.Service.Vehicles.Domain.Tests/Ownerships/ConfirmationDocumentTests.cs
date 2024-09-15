using Carhub.Service.Vehicles.Domain.Ownerships.Entities;
using Carhub.Service.Vehicles.Domain.Ownerships.Exceptions;
using Carhub.Service.Vehicles.Domain.Ownerships.ValueObjects.ConfirmationDocument;
using Shouldly;
using Xunit;

namespace Carhub.Service.Vehicles.Domain.Tests.Ownerships;

public sealed class ConfirmationDocumentCreateTests
{
    [Fact]
    public void Create_GivenValidArguments_ShouldReturnConfirmationStatusWithStatusNew()
    {
        //arrange
        var id = Guid.NewGuid();
        var attachmentId = Guid.NewGuid();
        var createdAt = DateTime.Now;
        
        //act
        var result = ConfirmationDocument.Create(id, attachmentId, createdAt);
        
        //assert
        result.Id.Value.ShouldBe(id);
        result.AttachmentId.Value.ShouldBe(attachmentId);
        result.CreatedAt.Value.ShouldBe(createdAt);
        result.Status.Value.ShouldBe("new");
    }
    
    [Fact]
    public void Create_GivenEmptyAttachmentId_ShouldThrowEmptyAttachmentIdException()
    {
        //act
        var exception = Record.Exception(() => ConfirmationDocument.Create(Guid.NewGuid(),
            Guid.Empty, DateTime.Now));
        
        //assert
        exception.ShouldBeOfType<EmptyAttachmentIdException>();
    }
}