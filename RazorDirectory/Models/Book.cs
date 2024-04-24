namespace RazorDirectory.Models;

public class Book
{
    public string Author { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string Imagelink { get; set; } = default!;
    public string Language { get; set; } = default!;
    public string Link { get; set; } = default!;
    public int Pages { get; set; }
    public string Title { get; set; } = default!;
    public int Year { get; set; }
}