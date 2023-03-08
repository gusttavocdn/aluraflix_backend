using AluraFlixServer.Data;
using AluraFlixServer.Dtos;
using AluraFlixServer.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace AluraFlixServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public CategoryController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    [Produces("application/json")]
    [ProducesResponseType(typeof(IEnumerable<CategoryResponse>), 200)]
    public IActionResult GetCategories([FromQuery] int page = 1)
    {
        var skip = (page - 1) * 5;
        IEnumerable<CategoryResponse> categories = _mapper.Map<List<CategoryResponse>>(
            _context.Categories.Skip(skip).Take(5).ToList());
        return Ok(categories);
    }

    [HttpGet("{id:int}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CategoryResponse), 200)]
    public IActionResult GetCategory(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        var categoryResponse = _mapper.Map<CategoryResponse>(category);
        return Ok(categoryResponse);
    }

    [HttpPost]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CategoryResponse), 201)]
    public IActionResult AddCategory([FromBody] CategoryRequest categoryRequest)
    {
        var newCategory = _mapper.Map<Category>(categoryRequest);

        _context.Categories.Add(newCategory);
        _context.SaveChanges();

        var categoryResponse = _mapper.Map<CategoryResponse>(newCategory);
        return Ok(categoryResponse);
    }

    [HttpPut("{id:int}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CategoryResponse), 200)]
    public IActionResult UpdateCategory(int id, [FromBody] CategoryRequest updateCategoryRequest)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        _mapper.Map(updateCategoryRequest, category);
        _context.SaveChanges();

        var categoryResponse = _mapper.Map<CategoryResponse>(category);
        return Ok(categoryResponse);
    }

    [HttpPatch("{id:int}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(CategoryResponse), 200)]
    public IActionResult PatchCategory(int id, [FromBody] JsonPatchDocument<CategoryRequest> patchDocument)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        var categoryRequest = _mapper.Map<CategoryRequest>(category);
        patchDocument.ApplyTo(categoryRequest);

        _mapper.Map(categoryRequest, category);
        _context.SaveChanges();

        var categoryResponse = _mapper.Map<CategoryResponse>(category);
        return Ok(categoryResponse);
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(204)]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        _context.Categories.Remove(category);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpGet("{id:int}/videos")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<VideoRequest>), 200)]
    public IActionResult GetVideosByCategory(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        var videos = _context.Videos.Where(x => x.CategoryId == category.Id).ToList();

        var videosResponse = _mapper.Map<List<VideoRequest>>(videos);

        return Ok(videosResponse);
    }
}
