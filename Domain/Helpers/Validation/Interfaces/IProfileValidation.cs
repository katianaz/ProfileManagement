using Domain.ViewModels;
using Repository.Entities;

namespace Domain.Helpers.Validation.Interfaces
{
    public interface IProfileValidation
    {
        bool ValidateIfProfileNameExists(string profileName);
        bool ValidateIfProfilesIsValid(ProfileRequestDto profile);
    }
}
