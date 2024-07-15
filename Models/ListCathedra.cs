using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class ListCathedra
    {
        public ListCathedra()
        {
            Disciplines = new HashSet<Discipline>();
        }

        public int Id { get; set; }
        [Display(Name = "Код")]
        public int Number { get; set; }
        [Display(Name = "Кафедра")]
        public string NameCathedra { get; set; }

        public virtual ICollection<Discipline> Disciplines { get; set; }
    }
}
