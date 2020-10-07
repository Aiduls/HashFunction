using System;

namespace HashFunction
{
    class Program
    {
        public static string inputString;
        public static string hashString;
        static void Main(string[] args)
        {
            if (args[0] != "")
            {
                for (int i = 0; i < args.Length; i++)
                {
                    inputString = System.IO.File.ReadAllText(args[i]);
                    Console.WriteLine("Your input string from file no. " + i + ":\n" + inputString);
                    hashString = hashFunc(inputString);
                    Console.WriteLine("String after hash function:\n" + hashString);
                }
            } 
            else
            {
                Console.WriteLine("Enter your string:");
                inputString = Console.ReadLine();

                hashString = hashFunc(inputString);
                Console.WriteLine("String after hash function:\n" + hashString);
            }
        }
        static string hashFunc(string inputString)
        {
            string hashString;

            // TODO: Hash logic

            hashString = "";
            return hashString;
        }
    }
}
