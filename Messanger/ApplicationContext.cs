using Microsoft.EntityFrameworkCore;

namespace Messanger
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Message> Messages { get; set; }
        public ApplicationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=opd;Username=postgres;Password=12345");
        }
        public List<Client> GetClients()
        {
            return this.Clients.ToList();
        }
        public Client? GetClient(int id)
        {
            return this.Clients.First(c => c.Id == id);
        }
        public void SetClient(Client client)
        {
            this.Clients.Add(client);
            this.SaveChanges();
        }
        public void DeleteClient(int id)
        {
            var client = GetClient(id);
            if (client == null)
            {
                return;
            }
            this.Clients.Remove(client);
            this.SaveChanges();
        }
        public void UpdateClient(Client client)
        {
            var c = GetClient(client.Id);
            if (c == null)
            {
                this.SetClient(client);
                return;
            }
            c.Name = client.Name;
            c.Email = client.Email;
            c.Password = client.Password;
            c.About = client.About;
            this.SaveChanges();
        }
        public List<Message> GetMessages()
        {
            return this.Messages.ToList();
        }
        public Message? GetMessage(int id)
        {
            return this.Messages.First(m => m.Id == id);
        }
        public void SetMessage(Message message)
        {
            this.Messages.Add(message);
            this.SaveChanges();
        }
        public void DeleteMessage(int id)
        {
            var message = GetMessage(id);
            if (message == null)
            {
                return;
            }
            this.Messages.Remove(message);
            this.SaveChanges();
        }
        public void UpdateMessage(Message message)
        {
            var m = GetMessage(message.Id);
            if (m == null)
            {
                this.SetMessage(message);
                return;
            }
            m.Content = message.Content;
            this.SaveChanges();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().HasData(
             new Client[]
             {
                new Client { Id = 1, Name = "Viktor", Email = "viktor@mail.ru", Password = "1234", About = "My name is Viktor, dev from California" },
                new Client { Id = 2, Name = "Kiktor", Email = "kiktor@mail.ru", Password = "5678", About = "ZXC ghoul" },
                new Client { Id = 3, Name = "Mikola", Email = "mikola@mail.ru", Password = "9876", About = "" }
             });

            modelBuilder.Entity<Message>().HasData(
                new Message[]
                {
                    new Message { Id = 1, Content = "Hi, how are you?", SenderId = 1, ReceiverId = 2 },
                    new Message { Id = 2, Content = "I'm fine, Thanks", SenderId = 2, ReceiverId = 1 },
                    new Message { Id = 3, Content = "Do you like C++?", SenderId = 2, ReceiverId = 3 },
                    new Message { Id = 4, Content = "One of my favourites!", SenderId = 3, ReceiverId = 2 }
                });

            modelBuilder.Entity<Message>()
                .Property(m => m.Time)
                .HasDefaultValueSql("current_timestamp");
        }
    }
}