using Business.Models;
using Business.Services;

namespace Contacts.ConsoleApp.Services;

public class MenuDialogs
{
    private readonly IFileService _fileService;
    private readonly IContactService _contactService;

    public MenuDialogs()
    {
        _fileService = new FileService();
        _contactService = new ContactService(_fileService);
    }


    //Metod för att köra menyn vid start
    public void Show()
    {
        while (true)
        {
            MainMenu();
        }
    }

    private void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("---------MAIN MENU---------");
        Console.WriteLine($"{"1.",-5} Add new contact");
        Console.WriteLine($"{"2.",-5} View all contacts");
        Console.WriteLine($"{"3.",-5} Remove all contacts");
        Console.WriteLine($"{"Q.",-5} Quit App");

        Console.Write("Choose your menu option: ");
        var option = Console.ReadLine()!;

        switch (option.ToLower())
        {
            case "1":
                AddContact();
                break;

            case "2":
                ViewContacts();
                break;

                case "3":
                ClearList();
                break;

            case "q":
                QuitApp();
                break;

            default:
                Console.WriteLine("Invalid option");
                Console.ReadKey();
                break;
        }
    }

    public void AddContact()
    {
        Console.Clear();
        Console.WriteLine("------ADD CONTACT-------");
        var contact = new ContactModel();

        Console.Write("Enter your first name: ");
        contact.FirstName = Console.ReadLine()!;

        Console.Write("Enter your last name: ");
        contact.LastName = Console.ReadLine()!;

        Console.Write("Enter your email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("Enter your phonenumber: ");
        contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("Enter your street adress: ");
        contact.StreetAdress = Console.ReadLine()!;

        Console.Write("Enter your postal code: ");
        contact.PostalCode = Console.ReadLine()!;

        Console.Write("Enter your city: ");
        contact.City = Console.ReadLine()!;

        //Skickar contact till CreateContact för att lägga till i listan som en ContactModel
        _contactService.CreateContact(contact);

        Console.WriteLine("Contact was added to the list");
        Console.ReadKey();
    }

    private void ViewContacts()
    {
        Console.Clear();

        //Hämtar listan från ContactService.GetAllContacts()
        var contacts = _contactService.GetAllContacts();
        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found");
            Console.ReadKey();
            return;
        }
        //Skriver ut listan i en loop om den inte är tom.
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{"Id:",-15}{contact.Id}");
                Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
                Console.WriteLine($"{"Email:",-15}{contact.Email}");
                Console.WriteLine($"{"Phonenumber:",-15}{contact.PhoneNumber}");
                Console.WriteLine($"{"Street name:",-15}{contact.StreetAdress}");
                Console.WriteLine($"{"Postal code:",-15}{contact.PostalCode}");
                Console.WriteLine($"{"City:",-15}{contact.City}");
                Console.WriteLine("----------------------------------------------------------------");

            }
            Console.ReadKey();
        }
    }

    //ClearList rensar listan men uppdaterar inte förrän programmet startats om. 
    private void ClearList()
    {
        Console.WriteLine("Do you want to remove all contacts from the list? Y/N ");
        var option = Console.ReadLine()!;
        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            _fileService.ClearFile();
        }
        else
        {
            return;
        }
    }
     
    private void QuitApp()
    {
        Console.Clear();
        OutputDialog("Do you want to quit? (Y/N): ");
        var option = Console.ReadLine()!;

        //Jämför option med y, ignorerar stor/liten bokstav, stänger programmet om de stämmer överens
        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }

    private void OutputDialog(string message)
    {
        Console.WriteLine(message);
    }
}
