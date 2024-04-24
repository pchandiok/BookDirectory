// using System.Text.Json;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using RazorDirectory.Models;

namespace RazorDirectory.Controllers;

[Route("api")]
[ApiController]
public class BookList
{
    public IList<Book> Books = new List<Book>();

    [HttpGet("books")]
    public List<Book> GetBooks()
    {
        using(StreamReader r = new StreamReader("./wwwroot/books.json"))
        {
            string json = r.ReadToEnd();
            Books = JsonConvert.DeserializeObject<List<Book>>(json);
        }
        return Books.ToList();
    }
}