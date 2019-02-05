using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamCompositionLine
    {
        public long ExamCompositionLineId { get; set; }
        public int? ExamOrderId { get; set; }
        public int? PositionNr { get; set; }
        public long? QuestionId { get; set; }
        public string Question { get; set; }
        public long? AnswerToQuestionId { get; set; }
        public string Answer { get; set; }
        public bool? Value { get; set; }
        public int? SortVersionId { get; set; }
    }
}
