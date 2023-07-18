using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Blog
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BlogDataContext())
            {
                //1.CREATE
                var tag = new Tag { Name = "C#", Slug = "csharp" };
                context.Tags.Add(tag);
                context.SaveChanges();

                //2. UPDATE
                var tag = context.Tags.FirstOrDefault(x => x.Id == 2);
                tag.Name = "C#";
                tag.Slug = "csharp";

                context.Update(tag);
                context.SaveChanges();

                //3. DELETE
                var tag = context.Tags.FirstOrDefault(x => x.Id == 2);
                context.Remove(tag);
                context.SaveChanges();

                //4.READ
                var tags = context
                    .Tags
                    .Where(c => c.Name.Contains(".NET"))
                    .AsNoTracking()
                    .ToList();

                foreach (var tag in tags)
                {
                    Console.WriteLine(tag.Name);
                }
            }
        }
    }
}
