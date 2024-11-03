using System;

namespace PollyBookApp_ST2.Models.Observer
{
    //That's the class that is responsible for "controling" the observer.
    // It has several methods - to add, remove an observer and to relay messages.
    // (I, later on, implement it in the Controller and send the messages to the view in order to visualise them on the UI)
    public class ReadingItemNotifier
    {
        private List<INotificationObserver> _observers = new List<INotificationObserver>();

        public void Attach(INotificationObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(INotificationObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
            {
                observer.Update(message);
            }
        }
    }
}
