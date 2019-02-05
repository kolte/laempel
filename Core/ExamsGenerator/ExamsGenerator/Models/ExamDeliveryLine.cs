using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamDeliveryLine
    {
        public long ExamDeliveryLineId { get; set; }
        public int? ExamOrderId { get; set; }
        public int? QuestionTypeId { get; set; }
        public long? QuestionId { get; set; }
        public string Question { get; set; }
        public long? AnswerId { get; set; }
        public string Answer { get; set; }
        public int? DegreeOfDifficultyId { get; set; }
        public bool? Value { get; set; }

        public Answer AnswerNavigation { get; set; }
        public ExamOrder ExamOrder { get; set; }
        public Question QuestionNavigation { get; set; }
    }
}
