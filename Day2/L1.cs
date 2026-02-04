using System;
using System.Runtime.InteropServices;
class L1
{
    //creating main function 
    static void Main6()
    {
        //read the number of terms from the user
        int numberOfTerms=ReadTerms();
        PrintFibonacciSeries(numberOfTerms);
    }
    //creating a function for taking input for number of terms
    static int ReadTerms()
    {
        Console.WriteLine("Enter the number of terms: ");
        return int.Parse(Console.ReadLine());

    }
    //function for printing the fibonnaci series

    static void PrintFibonacciSeries(int terms)
    {
        Console.WriteLine("Fibonacci Series: ");
        for(int i= 0; i < terms; i++)
        {
            Console.Write(Fibonacci(i)+" ");
        }
    }
    //finding the elements in the series using recursion
    static int Fibonacci(int n)
    {
        //base case which are required to put an end to the recursion
        if(n==0)
            return 0;
        if(n==1)
            return 1;
        return Fibonacci(n-1)+Fibonacci(n-2);
    }
}