namespace WebApi.Entities;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Username { get; set; }
    public string LastName { get; set; } 
    public DateTime CreationDateTime { get; set; }
    public DateTime? LastUpdateDateTime { get; set; }

    [JsonIgnore]
    public string Password { get; set; }

    


}