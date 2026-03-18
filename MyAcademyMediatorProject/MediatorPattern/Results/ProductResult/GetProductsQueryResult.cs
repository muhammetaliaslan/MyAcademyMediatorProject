using System;

namespace MyAcademyMediatorProject.MediatorPattern.Results.ProductResult
{
    public class GetProductsQueryResult
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public int Stock { get; set; }

        public string Description { get; set; } = string.Empty;

        public string CategoryName { get; set; } = string.Empty; // ⭐ EKLENDİ
        public string ProductName { get; set; } = string.Empty; // ⭐ EKLENDİ
     
    }
}