namespace Domain.ViewModels
{
    public class ProfileResponseDto
    {
        public string ProfileName { get; set; } = string.Empty;
        public Dictionary<string, string> Parameters { get; set; } = new();
    }
}
