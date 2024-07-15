using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.CompetenciesTable
{
    public class EditModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public EditModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RefBookCompetency RefBookCompetency { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RefBookCompetency = await _context.RefBookCompetencies.FirstOrDefaultAsync(m => m.Id == id);

            if (RefBookCompetency == null)
            {
                return NotFound();
            }
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

            _context.Attach(RefBookCompetency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefBookCompetencyExists(RefBookCompetency.Id))
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

        private bool RefBookCompetencyExists(int id)
        {
            return _context.RefBookCompetencies.Any(e => e.Id == id);
        }
    }
}
