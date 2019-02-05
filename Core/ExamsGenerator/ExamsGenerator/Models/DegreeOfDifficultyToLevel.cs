using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class DegreeOfDifficultyToLevel
    {
        public int DegreeOfDifficultyToLevelOfEductionId { get; set; }
        public int? DegreeIdfrom { get; set; }
        public int? DegreeIdto { get; set; }
        public int? LevelId { get; set; }
    }
}
