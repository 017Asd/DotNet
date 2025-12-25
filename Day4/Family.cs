using System;
namespace MainConstructor
{
    public class Father
    {
        public virtual string InterestOn()  //we use virtual given as permission to be overwritten
        {
            return "Football";
        }
    }
    public class Son : Father
    {
        //this is overloading to avoid this we meniton in the parent that this function can be overwritten .Theusage of same function twice is overloading that is runtime error and 

        public override string InterestOn()
        {
            return "mobile games";
        }
    
    }

}