namespace CSVApi.Services.Interfaces;

public interface IManagerService
{
    Task UploadAsync(IFormFileCollection file);
    Task<IEnumerable<ManagerModel>> GetAllAsync();
    Task DeleteAsync(int id);
}
