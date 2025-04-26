namespace Domain.ViewModels
{
    public class ProfileRequestDto
    {
        public string ProfileName { get; set; } = string.Empty;
        public Dictionary<string, string> Parameters { get; set; } = new();
    }
}
