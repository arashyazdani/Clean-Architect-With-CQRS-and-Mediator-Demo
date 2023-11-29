using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _context;
        public BlogRepository(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<List<Blog>> GetAllBlogAsync()
        {
            return await _context.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
            return await _context.Blogs.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
            return blog;
        }

        public async Task<int> UpdateAsync(int id, Blog blog)
        {
            return await _context.Blogs.Where(c => c.Id == id).ExecuteUpdateAsync(setters => setters
                .SetProperty(m => m.Id, blog.Id)
                .SetProperty(m=>m.Name, blog.Name)
                .SetProperty(m=>m.Desctiption, blog.Desctiption)
                .SetProperty(m => m.Author, blog.Author)
            );
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _context.Blogs.Where(c => c.Id == id).ExecuteDeleteAsync();
        }
    }
}
