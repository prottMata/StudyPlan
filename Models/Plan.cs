using System;
using System.Collections.Generic;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class Plan
    {
        public int Id { get; set; }
        public int IdDiscip { get; set; }
        public int IdSemestr { get; set; }
        public int? IdTypeControl { get; set; }

        public virtual Discipline IdDiscipNavigation { get; set; }
        public virtual Semester IdSemestrNavigation { get; set; }
        public virtual TypeOfControl IdTypeControlNavigation { get; set; }
    }
}
