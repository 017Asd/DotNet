

// string filePath = "Employees.xml";
        // ds.WriteXml(filePath);
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections;

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
        rw["EmployeeId"] = 16;
        rw["FullName"] = "Anuska";
        rw["Department"] = "CFO";
        rw["Salary"] = 7500000;
        table.Rows.Add(rw);
        // FIX HER
        adapter.Update(ds, "Employees");
        Console.WriteLine("Inserted successfully");
        DataRow row = table.Rows[0];
        row["Salary"] = 90000;

        // VIEW CHANGES
        adapter.Update(ds, "Employees");


    }
}
