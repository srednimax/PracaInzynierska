using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using LibraryDatabase.Models;

namespace LibraryBackend.Dtos.Book;

public class BookUpdateDto
{
    [Required]
    public int Id { get; set; }

    [Required(AllowEmptyStrings = true)]
    [DefaultValue("")]
    [MaxLength(100)]
    public string? Title { get; set; }

    [Required(AllowEmptyStrings = true)]
    [DefaultValue("")]
    [MaxLength(200)]
    public string? Author { get; set; }

    [Required(AllowEmptyStrings = true)]
    
    public int PublishYear { get; set; }
}