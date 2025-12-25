using System;
namespace MainConstructor
{
    public class CallField
    {
        public static void Main(string[] args)
        {
            // Employee employee=new Employee();
            // employee.Id=-1;
            // string result=employee.DisplayEmpDetails();
            // Console.WriteLine(result);
            Associate associate=new Associate(0,"",-1);
            associate.AssociateDetails();


        }
    }
}