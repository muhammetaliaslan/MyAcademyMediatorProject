using MediatR;
using MyAcademyMediatorProject.Context;
using MyAcademyMediatorProject.Entities;
using MyAcademyMediatorProject.Patterns.Observer;
using MyAcademyMediatorProject.Patterns.ChainOfResponsibility;
using MyAcademyMediatorProject.MediatorPattern.Commands.OrderCommands;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly AppDbContext _context;
    private readonly OrderSubject _orderSubject;

    public CreateOrderCommandHandler(AppDbContext context, OrderSubject orderSubject)
    {
        _context = context;
        _orderSubject = orderSubject;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerName = request.CustomerName,
            CustomerEmail = request.CustomerEmail,
            OrderDate = DateTime.Now,
            TotalAmount = request.TotalAmount
        };

        // Zincir kurulumu
        var stockHandler = new StockControlHandler(_context);
        var campaignHandler = new CampaignControlHandler(_context);
        var minAmountHandler = new MinimumAmountControlHandler(50); // Minimum 50 TL

        stockHandler.SetNext(campaignHandler);
        campaignHandler.SetNext(minAmountHandler);

        // Zinciri çalıştır
        await stockHandler.Handle(order);

        // Siparişi kaydet
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();

        // Observer ile loglama
        await _orderSubject.Notify(order);

        return order.Id;
    }
}