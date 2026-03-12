using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAcademyMediatorProject.Patterns.Observer
{
    // Observer interface
    public interface IContactObserver
    {
        Task NotifyAsync(string name, string email, string message);
    }

    // Subject
    public class ContactSubject
    {
        private readonly List<IContactObserver> _observers = new List<IContactObserver>();

        // Observer ekleme
        public void Attach(IContactObserver observer)
        {
            _observers.Add(observer);
        }

        // Observer kaldırma
        public void Detach(IContactObserver observer)
        {
            _observers.Remove(observer);
        }

        // Tüm observer’lara mesaj gönder
        public async Task NotifyAsync(string name, string email, string message)
        {
            foreach (var observer in _observers)
            {
                await observer.NotifyAsync(name, email, message);
            }
        }
    }
}