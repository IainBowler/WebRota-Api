using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRotaApi.Models;

namespace WebRotaApi.Persistence
{
    public class WebRotaDbContext :DbContext
    {
        public WebRotaDbContext(DbContextOptions<WebRotaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organisation> Organisations { get; set; }
    }
}
