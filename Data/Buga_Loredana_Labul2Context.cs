using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Buga_Loredana_Labul2.Models;

namespace Buga_Loredana_Labul2.Data
{
    public class Buga_Loredana_Labul2Context : DbContext
    {
        public Buga_Loredana_Labul2Context (DbContextOptions<Buga_Loredana_Labul2Context> options)
            : base(options)
        {
        }

        public DbSet<Buga_Loredana_Labul2.Models.Book> Book { get; set; } = default!;
        public DbSet<Buga_Loredana_Labul2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Author { get; set; } = default!;
        public DbSet<Buga_Loredana_Labul2.Models.Category> Category { get; set; } = default!;
        public DbSet<Buga_Loredana_Labul2.Models.Member> Member { get; set; } = default!;
        public DbSet<Buga_Loredana_Labul2.Models.Borrowing> Borrowing { get; set; } = default!;
    }
}
