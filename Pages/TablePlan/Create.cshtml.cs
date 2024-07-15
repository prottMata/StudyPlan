using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.TablePlan
{
    public class CreateModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public CreateModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["IdDiscip"] = new SelectList(_context.Disciplines, "Id", "Code");
        ViewData["IdSemestr"] = new SelectList(_context.Semesters, "Id", "Name");
        ViewData["IdTypeControl"] = new SelectList(_context.TypeOfControls, "IdToc", "IdToc");
            return Page();
        }

        [BindProperty]
        public Plan Plan { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Plans.Add(Plan);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
