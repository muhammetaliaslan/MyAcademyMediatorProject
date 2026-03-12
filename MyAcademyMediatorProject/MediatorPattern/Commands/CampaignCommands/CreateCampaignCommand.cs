using MediatR;
using System;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.CampaignCommands
{
    // Unit dönmesi için IRequest<Unit> implement et
    public class CreateCampaignCommand : IRequest<Unit>
    {
        public string Title { get; set; } = string.Empty; // Handler’da Name olarak map edilecek
        public string Description { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public decimal MinimumAmount { get; set; } // ekledik
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}