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
    public IActionResult GetCategories()
    {
        IEnumerable<ReadCategoryDTO> categories = _mapper.Map<List<ReadCategoryDTO>>(_context.Categories.ToList());
        return Ok(categories);
    }

    [HttpGet("{id}", Name = "Get")]
    public IActionResult GetCategory(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        var readCategoryDTO = _mapper.Map<ReadCategoryDTO>(category);
        return Ok(readCategoryDTO);
    }

    [HttpPost]
    public IActionResult AddCategory([FromBody] CategoryDTO categoryDTO)
    {
        var newCategory = _mapper.Map<Category>(categoryDTO);

        _context.Categories.Add(newCategory);
        _context.SaveChanges();
        return Ok(newCategory);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateCategory(int id, [FromBody] CategoryDTO updateCategoryDTO)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        _mapper.Map(updateCategoryDTO, category);
        _context.SaveChanges();
        return Ok(category);
    }

    [HttpPatch("{id:int}")]
    public IActionResult PatchCategory(int id, [FromBody] JsonPatchDocument<CategoryDTO> patchDocument)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        var categoryDTO = _mapper.Map<CategoryDTO>(category);
        patchDocument.ApplyTo(categoryDTO);

        _mapper.Map(categoryDTO, category);
        _context.SaveChanges();

        return Ok(category);
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);

        if (category == null) return NotFound(new { message = "Category not found" });

        _context.Categories.Remove(category);
        _context.SaveChanges();
        return NoContent();
    }
}
