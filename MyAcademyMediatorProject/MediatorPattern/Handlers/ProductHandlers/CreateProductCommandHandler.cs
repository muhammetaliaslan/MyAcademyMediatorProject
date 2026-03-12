using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler(IRepository<Product> _repository) : IRequestHandler<CreateProductCommand>
    {
        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await _repository.CreateAsync(product);
        }
    }
}
