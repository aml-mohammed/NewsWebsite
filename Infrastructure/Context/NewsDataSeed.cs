using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Context
{
    public static class NewsDataSeed
    {
        public static async Task SeedAsync(DataContext dbContext)
        {
            if (!dbContext.Authors.Any())
            {
                var AuthorData = File.ReadAllText("../Infrastructure/DataSeeding/Author.json");
                var authors = JsonSerializer.Deserialize<List<Author>>(AuthorData);
                if (authors?.Count > 0)
                {
                    foreach (var auth in authors)

                        await dbContext.Set<Author>().AddAsync(auth);

                    await dbContext.SaveChangesAsync();
                }

            }
            if (!dbContext.News.Any())
            {
                var NewsData = File.ReadAllText("../Infrastructure/DataSeeding/News.json");
                var MyNews = JsonSerializer.Deserialize<List<News>>(NewsData);
                if (MyNews?.Count > 0)
                {
                    foreach (var news in MyNews)

                        await dbContext.Set<News>().AddAsync(news);

                    await dbContext.SaveChangesAsync();
                }

            }

       

        }
    }
}
