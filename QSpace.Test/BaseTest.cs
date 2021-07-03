using QSpace.Data;
using Microsoft.EntityFrameworkCore;
using QSpace.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using QSpace.Infrastructure.AutoMapper;

namespace QSpace.Test
{
    public abstract class BaseTest
    {
        protected QSpaceDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<QSpaceDbContext>().Options;
            return new QSpaceDbContext(options);
        }
        protected IMapper GetMapper() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            return config.CreateMapper();
        }
    }
}
