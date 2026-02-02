using System;
/// <summary>
/// <para>Description: This program calculates the hazard risk score of industrial robots based on arm precision, worker density, and machinery state. It includes custom exception handling for invalid inputs.</para>
/// </summary>
namespace RobotHazardAnalyzer
{
    //class for custom exception
    public class RobotSafetyException : Exception
    {
        public RobotSafetyException(string? message): base(message)
        {
            
        }
    }
    public class Program
    {
        //method to calculate hazard risk
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
            //input validation
            if (armPrecision < 0.0 || armPrecision > 1.0)
        {
            throw new RobotSafetyException("Error: Arm precision must be 0.0-1.0");
        }
            //input validation
            if (workerDensity < 1 || workerDensity > 20)
        {
            throw new RobotSafetyException("Error: Worker density must be 1-20");
        }
        double machineRiskFactor;
            //determine machine risk factor based on machinery state
            if (machineryState == "Worn")
        {
            machineRiskFactor = 1.3;
        }
        else if(machineryState == "Faulty")
        {
            machineRiskFactor = 2.0;
        }
        else if(machineryState == "Critical")
        {
            machineRiskFactor = 3.0;
        }
            //unsupported machinery state
            else
            {
            throw new RobotSafetyException("Error: Unsupported machinery state");
        }
            //calculate hazard risk
            double hazardRisk = ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
            //return hazard risk score
            return hazardRisk;
    }
        ///main method
        static void Main(string[] args)
        {
            //object of Program class
            Program p = new Program();
            //user input and exception handling
            try
            {
            Console.WriteLine("Enter Arm Precision (0.0 - 1.0):");
            double armPrecision = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Worker Density (1 - 20):");
            int workerDensity = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Machinery State (Worn/Faulty/Critical):");
            string machineryState = Console.ReadLine();

            Program program = new Program();
            double risk = program.CalculateHazardRisk(armPrecision, workerDensity, machineryState);

            Console.WriteLine("Robot Hazard Risk Score: " + risk);
        }
            //handle custom exceptions
            catch (RobotSafetyException ex)
        {
            Console.WriteLine(ex.Message);
        }
        }
    }
}