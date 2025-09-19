namespace TodoList.Models;

public class TodoTask
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool IsCompleted { get; set; }

    public required Category Category { get; set; }

}