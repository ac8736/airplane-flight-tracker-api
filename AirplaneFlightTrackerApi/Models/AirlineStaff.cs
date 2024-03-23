namespace AirplaneFlightTrackerApi.Models;

public class AirlineStaff(string username, string email, string password, string firstName, string lastName, string airline, DateTime dateCreated, DateTime dateModified)
{
    public string Username { get; } = username;
    public string Email { get; } = email;
    public string Password { get; } = password;
    public string FirstName { get; } = firstName;
    public string LastName { get; } = lastName;
    public string Airline { get; } = airline;
    public DateTime DateCreated { get; } = dateCreated;
    public DateTime LastModified { get; } = dateModified;
}