namespace CSVApi.Services;

public class ManagerService(IManagerRepo repo, ICSVService csvService) : IManagerService
{
    public async Task DeleteAsync(int id)
    {
        //Don't consider cases whereas several same manager's id are presented
        //In this case will be delete only first found
        //Check whether we got a manager with certain id
        var manager = await repo.GetAsync(id)
            ?? throw new ArgumentException($"Manager {id} doesn't exist");

        await repo.DeleteAsync(manager);
    }

    public async Task<IEnumerable<ManagerModel>> GetAllAsync()
    {
        var managers = await repo.GetAllAsync();
        //Converting entities to models
        var result = ManagerModel.ConvertFromManagers(managers);

        return result;
    }

    public async Task UploadAsync(IFormFileCollection file)
    {
        //storing manager entities for further saving into db
        List<Manager> validManagersList = [];

        //Read csv
        var managers = csvService.ReadCSV<ManagerModel>(file);
        foreach (var record in managers)
        {
            // Perform validation on each Manager Model
            if (!record.IsValid(out List<string> errors))
            {
                // Log validation errors to console (or we could log to file, throw excep, etc.)
                Console.WriteLine($"Record with ManagerId {record.ManagerId} has validation errors: {string.Join(", ", errors)}");
            }
            // Add only valid data into db 
            else
            {
                validManagersList.Add(record);
            }
        }

        //Check  whether list contain any valid data
        if (validManagersList.Count > 0)
        {
            await repo.AddRangeAsync(validManagersList);
        }
        return;
    }
}
