using LibraryDatabase.Models;

namespace LibraryBackend.Authentication;

public interface IAuth
{
    string Authentication(User user);
}