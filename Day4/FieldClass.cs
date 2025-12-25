using System;
using MainConstructor;
public class Employee
{
    //creating a field it will not be exposed outside we have to create cirresponding property
    //first we can validate the input and then assign it to the property
    private int id;
    // public int Id{get=>id;set=>id=value;}

    //validating example we are only setting the value we cant read the alue
    public int Id
    {
        set
        {
            if (value > 0)
            {
                id=value;
            }
            else
            {
                id=0;
            }
        }
    }
    public string DisplayEmpDetails()
    {
        return $"Employee Id i {id}";
    }

}

