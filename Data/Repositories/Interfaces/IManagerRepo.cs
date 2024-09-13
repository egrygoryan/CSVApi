namespace CSVApi.Data.Repositories.Interfaces;

public interface IManagerRepo
{
    Task<Manager?> GetAsync(int managerId);
    Task<IEnumerable<Manager>> GetAllAsync();
    Task AddRangeAsync(IEnumerable<Manager> managers);
    Task DeleteAsync(Manager manager);
}
