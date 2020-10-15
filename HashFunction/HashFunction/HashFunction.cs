using System;
using System.Text;

namespace HashFunction
{
    class HashFunction
    {
        public static string inputString;
        public static char[] outputString;
        public const int count = 64;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    inputString = System.IO.File.ReadAllText(args[i]);
                    Console.WriteLine("Your input string from file no. {0}:\n {1}", i, inputString);

                    outputString = hashFunc(inputString);
                    Console.WriteLine("String after hash function:");
                    foreach(char ch in outputString) { Console.Write(ch); }
                }
            }
            else
            {
                Console.WriteLine("Enter your string:");
                inputString = Console.ReadLine();

                outputString = hashFunc(inputString);
                Console.WriteLine("String after hash function:");
                foreach (char ch in outputString) { Console.Write(ch); }
            }
        }
        static char[] hashFunc(string inputString)
        {
            byte[] ba;
            byte[] newBa;
            char[] finalHashString = new char[count];
            string hexString;
            bool isLong = false;

            Console.WriteLine(inputString);
            ba = Encoding.ASCII.GetBytes(inputString);
            byte ch2;
            int j = 0;
            int loop = 0;
            byte prevVal = Byte.MinValue;

            newBa = new byte[ba.Length];

            if (ba.Length > count) { isLong = true; }

            foreach (var ch in ba)
            {
                ch2 = ch;

                if (j % 3 == 0 || j % 5 == 0)
                {
                    prevVal /= 2;
                    ch2 -= prevVal;
                }
                else if (j % 7 == 0)
                {
                    prevVal /= 3;
                    ch2 += prevVal;
                }
                else
                {
                    ch2 += prevVal;
                }

                if (isLong && j == (count/2 - 1)) 
                { 
                    loop++;
                    j = 0;
                }

                if (loop == 0)
                {
                    newBa[j] = ch2;
                }
                else
                {
                    newBa[j] += ch2;
                }

                prevVal = newBa[j];
                j++;
            }

            hexString = BitConverter.ToString(newBa);
            hexString = hexString.Replace("-", "");
            if (!isLong)
            {
                for (int i = 0, k = 0; i < count; i++)
                {
                    finalHashString[i] = hexString[k];
                    k++;
                    if (k >= hexString.Length - 1)
                    {
                        k = i / 2 - (i / 3);
                        if (k >= hexString.Length) { k = hexString.Length - k; }
                    }
                }
            }
            else
            {
                for (int i = 0, k = 0, t = 0; i < hexString.Length; i++)
                {
                    if (k == count)
                    {
                        k = 0;
                        t++;
                    }
                    if (t == 0)
                    {
                        finalHashString[k] = hexString[i];
                        k++;
                    }
                    else
                    {
                        finalHashString[k] += hexString[i];
                    }

                }
            }
            return finalHashString;
        }
    }
}
