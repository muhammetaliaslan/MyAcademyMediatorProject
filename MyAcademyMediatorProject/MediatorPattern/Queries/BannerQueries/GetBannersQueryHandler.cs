using MediatR;
using MyAcademyMediatorProject.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

// Alias
using BannerEntity = MyAcademyMediatorProject.Entities.Banner;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.Banner
{
    public class GetBannersQueryHandler : IRequestHandler<GetBannersQuery, List<BannerEntity>>
    {
        private readonly IRepository<BannerEntity> _repository;

        public GetBannersQueryHandler(IRepository<BannerEntity> repository)
        {
            _repository = repository;
        }

        public async Task<List<BannerEntity>> Handle(GetBannersQuery request, CancellationToken cancellationToken)
        {
            var banners = await _repository.GetAllAsync(); // PARAMETRESİZ!
            return banners.Where(b => b.IsActive).ToList(); // BURADA filtre
        }
    }
}