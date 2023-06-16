namespace Application.Mediator.Queries.Room.GetRooms
{
    public class GetRoomsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsPublic { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Username { get; set; }
        public int UserCount { get; set; }
    }
}