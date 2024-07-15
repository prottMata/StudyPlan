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
    public class DeleteModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public DeleteModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Discipline Discipline { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discipline = await _context.Disciplines
                .Include(d => d.IdCathedraNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Discipline == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discipline = await _context.Disciplines.FindAsync(id);

            if (Discipline != null)
            {
                _context.Disciplines.Remove(Discipline);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
