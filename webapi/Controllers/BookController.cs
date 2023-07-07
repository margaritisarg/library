using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webapi.Model;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;

    [HttpGet]
    public async Task<IActionResult> Books()
    {
        using (HttpClient client = new HttpClient())
        {
            string apiUrl = "https://www.googleapis.com/books/v1/volumes?q=trees";
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Root>(responseContent);

                var firstFiveBooks = root.Items.Take(5);

                List<BookItem> listOfBooks = new List<BookItem>();

                foreach (var book in firstFiveBooks)
                {
                    BookItem temp = new BookItem();

                    temp.Title = book.VolumeInfo?.Title ?? "unk";
                    temp.Authros = book.VolumeInfo?.Authors != null ? string.Join(", ", book.VolumeInfo.Authors) : "unk";
                    temp.Publisher = book.VolumeInfo?.Publisher ?? "unk";

                    listOfBooks.Add(temp);
                }

                var serializedBooks = JsonConvert.SerializeObject(listOfBooks);
                return Ok(serializedBooks);
            }
            else return BadRequest();
            
        }
    }
}

