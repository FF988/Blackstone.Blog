using Blackstone.Models;
using Microsoft.EntityFrameworkCore;

namespace Blackstone.Repoistory;
public class BlogCategoryRepository
{
    private readonly AppDbContext context;

    public BlogCategoryRepository(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<BlogCategory> AddAsync(BlogCategory entity)
    {
        context.BlogCategory.Add(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    public async Task<BlogCategory> UpdateAsync(BlogCategory entity)
    {
        context.BlogCategory.Update(entity);
        await context.SaveChangesAsync();
        return entity;
    }
    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await context.BlogCategory.Where(x=>x.Id==id).SingleOrDefaultAsync();
        if (entity == null)
            return false;
        context.BlogCategory.Remove(entity);
        await context.SaveChangesAsync();
        return true;
    }
    public async Task<IEnumerable<BlogCategory>> GetAllAsync()
    {
        return await context.BlogCategory.ToListAsync();
    }
    public async Task<BlogCategory> GetByIdAsync(Guid id)
    {
        return await context.BlogCategory.Where(x=>x.Id==id).SingleOrDefaultAsync();
    }
}   