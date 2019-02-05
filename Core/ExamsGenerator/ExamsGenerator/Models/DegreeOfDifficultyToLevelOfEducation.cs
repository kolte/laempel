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

        public DegreeOfDifficulty DegreeIdfromNavigation { get; set; }
        public DegreeOfDifficulty DegreeIdtoNavigation { get; set; }
        public LevelOfEducationInternational LevelOfEduction { get; set; }
    }
}
