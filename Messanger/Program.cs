namespace Messanger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var clients = db.GetClients();
                var messages = db.GetMessages();

                Console.WriteLine("Client and messages");

                foreach (Message m in messages)
                {
                    var sender = db.GetClient(m.SenderId);
                    var receiver = db.GetClient(m.ReceiverId);
                    Console.WriteLine($"{sender.Name} send '{m.Content}' to {receiver.Name} ");
                }


                var newClient = new Client() { Id = 4, Name = "Volodimir", Email = "anime@mail.ru", Password = "3123", About = "" };
                db.SetClient(newClient);

                var newMessage = new Message() { Id = 5, SenderId = 4, ReceiverId = 1, Content = "Shalom!" };
                db.SetMessage(newMessage);


                messages = db.GetMessages();

                foreach (Message m in messages)
                {
                    var sender = db.GetClient(m.SenderId);
                    var receiver = db.GetClient(m.ReceiverId);
                    Console.WriteLine($"{sender.Name} send '{m.Content}' to {receiver.Name} ");
                }

                db.DeleteClient(4);
                db.DeleteMessage(5);

                messages = db.GetMessages();

                foreach (Message m in messages)
                {
                    var sender = db.GetClient(m.SenderId);
                    var receiver = db.GetClient(m.ReceiverId);
                    Console.WriteLine($"{sender.Name} send '{m.Content}' to {receiver.Name} ");
                }
            }
        }

    }
}