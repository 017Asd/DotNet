namespace Q4
{
    public class Doctor:Person
    {
        public bool IsAvailable{get;set;}
        public Doctor(int id,string name,bool availability):base(id,name)
        {
            IsAvailable=availability;

        }
    }
}