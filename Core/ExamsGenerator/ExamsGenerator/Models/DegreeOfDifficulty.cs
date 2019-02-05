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

        public ICollection<DegreeOfDifficultyToLevelOfEducation> DegreeOfDifficultyToLevelOfEducationDegreeIdfromNavigation { get; set; }
        public ICollection<DegreeOfDifficultyToLevelOfEducation> DegreeOfDifficultyToLevelOfEducationDegreeIdtoNavigation { get; set; }
        public ICollection<ExamOrder> ExamOrder { get; set; }
        public ICollection<Question> Question { get; set; }
    }
}
