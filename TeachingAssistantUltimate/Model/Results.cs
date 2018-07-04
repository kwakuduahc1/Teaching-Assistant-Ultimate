using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TeachingAssistantUltimate.Model
{
    public class Results
    {
        [Key]
        public int ResultsID { get; set; }

        [Required]
        public int StudentsID { get; set; }

        [Required]
        public int SubjectsID { get; set; }

        [Required]
        public byte AssessmentTypesID { get; set; }

        [Required]
        [Range(0, 100)]
        public double Score { get; set; }

        [Required]
        [Range(1, 100)]
        public double TotalScore { get; set; }

        public virtual Students Students { get; set; }

        public virtual AssessmentTypes AssessmentTypes { get; set; }

        public virtual Subjects Subjects { get; set; }
    }
}
