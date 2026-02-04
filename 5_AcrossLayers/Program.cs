using System;

class Controller
{
    static void Main()
    {
        try
        {
            Service.Process();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Handled in Controller: " + ex.Message);
        }
    }
}

class Service
{
    public static void Process()
    {
        try
        {
            Repository.GetData();
        }
        catch (Exception)
        {
            Console.WriteLine("Logged in Service");
            throw;
        }
    }
}

class Repository
{
    public static void GetData()
    {
        throw new Exception("Database failure");
    }
}
