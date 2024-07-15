using System;
using System.Collections.Generic;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class DisciplinesCompetency
    {
        public int Id { get; set; }
        public int? IdRef { get; set; }
        public int? IdDiscip { get; set; }

        public virtual Discipline IdDiscipNavigation { get; set; }
        public virtual RefBookCompetency IdRefNavigation { get; set; }
    }
}
