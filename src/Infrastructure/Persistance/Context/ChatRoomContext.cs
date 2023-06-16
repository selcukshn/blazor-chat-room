using System.Reflection;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class ChatRoomContext : DbContext
    {
        public ChatRoomContext() { }
        public ChatRoomContext(DbContextOptions<ChatRoomContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=SELCUK\\SQLEXPRESS;Initial Catalog=ChatRoomDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<UserRoom> UserRooms { get; set; }
    }
}