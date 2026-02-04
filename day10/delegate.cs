using System;
using System.Data;
public class Checkkk
{
    public delegate int AddDeligate(int a,int b);
    public void Delegate()
    {
        AddDeligate deligatevariable=new AddDeligate(Add1);
        Console.WriteLine(deligatevariable(1,5));
    }
    public int Add1(int a,int b)
    {
        return a+b+10;
    }
}