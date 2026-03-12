using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler(IRepository<Product> _repository) : IRequestHandler<RemoveProductCommand>
    {
        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
        }
    }
}
