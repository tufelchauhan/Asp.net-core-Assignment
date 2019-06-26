using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAppAPI.Models
{
    public partial class Test
    {
        [Key]
        public int TestId { get; set; }
        [Required]
        public string TestDate { get; set; }
        [Required]
        public string TestType { get; set; }
    }
}
