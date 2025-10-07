using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== C# Assignment Menu ===");
            Console.WriteLine("1. Q1: Operations");
            Console.WriteLine("2. Q2: Swap Numbers");
            Console.WriteLine("3. Q3: Sum or Triple");
            Console.WriteLine("4. Q4: Celsius Conversion");
            Console.WriteLine("5. Q5: Print Odd Numbers 1-99");
            Console.WriteLine("6. Q6: Number Key Check");
            Console.WriteLine("7. Q7: Square Root with Try..Catch");
            Console.WriteLine("0. Exit");
            Console.Write("Select a question (0-7): ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Q1_Operations();
                    break;
                case "2":
                    Q2_SwapNumbers();
                    break;
                case "3":
                    Q3_SumTriple();
                    break;
                case "4":
                    Q4_CelsiusConversion();
                    break;
                case "5":
                    Q5_PrintOddNumbers();
                    break;
                case "6":
                    Q6_NumberKeyCheck();
                    break;
                case "7":
                    Q7_SquareRoot();
                    break;
                case "0":
                    Console.WriteLine("Exiting program.");
                    return;
                default:
                    Console.WriteLine("Invalid selection. Please choose 0-7.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // --- Question Methods ---
    static void Q1_Operations()
    {
        Console.WriteLine(-1 + 4 * 6);           // 23
        Console.WriteLine((35 + 5) % 7);         // 5
        Console.WriteLine(14 + -4 * 6 / 11);     // 12
        Console.WriteLine(2 + 15 / 6 * 1 - 7 % 2); // 3
    }

    static void Q2_SwapNumbers()
    {
        Console.Write("Input the First Number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Input the Second Number: ");
        int b = int.Parse(Console.ReadLine());

        int temp = a;
        a = b;
        b = temp;

        Console.WriteLine("After Swapping:");
        Console.WriteLine("First Number: " + a);
        Console.WriteLine("Second Number: " + b);
    }

    static void Q3_SumTriple()
    {
        Console.Write("Enter first integer: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter second integer: ");
        int y = int.Parse(Console.ReadLine());

        int result = (x == y) ? (x + y) * 3 : x + y;
        Console.WriteLine("Result: " + result);
    }

    static void Q4_CelsiusConversion()
    {
        Console.Write("Enter Celsius: ");
        double celsius = double.Parse(Console.ReadLine());

        double kelvin = celsius + 273;
        double fahrenheit = celsius * 18 / 10 + 32;

        Console.WriteLine("Kelvin = " + kelvin);
        Console.WriteLine("Fahrenheit = " + fahrenheit);
    }

    static void Q5_PrintOddNumbers()
    {
        for (int i = 1; i < 100; i += 2)
        {
            Console.WriteLine(i);
        }
    }

    static void Q6_NumberKeyCheck()
    {
        Console.Write("Press a key: ");
        char key = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (char.IsDigit(key))
            Console.WriteLine("You pressed: " + key);
        else
            Console.WriteLine("Not allowed");
    }

    static void Q7_SquareRoot()
    {
        try
        {
            Console.Write("Enter a real number: ");
            double num = double.Parse(Console.ReadLine());

            if (num < 0)
                Console.WriteLine("Cannot compute square root of a negative number.");
            else
                Console.WriteLine("Square root: " + Math.Sqrt(num));
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input! Please enter a valid number.");
        }
    }
}
