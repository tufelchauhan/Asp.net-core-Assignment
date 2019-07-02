using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsAppAPI.Models
{
    public class TestResult
    {
        public TestResult(int testResultId, string athleteName, int testId, int distance, string rating)
        {
            TestResultId = testResultId;
            AthleteName = athleteName;
            TestId = testId;
            Distance = distance;
            Rating = rating;
        }

        [Key]
        public int TestResultId { get; set; }
        [Required]
        public string AthleteName { get; set; }
        [Required]
        public int TestId { get; set; }
        [Required]
        public int Distance { get; set; }
        [Required]
        public string Rating { get; set; }
    }
}
