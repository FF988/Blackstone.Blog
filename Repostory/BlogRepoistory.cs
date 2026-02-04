using Blackstone;
using Blackstone.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace Blackstone.Repoistory;
public class BlogRepository
{
    private readonly AppDbContext context;

    public BlogRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<Blog> AddAsync(Blog entity)
    {
        context.Blog.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    public async Task<Blog> UpdateAsync(Blog entity)
    {
        context.Blog.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await context.Blog.Where(x=>x.Id==id).SingleOrDefaultAsync();
        if (entity == null)
            return false;
        context.Blog.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await context.Blog.ToListAsync();
    }
    public async Task<Blog> GetByIdAsync(Guid id)
    {
        return await context.Blog.Where(x=>x.Id==id).SingleOrDefaultAsync();
    }
}   