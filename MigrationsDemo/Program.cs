using System;
using System.Data.Entity;

namespace MigrationsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Recreate database on change
            Database.SetInitializer<BlogContext>(new DropCreateDatabaseIfModelChanges<BlogContext>());

            using (var db = new BlogContext())
            {
                db.Blogs.Add(new Blog { Name = "Another Blog ", Test = "Hejhej"});
                db.SaveChanges();

                foreach (var blog in db.Blogs)
                {
                    Console.WriteLine(blog.Name);
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}