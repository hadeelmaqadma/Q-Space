using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QSpace.Data.DbEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Data.Data
{
    public class QSpaceDbContext : IdentityDbContext<User>
    {
        public QSpaceDbContext(DbContextOptions<QSpaceDbContext> options)
            : base(options)
        {

        }
        public DbSet<QuizDbEntity> Quizes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<QuizDbEntity>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}
