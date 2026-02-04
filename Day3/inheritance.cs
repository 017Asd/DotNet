using System;
public class Person
{
    public int id{get; set;}
    public string Name;

    public int age{get; set;}
}
public class Man : Person
{
    public string? PLaying {get; set;}
}
public class Woman : Person
{
    public string Play {get; set;}
}
public class Child: Person
{
    public string cartoon {get; set;}
}