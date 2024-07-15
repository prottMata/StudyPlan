using System;
using System.Collections.Generic;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class FixedCathedra
    {
        public int Id { get; set; }
        public int IdCathedra { get; set; }
        public int IdCompet { get; set; }

        public virtual ListCathedra IdCathedraNavigation { get; set; }
        public virtual RefBookCompetency IdCompetNavigation { get; set; }
    }
}
