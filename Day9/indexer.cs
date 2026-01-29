using System;
class MyData
{
    private string[] data=new string[4];
    public string this [int index]
    {
        get
        {
            return data[index];
        }
        set
        {
            data[index]=value;
        }
    }
}
