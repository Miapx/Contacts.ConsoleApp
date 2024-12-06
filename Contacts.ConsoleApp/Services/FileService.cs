﻿namespace Contacts.ConsoleApp.Services;
using ConsoleApp.Models;



public class FileService
{

    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "list.json")
    {
        _directoryPath = directoryPath;
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    public void SaveContentToFile(string content)
    {
        if (string.IsNullOrEmpty(content)) 
        if (!Directory.Exists(_directoryPath)) 
            Directory.CreateDirectory(_directoryPath);


        File.WriteAllText(_filePath, content);
    }

    public string? GetContentFromFile()
    {
        if (File.Exists(_filePath))
            return File.ReadAllText(_filePath);
        return null;
    }
}
