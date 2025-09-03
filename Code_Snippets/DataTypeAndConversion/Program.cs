using System;

public class Program
{
    public static void Main()
    {
        // Find variable type
        object myVariable = 123;

        Console.WriteLine("Type : " + myVariable.GetType());

        myVariable = "123";

        Console.WriteLine("Type : " + myVariable.GetType());

        // Convert variable type using Parsing
        string myVar = "123";

        int myIntVar = int.Parse(myVar);

        Console.WriteLine(myIntVar);

        // Validating Conversion using Parsing
        string myVar2 = "123ABC";

        if (int.TryParse(myVar2, out int numberVar))
        {
            Console.WriteLine($"Conversion Successful with Value {numberVar}");
        }
        else
        {
            Console.WriteLine($"Conversion Falied with Value {myVar2}");
        }

        // Convert variable type using Parsing
        double piVar = 3.142;

        int piVarInt = (int)piVar;

        Console.WriteLine(piVarInt);
	}
}