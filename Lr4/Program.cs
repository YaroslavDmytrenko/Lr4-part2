public class Program
{
    static void Main(string[] args)
    {
        EventManager eventManager = new EventManager(1000);

        eventManager.AddEventHandler("event1", (sender, args) => Console.WriteLine("Event 1 handled"));
        eventManager.AddEventHandler("event2", (sender, args) => Console.WriteLine("Event 2 handled"));

        eventManager.PublishEvent("event1", EventArgs.Empty);
        Thread.Sleep(500);
        eventManager.PublishEvent("event2", EventArgs.Empty);
        Thread.Sleep(500);
        eventManager.PublishEvent("event1", EventArgs.Empty);

        Publisher publisher = new Publisher();

        publisher.Subscribe(1, () => Console.WriteLine("Subscriber 1 handled priority 1"));
        publisher.Subscribe(2, () => Console.WriteLine("Subscriber 2 handled priority 2"));
        publisher.Subscribe(1, () => Console.WriteLine("Subscriber 3 handled priority 1"));

        publisher.Publish(1);
        publisher.Publish(2);
        publisher.Publish(1);
    }
}