using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class Class
    {
        public Class()
        {
            ExamOrder = new HashSet<ExamOrder>();
        }

        public int ClassId { get; set; }
        public string Name { get; set; }
        public int? InstituteId { get; set; }
        public int? LevelOfEducationInternationalId { get; set; }

        public virtual Institute Institute { get; set; }
        public virtual LevelOfEducationInternational LevelOfEducationInternational { get; set; }
        public virtual ICollection<ExamOrder> ExamOrder { get; set; }
    }
}
