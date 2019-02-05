using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class QuestionToSubject
    {
        public long QuestionToSubjectId { get; set; }
        public long? QuestionId { get; set; }
        public int? SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
