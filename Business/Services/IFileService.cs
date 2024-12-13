namespace Business.Services
{
    public interface IFileService
    {
        string? GetContentFromFile();
        void SaveContentToFile(string content);
    }
}