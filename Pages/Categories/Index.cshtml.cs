using Buga_Loredana_Labul2.Data;
using Buga_Loredana_Labul2.Models;
using Buga_Loredana_Labul2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buga_Loredana_Labul2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Buga_Loredana_Labul2.Data.Buga_Loredana_Labul2Context _context;

        public IndexModel(Buga_Loredana_Labul2.Data.Buga_Loredana_Labul2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }

        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CategoryData = new CategoryIndexData();

            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                .ThenInclude(i => i.Book)    
                .ThenInclude(b => b.Author) 
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;

                var category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();

                CategoryData.Books = category.BookCategories
                    .Select(bc => bc.Book);
            }
        }
    }
}
