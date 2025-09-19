using System.ComponentModel.DataAnnotations;
namespace TodoList;
public class CategoryAddModel
{
    [Required]
    [MaxLength(36)]
    public required string Name { get; set; }
}