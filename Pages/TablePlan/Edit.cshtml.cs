using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.TablePlan
{
    public class EditModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public EditModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["IdDiscip"] = new SelectList(_context.Disciplines, "Id", "Code");
           ViewData["IdSemestr"] = new SelectList(_context.Semesters, "Id", "Name");
           ViewData["IdTypeControl"] = new SelectList(_context.TypeOfControls, "IdToc", "IdToc");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(Plan.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PlanExists(int id)
        {
            return _context.Plans.Any(e => e.Id == id);
        }
    }
}
