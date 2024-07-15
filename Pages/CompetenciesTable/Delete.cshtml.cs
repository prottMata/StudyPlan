﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.CompetenciesTable
{
    public class DeleteModel : PageModel
    {
        private readonly StudyPlanProject.Models.StudyPlanContext _context;

        public DeleteModel(StudyPlanProject.Models.StudyPlanContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RefBookCompetency = await _context.RefBookCompetencies.FindAsync(id);

            if (RefBookCompetency != null)
            {
                _context.RefBookCompetencies.Remove(RefBookCompetency);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
