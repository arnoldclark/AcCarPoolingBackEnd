using System.ComponentModel.DataAnnotations.Schema;

namespace AcCarPooling.Models
{
    [Table("LiftRequest")]
    public class LiftRequest
    {
        public int Id { get; set; }
        [ForeignKey("JourneyId")]
        public int JourneyId { get; set; }
        [ForeignKey("DriverId")]

        public int DriverId { get; set; }
        [ForeignKey("PassengerId")]
        public int PassengerId { get; set; }
    }
}
