namespace PollyBookApp_ST2.Models.Observer
{
    public class OrderNotifier
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

        public void OrderMade() => NotifyObservers("A new order has been placed.");
        public void OrderDelivered() => NotifyObservers("An order has been delivered.");
    }
}
