using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Plans = new HashSet<Plan>();
        }

        public int Id { get; set; }
        [Display(Name = "Семестр")]
        public string Name { get; set; }
        public int? IdCourse { get; set; }

        public virtual Course IdCourseNavigation { get; set; }
        public virtual ICollection<Plan> Plans { get; set; }
    }
}
