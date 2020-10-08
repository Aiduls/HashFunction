using System;

namespace HashFunction
{
    class HashFunction
    {
        public static string inputString;
        public static string outputString;
        //public static char[] hashString = new char[128];
        public const int count = 128;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    inputString = System.IO.File.ReadAllText(args[i]);
                    Console.WriteLine("Your input string from file no. {0}:\n{1}", i, inputString);

                    outputString = hashFunc(inputString);
                    Console.WriteLine("String after hash function:\n{0}", outputString);
                }
            }
            else
            {
                //Console.WriteLine("Enter your string:");
                //inputString = Console.ReadLine();

                outputString = hashFunc(inputString);
                Console.WriteLine("String after hash function:\n{0}", outputString);
            }
        }
        static string hashFunc(string inputString)
        {
            inputString = "testing";

            char[] hashString = new char[128];
            byte symbol;
            byte prevSymbol = count;
            byte[] hashSymbol;
            //int i = 0;

            //hashSymbol = GetBytes(inputString);
            hashSymbol = Convert.FromBase64String(inputString);

            //if (inputString.Length <= count)
            //{
            /*for (int i = 0, j = 0; i < 7; i++)
            {
                try
                {
                    symbol = hashSymbol[i];
                    hashSymbol[i] += prevSymbol;
                    prevSymbol = symbol;

                    // sth
                    *//*symbol = inputString[j];
                    hashSymbol = Convert.ToByte(symbol);
                    hashSymbol += prevSymbol;
                    hashSymbol %= 16;

                    prevSymbol = Convert.ToByte(symbol);
                    // prideda prie galinio hashStringo
                    hashString[i] = Convert.ToChar(hashSymbol);
                    Console.WriteLine("{0} is converted to {1}. Final symbol: {2}", symbol, hashSymbol, hashString[i]);

                    j++;

                    //temp
                    if (j == inputString.Length) break;*//*


                }
                catch (OverflowException)
                {
                    // console.writeline("unable to convert u+{0} to a byte.",
                    //                 Convert.ToInt16(symbol).ToString("X4"));
                }
                //  }
                }*/

            /*foreach (char symbol in inputString)
            {
                try
                {

                    byte result = Convert.ToByte(symbol);
                    Console.WriteLine("{0} is converted to {1}.", symbol, result);

                    i++;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Unable to convert u+{0} to a byte.",
                                      Convert.ToInt16(symbol).ToString("X4"));
                }
            }*/
            //string str = GetString(hashSymbol);
            string str = Convert.ToBase64String(hashSymbol);

            foreach (char ch in str)
                {
                    Console.Write(ch);
                }

                return str;
            }
            static byte[] GetBytes(string str)
            {
                byte[] bytes = new byte[str.Length * sizeof(char)];
                System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
                return bytes;
            }
            static string GetString(byte[] bytes)
            {
                char[] chars = new char[bytes.Length / sizeof(char)];
                System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
                return new string(chars);
            }

        }
    }
