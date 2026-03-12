using MediatR;
using System;

namespace MyAcademyMediatorProject.MediatorPattern.Commands.OrderCommands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}