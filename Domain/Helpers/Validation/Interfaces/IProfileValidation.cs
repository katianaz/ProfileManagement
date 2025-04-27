using Domain.ViewModels;
using Repository.Entities;

namespace Domain.Helpers.Validation.Interfaces
{
    public interface IProfileValidation
    {
        bool ValidateIfActionExists(ProfileParameter profile, string action);
        bool ValidateIfProfileExists(ProfileParameter profile);
        bool ValidateIfProfileNameExists(string profileName);
        bool ValidateIfProfilesIsValid(ProfileRequestDto profile);
    }
}
