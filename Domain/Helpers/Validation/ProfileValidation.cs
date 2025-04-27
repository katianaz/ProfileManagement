using CrossCutting.Error;
using Domain.Helpers.Validation.Interfaces;
using Domain.ViewModels;
using Repository.Entities;

namespace Domain.Helpers.Validation
{
    public class ProfileValidation(ErrorContext errorContext) : IProfileValidation
    {
        public bool ValidateIfProfilesIsValid(ProfileRequestDto profile)
        {
            if (profile == null)
            {
                errorContext.Add(ErrorType.ProfileNotFound);
                return false;
            }

            return true;
        }

        public bool ValidateIfProfileNameExists(string profileName)
        {
            if (string.IsNullOrEmpty(profileName))
            {
                errorContext.Add(ErrorType.InvalidProfileName);
                return false;
            }

            return true;
        }

        public bool ValidateIfProfileExists(ProfileParameter profile)
        {
            if (profile == null)
            {
                errorContext.Add(ErrorType.ProfileNotFound);
                return false;
            }

            return true;
        }

        public bool ValidateIfActionExists(ProfileParameter profile, string action)
        {
            if (profile == null)
            {
                errorContext.Add(ErrorType.ProfileNotFound);
                return false;
            }

            if (profile.Parameters == null || !profile.Parameters.ContainsKey(action))
            {
                errorContext.Add(ErrorType.ActionNotFoundForProfile);
                return false;
            }

            return true;
        }
    }
}
