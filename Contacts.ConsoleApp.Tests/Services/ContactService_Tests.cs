﻿using Business.Models;
using Business.Services;
using Moq;
using System.Text.Json;

namespace Contacts.ConsoleApp.Tests.Services;

public class ContactService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactService = new ContactService(_fileServiceMock.Object);
    }


    [Fact]
    //Testet kollar om metoden returnerar en tom lista av typen ContactModel
    public void GetAllContacts_ShouldReturnAnEmptyList()
    {
        //Act
        var result = _contactService.GetAllContacts();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<ContactModel>>(result);
        Assert.Empty(result);
    }


    [Fact]

    public void GetAllContacts_ShouldReturnAListWithContacts()
    {
        //Arrange
        var expectedContacts = new List<ContactModel>()
        {
            new ContactModel { Id = "24d452e8-69f1-4fb8-89f5-56ff109d9839", FirstName = "Hans", LastName = "Mattin-Lassei" }
        };

        var json = JsonSerializer.Serialize(expectedContacts);
        _fileServiceMock.Setup(fs => fs.GetContentFromFile()).Returns(json);

        //Act
        var result = _contactService.GetAllContacts();

        //Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<ContactModel>>(result);
        Assert.Equal(expectedContacts.Count, result.Count());

    }
}
