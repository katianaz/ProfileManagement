using Domain.Helpers.Mappers;
using Domain.Helpers.Validation.Interfaces;
using Domain.Services.Interfaces;
using Domain.ViewModels;
using Repository.Entities;
using Repository.Repositories.Interfaces;

namespace Domain.Services
{
    public class ProfileService(IProfileRepository profileRepository, IProfileValidation profileValidation) : IProfileService
    {
        public Dictionary<string, ProfileParameter> GetAllProfiles()
        {
            return profileRepository.GetAll();
        }

        public ProfileResponseDto Get(string profileName)
        {
            if (!profileValidation.ValidateIfProfileNameExists(profileName))
            {
                return null;
            }

            var existingProfile = profileRepository.Get(profileName);
            if (!profileValidation.ValidateIfProfileExists(existingProfile))
            {
                return null;
            }

            var result = profileRepository.Get(profileName);
            var response = result.ToResponseDto();

            return response;
        }

        public ProfileResponseDto Add(string profileName, ProfileRequestDto request)
        {
            if (!profileValidation.ValidateIfProfileNameExists(profileName))
            {
                return null;
            }

            if (!profileValidation.ValidateIfProfilesIsValid(request))
            {
                return null;
            }

            var parameters = request.ToModel();

            var result = profileRepository.Add(profileName, parameters);
            var response = result.ToResponseDto();

            return response;
        }

        public ProfileResponseDto Update(string profileName, UpdateProfileRequestDto request)
        {
            if (!profileValidation.ValidateIfProfileNameExists(profileName))
            {
                return null;
            }

            var existingProfile = profileRepository.Get(profileName);
            if (!profileValidation.ValidateIfProfileExists(existingProfile))
            {
                return null;
            }

            var parameters = request.ToModel();
            var result = profileRepository.Update(profileName, parameters);
            var response = result.ToResponseDto();

            return response;
        }

        public void Delete(string profileName)
        {
            if (!profileValidation.ValidateIfProfileNameExists(profileName))
            {
                return;
            }

            var existingProfile = profileRepository.Get(profileName);
            if (!profileValidation.ValidateIfProfileExists(existingProfile))
            {
                return;
            }

            profileRepository.Delete(profileName);
        }

        public bool? ValidatePermission(string profileName, string action)
        {
            if (!profileValidation.ValidateIfProfileNameExists(profileName))
            {
                return null;
            }

            var profile = profileRepository.Get(profileName);

            if (!profileValidation.ValidateIfActionExists(profile, action))
            {
                return null;
            }

            return profile.Parameters[action].Equals("true", StringComparison.OrdinalIgnoreCase);
        }
    }
}