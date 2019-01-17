using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace AcCarPooling.Models
{
    [Table("Journey")]
    public class Journey
    {
        public int Id { get; set; }
        public string Destination { get; set; }
        public ICollection<User> Users { get; set; }
    }
}