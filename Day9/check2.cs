using System;
namespace CheckNS
{
    public partial class Checker
    {
        public int D{get;set;}
        public string? name{get;set;}
        public string Display()
        {
            return $"Name is {name}";
        }
    }
}