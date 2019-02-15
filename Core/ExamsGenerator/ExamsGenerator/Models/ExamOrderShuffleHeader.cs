using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamOrderShuffleHeader
    {
        public long ExamOrderShuffleHeaderId { get; set; }
        public int? ExamOrderId { get; set; }
        public int? ExamOrderShuffleId { get; set; }
        public int? DegreeOfDifficultyId { get; set; }
        public int? NumberOfQuestions { get; set; }

        public virtual ExamOrder ExamOrder { get; set; }
    }
}
