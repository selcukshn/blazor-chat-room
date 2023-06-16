namespace Application.Mediator.Queries.User.GetUserRooms
{
    public class GetUserRoomsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public GetUserRoomsViewModel() { }
        public GetUserRoomsViewModel(Domain.Room entity)
        {
            Id = entity.Id;
            Title = entity.Title;
            Description = entity.Description;
            CreatedDate = entity.CreatedDate;
        }
    }
}