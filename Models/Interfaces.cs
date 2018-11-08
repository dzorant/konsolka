namespace konsolowe.Models
{
    public interface IEmailSender  // interface zawsze publiczne > dostęp dla uzytkownia 
    { 
        void SendMessage(string receiver, string title, string message); 
    }

    public class EmailSender : IEmailSender
    {
        void IEmailSender.SendMessage(string receiver, string title, string message)
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IDatabase
    {
        bool IsConnected { get; }
        void Connect();
        User GetUser(string email);
        Order GetOrder(int id);
        void SaveChanges();
    }

    public class DataBase : IDatabase
    {
        bool IDatabase.IsConnected => throw new System.NotImplementedException();

        void IDatabase.Connect()
        {
            throw new System.NotImplementedException();
        }

        Order IDatabase.GetOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        User IDatabase.GetUser(string email)
        {
            throw new System.NotImplementedException();
        }

        void IDatabase.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface IOrderProcessor
    {
        void ProcessOrder(string email, int orderId);
    }

    public class OrderProcessor : IOrderProcessor
    {
        private readonly IDatabase _database;
        private readonly IEmailSender _emailsender;
        public OrderProcessor(IDatabase database, IEmailSender emailSender)
        {
            _database = database;
            _emailsender = emailSender;
        }
        public void ProcessOrder(string email, int orderId)
        {
            User user = _database.GetUser(email);
            Order order = _database.GetOrder(orderId);

            user.PurchaseOrder(order);
            _database.SaveChanges();
            _emailsender.SendMessage(email, "Order purchased", " You have purchased an order.");
        }
    }

    public class FakeEmailSender : IEmailSender
    {
        void IEmailSender.SendMessage(string receiver, string title, string message)
        {
            throw new System.NotImplementedException();
        }
    }
    public class FakeDataBase : IDatabase
    {
        bool IDatabase.IsConnected => throw new System.NotImplementedException();

        void IDatabase.Connect()
        {
            throw new System.NotImplementedException();
        }

        Order IDatabase.GetOrder(int id)
        {
            throw new System.NotImplementedException();
        }

        User IDatabase.GetUser(string email)
        {
            throw new System.NotImplementedException();
        }

        void IDatabase.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Shop
    {
        public void CompleteOrder()
        {
        IDatabase database = new DataBase();
        IEmailSender emailSender = new EmailSender();
        IOrderProcessor orderProcessor = new OrderProcessor(database, emailSender);
        }

        public void CompleteFakeOrder()
        {
        IDatabase database = new FakeDataBase();
        IEmailSender emailSender = new FakeEmailSender();
        IOrderProcessor orderProcessor = new OrderProcessor(database, emailSender);
        }
    }
}