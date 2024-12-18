namespace Business.Services;

public class FileService : IFileService
{
    //Skapar två privata fält för sökvägen där json-filen ska sparas
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    //Metod för att ta den json-formaterade variabeln (content) och (om den inte redan finns) skapar
    //filen via sökvägen och sparar den där
    public void SaveContentToFile(string content)
    {
        if (string.IsNullOrEmpty(content))
            return;
        if (!Directory.Exists(_directoryPath))
            Directory.CreateDirectory(_directoryPath);


        File.WriteAllText(_filePath, content);
    }

    //Metod för att hämta informationen i json-filen om filen existerar
    public string? GetContentFromFile()
    {
        if (File.Exists(_filePath))
            return File.ReadAllText(_filePath);
        return null;
    }

    public void ClearFile()
    {
        if (File.Exists(_filePath))
            File.Delete(_filePath);
    }
}
