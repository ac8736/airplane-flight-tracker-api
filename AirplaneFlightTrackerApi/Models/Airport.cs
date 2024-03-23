namespace AirplaneFlightTrackerApi.Models;

public class Airport(string name, string code, string city, string country, DateTime dateCreated)
{
    public string Name { get; } = name;
    public string Code { get; } = code;
    public string City { get; } = city;
    public string Country { get; } = country;
    public DateTime DateCreated { get; } = dateCreated;
}