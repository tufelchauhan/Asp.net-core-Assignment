using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAppAPI.Models
{
    public class TestsList
    {
        public int TestId { get; set; }
        public string TestDate { get; set; }
        public int ParticipantsCount { get; set; }
        public string TestType { get; set; }
    }
}
