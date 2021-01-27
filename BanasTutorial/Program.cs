﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;

namespace BanasTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Part2(args);
        }
        private static void SayHello() //"Keep functions to about 10 lines of code per function
        {
            string name = "";
            Console.Write("What is your name? ");
            name = Console.ReadLine();
            Console.WriteLine("Hello, {0}!", name);
        }
        private static void Part1(string[] args)
        {
            //Console.WriteLine("Hello World!");

            ////Right click on the C# file, go to Properties->Debug->Application arguments. This is how you simulate Console inputs and create the contents of "args"
            //for (int i = 0; i < args.Length; i++)
            //{
            //    Console.WriteLine("Arg {0}: {1}",i, args[i]);
            //    //Console.WriteLine($"Arg {i}: {args[i]}");     //How I have done it in the past. Slower? Cleaner? Whose to say.
            //}

            //string[] myArgs = Environment.GetCommandLineArgs();  //The other way to acheive the same thing: "Probably never gonna do this"
            //Console.WriteLine(string.Join(", ", myArgs)); //does what you think it does

            //SayHello();

            ////The Data Types:
            //bool CanIVote = true;
            //Console.WriteLine("Biggest int: {0}", int.MaxValue);
            //Console.WriteLine("Smallest int: {0}", int.MinValue);

            ////doubles are big but not precise
            //Console.WriteLine("Biggest Double : {0}", Double.MaxValue.ToString("#")); //you need the pound sign if you want to print out the full decimal rather than scientific notation

            //floats: about half as big as double, even less precise

            /*Other Data Types:
             * byte: 8-bit unsigned int 0 to 255
             * char: 16-bit unicode character
             * sbyte: 8-bit signed int -128 to 127
             * short: 16-bit signed int -32,768 to 32,767
             * uint: 32-bit unsigned int 0 to 4,294,967,295
             * ulong: 64-bit unsigned int 0 to 18,446,744,073,709,551,615
             * ushort: 16-bit unsigned int 0 to 65,535
             */

            ////How parsing works
            //bool boolFromStr = bool.Parse("true");
            //int intFromStr = int.Parse("100");
            //double dblFromStr = double.Parse("1.111");

            ////Dates
            //DateTime awesomeDate = new DateTime(1997, 4, 24);
            //Console.WriteLine("It was a {0}", awesomeDate.DayOfWeek);
            //awesomeDate = awesomeDate.AddDays(4);
            //awesomeDate = awesomeDate.AddMonths(4);
            //awesomeDate = awesomeDate.AddYears(4);
            //Console.WriteLine(awesomeDate.Date);

            ////Time
            //TimeSpan lunchTime = new TimeSpan(12, 30, 0);
            //lunchTime = lunchTime.Subtract(new TimeSpan(0, 15, 0));
            //Console.WriteLine(lunchTime.ToString());    

            //BigInteger bigNum = BigInteger.Parse("1212412442134234523423423423423423434565687879567341434563452345");
            //Console.WriteLine(bigNum*5);

            ////Currency
            //Console.WriteLine("Currency: {0:c}", 23.455);
            //Console.WriteLine("Pad w zeroes: {0:d4}", 23); //doesn't work w decimal values?
            //Console.WriteLine("3 decimals: {0:f3}", 23.455);
            //Console.WriteLine("Commas: {0:n4}", 2300);

            //Fun with strings!
            string randString = "This is a string";
            Console.WriteLine("String length: {0}", randString.Length);
            Console.WriteLine("String has is: {0}", randString.Contains("is"));
            Console.WriteLine("Index of is: {0}", randString.IndexOf("is"));
            Console.WriteLine("Remove String: {0}", randString.Remove(0, 6));
            Console.WriteLine("Insert: {0}", randString.Insert(10, "short"));
            Console.WriteLine("Replace: {0}", randString.Replace("string", "sentence"));
            Console.WriteLine("Compare A to B: {0}", String.Compare("A", "B", StringComparison.OrdinalIgnoreCase)); //check alphabetical order
            Console.WriteLine("A = a : {0}", String.Equals("A", "a", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Pad left : {0}", randString.PadLeft(20, '.'));
            Console.WriteLine("Pad right : {0}", randString.PadRight(20, '.'));
            Console.WriteLine("Trim : {0}", randString.Trim());
            Console.WriteLine("Uppercase : {0}", randString.ToUpper());
            Console.WriteLine("Uppercase : {0}", randString.ToUpper());

            string newString = String.Format("{0} saw {1} with the {2}", "Bob", "Jenny", "Dog"); //Mad libs shit, we know these things

            //put a \ if you want a double quote: \" or \'. backslash is \
            Console.WriteLine(@"no matter how many ' things I put in, it won't matter ");
        }
        
        private static void Part2(string[] args)
        {
            //implicit typing
            var intVal = 4; //c# knows this is an int. bad practice though
            Console.WriteLine(intVal.GetType());

            //arrays
            int[] favNums = new int[3]; //max size 3
            favNums[0] = 23;
            Console.WriteLine("Favorite num 0: {0}", favNums[0]);

            string[] customers = { "bob", "jake" };
            var employees = new[] { "mike", "PAUL" }; 
            object[] randomArray = { 0, "Kelp" };     //array of any object
            Console.WriteLine("Random array 0: {0}", randomArray[0]);

            Console.WriteLine("Array size: {0}", randomArray.Length);
            for (int i = 0; i < randomArray.Length; i++)
            {
                Console.WriteLine("Array {0}: {1}", i, randomArray[i]);
            }

            //multidimensional
            string[,] custNames = new string[2, 2] { { "Bob", "Bob" }, { "Bob", "Bob" } };
            Console.WriteLine("customer name: {0}", custNames.GetValue(1,1));

            for (int i = 0; i < custNames.GetLength(0); i++)
            {
                for (int j = 0; j < custNames.GetLength(1); j++)
                {
                    Console.Write(custNames[i,j]);
                }
                Console.WriteLine();
            }

            int[] randNums = { 1, 4, 6, 8 };
            PrintArray(randNums, "Foreach");
            Array.Sort(randNums);
            Array.Reverse(randNums);
            Console.WriteLine(Array.IndexOf(randNums, 0));
            randNums.SetValue(0, 1);

            int[] srcArray = { 1, 2, 3 };
            int[] destArray = new int[2];
            int startIndex = 0;
            int length = 2;
            Array.Copy(srcArray, startIndex, destArray, startIndex, length);

            Array anothArray = Array.CreateInstance(typeof(int), 10);
            srcArray.CopyTo(anothArray, 5);

            foreach(int m in anothArray)
            {
                Console.WriteLine("Copy to: {0}", m);
            }

            int[] numArray = { 1, 11, 22 };
            Console.WriteLine(">10: {0}", Array.Find(numArray, GT10)); //array.find gives the first match. findall gives all matches, findindex will give the index of the first match.


            //String Builders
            //any time you change a string, you make a new string
            //if you use a string builder, though, you actually change the string
            StringBuilder sb = new StringBuilder("Random Text");
            StringBuilder sb2 = new StringBuilder("More stuff is important", 256);

            Console.WriteLine("capacity: {0}", sb.Capacity);
            Console.WriteLine("capacity: {0}", sb2.Capacity);
            Console.WriteLine("length: {0}", sb2.Length);
            sb2.AppendLine("\nmore imprtant shit");
            CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US"); //need system.globalization for this part
            string bestCustomer = "bob";
            sb2.AppendFormat(enUS, "best Customer: {0}", bestCustomer);
            Console.WriteLine(sb2.ToString());
            sb2.Replace("text", "characters");
            Console.WriteLine(sb2.ToString());

            sb2.Clear();
            sb2.Append("random text");
            Console.WriteLine(sb.Equals(sb2));
            sb2.Insert(11, "thats great");
            Console.WriteLine(sb2.ToString());
            sb2.Remove(11, 7); //remove 7 characters starting at character 11

            //casting(fancy word for converting)
            long num1 = 1234;
            int num2 = (int)num1;
        }
        
        static void PrintArray(int[] intArray, string mess)
        {
            foreach (int k in intArray)
            {
                Console.WriteLine("{0}: {1}", mess, k);
            }
        }

        private static bool GT10(int val)
        {
            return val > 10;
        }
    }
}
