using AutoRepairJsonWersion.Components.Models;
using Newtonsoft.Json;

namespace AutoRepairJsonWersion.Components.Services;

public class ClientProvider
{
    const string PathAllClients = "AllClient.json";
    private static List<Client>? _newClients = [];
    

    protected void OnInitialized()
    { OpenFile(); }
    private void OpenFile()
    {
        if (File.Exists(PathAllClients))
        { 
            var json = File.ReadAllText(PathAllClients);
            _newClients = JsonConvert.DeserializeObject<List<Client>>(json); 
        }
        else
        { SaveFile(); }
    }
    public static void SaveFile()
    {
        var json = JsonConvert.SerializeObject(_newClients);
        File.WriteAllText(PathAllClients, json);
    }
    
    
    public static void AddNewClient(string name, string lastname, Role role, string login, string password) 
    {
        var credentials = new Credentials(login, password);
        var client = new Client(name, lastname, role, credentials); 
        _newClients?.Add(client);
    }
    public static void DeleteClient(Client? client)
    {
        _newClients?.Remove(client);
        SaveFile();
    }
    public static Client? GetUserByEmailStatic(string login)//вот это мне кажется такооой колхоз, но пока хз как фиксить
    {
        return _newClients.FirstOrDefault(x=> x.ClientCredentials.Login == login);
    } 
    public Client? GetUserByEmail(string login)
    {
        return _newClients.FirstOrDefault(x=> x.ClientCredentials.Login == login);
    } 
    
    
    public static IList<Client?>? ClientGetInfo()
    {  
        var json = File.ReadAllText(PathAllClients);
        _newClients = JsonConvert.DeserializeObject<List<Client>>(json);
        if (_newClients != null) 
            return null;
        return null;
    }

   
}