using System.ComponentModel.DataAnnotations;

namespace LibraryBackend.Dtos.Genre;

public class GenreUpdateDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; }
}