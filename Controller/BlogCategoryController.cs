using Blackstone.Models;
using Blackstone.Repoistory;
using Microsoft.AspNetCore.Mvc;

namespace Blackstone.Controller;
[ApiController]
[Route("api/[controller]")]
public class BlogCategoryController : ControllerBase
{
    private readonly BlogCategoryRepository blogRepository;
    public BlogCategoryController(BlogCategoryRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(BlogCategory entity)
    {
        await blogRepository.AddAsync(entity);
        return Ok();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(BlogCategory entity)
    {
        await blogRepository.UpdateAsync(entity);
        return Ok();
    } 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await blogRepository.DeleteAsync(id);
        return Ok();
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var blog = await blogRepository.GetAllAsync();
        return Ok();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var entity = await blogRepository.GetByIdAsync(id);
        return Ok(entity);
    }
}