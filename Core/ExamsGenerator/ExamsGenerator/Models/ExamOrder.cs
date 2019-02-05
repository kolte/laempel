using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class ExamOrder
    {
        public ExamOrder()
        {
            ExamCandidateHeader = new HashSet<ExamCandidateHeader>();
            ExamCandidateLine = new HashSet<ExamCandidateLine>();
            ExamDeliveryLine = new HashSet<ExamDeliveryLine>();
            ExamOrderItem = new HashSet<ExamOrderItem>();
            ExamOrderShuffleHeader = new HashSet<ExamOrderShuffleHeader>();
            ExamOrderShuffleLine = new HashSet<ExamOrderShuffleLine>();
            ExamOrderStatusLog = new HashSet<ExamOrderStatusLog>();
        }

        public int ExamOrderId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Disclaimer { get; set; }
        public string Instruction { get; set; }
        public int? DurationInMinutes { get; set; }
        public string LanguageId { get; set; }
        public int? NumberOfSortVersions { get; set; }
        public int? DegreeOfDifficultyId { get; set; }
        public int? SubjectId { get; set; }
        public int? ClassId { get; set; }

        public Class Class { get; set; }
        public DegreeOfDifficulty DegreeOfDifficulty { get; set; }
        public Language Language { get; set; }
        public Subject Subject { get; set; }
        public ICollection<ExamCandidateHeader> ExamCandidateHeader { get; set; }
        public ICollection<ExamCandidateLine> ExamCandidateLine { get; set; }
        public ICollection<ExamDeliveryLine> ExamDeliveryLine { get; set; }
        public ICollection<ExamOrderItem> ExamOrderItem { get; set; }
        public ICollection<ExamOrderShuffleHeader> ExamOrderShuffleHeader { get; set; }
        public ICollection<ExamOrderShuffleLine> ExamOrderShuffleLine { get; set; }
        public ICollection<ExamOrderStatusLog> ExamOrderStatusLog { get; set; }
    }
}
