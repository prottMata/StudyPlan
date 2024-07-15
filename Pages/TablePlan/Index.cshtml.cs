using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.TablePlan
{
    public class IndexModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public IndexModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }
      
        public IList<Plan> Plan { get;set; }
        public async Task OnGetAsync()
        {
            Plan = await _context.Plans
                .Include(p => p.IdDiscipNavigation)
                .Include(p => p.IdSemestrNavigation)
                .Include(p => p.IdTypeControlNavigation)
                .ToListAsync();
        }
    }
}
