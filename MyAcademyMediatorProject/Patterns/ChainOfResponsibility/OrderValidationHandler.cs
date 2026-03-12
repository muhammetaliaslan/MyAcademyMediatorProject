using MyAcademyMediatorProject.Entities;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.Patterns.ChainOfResponsibility
{
    public abstract class OrderValidationHandler
    {
        protected OrderValidationHandler? Next { get; private set; }

        public void SetNext(OrderValidationHandler next)
        {
            Next = next;
        }

        public virtual async Task Handle(Order order)
        {
            if (Next != null)
                await Next.Handle(order);
        }
    }
}