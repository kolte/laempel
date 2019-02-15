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

        public virtual ExamOrder ExamOrder { get; set; }
        public virtual QuestionType QuestionType { get; set; }
    }
}
