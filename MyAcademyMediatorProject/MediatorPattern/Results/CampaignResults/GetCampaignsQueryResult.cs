using System;

namespace MyAcademyMediatorProject.MediatorPattern.Results.CampaignResults
{
    public class GetCampaignsQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public decimal MinimumAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public string? ImageUrl { get; set; } // ekledik

        // 8 parametreli constructor
        public GetCampaignsQueryResult(
            Guid id,
            string name,
            string description,
            decimal discount,
            decimal minimumAmount,
            DateTime startDate,
            DateTime endDate,
            bool isActive
        )
        {
            Id = id;
            Name = name;
            Description = description;
            Discount = discount;
            MinimumAmount = minimumAmount;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = isActive;
        }

        // Parametresiz constructor (opsiyonel)
        public GetCampaignsQueryResult() { }
    }
}