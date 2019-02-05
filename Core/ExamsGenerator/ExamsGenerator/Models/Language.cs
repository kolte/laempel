using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class Language
    {
        public Language()
        {
            ExamOrder = new HashSet<ExamOrder>();
            Question = new HashSet<Question>();
        }

        public string LanguageId { get; set; }
        public string Language1 { get; set; }

        public ICollection<ExamOrder> ExamOrder { get; set; }
        public ICollection<Question> Question { get; set; }
    }
}
