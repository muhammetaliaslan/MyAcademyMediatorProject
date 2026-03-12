using MediatR;
using MyAcademyMediatorProject.MediatorPattern.Results;
using MyAcademyMediatorProject.MediatorPattern.Results.ProductResult;

public class GetTestimonialsQueryHandler : IRequestHandler<GetTestimonialsQuery, IEnumerable<GetTestimonialsQueryResult>>
{
    public async Task<IEnumerable<GetTestimonialsQueryResult>> Handle(GetTestimonialsQuery request, CancellationToken cancellationToken)
    {
        return new List<GetTestimonialsQueryResult>
        {
            new GetTestimonialsQueryResult { Name = "Jane Doe", Comment = "Absolutely delicious!", ImageUrl = "testimonial-1.png" },
            new GetTestimonialsQueryResult { Name = "John Smith", Comment = "Friendly staff and amazing products.", ImageUrl = "testimonial-2.png" },
            new GetTestimonialsQueryResult { Name = "Mary Johnson", Comment = "Highly recommend their fresh bread and pastries.", ImageUrl = "testimonial-3.png" },
        };
    }
}