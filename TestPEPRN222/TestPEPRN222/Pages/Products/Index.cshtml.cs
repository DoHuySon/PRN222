using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TestPEPRN222.Models;

namespace TestPEPRN222.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly TestPEPRN222.Models.MyStockContext _context;

        public IndexModel(TestPEPRN222.Models.MyStockContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.ToListAsync();
        }
    }
}
