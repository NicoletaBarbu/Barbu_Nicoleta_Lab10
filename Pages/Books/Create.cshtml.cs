﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Barbu_Nicoleta_Lab9.Data;
using Barbu_Nicoleta_Lab9.Models;
using Microsoft.EntityFrameworkCore;

namespace Barbu_Nicoleta_Lab9.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly Barbu_Nicoleta_Lab9.Data.Barbu_Nicoleta_Lab9Context _context;

        public CreateModel(Barbu_Nicoleta_Lab9.Data.Barbu_Nicoleta_Lab9Context context)
        {
            _context = context;
        }

        public IList<Publisher> Publishers { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Publishers = await _context.Publisher.ToListAsync();
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
