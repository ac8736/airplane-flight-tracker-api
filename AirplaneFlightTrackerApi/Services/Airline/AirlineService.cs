using AirplaneFlightTrackerApi.Models;
using AirplaneFlightTrackerApi.Services.Database;
using MySql.Data.MySqlClient;

namespace AirplaneFlightTrackerApi.Services.Airlines;

public class AirlineService(IDatabaseService databaseService) : IAirlineService
{
    private readonly IDatabaseService _databaseService = databaseService;

    public bool CreateAirline(Airline airline)
    {
        _databaseService.Connect();
        string query = $"SELECT * FROM airline WHERE name='{airline.Name}'";
        MySqlDataReader data = _databaseService.GetItem(query);
        if (data.HasRows)
        {
            _databaseService.Disconnect();
            return false;
        }
        _databaseService.Disconnect();
        _databaseService.Connect();

        query = $"INSERT INTO airline VALUES('{airline.Name}');";
        _databaseService.CreateItem(query);
        _databaseService.Disconnect();
        return true;
    }

    public void RemoveAirline(string name)
    {
        _databaseService.Connect();
        string query = $"DELETE FROM airline WHERE name='{name}'";
        _databaseService.DeleteItem(query);
        _databaseService.Disconnect();
    }
}