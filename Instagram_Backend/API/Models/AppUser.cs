using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        [Required] public string UserName { get; set; } = string.Empty;
        public string? FullName { get; set; } = string.Empty;
        [EmailAddress] public string? EmailAddress { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; } = default!;
        public byte[] PasswordSalt { get; set; } = default!;
        public string? ProfilePic { get; set; } = string.Empty;
        public string? Bio { get; set; } = string.Empty;
        public List<Post> Post { get; set; } = new List<Post>();

        [JsonIgnore]
        [NotMapped]
        public List<Follower> Followers { get; set; } = new List<Follower>();

        [JsonIgnore]
        [NotMapped]
        public List<Follower> Following { get; set; } = new List<Follower>();




    }
}
