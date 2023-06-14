using Domain.Base;

namespace Domain
{
    public class Message : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }
        public string Text { get; set; }
        public DateTime MessageDate { get; set; }

        public virtual User User { get; set; }
        public virtual Room Room { get; set; }
    }
}