using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Buga_Loredana_Labul2.Data;
using Buga_Loredana_Labul2.Models;

namespace Buga_Loredana_Labul2.Pages.Members
{
    public class DeleteModel : PageModel
    {
        private readonly Buga_Loredana_Labul2.Data.Buga_Loredana_Labul2Context _context;

        public DeleteModel(Buga_Loredana_Labul2.Data.Buga_Loredana_Labul2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Member Member { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FirstOrDefaultAsync(m => m.ID == id);

            if (member == null)
            {
                return NotFound();
            }
            else
            {
                Member = member;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member != null)
            {
                Member = member;
                _context.Member.Remove(Member);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
