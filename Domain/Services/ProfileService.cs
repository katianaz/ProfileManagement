using Domain.Services.Interfaces;
using Repository.Entities;
using Repository.Repositories.Interfaces;

namespace Domain.Services
{
    public class ProfileService(IProfileRepository profileRepository) : IProfileService
    {
        private readonly IProfileRepository _profileRepository = profileRepository;

        public Dictionary<string, ProfileParameter> GetAllProfiles()
        {
            return _profileRepository.GetAll();
        }

        public ProfileParameter? Get(string profileName)
        {
            return _profileRepository.Get(profileName);
        }

        public void Add(string profileName, ProfileParameter parameters)
        {
            _profileRepository.Add(profileName, parameters);
        }

        public void Update(string profileName, Dictionary<string, string> parameters)
        {
            _profileRepository.Update(profileName, parameters);
        }

        public void Delete(string profileName)
        {
            _profileRepository.Delete(profileName);
        }

        public bool ValidatePermission(string profileName, string action)
        {
            var profile = _profileRepository.Get(profileName);
            if (profile == null) return false;

            return profile.Parameters.TryGetValue(action, out var value) && value == "true";
        }

        public void UpdateParametersPeriodically()
        {
            var profiles = _profileRepository.GetAll();
            foreach (var profile in profiles.Values)
            {
                foreach (var key in profile.Parameters.Keys.ToList())
                {
                    profile.Parameters[key] = profile.Parameters[key] == "true" ? "false" : "true";
                }
            }
        }
    }
}