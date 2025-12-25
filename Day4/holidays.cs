using System;
namespace MainConstructor
{
    public class Indian
    {
        public  virtual string HolidayList()
        {
            string lists="1-01-2026 New Year\n 14-01-2026 Pongal\n 15-03-2026 Holi" ;
            return lists;
             
        }
    }
    public class USA:Indian
    {
        public  override string HolidayList()

        { 
            string lists="25-11-2026 Thanksgiving 31-12-2026 New Year";
            return lists;
            
        }
    }
}