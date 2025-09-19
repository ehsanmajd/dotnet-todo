
using Microsoft.AspNetCore.Mvc;
using TodoList.Data;
using TodoList.Models;

namespace TodoList;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public CategoryController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpPost]
    public void Add([FromBody] CategoryAddModel categoryAddModel)
    {
        _appDbContext.Categories.Add(new Category { Title = categoryAddModel.Name });
        _appDbContext.SaveChanges();
    }

    [HttpGet]
    public List<string> GetAll()
    {
        return _appDbContext.Categories.Select(category => category.Title).ToList();
    }

    [HttpDelete("{id}")]
    public void Delete([FromRoute]int id)
    {
        var category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);
        if (category != null)
        {
            _appDbContext.Categories.Remove(category);
            _appDbContext.SaveChanges();
        }
        else
        {
            throw new CategoryNotFoundException(id);
        }
    }

    [HttpPut("{id}")]
    public void Update([FromRoute]int id, [FromBody] CategoryUpdateModel updateModel)
    {
        var category = _appDbContext.Categories.SingleOrDefault(c => c.Id == id);
        if (category != null)
        {
            category.Title = updateModel.Name;
            _appDbContext.SaveChanges();
        }
        else
        {
            throw new CategoryNotFoundException(id);
        }
    }

    [HttpGet("{id}")]
    public CategoryViewModel Get(int id)
    {
        var category = _appDbContext.Categories.SingleOrDefault(r => r.Id == id);
        if (category != null)
        {
            return new CategoryViewModel
            {
                Name = category.Title,
                Id = category.Id
            };
        }
        else
        {
            throw new CategoryNotFoundException(id);
        }
    }
}
