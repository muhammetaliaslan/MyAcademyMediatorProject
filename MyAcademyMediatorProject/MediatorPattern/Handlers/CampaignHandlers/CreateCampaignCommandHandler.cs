using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Commands.CampaignCommands;
using MyAcademyMediatorProject.Repositories;

public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Unit>
{
    private readonly IRepository<Campaign> _repository;

    public CreateCampaignCommandHandler(IRepository<Campaign> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(CreateCampaignCommand request, CancellationToken cancellationToken)
    {
        var campaign = new Campaign
        {
            Id = Guid.NewGuid(),
            Name = request.Title, // Title yerine Name
            Description = request.Description,
            Discount = request.Discount,
            MinimumAmount = request.MinimumAmount, // ekledik
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            IsActive = true // default olarak aktif
        };

        await _repository.CreateAsync(campaign);
        return Unit.Value;
    }
}