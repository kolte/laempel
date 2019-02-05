using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class Question
    {
        public Question()
        {
            AnswerToQuestion = new HashSet<AnswerToQuestion>();
            ExamCandidateLine = new HashSet<ExamCandidateLine>();
            ExamDeliveryLine = new HashSet<ExamDeliveryLine>();
            ExamOrderShuffleLine = new HashSet<ExamOrderShuffleLine>();
        }

        public long QuestionId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UserId { get; set; }
        public string LanguageId { get; set; }
        public string Text { get; set; }
        public int? SubjectId { get; set; }
        public int? DegreeOfDifficultyId { get; set; }
        public int? QuestionTypeId { get; set; }
        public int? LevelOfEducationInternationalId { get; set; }

        public DegreeOfDifficulty DegreeOfDifficulty { get; set; }
        public Language Language { get; set; }
        public LevelOfEducationInternational LevelOfEducationInternational { get; set; }
        public QuestionType QuestionType { get; set; }
        public Subject Subject { get; set; }
        public ICollection<AnswerToQuestion> AnswerToQuestion { get; set; }
        public ICollection<ExamCandidateLine> ExamCandidateLine { get; set; }
        public ICollection<ExamDeliveryLine> ExamDeliveryLine { get; set; }
        public ICollection<ExamOrderShuffleLine> ExamOrderShuffleLine { get; set; }
    }
}
