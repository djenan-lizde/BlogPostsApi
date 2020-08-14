using Microsoft.EntityFrameworkCore;

namespace Posts.Database
{
    public class Data
    {
        public static void Seed(PostsDbContext context)
        {
            context.Database.Migrate();
        }
    }
}
