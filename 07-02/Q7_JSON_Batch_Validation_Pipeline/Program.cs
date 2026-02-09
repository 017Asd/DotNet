using System;
using System.Collections.Generic;
using System.Text.Json;

class Program
{
    static void Main()
    {
        var validator = new BatchValidator();

        var jsons = new List<string>
        {
            "{\"Email\":\"test@mail.com\",\"Age\":25}",
            "{\"Email\":\"badmail\",\"Age\":17}"
        };

        var report = validator.ValidateBatch(jsons);

        Console.WriteLine($"Valid: {report.Valid}");
        Console.WriteLine($"Invalid: {report.Invalid}");
    }
}

class BatchValidator
{
    public ValidationReport ValidateBatch(List<string> payloads)
    {
        var report = new ValidationReport();

        foreach (var json in payloads)
        {
            try
            {
                var root = JsonDocument.Parse(json).RootElement;

                if (!root.GetProperty("Email").GetString().Contains("@"))
                    throw new Exception("Invalid Email");

                int age = root.GetProperty("Age").GetInt32();
                if (age < 18 || age > 60)
                    throw new Exception("Invalid Age");

                report.Valid++;
            }
            catch
            {
                report.Invalid++;
            }
        }

        return report;
    }
}

class ValidationReport
{
    public int Valid;
    public int Invalid;
}
