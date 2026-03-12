using System;

namespace MyAcademyMediatorProject.Entities
{
    public class Campaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty; 
        public string Description { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public decimal MinimumAmount { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string ImageUrl { get; set; } = string.Empty;
    }
}