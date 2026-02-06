using Blackstone.Models;
using Blackstone.Repoistory;
using Microsoft.AspNetCore.Mvc;

namespace Blackstone.Controller;
[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly BlogRepository blogRepository;
    public BlogController(BlogRepository blogRepository)
    {
        this.blogRepository = blogRepository;
    }
    [HttpPost]
    public async Task<IActionResult> AddAsync(Blog entity)
    {
        await blogRepository.AddAsync(entity);
        return Ok(entity);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(Blog entity)
    {
        await blogRepository.UpdateAsync(entity);
        return Ok(entity);
    } 
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        var result = await blogRepository.DeleteAsync(id);
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var blog = await blogRepository.GetAllAsync();
        return Ok(blog);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var entity = await blogRepository.GetByIdAsync(id);
        return Ok(entity);
    }
}