using System.Diagnostics;

namespace Task1_ADv
{
    internal class Program
    {
        static void Main(string[] args)
        {
             Console.WriteLine("Hello, World!");
             string x= Console.ReadLine();
            /////////////////////////////////////////////////
            // TASK1
            //Console.WriteLine("sizeOFArray: ");
            //int size = int.Parse(Console.ReadLine());
            //int[] numbers = new int[size];
            //// Input numbers
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    Console.WriteLine($"Enter number {i + 1}: ");
            //    numbers[i] = int.Parse(Console.ReadLine());
            //}
            //// Find the longest distance
            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    int maxDistance = 0;

            //    for (int j = i + 1; j < numbers.Length; j++)
            //    {
            //        if (numbers[i] == numbers[j])
            //        {
            //            int distance = j - i - 1;

            //            if (distance > maxDistance)
            //            {
            //                maxDistance = distance;
            //            }
            //        }
            //    }

            //Console.WriteLine($"Longest distance for number {numbers[i]} = {maxDistance}");

            //////////////////////////////////////////////////////////////
            //TASK2
            /////////////Task 2 way 1 ReverseTheorderofthewords ///////////////////

            //        Console.WriteLine("Enter seprated words:");
            //        string input = Console.ReadLine();
            //        string[] words = input.Split(' ');

            //        Array.Reverse(words);

            //        string reversedSentence = string.Join(" ", words);

            //        Console.WriteLine(reversedSentence);


            ////////////////////////// Task 2 way 1 ReverseTheorderofthewords ////////////////////////////


            //Console.WriteLine("Enter seprated words:");
            //string str = Console.ReadLine();
            //// var to track the start and end positions of words

            //int wordStart = 0;
            //int wordEnd = str.Length;
            //// Iterate through the characters of the input string in reverse order

            //for (int i = str.Length - 1; i >= 0; i--)
            //{        // Check if the current character is a space

            //    if (str[i] == ' ')
            //    {
            //        // Extract and print the word from the input string

            //        Console.Write($"{str.Substring(i + 1, wordEnd - i - 1)}  ");
            //        // Update the end position of the current word

            //        wordEnd = i;
            //    }
            //}
            //// Print the first word (or the entire string if there's only one word)

            //Console.Write(str.Substring(0, wordEnd));

            //string reversedSentence = "";


            //////////////////////////TASK3///////////////////////////////

        //    Stopwatch sw = new Stopwatch();
        //    sw.Start();
        //    int num = 99999999;
        //    string numToString = num.ToString();
        //    int numberOfOnes = (numToString.Length * (int)Math.Pow(10, numToString.Length - 1));
        //    Console.WriteLine(numberOfOnes);
        //    Console.WriteLine($"Number of digit '1'  {numberOfOnes}");
        //    sw.Stop();
        //    Console.WriteLine($"Execution Time: {sw.Elapsed}");
        //}
        //////////////////////////////////////////////////////////////

    }
}
}
        
        
    

        
   

