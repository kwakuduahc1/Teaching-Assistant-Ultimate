using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachingAssistant.Model
{
    public class Subjects
    {
        public int SubjectsID { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 5)]
        public string Subject { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Questions> Questions { get; set; }
    }
}
