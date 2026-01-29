using System;
class Student
{
    public int Rno;
    public string? Name;
    private string address;
    private string[] books=new string[4];   
    public string this [int index]
    {
        get
        {
            return books[index];
        }
        set
        {
            books[index]=value;
        }
    }
}
