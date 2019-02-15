using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class Answer
    {
        public Answer()
        {
            AnswerToQuestion = new HashSet<AnswerToQuestion>();
            ExamDeliveryLine = new HashSet<ExamDeliveryLine>();
            ExamOrderShuffleLine = new HashSet<ExamOrderShuffleLine>();
        }

        public long AnswerId { get; set; }
        public string Text { get; set; }
        public int? UserId { get; set; }
        public string LanguageId { get; set; }

        public virtual ICollection<AnswerToQuestion> AnswerToQuestion { get; set; }
        public virtual ICollection<ExamDeliveryLine> ExamDeliveryLine { get; set; }
        public virtual ICollection<ExamOrderShuffleLine> ExamOrderShuffleLine { get; set; }
    }
}
