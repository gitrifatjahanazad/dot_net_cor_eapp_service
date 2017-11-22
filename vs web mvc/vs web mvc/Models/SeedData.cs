using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace vs_web_mvc.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToDoContext(
                serviceProvider.GetRequiredService<DbContextOptions<ToDoContext>>()))
            {
                // Look for any movies.
                if (context.ToDoItem.Any())
                {
                    return;   // DB has been seeded
                }

                context.ToDoItem.AddRange(
                     new ToDoItem
                     {
                         Title = "Export import word, pdf and excel",
                         ModifiedOn = DateTime.Parse("2017-11-22"),
                         Description = "Ensure from kalina and find ways to export import",
                         Category = "Top priority",
                         EstimatedHour = 7.99M
                     },

                     new ToDoItem
                     {
                         Title = "Reporting using angular",
                         ModifiedOn = DateTime.Parse("2017-11-22"),
                         Description = "Need to find out why reporting is so important using serverside. Everyone like crystal report.",
                         Category = "If I have time",
                         EstimatedHour = 8.99M
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
