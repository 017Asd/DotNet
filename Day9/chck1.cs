using System;
namespace CheckNS
{
    public  partial class Checker{
        public int ID{get;set;}
        public int Name{get;set;}
        public int Addd()
        {
            return ID+Name;
        }
    }
}