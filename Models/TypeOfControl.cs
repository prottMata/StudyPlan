using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class TypeOfControl
    {
        public TypeOfControl()
        {
            Plans = new HashSet<Plan>();
        }

        public int IdToc { get; set; }
        [Display(Name = "з.е.")]
        public int? CreditUnits { get; set; }
        [Display(Name = "Итого")]
        public int? Total { get; set; }
        [Display(Name = "Ауд")]
        public int? Aud { get; set; }
        [Display(Name = "Лек")]
        public int? Lection { get; set; }
        [Display(Name = "Лаб")]
        public int? Lab { get; set; }
        [Display(Name = "Пр")]
        public int? Pract { get; set; }
        [Display(Name = "АттК")]
        public float? AttC { get; set; }
        [Display(Name = "СР")]
        public float? Aver { get; set; }
        [Display(Name = "Контроль")]
        public float? Control { get; set; }

        public virtual ICollection<Plan> Plans { get; set; }
    }
}
