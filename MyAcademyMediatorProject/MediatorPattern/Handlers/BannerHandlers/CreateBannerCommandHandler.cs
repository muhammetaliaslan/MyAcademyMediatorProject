using MediatR;
using MyAcademyMediatorProject.Repositories;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

// Alias kullanıyoruz, namespace çakışmasını önlemek için
using BannerEntity = MyAcademyMediatorProject.Entities.Banner;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.BannerCommands
{
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand, int>
    {
        private readonly IRepository<BannerEntity> _repository;
        private readonly IWebHostEnvironment _env;

        public CreateBannerCommandHandler(IRepository<BannerEntity> repository, IWebHostEnvironment env)
        {
            _repository = repository;
            _env = env;
        }

        public async Task<int> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            // Banner görselleri için klasör yolu
            var folderPath = Path.Combine(_env.WebRootPath, "assets/images/banner");

            // Eğer klasör yoksa oluştur
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // Dosya adı oluştur
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(request.ImageFile.FileName)}";
            var path = Path.Combine(folderPath, fileName);

            // Dosyayı kaydet
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await request.ImageFile.CopyToAsync(stream);
            }

            // Banner entity oluştur
            var banner = new BannerEntity
            {
                Title = request.Title,
                Subtitle = request.Subtitle,
                ImageUrl = $"/assets/images/banner/{fileName}",
                IsActive = true
            };

            // Veritabanına kaydet
            await _repository.CreateAsync(banner);

            return banner.Id;
        }
    }
}