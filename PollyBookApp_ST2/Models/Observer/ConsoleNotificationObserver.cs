namespace PollyBookApp_ST2.Models.Observer
{
    // Here is the class that implement the INotificationObserver interface.
    // To give feedback and track the message's arrival we log a message in the console.
    public class ConsoleNotificationObserver: INotificationObserver
    {
        // This method overrides the one in the Interface as it provides a specific implementation
        public void Update(string message)
        {
            Console.WriteLine($"Notification received: {message}");
        }
    }
}
