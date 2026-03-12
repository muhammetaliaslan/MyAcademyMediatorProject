using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;

public class GetGalleryQueryHandler : IRequestHandler<GetGalleryQuery, IEnumerable<GetGalleryQueryResult>>
{
    // Eğer DB kullanıyorsan DbContext burada olacak
    public async Task<IEnumerable<GetGalleryQueryResult>> Handle(GetGalleryQuery request, CancellationToken cancellationToken)
    {
        // Örnek statik veri
        return new List<GetGalleryQueryResult>
        {
            new GetGalleryQueryResult { Title = "Gallery 1", ImageUrl = "project-1.jpg" },
            new GetGalleryQueryResult { Title = "Gallery 2", ImageUrl = "project-2.jpg" },
            new GetGalleryQueryResult { Title = "Gallery 3", ImageUrl = "project-3.jpg" },
        };
    }
}