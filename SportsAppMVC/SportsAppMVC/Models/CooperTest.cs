using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAppMVC.Models
{
    public class CooperTest
    {
        [Key]
        [DisplayName("Test Id")]
        public int TestID { get; set; }
        [Required]
        [DisplayName("Test Name")]
        public string TestName { get; set; }
    }
}
