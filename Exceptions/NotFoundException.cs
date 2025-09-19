namespace TodoList;

public class NotFoundException : Exception
{
    private const string messageFormat = "{0} with Id = {1} not found.";
    public NotFoundException(string entityName, int id) : base(String.Format(messageFormat, entityName, id))
    {
        
    }
}