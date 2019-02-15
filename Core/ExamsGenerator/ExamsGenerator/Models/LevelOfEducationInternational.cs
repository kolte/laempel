﻿using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class LevelOfEducationInternational
    {
        public LevelOfEducationInternational()
        {
            Class = new HashSet<Class>();
            DegreeOfDifficultyToLevelOfEducation = new HashSet<DegreeOfDifficultyToLevelOfEducation>();
            Question = new HashSet<Question>();
        }

        public int LevelOfEducationInternationalId { get; set; }
        public string Iscedcode { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        public virtual ICollection<Class> Class { get; set; }
        public virtual ICollection<DegreeOfDifficultyToLevelOfEducation> DegreeOfDifficultyToLevelOfEducation { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
