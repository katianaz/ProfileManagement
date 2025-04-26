using Repository.Entities;

namespace Domain.Services.Interfaces
{
    public interface IProfileService
    {
        Dictionary<string, ProfileParameter> GetAllProfiles();
        ProfileParameter? Get(string profileName);
        void Add(string profileName, ProfileParameter profile);
        void Update(string profileName, Dictionary<string, string> parameters);
        void Delete(string profileName);
        bool ValidatePermission(string profileName, string action);
        void UpdateParametersPeriodically();
    }
}
