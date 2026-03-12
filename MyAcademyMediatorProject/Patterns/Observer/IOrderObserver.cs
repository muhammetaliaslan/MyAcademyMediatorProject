using MyAcademyMediatorProject.Entities;

namespace MyAcademyMediatorProject.Patterns.Observer
{
    public interface IOrderObserver
    {
        Task Notify(Order order);
    }
}