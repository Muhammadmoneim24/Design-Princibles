namespace Loose_vs_Tight_Coupling
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ServiceMode = NotificationModeFactory.Create(NotificationMode.Email);
            NotificationService notificationService = new NotificationService(ServiceMode);
            notificationService.Notify();
            Console.ReadKey();
        }
    }

    class NotificationModeFactory 
    {
        public static INotificationMode Create(NotificationMode mode) 
        {
            switch (mode) 
            {
                case NotificationMode.Email:
                    return new EmailService();


                case NotificationMode.SMS:
                    return new SmsService();

                case NotificationMode.Weird:
                    return new WeirdService();


                default:
                    return new EmailService();
            }
        }
    }

    enum NotificationMode 
    {
        Email,
        SMS,
        Weird
    }

    interface INotificationMode 
    {
        void Send();
    }

    class EmailService : INotificationMode
    {
        public void Send() 
        {
            Console.WriteLine("Email Sent");
        }
    }

    class SmsService :INotificationMode
    {
        public void Send()
        {
            Console.WriteLine("SMS Sent");
        }
    }

    class WeirdService : INotificationMode
    {
        public void Send()
        {
            Console.WriteLine("Weird Sent");
        }
    }
    class NotificationService 
    {
        private readonly INotificationMode _notificationMode;

        public NotificationService(INotificationMode notificationMode)
        {
            _notificationMode = notificationMode;
        }

        public void Notify()
        {
            _notificationMode.Send();
        }
    }
}
