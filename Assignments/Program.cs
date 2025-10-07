using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            // Display menu
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

    // ==================== Q1 ====================
    /// <summary>
    /// Pseudocode:
    /// - Evaluate arithmetic expressions
    /// - Print each result
    /// </summary>
    static void Q1_Operations()
    {
        Console.WriteLine("Q1 Results:");
        Console.WriteLine(-1 + 4 * 6);           // 23
        Console.WriteLine((35 + 5) % 7);         // 5
        Console.WriteLine(14 + -4 * 6 / 11);     // 12
        Console.WriteLine(2 + 15 / 6 * 1 - 7 % 2); // 3
    }

    // ==================== Q2 ====================
    /// <summary>
    /// Pseudocode:
    /// - Read two numbers from user
    /// - Swap values using temporary variable
    /// - Print swapped numbers
    /// </summary>
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

    // ==================== Q3 ====================
    /// <summary>
    /// Pseudocode:
    /// - Read two integers
    /// - If equal, return triple their sum
    /// - Otherwise, return sum
    /// </summary>
    static void Q3_SumTriple()
    {
        Console.Write("Enter first integer: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter second integer: ");
        int y = int.Parse(Console.ReadLine());

        int result = (x == y) ? (x + y) * 3 : x + y;
        Console.WriteLine("Result: " + result);
    }

    // ==================== Q4 ====================
    /// <summary>
    /// Pseudocode:
    /// - Read Celsius temperature
    /// - Convert to Kelvin: kelvin = celsius + 273
    /// - Convert to Fahrenheit: fahrenheit = celsius * 18 / 10 + 32
    /// - Print results
    /// </summary>
    static void Q4_CelsiusConversion()
    {
        Console.Write("Enter Celsius: ");
        double celsius = double.Parse(Console.ReadLine());

        double kelvin = celsius + 273;
        double fahrenheit = celsius * 18 / 10 + 32;

        Console.WriteLine("Kelvin = " + kelvin);
        Console.WriteLine("Fahrenheit = " + fahrenheit);
    }

    // ==================== Q5 ====================
    /// <summary>
    /// Pseudocode:
    /// - Loop from 1 to 99
    /// - Print only odd numbers
    /// </summary>
    static void Q5_PrintOddNumbers()
    {
        for (int i = 1; i < 100; i += 2)
        {
            Console.WriteLine(i);
        }
    }

    // ==================== Q6 ====================
    /// <summary>
    /// Pseudocode:
    /// - Read a key from the user
    /// - If 0-9, display number
    /// - Otherwise, display "Not allowed"
    /// </summary>
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

    // ==================== Q7 ====================
    /// <summary>
    /// Pseudocode:
    /// - Loop until user types "exit"
    /// - Read a real number
    /// - If negative, print error
    /// - Otherwise, compute square root
    /// - Handle FormatException, OverflowException, other exceptions
    /// </summary>
    static void Q7_SquareRoot()
    {
        while (true)
        {
            try
            {
                Console.Write("Enter a real number (or type 'exit' to return to menu): ");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "exit")
                    break;

                double num = double.Parse(input);

                if (num < 0)
                {
                    Console.WriteLine("Error: Cannot compute square root of a negative number.");
                }
                else
                {
                    double sqrt = Math.Sqrt(num);
                    Console.WriteLine($"Square root of {num} is {sqrt}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a valid real number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Number too large or too small to process.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}