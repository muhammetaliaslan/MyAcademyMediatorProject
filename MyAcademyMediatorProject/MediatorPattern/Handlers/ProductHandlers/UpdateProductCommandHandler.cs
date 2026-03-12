using Mapster;
using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.ProductCommands;
using MyAcademyMediatorProject.Repositories;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler(IRepository<Product> _repository) : IRequestHandler<UpdateProductCommand>
    {
        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
          var product = request.Adapt<Product>();
            await _repository.UpdateAsync(product);
        }
    }
}
