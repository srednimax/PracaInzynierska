using System.ComponentModel.DataAnnotations;
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
    [EnumDataType(typeof(Genre))]
    public Genre Genre { get; set; }
    [Required]
    [MaxLength(4)]
    [MinLength(4)]
    [RegularExpression(@"^(19|20)\d{2}$")]
    public int PublishYear { get; set; }
}