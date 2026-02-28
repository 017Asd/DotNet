using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using Question.Models;
public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<string>> GetSourcesAsync()
    {
        var list = new List<string>();

        using SqlConnection conn = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetSources", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        await conn.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
            list.Add(reader["Source"].ToString());

        return list;
    }

    public async Task<List<string>> GetDestinationsAsync()
    {
        var list = new List<string>();

        using SqlConnection conn = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetDestinations", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        await conn.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
            list.Add(reader["Destination"].ToString());

        return list;
    }

    public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
    {
        var list = new List<FlightResult>();

        using SqlConnection conn = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("sp_SearchFlights", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Source", source);
        cmd.Parameters.AddWithValue("@Destination", destination);
        cmd.Parameters.AddWithValue("@Persons", persons);

        await conn.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(new FlightResult
            {
                FlightId = (int)reader["FlightId"],
                FlightName = reader["FlightName"].ToString(),
                FlightType = reader["FlightType"].ToString(),
                Source = reader["Source"].ToString(),
                Destination = reader["Destination"].ToString(),
                TotalCost = (decimal)reader["TotalCost"]
            });
        }

        return list;
    }

    public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
    {
        var list = new List<FlightHotelResult>();

        using SqlConnection conn = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("sp_SearchFlightsWithHotels", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Source", source);
        cmd.Parameters.AddWithValue("@Destination", destination);
        cmd.Parameters.AddWithValue("@Persons", persons);

        await conn.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(new FlightHotelResult
            {
                FlightId = (int)reader["FlightId"],
                FlightName = reader["FlightName"].ToString(),
                Source = reader["Source"].ToString(),
                Destination = reader["Destination"].ToString(),
                HotelName = reader["HotelName"].ToString(),
                TotalCost = (decimal)reader["TotalCost"]
            });
        }

        return list;
    }
}