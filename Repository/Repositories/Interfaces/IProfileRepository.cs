using Repository.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IProfileRepository
    {
        ProfileParameter Add(string profileName, ProfileParameter profileParameter);
        void Delete(string profileName);
        ProfileParameter Get(string profileName);
        Dictionary<string, ProfileParameter> GetAll();
        ProfileParameter Update(string profileName, ProfileParameter profileParameter);
    }
}
