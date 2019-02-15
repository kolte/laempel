using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class DegreeOfDifficultyToLevelOfEducation
    {
        public long DegreeOfDifficultyToLevelOfEduction { get; set; }
        public int? DegreeIdfrom { get; set; }
        public int? DegreeIdto { get; set; }
        public int? LevelOfEductionId { get; set; }

        public virtual DegreeOfDifficulty DegreeIdfromNavigation { get; set; }
        public virtual DegreeOfDifficulty DegreeIdtoNavigation { get; set; }
        public virtual LevelOfEducationInternational LevelOfEduction { get; set; }
    }
}
