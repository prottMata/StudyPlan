using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            DisciplinesCompetencies = new HashSet<DisciplinesCompetency>();
            Plans = new HashSet<Plan>();
        }

        public int Id { get; set; }
        [Display(Name ="Код")]
        public string Code { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        public int? IdCathedra { get; set; }

        [Display(Name = "Кафедра")]
        public virtual ListCathedra IdCathedraNavigation { get; set; }
        public virtual ControlForm ControlForm { get; set; }
        public virtual ICollection<DisciplinesCompetency> DisciplinesCompetencies { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
