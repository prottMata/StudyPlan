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
    public class DetailsModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public DetailsModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }

        public Plan Plan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Plan = await _context.Plans
                .Include(p => p.IdDiscipNavigation)
                .Include(p => p.IdSemestrNavigation)
                .Include(p => p.IdTypeControlNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Plan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
