namespace Models
{
    public enum Role
    {
        User,
        Employee
    }

    public enum Gender
    {
        Undefined,
        Male,
        Female
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? Birth  { get; set; }
        public Gender Gender { get; set; }
        public Role Role { get; set; }
    }
}