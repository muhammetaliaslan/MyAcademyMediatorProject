using MediatR;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.MediatorPattern.Queries.DashboardQueries;
using MyAcademyMediatorProject.Repositories;

public class GetDashboardCountsQueryHandler : IRequestHandler<GetDashboardCountsQuery, DashboardCountsResult>
{
    private readonly IRepository<Category> _categoryRepo;
    private readonly IRepository<Product> _productRepo;
    private readonly IRepository<Order> _orderRepo;
    private readonly IRepository<Promotion> _promoRepo;
    private readonly IRepository<User> _userRepo;

    public GetDashboardCountsQueryHandler(
        IRepository<Category> categoryRepo,
        IRepository<Product> productRepo,
        IRepository<Order> orderRepo,
        IRepository<Promotion> promoRepo,
        IRepository<User> userRepo)
    {
        _categoryRepo = categoryRepo;
        _productRepo = productRepo;
        _orderRepo = orderRepo;
        _promoRepo = promoRepo;
        _userRepo = userRepo;
    }

    public async Task<DashboardCountsResult> Handle(GetDashboardCountsQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepo.GetAllAsync();
        var products = await _productRepo.GetAllAsync();
        var orders = await _orderRepo.GetAllAsync();
        var promos = await _promoRepo.GetAllAsync();
        var users = await _userRepo.GetAllAsync();

        return new DashboardCountsResult(
            categories.Count,
            products.Count,
            orders.Count,
            promos.Count,
            users.Count
        );
    }
}