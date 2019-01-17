namespace AcCarPooling.Models
{
    public class LiftRequest
    {
        public int Id { get; set; }
        public Journey Journey { get; set; }
        public User Driver { get; set; }
        public User Passenger { get; set; }
    }
}
