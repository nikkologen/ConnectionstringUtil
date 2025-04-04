// See https://aka.ms/new-console-template for more information

using ConnectionstringUtil;
using ConnectionstringUtil.functions;

Console.WriteLine("List of commands");
Console.WriteLine(" testcon - for testing connection strings (testcon {connection string})");

string commandInput; // Gets input from the user

do
{
    commandInput = Console.ReadLine();
    var command = new CommandInterpeter(commandInput);
    switch (command.Function)
    {
        case "testcon":
            Console.WriteLine(ConnectionStringTester.TestConnectionString(command));
            break;
        default:
            Console.WriteLine(command.Function + " is not a recognized function");
            break;
    }

} while (commandInput.ToLower() != "exit");