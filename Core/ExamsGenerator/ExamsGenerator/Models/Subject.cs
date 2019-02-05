using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class Subject
    {
        public Subject()
        {
            ExamOrder = new HashSet<ExamOrder>();
            Question = new HashSet<Question>();
            QuestionToSubject = new HashSet<QuestionToSubject>();
        }

        public int SubjectId { get; set; }
        public string Name { get; set; }

        public ICollection<ExamOrder> ExamOrder { get; set; }
        public ICollection<Question> Question { get; set; }
        public ICollection<QuestionToSubject> QuestionToSubject { get; set; }
    }
}
