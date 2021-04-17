using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace QSpace.Data.Data
{
    public class QSpaceDbContext : IdentityDbContext
    {
        public QSpaceDbContext(DbContextOptions<QSpaceDbContext> options)
            : base(options)
        {
        }
    }
}
