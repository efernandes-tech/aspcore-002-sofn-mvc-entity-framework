using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCore.Data;
using WebCore.Models.ManageBlog;
using WebCore.Services.Especificacao;

namespace WebCore.Services.Implementacao
{
    public class BlogService : IBlogService
    {
        // CRUD

        Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext> options = new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>();

        public void Salvar(Blog blog)
        {
            using (var db = new ApplicationDbContext(options))
            {
                if (blog.ID > 0)
                {
                    db.Blog.Attach(blog);
                    db.Entry(blog).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }
                else 
                    db.Blog.Add(blog);

                db.SaveChanges();
            }
        }

        public Blog Obter(int id)
        {
            using (var db = new ApplicationDbContext(options))
            {
                return db.Blog.Where(b => b.ID == id).FirstOrDefault();
            }
        }

        public IEnumerable<Blog> Listar()
        {
            using (var db = new ApplicationDbContext(options))
            {
                return db.Blog.ToList();
            }
        }

        public void Deletar(int id)
        {
            using (var db = new ApplicationDbContext(options))
            {
                var b = new Blog() { ID = id };
                db.Blog.Attach(b);
                db.Blog.Remove(b);
                db.SaveChanges();
            }
        }
    }
}
