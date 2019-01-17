using System.ComponentModel.DataAnnotations.Schema;

namespace AcCarPooling.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public bool IsDriver { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string From { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? JourneyId { get; set; }
        public Journey Journey { get; set; }
    }
}
