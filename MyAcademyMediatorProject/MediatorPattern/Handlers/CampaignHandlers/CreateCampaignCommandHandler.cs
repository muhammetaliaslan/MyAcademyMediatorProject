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
            Name = request.Name, // Artık Title kullanıyoruz
            Description = request.Description,
            Discount = request.Discount,
            MinimumAmount = request.MinimumAmount,
            // ⚡ DateTime UTC olarak ayarlandı
            StartDate = DateTime.SpecifyKind(request.StartDate, DateTimeKind.Utc),
            EndDate = DateTime.SpecifyKind(request.EndDate, DateTimeKind.Utc),
            IsActive = true
        };

        await _repository.CreateAsync(campaign);
        return Unit.Value;
    }
}