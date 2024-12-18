using Business.Services;

namespace Contacts.ConsoleApp.Tests.Services;

public class FileService_Tests
{
    private readonly IFileService _fileService;

    public FileService_Tests()
    {
        _fileService = new FileService("Test", "testlist.json");
    }

    [Fact]
    public void GetContentFromFile_ShouldReturnNull()
    {
        //Arrange
        _fileService.ClearFile();

        //Act
        var result = _fileService.GetContentFromFile();

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void SaveContentToFile_ShouldPersist()
    {
        //Arrange
        _fileService.ClearFile();
        string content = "Hejhej jag är smrt";

        //Act
        _fileService.SaveContentToFile(content);
        var gettedResult = _fileService.GetContentFromFile();

        //Assert
        Assert.Equal(content, gettedResult);
    }

    [Fact]
    public void ClearFile_ShouldClearContent()
    {
        //Arrange
        _fileService.ClearFile();
        string content = "Hejhej jag är smrt";

        //Act
        _fileService.SaveContentToFile(content);
        _fileService.ClearFile();
        var gettedResult = _fileService.GetContentFromFile();

        //Assert
        Assert.Null(gettedResult);
    }
}
