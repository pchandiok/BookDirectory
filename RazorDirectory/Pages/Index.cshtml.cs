using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

// using Newtonsoft.Json.Bson;
// using Newtonsoft.Json.Linq;
// using Newtonsoft.Json.Serialization;
// using Newtonsoft.Json.Utilities;
using RazorDirectory.Models;

namespace RazorDirectory.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly HttpClient _httpClient;

    public IndexModel(ILogger<IndexModel> logger, HttpClient httpClient)
    {
        _logger = logger;
        _httpClient = httpClient;
    }

    public IList<Book> Books { get; set; }
    public IList<Book> FilteredBooks { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }

    public SelectList? Language { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? BookLanguage { get; set; }

    public async Task OnGet()
    {
        _httpClient.BaseAddress = new Uri("http://localhost:5126");
        var response = await _httpClient.GetAsync("/api/books");
        
        if(response.IsSuccessStatusCode)
        {
            Books = await response.Content.ReadAsAsync<List<Book>>();
        }
        var LanguageFilter = Books.Select(x => x.Language).ToList();
        Language = new SelectList( LanguageFilter.Distinct().ToList() );

        FilteredBooks = Books;

        if(!string.IsNullOrEmpty(SearchString))
        {
            FilteredBooks = Books.Where(b => b.Title.Contains(SearchString) && b.Language.Contains(BookLanguage)).ToList();
        }
        else if(!string.IsNullOrEmpty(BookLanguage))
        {
            FilteredBooks = Books.Where(b => b.Language.Contains(BookLanguage)).ToList();
        }
    }
}
