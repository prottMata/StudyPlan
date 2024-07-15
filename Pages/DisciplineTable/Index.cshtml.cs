using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.DisciplineTable
{
    public class IndexModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public IndexModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }

        public IList<Discipline> Discipline { get;set; }

        public async Task OnGetAsync()
        {
            Discipline = await _context.Disciplines
                .Include(d => d.IdCathedraNavigation).ToListAsync();
        }
    }
}
