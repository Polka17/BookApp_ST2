namespace PollyBookApp_ST2.Models.Observer
{
    //I wanted to inmlement logic about notifyng the user about changes to the object, later on I did the same with the creation.
    // So I opted for the Observer pattern - to invoke notifications, based on a triggering action. (in our case Create and Edit)

    // The first step of the Observer pattern.
    // Here is the Observer interface that is responsible for the message relaying logic.
    public interface INotificationObserver
    {
        void Update(string message);
    }
}
