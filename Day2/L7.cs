using System;

class BinaryToDecimal
{
    static void Main()
    {
        // Read binary number as string
        string binary = ReadBinary();

        // Convert binary to decimal
        int decimalValue = ConvertToDecimal(binary);

        // Display result
        Console.WriteLine("Decimal Value: " + decimalValue);
    }

    // Reads binary input
    static string ReadBinary()
    {
        Console.Write("Enter binary number: ");
        return Console.ReadLine()!;
    }

    // Converts binary string to decimal manually
    static int ConvertToDecimal(string binary)
    {
        int result = 0;
        int power = 1; // Represents 2^0 initially

        // Traverse binary number from right to left
        for (int i = binary.Length - 1; i >= 0; i--)
        {
            // If bit is 1, add corresponding power of 2
            if (binary[i] == '1')
                result += power;

            power *= 2; // Move to next power of 2
        }

        return result;
    }
}
