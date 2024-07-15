using System;
using System.Collections.Generic;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class ControlForm
    {
        public int Id { get; set; }
        public int? Exam { get; set; }
        public int? Credit { get; set; }
        public int? ScoreCredit { get; set; }
        public int? Kp { get; set; }
        public int? Kt { get; set; }
        public int IdDiscip { get; set; }

        public virtual Discipline IdDiscipNavigation { get; set; }
    }
}
