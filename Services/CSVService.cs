namespace CSVApi.Services;
public class CSVService : ICSVService
{
    public IEnumerable<T> ReadCSV<T>(IFormFileCollection file)
    {

        var config = new CsvConfiguration(CultureInfo.CurrentCulture) { Delimiter = "," };

        using var reader = new StreamReader(file[0].OpenReadStream());
        using var csv = new CsvReader(reader, config);
        var records = csv.GetRecords<T>().ToList();

        return records;
    }
}
