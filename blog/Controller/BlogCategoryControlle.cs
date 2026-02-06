using Blackstone.Models;
using Blackstone.Repoistory;
using Microsoft.AspNetCore.Mvc;

namespace Blackstone.Controller;
[ApiController]
[Route("api/[controller]")]
public class BlogCategoryController : ControllerBase
{
    private readonly BlogCategoryRepository blogCategoryRepository;
    public BlogCategoryController(BlogCategoryRepository blogCategoryRepository)
    {
        this.blogCategoryRepository = blogCategoryRepository;
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(BlogCategory entity)
    {
        await blogCategoryRepository.AddAsync(entity);
        return Ok(entity);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(BlogCategory entity)
    {
        await blogCategoryRepository.UpdateAsync(entity);
        return Ok(entity);
    } 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await blogCategoryRepository.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var blogCategory = await blogCategoryRepository.GetAllAsync();
        return Ok(blogCategory);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var entity = await blogCategoryRepository.GetByIdAsync(id);
        return Ok(entity);
    }
}