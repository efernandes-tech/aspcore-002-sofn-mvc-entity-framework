using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        // CRUD

        public void Salvar(Blog blog)
        {
            if (blog.ID > 0)
            {
                _context.Blog.Attach(blog);
                _context.Entry(blog).State = EntityState.Modified;
            }
            else
                _context.Blog.Add(blog);

            _context.SaveChanges();
        }

        public Blog Obter(int id)
        {
            return _context.Blog.SingleOrDefault(b => b.ID == id);
        }

        public IEnumerable<Blog> Listar()
        {
            return _context.Blog.ToList();
        }

        public void Deletar(int id)
        {
            var b = new Blog() { ID = id };
            _context.Blog.Attach(b);
            _context.Blog.Remove(b);
            _context.SaveChanges();
        }
    }
}
