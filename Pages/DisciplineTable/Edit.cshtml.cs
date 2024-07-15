using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.DisciplineTable
{
    public class EditModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public EditModel(StudyPlanProject.Models.StudyPlanContext context)
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
           ViewData["IdCathedra"] = new SelectList(_context.ListCathedras, "Id", "NameCathedra");
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

            _context.Attach(Discipline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineExists(Discipline.Id))
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

        private bool DisciplineExists(int id)
        {
            return _context.Disciplines.Any(e => e.Id == id);
        }
    }
}
