using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAppMVC.Models
{
    public class TestResult
    {
        [Key]
        [DisplayName("Result Id")]
        public int ResultId { get; set; }
        [Required]
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [Required]
        [DisplayName("Test Id")]
        public int TestId { get; set; }
        [Required]
        [DisplayName("Meters")]
        public int Points { get; set; }
    }
}
