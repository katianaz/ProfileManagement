using Repository.Entities;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly Dictionary<string, ProfileParameter> _profileDictionary = new Dictionary<string, ProfileParameter>();

        public ProfileRepository()
        {
            _profileDictionary["Admin"] = new ProfileParameter
            {
                ProfileName = "Admin",
                Parameters = new Dictionary<string, string>
            {
                { "CanEdit", "true" },
                { "CanDelete", "true" }
            }
            };
            _profileDictionary["User"] = new ProfileParameter
            {
                ProfileName = "User",
                Parameters = new Dictionary<string, string>
            {
                { "CanEdit", "true" },
                { "CanDelete", "false" }
            }
            };
        }

        public Dictionary<string, ProfileParameter> GetAll()
        {
            return _profileDictionary;
        }

        public ProfileParameter Get(string profileName)
        {
            return _profileDictionary.GetValueOrDefault(profileName);
        }

        public void Add(string profileName, ProfileParameter profileParameter)
        {
            _profileDictionary[profileName] = profileParameter;
        }

        public void Update(string profileName, Dictionary<string, string> parameters)
        {
            if (_profileDictionary.TryGetValue(profileName, out ProfileParameter value))
            {
                value.Parameters = parameters;
            }
        }

        public void Delete(string profileName)
        {
            _profileDictionary.Remove(profileName);
        }
    }
}
