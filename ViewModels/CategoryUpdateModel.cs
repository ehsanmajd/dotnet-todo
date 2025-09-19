using System.ComponentModel.DataAnnotations;

namespace TodoList;

public class CategoryUpdateModel
{
    [Required]
    public required string Name { get; set; }
}