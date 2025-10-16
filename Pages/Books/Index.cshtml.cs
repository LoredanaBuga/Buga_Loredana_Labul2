using Buga_Loredana_Labul2.Data;
using Buga_Loredana_Labul2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Buga_Loredana_Labul2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Buga_Loredana_Labul2.Data.Buga_Loredana_Labul2Context _context;

        public IndexModel(Buga_Loredana_Labul2.Data.Buga_Loredana_Labul2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;


        public async Task OnGetAsync()
        {

             Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();

           // if (AuthorID != null)
            //{
               // books = books.Where(b => b.AuthorID == AuthorID);
           // }

           // Book = await books.ToListAsync();
        }
    }
}
