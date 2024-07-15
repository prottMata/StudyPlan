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
    public class DetailsModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public DetailsModel(StudyPlanProject.Models.StudyPlanContext context)
        {
            _context = context;
        }

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
    }
}
