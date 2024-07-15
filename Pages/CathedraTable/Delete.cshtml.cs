using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.CathedraTable
{
    public class DeleteModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public DeleteModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ListCathedra ListCathedra { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListCathedra = await _context.ListCathedras.FirstOrDefaultAsync(m => m.Id == id);

            if (ListCathedra == null)
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

            ListCathedra = await _context.ListCathedras.FindAsync(id);

            if (ListCathedra != null)
            {
                _context.ListCathedras.Remove(ListCathedra);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
