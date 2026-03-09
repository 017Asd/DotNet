using System.Net.Http.Json;

var client = new HttpClient();

client.BaseAddress = new Uri("http://localhost:5056/");

var employees = await client.GetFromJsonAsync<List<EmployeeDto>>("api/employee");

if (employees != null)
{
    foreach (var emp in employees)
    {
        Console.WriteLine($"{emp.EmployeeId} - {emp.Name} - {emp.Email}");
    }
}

public class EmployeeDto
{
    public int EmployeeId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
}