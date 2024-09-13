namespace CSVApi.Data.Entities;

public class Manager
{
    [Key]
    public int Id { get; set; }
    public int ManagerId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    //assume there will be cases where we don't know
    //whether manaager is maried or not and store null value in db
    //but for api response we will show as False value
    public bool? Married { get; set; }
    public string Phone { get; set; }
    [Column(TypeName = "decimal(18,4)")]
    public decimal Salary { get; set; }

    //converter from model to entity
    public static implicit operator Manager(ManagerModel managerModel) =>
        new()
        {
            ManagerId = managerModel.ManagerId,
            Name = managerModel.Name,
            DateOfBirth = managerModel.DateOfBirth,
            Married = managerModel.Married,
            Phone = managerModel.Phone,
            Salary = managerModel.Salary
        };
}
