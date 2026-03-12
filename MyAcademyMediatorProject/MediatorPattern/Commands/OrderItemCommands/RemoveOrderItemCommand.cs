using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.OrderItemCommands
{
    public record RemoveOrderItemCommand(Guid Id) : IRequest;
}