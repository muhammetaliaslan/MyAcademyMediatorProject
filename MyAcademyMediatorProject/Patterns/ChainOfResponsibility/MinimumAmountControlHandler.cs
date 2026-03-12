using MyAcademyMediatorProject.Entities;

namespace MyAcademyMediatorProject.Patterns.ChainOfResponsibility
{
    public class MinimumAmountControlHandler : OrderValidationHandler
    {
        private readonly decimal _minimumAmount;

        public MinimumAmountControlHandler(decimal minimumAmount)
        {
            _minimumAmount = minimumAmount;
        }

        public override async Task Handle(Order order)
        {
            if (order.TotalAmount < _minimumAmount)
                throw new Exception($"Sipariş tutarı minimum {_minimumAmount} TL olmalı!");

            await base.Handle(order);
        }
    }
}