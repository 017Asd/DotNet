

// string filePath = "Employees.xml";
        // ds.WriteXml(filePath);
using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string cs = @"Server=localhost\SQLEXPRESS;Database=TrainingDB;Trusted_Connection=True;TrustServerCertificate=True;";
        string sql = "SELECT EmployeeId, FullName, Department, Salary FROM dbo.Employees";

        using SqlConnection con = new SqlConnection(cs);
        using SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
        SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

        DataSet ds = new DataSet();
        adapter.Fill(ds, "Employees");

        DataTable table = ds.Tables["Employees"];

        DataRow rw = table.NewRow();
        rw["EmployeeId"] = 1006;
        rw["FullName"] = "Sachin";
        rw["Department"] = "CTO";
        rw["Salary"] = 750000;
        table.Rows.Add(rw);

        // FIX HER
        adapter.Update(ds, "Employees");

        Console.WriteLine("Inserted successfully");
    }
}
