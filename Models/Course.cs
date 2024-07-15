using System;
using System.Collections.Generic;

#nullable disable

namespace StudyPlanProject.Models
{
    public partial class Course
    {
        public Course()
        {
            Semesters = new HashSet<Semester>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
