using System;

namespace ConversorCalculator;

public class User
{
    public string Username {get; set;}
    public string Name {get; set;}
    public string Password {get; set;}
    public List<string> Operations {get; set;}

    public User()
    {
        this.Username = "";
        this.Name = "";
        this.Password = "";
        this.Operations = new List<string>();
    }

    public void AddOperation(string input,string output,string conversion)
    {
        string separator = ",";
        string operation = "";

        operation += input + separator;
        operation += output + separator;
        operation += conversion;

        this.Operations.Add(operation);
    }

    public void SaveOperations()
    {
        UserManager.SaveOperations(this);
    }
}