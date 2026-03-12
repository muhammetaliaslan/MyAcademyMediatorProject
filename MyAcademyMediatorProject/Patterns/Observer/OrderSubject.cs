using MyAcademyMediatorProject.Entities;

namespace MyAcademyMediatorProject.Patterns.Observer
{
    public class OrderSubject
    {
        private readonly IEnumerable<IOrderObserver> _observers;

        public OrderSubject(IEnumerable<IOrderObserver> observers)
        {
            _observers = observers;
        }

        public async Task Notify(Order order)
        {
            foreach (var observer in _observers)
            {
                await observer.Notify(order);
            }
        }
    }
}