using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamOrderStatus
    {
        public ExamOrderStatus()
        {
            ExamOrderStatusLog = new HashSet<ExamOrderStatusLog>();
        }

        public int ExamOrderStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<ExamOrderStatusLog> ExamOrderStatusLog { get; set; }
    }
}
