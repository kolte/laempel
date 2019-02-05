using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamOrderItem
    {
        public int ExamOrderItemId { get; set; }
        public int? ExamOrderId { get; set; }
        public int? QuestionTypeId { get; set; }
        public int? NumberOfQuestions { get; set; }

        public ExamOrder ExamOrder { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
