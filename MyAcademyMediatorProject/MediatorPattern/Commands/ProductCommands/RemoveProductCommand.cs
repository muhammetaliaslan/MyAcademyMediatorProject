using MediatR;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands;

    public record RemoveProductCommand(Guid Id) : IRequest;

