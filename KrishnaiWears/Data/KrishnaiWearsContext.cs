using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KrishnaiWears.Shared;

    public class KrishnaiWearsContext : DbContext
    {
        public KrishnaiWearsContext (DbContextOptions<KrishnaiWearsContext> options)
            : base(options)
        {
        }

        public DbSet<KrishnaiWears.Shared.Cloth> Cloth { get; set; } = default!;
    }
