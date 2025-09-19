namespace TodoList;
public class CategoryNotFoundException : NotFoundException
{
    public CategoryNotFoundException(int id): base("Category", id) {}
}