
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAppMVC.Models
{
    public class User
    {
        [Key]
        [DisplayName("User Id")]
        public int UserId { get; set; }
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("User Type")]
        public string UserType { get; set; }
    }
}
