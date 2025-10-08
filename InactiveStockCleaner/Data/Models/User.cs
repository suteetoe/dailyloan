namespace InactiveStockCleaner.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserCode { get; set; }
        public string Password { get; set; }
        public int UserRole { get; set; }

        public UserRole Role
        {
            get
            {
                return (UserRole)UserRole;
            }
        }
    }

    public enum UserRole
    {
        Admin = 1,
        User = 2,
        Manager = 3
    }
}