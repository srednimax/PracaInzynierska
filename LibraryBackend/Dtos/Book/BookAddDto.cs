using System.ComponentModel.DataAnnotations;
using LibraryBackend.Dtos.Genre;
using LibraryDatabase.Models;

namespace LibraryBackend.Dtos.Book;

public class BookAddDto
{
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    [MaxLength(200)]
    public string? Author { get; set; }

    [Required]
    [RegularExpression(@"^(19|20)\d{2}$")]
    public int PublishYear { get; set; }

    public List<GenreDto> Genres { get; set; }
}