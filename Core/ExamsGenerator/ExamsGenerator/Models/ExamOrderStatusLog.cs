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

        public virtual ExamOrder ExamOrder { get; set; }
        public virtual ExamOrderStatus ExamOrderStatus { get; set; }
    }
}
