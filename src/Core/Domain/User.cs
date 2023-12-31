using Domain.Base;

namespace Domain
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool EmailConfirmed { get; set; }
        public DateTime RegisterDate { get; set; }

        public virtual List<UserRoom> UserRooms { get; set; }
        public virtual List<Room> Rooms { get; set; }
        public virtual List<Message> Messages { get; set; }
    }
}