using AirplaneFlightTrackerApi.Models;
using AirplaneFlightTrackerApi.Services.Database;
using MySql.Data.MySqlClient;

namespace AirplaneFlightTrackerApi.Services.Airports;

public class AirportService(IDatabaseService databaseService) : IAirportService
{
    private readonly IDatabaseService _databaseService = databaseService;

    public bool CreateAirport(Airport airport)
    {
        _databaseService.Connect();
        string query = $"SELECT * FROM airport WHERE code='{airport.Code}';";
        MySqlDataReader data = _databaseService.GetItem(query);
        if (data.HasRows)
        {
            _databaseService.Disconnect();
            return false;
        }
        _databaseService.Disconnect();
        _databaseService.Connect();

        string sqlDateString = airport.DateCreated.ToString("yyyy-MM-dd HH:mm:ss");
        query = $"INSERT INTO airport VALUES('{airport.Name}','{airport.Code}','{airport.City}','{airport.Country}', '{sqlDateString}')";
        _databaseService.CreateItem(query);

        _databaseService.Disconnect();
        return true;
    }

    public Airport? GetAirport(string code)
    {
        _databaseService.Connect();
        string query = $"SELECT * FROM airport WHERE code='{code}';";
        MySqlDataReader data = _databaseService.GetItem(query);
        while (data.Read())
        {
            Airport airport = new(data.GetString("name"), data.GetString("code"), data.GetString("city"), data.GetString("country"), data.GetDateTime("dateCreated"));

            _databaseService.Disconnect();
            return airport;
        }

        _databaseService.Disconnect();
        return null;
    }

    public void RemoveAirport(string code)
    {
        _databaseService.Connect();
        string query = $"DELETE FROM airport WHERE code='{code}'";
        _databaseService.DeleteItem(query);

        _databaseService.Disconnect();
        return;
    }
}
