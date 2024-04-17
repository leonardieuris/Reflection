// See https://aka.ms/new-console-template for more information

using ConsoleAppReflection;


var person = new Person
{
    Address = "via roma 1",
    Id = 15,
    Name = "Mario",
    Surname = "Rossi"
};

var myperson = RenameAttributeUtility.GetAttributeValues(person);

foreach (var keyvaluePair in myperson)
{
    Console.WriteLine($"{keyvaluePair.Key} {keyvaluePair.Value}");
}