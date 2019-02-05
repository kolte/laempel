using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamOrderStatusLog
    {
        public long ExamOrderStatusLogId { get; set; }
        public int? ExamOrderId { get; set; }
        public string Date { get; set; }
        public string UserId { get; set; }
        public int? ExamOrderStatusId { get; set; }

        public ExamOrder ExamOrder { get; set; }
        public ExamOrderStatus ExamOrderStatus { get; set; }
    }
}
