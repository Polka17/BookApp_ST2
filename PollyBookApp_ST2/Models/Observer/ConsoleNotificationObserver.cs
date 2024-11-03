namespace PollyBookApp_ST2.Models.Observer
{
    public class ConsoleNotificationObserver: INotificationObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"Notification received: {message}");
        }
    }
}
