using System;
using System.Collections.Generic;

namespace ExamsGenerator.Models
{
    public partial class User
    {
        public User()
        {
            ExamCandidateHeader = new HashSet<ExamCandidateHeader>();
            ExamCandidateLine = new HashSet<ExamCandidateLine>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? RoleId { get; set; }

        public virtual ICollection<ExamCandidateHeader> ExamCandidateHeader { get; set; }
        public virtual ICollection<ExamCandidateLine> ExamCandidateLine { get; set; }
    }
}
