using System.ComponentModel.DataAnnotations;
using LibraryDatabase.Models;

namespace LibraryBackend.Dtos.BorrowedBook;

public class BorrowedBookChangeStatusDto
{
    public int EmployeeId { get; set; }

    [Required]
    public int BorrowedBookId { get; set; }

    [Required]
    [EnumDataType(typeof(Status))]
    public Status Status { get; set; }
}