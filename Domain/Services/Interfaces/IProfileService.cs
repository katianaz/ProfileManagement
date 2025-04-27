using Domain.ViewModels;
using Repository.Entities;

namespace Domain.Services.Interfaces
{
    public interface IProfileService
    {
        Dictionary<string, ProfileParameter> GetAllProfiles();
        ProfileResponseDto Get(string profileName);
        ProfileResponseDto Add(string profileName, ProfileRequestDto profile);
        void Delete(string profileName);
        bool? ValidatePermission(string profileName, string action);
        ProfileResponseDto Update(string profileName, UpdateProfileRequestDto request);
    }
}
