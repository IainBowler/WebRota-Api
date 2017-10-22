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
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<OrganisationMember> OrganisationMembers { get; set; }
        public DbSet<Member> Members { get; set; }

        public WebRotaDbContext(DbContextOptions<WebRotaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganisationMember>()
                .HasKey(om => new { om.MemberId, om.OrganisationId });

            modelBuilder.Entity<OrganisationMember>()
                .ToTable("OrganisationMembers");

            modelBuilder.Entity<Member>()
                .ToTable("Members");

        }
    }
}
