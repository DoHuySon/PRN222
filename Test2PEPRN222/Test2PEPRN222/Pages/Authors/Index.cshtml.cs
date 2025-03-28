﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test2PEPRN222.Models;

namespace Test2PEPRN222.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Test2PEPRN222.Models.LibraryManagementContext _context;

        public IndexModel(Test2PEPRN222.Models.LibraryManagementContext context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Author = await _context.Authors.ToListAsync();
        }
    }
}
