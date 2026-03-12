using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.CampaignCommands;
using MyAcademyMediatorProject.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.MediatorPattern.Handlers.CampaignHandlers
{
    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Unit>
    {
        private readonly IRepository<Campaign> _repository;

        public UpdateCampaignCommandHandler(IRepository<Campaign> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            var campaign = await _repository.GetByIdAsync(request.Id);

            // Title → Name
            campaign.Name = request.Title;
            campaign.Description = request.Description;
            campaign.Discount = request.Discount;
            campaign.MinimumAmount = request.MinimumAmount; // ekledik
            campaign.StartDate = request.StartDate;
            campaign.EndDate = request.EndDate;
            campaign.IsActive = request.IsActive; // ekledik

            await _repository.UpdateAsync(campaign);

            return Unit.Value;
        }
    }
}