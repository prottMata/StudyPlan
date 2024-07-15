using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.DisciplineTable
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
        ViewData["IdCathedra"] = new SelectList(_context.ListCathedras, "Id", "NameCathedra");
            return Page();
        }

        [BindProperty]
        public Discipline Discipline { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Disciplines.Add(Discipline);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
