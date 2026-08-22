using System.Data.Common;
using Newtonsoft.Json;

public class Person
{
    public int id {get; set;}

    public string? name {get; set;}

    public bool isActive {get; set;}

    public string[]? roles {get; set;}

    public Dictionary<string, string>? location {get; set;}
}

public class Program
{
    public static void Main()
    {
        // Serielized string data
        string? personSerielisedData = "{\"id\":101,\"name\":\"Alice Smith\",\"isActive\":true,\"roles\":[\"admin\",\"user\"],\"location\":{\"city\":\"Austin\",\"state\":\"TX\"}}";

        // Deserielize and store into object
        Person? lobjPerson = JsonConvert.DeserializeObject<Person>(personSerielisedData);

        Console.WriteLine("Deserielization of JSON Data into C# object...");
        Console.WriteLine($" Person Name : {lobjPerson.id} \n Has Top Role Assigned : {lobjPerson.roles[0]} \n Location : {lobjPerson.location["city"]}, {lobjPerson.location["state"]}");

        // Serielize and store into string
        Person? lobjPerson2 = new Person{
            id = 102,
            name = "Veersen Jadhav",
            isActive = true,
            roles = new string[] {"CEO", "CFO"},
            location = new Dictionary<string, string>
            {
                { "city", "St. Louis" },
                { "state", "NY" }
            }
        };

        string? personSerielisedData2 = JsonConvert.SerializeObject(lobjPerson2);

        Console.WriteLine("\n Serielization of Data - C# object into JSON string...");
        Console.WriteLine(personSerielisedData2);
    }
}