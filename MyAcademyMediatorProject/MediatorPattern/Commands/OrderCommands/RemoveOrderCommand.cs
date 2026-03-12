using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.OrderCommands
{
    public record RemoveOrderCommand(Guid Id) : IRequest;
}