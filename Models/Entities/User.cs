namespace Entitytest.Models.Entities;
 
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
}