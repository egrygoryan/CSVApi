namespace CSVApi.Models;

public class ManagerModel
{
    public int ManagerId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool? Married { get; set; }
    public string Phone { get; set; }
    public decimal Salary { get; set; }

    // Simple validator Manager's data
    public bool IsValid(out List<string> validationErrors)
    {
        validationErrors = new List<string>();

        if (ManagerId <= 0)
        {
            validationErrors.Add("ManagerId cannot be 0 or less.");
        }
        if (string.IsNullOrWhiteSpace(Name))
        {
            validationErrors.Add("Name cannot be empty.");
        }
        if (DateOfBirth == default)
        {
            validationErrors.Add("DateOfBirth is not valid.");
        }
        if (string.IsNullOrWhiteSpace(Phone))
        {
            validationErrors.Add("Phone cannot be empty.");
        }
        if (Salary <= 0)
        {
            validationErrors.Add("Salary must be greater than zero.");
        }

        // Returns true if no errors
        return validationErrors.Count == 0;
    }

    //converter from manager to model
    public static implicit operator ManagerModel(Manager manager) =>
        new()
        {
            ManagerId = manager.ManagerId, // return managerId not identifier for a record
            Name = manager.Name,
            DateOfBirth = manager.DateOfBirth,
            Married = manager.Married ?? false,
            Phone = manager.Phone,
            Salary = manager.Salary
        };

    //converter from seq. of managers to seq of models
    public static IEnumerable<ManagerModel> ConvertFromManagers(IEnumerable<Manager> managers)
    {
        List<ManagerModel> models = [.. managers];
        return models;
    }
}