namespace TodoList.Models;

public class Category
{
    public int Id { get; set; }

    public required string Title { get; set; }

    public IEnumerable<TodoTask> Tasks { get; set; }

    public Category()
    {
        Tasks = new HashSet<TodoTask>();
    }
}