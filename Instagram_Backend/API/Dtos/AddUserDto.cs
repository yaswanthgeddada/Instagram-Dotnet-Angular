namespace API.Dtos
{
    public class AddUserDto
    {
        public string UserName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
    }
}
