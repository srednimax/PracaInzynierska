using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using LibraryDatabase.Models;

namespace LibraryBackend.Dtos.Book;

public class BookUpdateDto
{
    [Required]
    public int Id { get; set; }

    [MaxLength(100)]
    public string? Title { get; set; }
    [MaxLength(200)]
    public string? Author { get; set; }
    [EnumDataType(typeof(Genre))]
    public Genre Genre { get; set; }
    [MaxLength(4)]
    [MinLength(4)]
    [RegularExpression(@"^(19|20)\d{2}$")]
    public int PublishYear { get; set; }
}