using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeachingAssistantUltimate.Model
{
    public class Classes
    {
        [Key]
        public short ClassesID { get; set; }

        [Required, StringLength(10, MinimumLength = 3)]
        public string ClassName { get; set; }

        [Required, StringLength(20, MinimumLength = 3)]
        public string IndexPrefix { get; set; }

        [Timestamp, ConcurrencyCheck]
        public byte[] Concurrency { get; set; }

        public virtual ICollection<Students> Students { get; set; }
    }
}
