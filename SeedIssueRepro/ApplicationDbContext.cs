using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace SeedIssueRepro
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext()
        {
            
        }

        public DbSet<SomeRootEntity> RootEntities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder
               .UseSqlServer("Server=(localdb)\\ProjectsV13;Initial Catalog=SeedIssueRepro;Integrated Security=SSPI");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Guid rootEntityId = Guid.NewGuid();

            modelBuilder.Entity<SomeRootEntity>().HasData(new SomeRootEntity() {Id = rootEntityId, Name = "Test"});

            modelBuilder.Entity<SomeRootEntity>()
                        .OwnsOne(x => x.UpdateDetails)
                        .HasData(new
                                 {
                                     SomeRootEntityId = rootEntityId,
                                     LastUpdatedBy = "Seed",
                                     LastUpdatedAt = DateTime.Now
                                 });
        }

        
    
    }
}
