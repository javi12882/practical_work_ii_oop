using System;
using System.Text.Json;

namespace ConversorCalculator;

public static class UserManager
{
    private static string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "DB_Users.json");
    public static User SignIn(string username, string password)
    {
        var users = new List<User>();
        
        if(!File.Exists(FilePath))
        {
            throw new ArgumentNullException();
        }

        foreach(var line in File.ReadLines(FilePath))
        {
            if(!string.IsNullOrWhiteSpace(line))
            {
                var user = JsonSerializer.Deserialize<User>(line);
                if (user.Username == username && user.Password == password)
                {
                    return user;
                }
            }
        }

        throw new InvalidOperationException("El usuario introducido no existe");
    }

    private static void CreateFile()
    {
        if(!File.Exists(FilePath))
        {
            File.Create(FilePath);
        }
    }

    //Save new user on a file
    public static void CreateNewUser(string nombre, string username, string password)
    {
        CreateFile();

        var user = new User {
            Username = username,
            Name = nombre,
            Password = password,
            Operations = new List<string>()
        };

        var options = new JsonSerializerOptions { WriteIndented = false};
        string json = JsonSerializer.Serialize(user, options);

        File.AppendAllText(FilePath, json + Environment.NewLine);
    }

    public static void SaveOperations(User u)
    {
        List<string> updateLines = new List<string>();
        
        if(!File.Exists(FilePath))
        {
            throw new ArgumentNullException();
        }

        foreach(var line in File.ReadLines(FilePath))
        {
            User user = JsonSerializer.Deserialize<User>(line);
            
            if(user.Username == u.Username)
            {
                var options = new JsonSerializerOptions { WriteIndented = false};
                updateLines.Add(JsonSerializer.Serialize(u, options));
            }
            else
            {
                updateLines.Add(line);
            }

        }

        File.WriteAllLines(FilePath, updateLines);

    }
}