using Domain.Base;

namespace Domain
{
    public class UserRoom : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid RoomId { get; set; }

        public virtual User User { get; set; }
        public virtual Room Room { get; set; }
    }
}