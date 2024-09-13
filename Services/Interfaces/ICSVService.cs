namespace CSVApi.Services.Interfaces;

public interface ICSVService
{
    IEnumerable<T> ReadCSV<T>(IFormFileCollection file);
}
