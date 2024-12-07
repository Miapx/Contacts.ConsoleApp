using Contacts.ConsoleApp.Models;
using System.Text.Json;
namespace Contacts.ConsoleApp.Services;

public class ContactService
{
    private readonly FileService _fileService = new FileService();

    private List<ContactModel> _contactList = [];

    public void CreateContact(ContactModel model)
    {

        _contactList.Add(model);
        var json = JsonSerializer.Serialize(_contactList);
        _fileService.SaveContentToFile(json);


    }



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
