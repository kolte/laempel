using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class DegreeOfDifficulty
    {
        public DegreeOfDifficulty()
        {
            DegreeOfDifficultyToLevelOfEducationDegreeIdfromNavigation = new HashSet<DegreeOfDifficultyToLevelOfEducation>();
            DegreeOfDifficultyToLevelOfEducationDegreeIdtoNavigation = new HashSet<DegreeOfDifficultyToLevelOfEducation>();
            ExamOrder = new HashSet<ExamOrder>();
            Question = new HashSet<Question>();
        }

        public int DegreeOfDifficultyId { get; set; }

        public virtual ICollection<DegreeOfDifficultyToLevelOfEducation> DegreeOfDifficultyToLevelOfEducationDegreeIdfromNavigation { get; set; }
        public virtual ICollection<DegreeOfDifficultyToLevelOfEducation> DegreeOfDifficultyToLevelOfEducationDegreeIdtoNavigation { get; set; }
        public virtual ICollection<ExamOrder> ExamOrder { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
