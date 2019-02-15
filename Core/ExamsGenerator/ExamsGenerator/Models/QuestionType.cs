using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            ExamOrderItem = new HashSet<ExamOrderItem>();
            Question = new HashSet<Question>();
        }

        public int QuestionTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ExamOrderItem> ExamOrderItem { get; set; }
        public virtual ICollection<Question> Question { get; set; }
    }
}
