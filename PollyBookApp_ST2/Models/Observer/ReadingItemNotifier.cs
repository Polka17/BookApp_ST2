using PollyBookApp_ST2.Models.ReadingItems;
using System;

namespace PollyBookApp_ST2.Models.Observer
{
    public class ReadingItemNotifier
    {
        private List<INotificationObserver> _observers = new List<INotificationObserver>();
        private List<ReadingItem> _items = new List<ReadingItem>();

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

        //public void AddItem(ReadingItem item)
        //{
        //    _items.Add(item);
        //    Notify($"New item was added: '{item.Title}' ");
        //}

        //public void UpdateItemTitle(int itemId, string newTitle)
        //{
        //    var item = _items.Find(i => i.Id == itemId);
        //    if (item != null)
        //    {
        //        item.Title = newTitle;
        //        Notify($"Item {itemId} updated with a new title: '{newTitle}' ");
        //    }
        //}
        //private readonly List<INotificationObserver> _observers = new();

        //public void AddObserver(INotificationObserver observer) => _observers.Add(observer);
        //public void RemoveObserver(INotificationObserver observer) => _observers.Remove(observer);

        //public void NotifyObservers(string message)
        //{
        //    foreach (var observer in _observers)
        //    {
        //        observer.Update(message);
        //    }
        //}

        //public void NewBookAdded() => NotifyObservers("A new book has been added to the library.");
    }
}
