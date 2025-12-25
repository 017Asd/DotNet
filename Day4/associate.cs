using System;
namespace MainConstructor
{
    public class Associate
    {
        private int id;
        private string? name;
        private int rank;
        List<string> errors=new List<string>();   //instead of list we can use a string 

        public int Id
        {
            set
            {
                if (value >= 1)
                {
                    id=value;
                }
                else
                {
                    errors.Add("Invalid ID mention ID greather than or equal to 1");
                }
                
            }
        }
        public string Name
        {
            set
            {
                if (value.Contains("  "))
                {
                    name=value;
                }
                else
                {
                    errors.Add("Name cannot be empty.Please mention a name");
                }
            }
        }
        public int Rank
        {
            set
            {
                if (value >= 1)
                {
                    rank=value;
                }
                else
                {
                    errors.Add("Invalid Rank!Check it again");
                }
            }
        }
        
        public Associate(int ID,string NAME, int RANK)
        {

            this.Id=ID;
            this.Name=NAME;
            this.Rank=RANK;
            if (errors.Count > 0)
            {
                throw new ArgumentException(string.Join("\n",errors));
            }

        }
        public string AssociateDetails()
        {
            return $"{id} {name} {rank}";
        }
    }
}