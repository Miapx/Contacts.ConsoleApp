using Business.Models;
using System.Text.Json;
namespace Business.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService;

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
    }

    private List<ContactModel> _contactList = [];

    //Metod som lägger till en model som typ ContactModel i _contactList
    //och gör om den till json-format
    public void CreateContact(ContactModel model)
    {
        _contactList.Add(model);
        var json = JsonSerializer.Serialize(_contactList);
        _fileService.SaveContentToFile(json);
    }

    //Metod som försöker hämtar informationen och gör om den från json till sträng, vid fel returnerar en tom lista.
    public IEnumerable<ContactModel> GetAllContacts()
    {
        var json = _fileService.GetContentFromFile();
        try
        {
            if (!string.IsNullOrEmpty(json))
                _contactList = JsonSerializer.Deserialize<List<ContactModel>>(json) ?? [];
            return _contactList;
        }
        catch
        {
            _contactList = [];
            return _contactList;
        }
    }
}   
