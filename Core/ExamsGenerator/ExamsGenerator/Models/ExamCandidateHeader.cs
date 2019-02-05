using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamCandidateHeader
    {
        public long ExamCandidateHeaderId { get; set; }
        public int? ExamOrderId { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? SubmitDate { get; set; }
        public DateTime? EvaluationDate { get; set; }
        public int? PointsScored { get; set; }
        public DateTime? CreateDate { get; set; }

        public ExamOrder ExamOrder { get; set; }
        public User User { get; set; }
    }
}
