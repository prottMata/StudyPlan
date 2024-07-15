﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyPlanProject.Models;

namespace StudyPlanProject.Pages.CompetenciesTable
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
            return Page();
        }

        [BindProperty]
        public RefBookCompetency RefBookCompetency { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RefBookCompetencies.Add(RefBookCompetency);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}