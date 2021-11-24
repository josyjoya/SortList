using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SortList.Models;

namespace SortList.Data
{
    public class RazorPagesSortListContext : DbContext
    {
        public RazorPagesSortListContext (DbContextOptions<RazorPagesSortListContext> options)
            : base(options)
        {
        }

        public DbSet<SortList.Models.ListData> ListData { get; set; }
    }
}
