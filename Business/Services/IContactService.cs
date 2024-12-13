using Business.Models;

namespace Business.Services
{
    public interface IContactService
    {
        void CreateContact(ContactModel model);
        IEnumerable<ContactModel> GetAllContacts();
    }
}