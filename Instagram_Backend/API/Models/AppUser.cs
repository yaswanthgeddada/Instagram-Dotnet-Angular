using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required] public string UserName { get; set; } = string.Empty;
        public string? FullName { get; set; } = string.Empty;
        [EmailAddress] public string? EmailAddress { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = new byte[0];
        public byte[] PasswordSalt { get; set; } = new byte[0];
        public string? ProfilePic { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public List<Post> Post { get; set; } = new List<Post>();
    }
}
