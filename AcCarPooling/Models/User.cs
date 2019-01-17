using System.ComponentModel.DataAnnotations.Schema;

namespace AcCarPooling.Models
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string From { get; set; }
        public string Gender { get; set; }
        public string ContactDetails { get; set; }
        public Journey Journey { get; set; }
    }
}
