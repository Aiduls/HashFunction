using System;

namespace HashFunction
{
    class Program
    {
        public static string inputString;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your string:");
            inputString = Console.ReadLine();

            Console.WriteLine("Hash function:\n" + hashFunc(inputString));
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
