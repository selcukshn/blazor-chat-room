using Domain.Base;

namespace Domain
{
    public class Room : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<RoomUser> RoomUsers { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}