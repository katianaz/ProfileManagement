using Repository.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        void Add(string profileName, ProfileParameter profileParameter);
        void Delete(string profileName);
        ProfileParameter Get(string profileName);
        Dictionary<string, ProfileParameter> GetAll();
        void Update(string profileName, Dictionary<string, string> parameters);
    }
}
