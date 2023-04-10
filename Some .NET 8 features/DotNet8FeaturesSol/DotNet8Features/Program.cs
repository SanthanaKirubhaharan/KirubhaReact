// Program.cs

using DotNet8Features;
using System.Text.Json;


// Feature 1: Interface serialization

ISedan detail = new CarDetails { Brand = "Honda", Model="Civic" };
var serializedValue = JsonSerializer.Serialize(detail); 
Console.WriteLine(serializedValue);


// Feature 2: Frozen dictionaries

FrozenDictionaryType frozenDictionaryType = new();
Console.WriteLine($"The value returned from the frozen dictionary is {frozenDictionaryType.GetValue("Key2")}");

