using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

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
        public Journey Journey { get; set; }
    }
}
