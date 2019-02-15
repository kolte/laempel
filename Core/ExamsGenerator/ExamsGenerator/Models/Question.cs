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
        public string Author { get; set; }

        public virtual AspNetUsers AuthorNavigation { get; set; }
        public virtual DegreeOfDifficulty DegreeOfDifficulty { get; set; }
        public virtual Language Language { get; set; }
        public virtual LevelOfEducationInternational LevelOfEducationInternational { get; set; }
        public virtual QuestionType QuestionType { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<AnswerToQuestion> AnswerToQuestion { get; set; }
        public virtual ICollection<ExamCandidateLine> ExamCandidateLine { get; set; }
        public virtual ICollection<ExamDeliveryLine> ExamDeliveryLine { get; set; }
        public virtual ICollection<ExamOrderShuffleLine> ExamOrderShuffleLine { get; set; }
    }
}
