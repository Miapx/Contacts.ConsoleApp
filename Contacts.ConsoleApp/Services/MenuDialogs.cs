using Contacts.ConsoleApp.Models;

namespace Contacts.ConsoleApp.Services;

public class MenuDialogs
{
    private readonly ContactService _contactService = new();

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
        Console.WriteLine($"{"1.", -5} Add new contact");
        Console.WriteLine($"{"2.",-5} View all contacts");
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

            case "q":
                QuitApp();
                break;

            default:
                Console.WriteLine("Invalid option");
                Console.ReadKey();
                break;
        }
    }

    private void AddContact()
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

        _contactService.CreateContact(contact);

        Console.WriteLine("Contact was added to the list");

        Console.ReadKey();
    }

    private void ViewContacts()
    {
        Console.Clear();


        var contacts = _contactService.GetAllContacts();
        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found");
            Console.ReadKey();
            return;
        }
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

            }
            Console.ReadKey();
        }
    }
    

    private void QuitApp()
    {
        Console.Clear();
        //Console.WriteLine("Do you want to quit? (Y/N): ");
        //Provar Output, vet ej om det funkar, annars kör ovanstående. 
        OutputDialog("Do you want to quit? (Y/N): ");
        var option = Console.ReadLine()!;
        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }





    /* VILL HA EGEN METOD FÖR OUTPUT-MESSAGES, MINNS EJ HUR MAN GÖR, LÄGG TILL SENARE*/
    private void OutputDialog(string message)
    {
        //Console.Clear();
        Console.WriteLine(message);
    }
}
