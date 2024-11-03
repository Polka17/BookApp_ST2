namespace PollyBookApp_ST2.Models.Observer
{
    // The first step of the Observer pattern.
    // Here is the Observer interface that 
    public interface INotificationObserver
    {
        void Update(string message);
    }
}
