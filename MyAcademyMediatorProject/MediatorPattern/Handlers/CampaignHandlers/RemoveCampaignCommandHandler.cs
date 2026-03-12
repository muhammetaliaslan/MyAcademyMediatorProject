using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.CampaignCommands;
using MyAcademyMediatorProject.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.CampaignHandlers
{
    public class RemoveCampaignCommandHandler : IRequestHandler<RemoveCampaignCommand, Unit>
    {
        private readonly IRepository<Campaign> _repository;

        public RemoveCampaignCommandHandler(IRepository<Campaign> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveCampaignCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}