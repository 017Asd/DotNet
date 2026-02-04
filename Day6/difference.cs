using System;
namespace MainConstructor{
interface ToDo
{
    void Study();
}

    public class Child : ToDo
    {
        public string Suject;

        // we using the interface methods which are predefined which had to be inherited irrespecitve of circumstances 
        //if we create a parent class with method Study() defined using abstract class the child   inherit the abstract and class and modify and 
        //create functionalities according to his requirement
        public void Study()
        {
            Console.WriteLine($"I am gng to study {Suject}");
        }
    }


}