using MediatR;
using System;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.CampaignCommands
{
    // Unit dönmesi için IRequest<Unit> implement ediliyor
    public class CreateCampaignCommand : IRequest<Unit>
    {
        // Kampanya başlığı
        public string Name { get; set; } = string.Empty;

        // Açıklama
        public string Description { get; set; } = string.Empty;

        // İndirim yüzdesi
        public decimal Discount { get; set; }

        // Minimum sipariş tutarı
        public decimal MinimumAmount { get; set; }

        // Başlangıç ve bitiş tarihleri
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Yeni alanlar: hangi kategori ve ürün için kampanya
        public Guid CategoryId { get; set; }
        public Guid ProductId { get; set; }
    }
}