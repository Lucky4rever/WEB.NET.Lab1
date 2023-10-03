using System;

class Program
{
    static void Main(string[] args)
    {
        CustomArray<int> array = new CustomArray<int>(new int[] { 1, 3, 2 }, 4);
        Console.WriteLine($"Item is {array[5]}");

        Console.ReadKey();
    }
}
