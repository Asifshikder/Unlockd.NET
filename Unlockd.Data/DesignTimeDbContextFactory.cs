using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace Unlockd.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<UnlockdContext>
    {
        public UnlockdContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UnlockdContext>();
            optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=unlockdb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new UnlockdContext(optionsBuilder.Options);
        }
    }
}
