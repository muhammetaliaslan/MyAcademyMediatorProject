using MediatR;
using System.Collections.Generic;

// Alias kullanıyoruz
using BannerEntity = MyAcademyMediatorProject.Entities.Banner;

namespace MyAcademyMediatorProject.MediatorPattern.Queries.Banner
{
    public class GetBannersQuery : IRequest<List<BannerEntity>>
    {
    }
}