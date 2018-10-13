using System;
using System.Linq;

namespace SeedIssueRepro
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var entity = context.RootEntities.First();

                Console.WriteLine("Entity Id = {0}, Last Updated={1}",entity.Id, entity.UpdateDetails.LastUpdatedAt);
            }
        }
    }
}
