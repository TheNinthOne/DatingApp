namespace API.Entities
{
    public class AppUser //class this is our first entity
    {
        public int Id { get; set; } //class property and will be used as primary key in our database
        public string UserName {get; set;}
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        
    }
}