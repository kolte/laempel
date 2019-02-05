using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamDeliveryHeader
    {
        public long ExamDeliveryHeaderId { get; set; }
        public int? ExamOrderId { get; set; }
        public int? DegreeOfDifficultyId { get; set; }
        public int? NumberOfQuestions { get; set; }
    }
}
