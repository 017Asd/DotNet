using System;
namespace Q1
{
    public class Patient
    {
        int Id{get;set;}
        string Name{get;set;}
        int Age{get;set;}
        string Condition{get;set;}
         public List<string> MedicalHistory { get; private set; }

         public Patient(int id, string name, int age, string condition)
    {
        Id = id;
        Name = name;
        Age = age;
        Condition = condition;
        MedicalHistory = new List<string>();
    }
    }
}