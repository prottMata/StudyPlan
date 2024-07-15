using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class RefBookCompetency
    {
        public RefBookCompetency()
        {
            DisciplinesCompetencies = new HashSet<DisciplinesCompetency>();
        }

        public int Id { get; set; }
        [Display(Name = "Код")]
        public string Code { get; set; }
        [Display(Name = "Наименование")]
        public string Content { get; set; }
        [Display(Name = "Тип")]
        public string TypeCode { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<DisciplinesCompetency> DisciplinesCompetencies { get; set; }
    }
}
