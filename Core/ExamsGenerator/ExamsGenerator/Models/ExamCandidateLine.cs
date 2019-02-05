using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamCandidateLine
    {
        public long ExamCanditateLineId { get; set; }
        public int? ExamOrderId { get; set; }
        public int? UserId { get; set; }
        public long? QuestionId { get; set; }
        public long? AnswerId { get; set; }
        public bool? Value { get; set; }

        public ExamOrder ExamOrder { get; set; }
        public Question Question { get; set; }
        public User User { get; set; }
    }
}
