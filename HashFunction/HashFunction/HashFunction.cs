using System;
using System.Text;
using System.IO;

namespace HashFunction
{
    class HashFunction
    {
        public static string inputString;
        public static char[] outputString;
        public static string konstitucija = "D:\\Mokslai\\3 semestras\\blockchain\\HashFunction\\HashFunction\\textFiles\\konstitucija.txt";
        public static long time = 0;
        public const int count = 64;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    inputString = File.ReadAllText(args[i]);
                    Console.WriteLine("\n\nYour input string from file no. {0}:\n{1}\n", i+1, inputString);

                    if (inputString != "")
                    {
                        outputString = hashFunc(inputString);
                        Console.WriteLine("String after hash function:");
                        foreach (char ch in outputString) { Console.Write(ch); }
                    }
                    else
                    {
                        Console.WriteLine("Your provided string is empty!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Enter your string:");
                inputString = Console.ReadLine();

                if (inputString != "")
                {
                    if (inputString == "konstitucija")
                    {
                        var watch = System.Diagnostics.Stopwatch.StartNew();
                        foreach (string line in File.ReadAllLines(konstitucija))
                        {
                            Console.WriteLine(hashFunc(line));
                        }
                        watch.Stop();
                        var elapsedMs = watch.ElapsedMilliseconds;
                        Console.WriteLine("\n\nTime taken for hashing: {0}ms", elapsedMs);
                    }
                    else
                    {
                        outputString = hashFunc(inputString);
                        Console.WriteLine("String after hash function:");
                        foreach (char ch in outputString) { Console.Write(ch); }
                    }
                }
                else
                {
                    Console.WriteLine("Your provided string is empty!");
                }
            }
        }
        static char[] hashFunc(string inputString)
        {   
            byte[] ba;
            byte[] newBa;
            char[] finalHashString = new char[count];
            string hexString;
            bool isLong = false;

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
                    if (k >= hexString.Length - 1 && k != 0)
                    {
                        k = i / 2 - (i / 3);
                        if (k >= hexString.Length)
                        {
                            k = hexString.Length - k;
                            if (k < 0) { k = 0; }
                        }
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
