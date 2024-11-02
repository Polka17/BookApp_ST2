namespace PollyBookApp_ST2.Models.Observer
{
    public class BookNotifier
    {
        private readonly List<INotificationObserver> _observers = new();

        public void AddObserver(INotificationObserver observer) => _observers.Add(observer);
        public void RemoveObserver(INotificationObserver observer) => _observers.Remove(observer);

        public void NotifyObservers(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }

        public void NewBookAdded() => NotifyObservers("A new book has been added to the library.");
    }
}
