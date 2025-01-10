using Business.Helpers;

namespace Business.Models;  

public class ContactModel
{
    public string Id { get; set; } = IdGenerator.Generate();
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string StreetAdress { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

}
