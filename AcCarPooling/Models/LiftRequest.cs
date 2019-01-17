using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcCarPooling.Models
{
    public class LiftRequest
    {
        public Journey Journey { get; set; }
        public User Driver { get; set; }
        public User Passenger { get; set; }
    }
}
