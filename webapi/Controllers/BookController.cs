using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    // get books list from https://www.googleapis.com/books/v1/volumes?q=trees
    private readonly ILogger<BookController> _logger;

   
}
