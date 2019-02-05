using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class AnswerToQuestion
    {
        public long AnswerToQuestionId { get; set; }
        public long AnswerId { get; set; }
        public long QuestionId { get; set; }
        public bool Value { get; set; }

        public Answer Answer { get; set; }
        public Question Question { get; set; }
    }
}
