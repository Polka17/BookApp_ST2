namespace PollyBookApp_ST2.Models.Observer
{
    public class ConsoleNotificationObserver: INotificationObserver
    {
        public void Update(string message)
        {
            // This could be a console log, a logging system, etc.
            Console.WriteLine($"Notification received: {message}");
        }
    }
}
