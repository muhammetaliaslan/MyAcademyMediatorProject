using MediatR;
using Microsoft.AspNetCore.Http;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.BannerCommands
{
    public class CreateBannerCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Subtitle { get; set; }

        public IFormFile ImageFile { get; set; }

        public string BgColor { get; set; }

        public int OrderNo { get; set; } = 0;

        public bool IsActive { get; set; } = true;
    }
}