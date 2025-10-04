

using Microsoft.AspNetCore.Mvc;

namespace TodoList;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    // UserController implementation goes here
    [HttpGet]
    public string Get()
    {
        return "UserController is working!";
    }

    [HttpPost]
    public void Post([FromBody] string value)
    {
        // Handle POST request
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
        // Handle PUT request
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        // Handle DELETE request
    }
}