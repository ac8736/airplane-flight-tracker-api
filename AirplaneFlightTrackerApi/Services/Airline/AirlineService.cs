using AirplaneFlightTrackerApi.Models;
using AirplaneFlightTrackerApi.Services.Database;
using MySql.Data.MySqlClient;

namespace AirplaneFlightTrackerApi.Services.Airlines;

public class AirlineService(IDatabaseService databaseService) : IAirlineService
{
    private readonly IDatabaseService _databaseService = databaseService;

    public bool CreateAirline(Airline airline)
    {
        Airline? data = GetAirline(airline.Name);
        if (data != null)
        {
            return false;
        }
        _databaseService.Connect();
        string query = $"INSERT INTO airline VALUES('{airline.Name}');";
        _databaseService.CreateItem(query);

        _databaseService.Disconnect();
        return true;
    }

    public Airline? GetAirline(string name)
    {
        _databaseService.Connect();
        string query = $"SELECT * FROM airline WHERE name='{name}'";
        MySqlDataReader data = _databaseService.GetItem(query);
        while (data.Read())
        {
            Airline airline = new(data.GetString("name"));
            _databaseService.Disconnect();
            return airline;
        }

        _databaseService.Disconnect();
        return null;
    }

    public void RemoveAirline(string name)
    {
        _databaseService.Connect();
        string query = $"DELETE FROM airline WHERE name='{name}'";
        _databaseService.DeleteItem(query);
        _databaseService.Disconnect();
    }
}