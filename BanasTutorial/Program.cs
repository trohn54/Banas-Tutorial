using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Numerics;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace BanasTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            Part18(args);
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
            Console.WriteLine("customer name: {0}", custNames.GetValue(1, 1));

            for (int i = 0; i < custNames.GetLength(0); i++)
            {
                for (int j = 0; j < custNames.GetLength(1); j++)
                {
                    Console.Write(custNames[i, j]);
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

            foreach (int m in anothArray)
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


        private static void Part3(string[] args)
        {
            //Relation Operations: < > >= <= == !=
            //Logical Operations: && || ! 
            int age = 17;
            if ((age >= 5) && (age <= 7))
            {
                Console.WriteLine("elementary school");
            }
            else if ((age >= 7) && (age <= 13))
            {
                Console.WriteLine("middle school");
            }
            else if ((age >= 13) && (age <= 19))
            {
                Console.WriteLine("high school");
            }
            else
            {
                Console.WriteLine("go to college");
            }

            if ((age < 14) || (age < 19))
            {
                Console.WriteLine("you shouldn't work");
            }

            bool canDrive = age >= 16 ? true : false;

            switch (age) //in other languages, you can use ranges in switch statements. in C#, you need to stack.
            {
                case 1:
                case 2:
                    Console.WriteLine("go to daycare");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("go to preschool");
                    break;

                case 5:
                    Console.WriteLine("go to kindergarten.");
                    break;
                default:
                    Console.WriteLine("Go to another school");
                    //goto OtherSchool; //evil und verboten
                    break;
            }

            //OtherSchool:
            //    Console.WriteLine("aaaaaah where am i");

            //    string name = "Derek";
            //    string name2 = "Derek";

            //    if (name.Equals(name2, StringComparison.Ordinal)) //
            //    {
            //        Console.WriteLine("same names");
            //    }
            //}

            int i = 1;

            while (i <= 10)
            {
                if (i % 2 == 0)
                {
                    i++;
                    continue;
                }

                if (i == 9)
                {
                    break;

                }
                i++;
            }

            Random rnd = new Random();
            int secretNumber = rnd.Next(1, 11);
            int numberGuessed = 0;
            do
            {
                Console.Write("pick a # between 1 and 10: ");
                numberGuessed = Convert.ToInt32(Console.ReadLine());
            } while (secretNumber != numberGuessed);

            //other convert options: ToBoolean, ToByte, ToChar, ToDecimal, ToDouble, ToInt64, ToString
            //They can convert from any type into any other type

            //ExceptionHandling
            double num1 = 5;
            double num2 = 0;

            try
            {
                Console.WriteLine("5/0= {0}", DoDivision(num1, num2));
            }
            catch (DivideByZeroException ex) //if u just type "exception" instead of "divide by zero exception", you'll catch everything.
            {
                Console.WriteLine("You cant do that");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error occured");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Cleaning Up");
            }

        }
        static double DoDivision(double x, double y)
        {
            if (y == 0)
            {
                throw new System.DivideByZeroException();
            }
            return x / y;
        }


        private static void Part4(string[] args)
        {
            double x = 5;
            double y = 4;

            Console.WriteLine("5+5 = {0}", GetSum(x, y));
            Console.WriteLine(); //proves x didn't change in the function, and was passed by value

            int solution;

            DoubleIt(15, out solution); //works with values putside the method itself, and defines the value of a variable inside the method

            Console.WriteLine("15*2 = {0}", solution);

            int num1 = 10;
            int num2 = 20;

            Console.WriteLine("Before swap num1: {0} num2: {1}", num1, num2);
            Swap(ref num1, ref num2);
            Console.WriteLine("After swap num1: {0} num2: {1}", num1, num2);

            Console.WriteLine("1+2+3 = {0}", GetSumMore(1, 2, 3));

            //named parameters
            PrintInfo(zipCode: 60053, name: "Tommy");

            //overloads
            Console.WriteLine("5.0 + 4.5 = {0}", GetSum(5.0, 4.5));
            Console.WriteLine("5+4 = {0}", GetSum(5, 4));
            Console.WriteLine("5+4 = {0}", GetSum("5", "4")); //parameters have to be different to have an overloaded method

            //enums
            carColor cc = carColor.Blue;
            PaintCar(cc);
        }
        static void DoubleIt(int x, out int solution)
        {
            solution = x * 2;
        }
        static double GetSum(double x = 1, double y = 1)
        {
            //double temp = x;
            //x = y;
            //y = temp;
            return x + y;
        }
        static double GetSum(string x = "x", string y = "1")
        {
            double dblX = Convert.ToDouble(x);
            double dblY = Convert.ToDouble(y);
            return dblX + dblY;
        }
        public static void Swap(ref int num1, ref int num2)
        {
            int temp = num1;
            num1 = num2;
            num2 = temp;
        }
        static double GetSumMore(params double[] nums)
        {
            double sum = 0;
            foreach (int i in nums)
            {
                sum += i;
            }
            return sum;
        }
        static void PrintInfo(string name, int zipCode)
        {
            Console.WriteLine("{0} lives in the zip code {1}", name, zipCode);
        }
        enum carColor : byte
        {
            Orange = 1,
            Blue,
            Green,
            Red,
            Yellow
        }
        static void PaintCar(carColor carColor)
        {
            Console.WriteLine("The car was painted {0} with the code {1}", carColor, (int)carColor);
        }
        private static void Part5(string[] args)
        {

            ////Structs
            //Rectangle rect1;
            //rect1.length = 200;
            //rect1.width = 50;
            //Console.WriteLine("Area of rect1: {0}", rect1.Area());
            //Rectangle rect2 = new Rectangle(75, 100);
            //rect2 = rect1;
            //rect1.length = 33;  //proves its not a reference, but a value
            //Console.WriteLine("rect2.length: {0}", rect2.length);

            ////OOP classes are structs that can be inherited from
            //Animal Fox = new Animal() { sound = "papapapapapow", name = "Fox" };
            //Console.WriteLine("# of animals: {0}", Animal.GetNumAnimals());
            //Fox.MakeSound();

            ////Static Classes
            //Console.WriteLine("Area of Rectangle: {0}", ShapeMath.GetArea("rectangle", 5,6));

            ////nullable types
            //int? randNum = null;
            //if(randNum == null)
            //{
            //    Console.WriteLine("randNum is Null");
            //}
            //if(!randNum.HasValue)
            //{
            //    Console.WriteLine("randNum is Null");
            //}

        } //Continued in ShapeMath and Animal
        //struct Rectangle
        //{
        //    public double length;
        //    public double width;

        //    public Rectangle(double l = 1, double w = 1)
        //    {
        //        length = l;
        //        width = w;
        //    }

        //    public double Area()
        //    {
        //        return length * width;
        //    }
        //}
        private static void Part6(string[] args)
        {
            //Animal cat = new Animal();

            //cat.SetName("Whiskers");
            //cat.Sound = "Meow";

            //Console.WriteLine("the cat is named {0} and says {1}", cat.GetName(), cat.Sound);

            //cat.Owner = "Derek";
            //Console.WriteLine("{0} owner is {1}", cat.GetName(), cat.Owner);
            //Console.WriteLine("{0} shelter id is {1}", cat.GetName(), cat.idNum);

            //Animal fox = new Animal("Oscar", "Papapapapapow");

            //Console.WriteLine("# of animals : {0}", Animal.numOfAnimals);
        } //Continued in Animal


        private static void Part7(string[] args)
        {
            //Animal whiskers = new Animal()
            //{
            //    Name = "Whiskers",
            //    Sound = "Prrrr"
            //};
            //Dog snickers = new Dog()
            //{
            //    Name = "Snickers",
            //    Sound = "grrr",
            //    Sound2 = "Aroooo"
            //};

            //snickers.Sound = "Woof";
            //whiskers.MakeSound();
            //snickers.MakeSound();

            //whiskers.SetAnimalIDInfo(12345, "Bobby Brown");
            //snickers.SetAnimalIDInfo(545454, "Tommy Rohn");

            //whiskers.GetAnimalIDInfo();
            //snickers.GetAnimalIDInfo();

            //Animal.AnimalHealth getHealth = new Animal.AnimalHealth();

            //Console.WriteLine("My animal is healthy: {0}", getHealth.HealthyWeight(11, 46));
            //Console.WriteLine("My animal is healthy: {0}", getHealth.HealthyWeight(11, 146));

            //Animal monke = new Animal()
            //{
            //    Name = "happy",
            //    Sound = "eee"
            //};

            //Animal spot = new Dog()
            //{
            //    Name = "Spot",
            //    Sound = "ruf",
            //    Sound2 = "grrr"
            //};

            //monke.MakeSound();
            //spot.MakeSound(); //

        } //Continued in Animal and Dog

        private static void Part8(string[] args)
        {
            Warrior maximus = new Warrior("Maximus", 1000, 120, 40);
            Warrior bob = new Warrior("Bob", 1000, 120, 40);

            Battle.StartFight(maximus, bob);
        } //continued in Battle and Warrior

        private static void Part9(string[] args)
        {
            Shape[] shapes = { new Circle(5), new Rectangle(4, 5) };

            foreach (Shape s in shapes)
            {
                s.GetInfo();
                Console.WriteLine("{0} area: {1:f2}", s.Name, s.Area());

                Circle testCircle = s as Circle;
                if (testCircle == null)
                {
                    Console.WriteLine("This isn't a circle");
                }

                if (s is Circle)
                {
                    Console.WriteLine("This isn't a rectangle");
                }

                Console.WriteLine();

                object circ1 = new Circle(4);
                Circle circ2 = (Circle)circ1;

                Console.WriteLine("The {0} area is {1:f2}", circ2.Name, circ2.Area());
            }
        }

        private static void Part10(string[] args)
        {
            Vehicle buick = new Vehicle("Buick", 4, 65);

            if (buick is IDrivable)
            {
                buick.Move();
                buick.Stop();
            }
            else
            {
                Console.WriteLine("Not Drivable");
            }

            IElectronicDevice TV = TVRemote.GetDevice();
            PowerButton powerButton = new PowerButton(TV);
            powerButton.Execute();
            powerButton.Undo();
        }

        private static void Part11(string[] args)
        {
            #region ArrayList Code

            ArrayList aList = new ArrayList();
            aList.Add("Bob");
            aList.Add(40);

            Console.WriteLine("Count: {0}", aList.Count);

            Console.WriteLine("Count: {0}", aList.Capacity);

            ArrayList aList2 = new ArrayList();

            aList.AddRange(new object[] { "Mike", "Sally", "egg" });

            aList.AddRange(aList2);

            aList2.Sort();

            //aList2.Reverse();
            //aList2.Insert(1, "June");

            ArrayList range = aList.GetRange(0, 2);

            foreach (object o in range)
            {
                Console.WriteLine(o);
            }

            //aList.RemoveAt(0);
            //aList.RemoveRange(0, 1);

            Console.WriteLine($"Turkey Index: {aList2.IndexOf("Turkey", 0)}");

            string[] myArray = (string[])aList2.ToArray(typeof(string)); //convert arraylist into an array

            string[] customers = { "Bob", "Sally", "Sue" }; //convert an array into an arraylist
            ArrayList custArrayList = new ArrayList();
            custArrayList.AddRange(customers);

            foreach (string s in custArrayList)
            {
                Console.WriteLine(s);
            }
            #endregion
            #region Dictionaries
            Dictionary<string, string> superheroes = new Dictionary<string, string>();

            superheroes.Add("Clark Kent", "Superman");
            superheroes.Add("Bruce Wayne", "Batman");
            superheroes.Add("Barry Allen", "The Flash");

            superheroes.Remove("Barry West");
            Console.WriteLine($"Count: {superheroes.Count}");
            Console.WriteLine($"Clark Kent: {superheroes.ContainsKey("Clark Kent")}");

            superheroes.TryGetValue("Clark Kent", out string test);
            Console.WriteLine($"Clark Kent: {test}");

            foreach (KeyValuePair<string, string> item in superheroes)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }

            superheroes.Clear();
            #endregion
            #region Queue
            Queue queue = new Queue();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine("1 in Queue: {0}", queue.Contains(1));
            Console.WriteLine("Remove 1: {0}", queue.Dequeue());
            Console.WriteLine("Peek 2: {0}", queue.Peek());

            object[] numArray = queue.ToArray();

            Console.WriteLine(string.Join(", ", numArray));

            //queue.Clear();

            foreach (object o in queue)
            {
                Console.WriteLine($"Queue: {o}");
            }
            #endregion
            #region Stack
            Stack stack = new Stack();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Peek 1: {stack.Peek()}");

            Console.WriteLine($"Pop 1: {0}", stack.Pop());

            Console.WriteLine("contains 1: {0}", stack.Contains(1));

            object[] numArray2 = stack.ToArray();

            Console.WriteLine(string.Join(", ", numArray2));

            //stack.Clear();

            foreach (object o in stack)
            {
                Console.WriteLine($"Stack: {o}");
            }
            #endregion
        }

        private static void Part12(string[] args) //continued in Animal
        {
            //List<Animal> animalList = new List<Animal>();

            ////List<int> numberList = new List<int>();
            ////numberList.Add(24);

            //animalList.Add(new Animal() { Name = "Doug" });
            //animalList.Add(new Animal() { Name = "Paul" });
            //animalList.Add(new Animal() { Name = "Sally" });

            //animalList.Insert(1, new Animal() { Name = "Steve" });
            //animalList.RemoveAt(1);
            //Console.WriteLine("Num of amimals: {0}", animalList.Count);

            //foreach (Animal a in animalList)
            //{
            //    Console.WriteLine(a.Name);
            //}

            //// Stack<T>, Queue<T>, Dictonary<TKey, TValue> //putting a T instead of a specific value allows us to manipulate the data still, but are treated generically

            //int x = 5, y = 4;
            //Animal.GetSum(ref x, ref y);
            //string strX = "5", strY = "4";
            //Animal.GetSum(ref strX, ref strY);

            //Rectangle<int> rec1 = new Rectangle<int>(20, 50);
            //Console.WriteLine(rec1.GetArea());

            //Rectangle<float> rec2 = new Rectangle<float>(20f, 50f);
            //Console.WriteLine(rec1.GetArea());

            //Arithmetic add, sub, addSub;

            //add = new Arithmetic(Add);
            //sub = new Arithmetic(Subtract);
            //addSub = add + sub;
            //sub = addSub - add;

            //Console.WriteLine($"Add 6& 10");
            //add(6, 10);
            //Console.WriteLine($"Add & subtract 10 & 4");
            //addSub(10, 4);
        }
        public struct Rectangle<T>
        {
            private T width;
            private T length;

            public T Width { get { return width; } set { width = value; } }
            public T Length { get { return length; } set { length = value; } }

            public Rectangle(T w, T l)
            {
                width = w;
                length = l;
            }

            public string GetArea()
            {
                double dblWidth = Convert.ToDouble(Width);
                double dblLength = Convert.ToDouble(Length);
                return string.Format($"{dblWidth} * {dblLength} = {dblLength * dblWidth}");
            }
        }
        public delegate void Arithmetic(double num1, double num2);
        public static void Add(double num1, double num2)
        {
            Console.WriteLine($"{num1} + {num2} = {num2 + num1}");
        }
        public static void Subtract(double num1, double num2)
        {
            Console.WriteLine($"{num1} - {num2} = {num2 - num1}");
        }

        private static void Part13(string[] args)
        {
            #region Lambdas
            //lambdas let you use anonymous methods that define the input parameters on the left and the code to execute on the right
            doubleIt dblIt = x => x * 2;
            Console.WriteLine($"5 * 2 = {dblIt(5)}");

            List<int> numList = new List<int>() { 1, 2, 3, 4 };

            var evenList = numList.Where(a => a % 2 == 0).ToList();

            foreach (var j in evenList)
            {
                Console.WriteLine(j);
            }

            var rangeList = numList.Where(x => (x > 2) && (x < 9));
            foreach (var j in rangeList)
            {
                Console.WriteLine(j);
            }

            List<int> flipList = new List<int>();

            int i = 0;
            Random rnd = new Random();
            while (i < 100)
            {
                flipList.Add(rnd.Next(1, 3));
                i++;
            }

            Console.WriteLine("Heads: {0}", flipList.Where(a => a == 1).ToList().Count());

            var nameList = new List<string> { "Bob", "Bobert" };

            var sNameList = nameList.Where(x => x.StartsWith("B"));

            foreach (var m in sNameList)
            {
                Console.WriteLine(m);
            }
            #endregion

            #region select
            //select allows us to execute a function on each item in a list
            var oneToTen = new List<int>();
            oneToTen.AddRange(Enumerable.Range(1, 10)); //sets limits on the list

            var squares = oneToTen.Select(x => x * x); //puts all of oneToTen into squares once modified by the function

            foreach (var l in squares)
            {
                Console.WriteLine(l);
            }
            #endregion

            #region Zip
            //add values from both lists together
            var listOne = new List<int>(new int[] { 1, 3, 4 });
            var listTwo = new List<int>(new int[] { 4, 6, 8 });

            var sumList = listOne.Zip(listTwo, (x, y) => x + y).ToList();

            foreach (var n in sumList)
            {
                Console.WriteLine(n);
            }
            #endregion

            #region aggregate
            //performs operation on each value of a list and then carries those results forward
            var numList2 = new List<int>() { 1, 2, 3, 4, 5 };

            Console.WriteLine("sum: {0}", numList2.Aggregate((a, b) => a + b));
            #endregion

            #region average
            var numList3 = new List<int>() { 1, 2, 3, 4, 5, 3 };

            Console.WriteLine("Avg: {0}", numList3.AsQueryable().Average());
            #endregion

            #region all, any, distinct, accept
            Console.WriteLine("all values greater than three: {0}", numList3.All(x => x > 3));
            Console.WriteLine("any values greater than three: {0}", numList3.Any(x => x > 3));
            Console.WriteLine("Distinct: {0}", string.Join(", ", numList3.Distinct())); //in first list
            Console.WriteLine("Except: {0}", string.Join(", ", numList3.Except(numList2))); //not in second list
            Console.WriteLine("Except: {0}", string.Join(", ", numList3.Intersect(numList2))); //in both lists
            #endregion
        }
        delegate double doubleIt(double val);

        private static void Part14(string[] args)
        {
            AnimalFarm myAnimals = new AnimalFarm();
            myAnimals[0] = new Animal("Silbur");
            myAnimals[1] = new Animal("bobert");
            myAnimals[2] = new Animal("danice");

            //foreach (Animal i in myAnimals)
            //{
            //    Console.WriteLine(i.name);
            //}

            Box box1 = new Box(2, 3, 4);
            Box box2 = new Box(4, 5, 4);
            Box box3 = box1 + box2;
            Console.WriteLine(box3);
            Console.WriteLine((int)box3);

            Box box4 = (Box)4;

            Console.WriteLine(box4);

            //anonymous type
            var shopkins = new { Name = "Shopkins", Price = 4.99 };

            Console.WriteLine("{0} costs {1}", shopkins.Name, shopkins.Price);

            var toyArray = new[]
            {
                new { Name = "Football", Price = 9.99 },
                new { Name = "doll", Price = 12.99 }
            };

            foreach (var item in toyArray)
            {
                Console.WriteLine($"{item.Name} costs {item.Price}");
            }
        } //continued in animal and box

        private static void Part15(string[] args) //Continued in Owner and Animal
        {
            QueryStringArray();
            QueryIntArray();
            QueryArrayList();
            QueryCollection();
            QueryAnimalData();
        }
        static void QueryStringArray()
        {
            string[] doggos = { "k 9", "Brian Griffin", "Scooby Doo", "Old Yeller", "Rin Tin Tin", "Benji", "Charlie B. Barkin", "Lassie", "Snoopy" };

            //Query example
            var dogSpaces = from dog in doggos          //from just tells us where the info will be coming from
                            where dog.Contains(" ")     //The Condition
                            orderby dog descending      //Define what data is used(in regards to how we are going to order the data)
                            select dog;                 //Define variable that is checked against this condition
            //LINQ stands for Language INtegrated Query

            foreach (var i in dogSpaces)
            {
                Console.WriteLine(i + "\n");
            }
        }
        static int[] QueryIntArray()
        {
            int[] nums = { 5, 10, 15, 20, 25, 30, 35 };
            var get20 = from num in nums
                        where num > 20
                        orderby num
                        select num;

            foreach (var i in get20)
            {
                Console.WriteLine(i + "\n");
            }

            Console.WriteLine($"Get Type: { get20.GetType() }");

            var listGT20 = get20.ToList<int>();
            var arrayGT20 = get20.ToArray();

            nums[0] = 40;

            foreach (var i in get20)
            {
                Console.WriteLine(i + "\n");
            }
            return arrayGT20;
        }
        static void QueryArrayList()
        {
            ArrayList famAnimals = new ArrayList()
            {
                 new Animal
                 {
                     Name = "Heidi",
                     Height = .8,
                     Weight = 18
                 },

                new Animal
                {
                    Name = "Shrek",
                    Height = 4,
                    Weight = 130
                },

                new Animal
                {
                    Name = "Congo",
                    Height = 3.8,
                    Weight = 90
                }
            };

            var famAnimalEnum = famAnimals.OfType<Animal>();
            var smAnimals = from animal in famAnimalEnum
                            where animal.Weight <= 90
                            orderby animal.Name
                            select animal;

            foreach (Animal a in smAnimals)
            {
                Console.WriteLine("{0} weighs {1}\n", a.Name, a.Weight);
            }
        }
        static void QueryCollection()
        {
            var animalList = new List<Animal>()
            {
                new Animal{Name = "German Shepherd",
                Height = 25,
                Weight = 77},
                new Animal{Name = "Chihuahua",
                Height = 7,
                Weight = 4.4},
                new Animal{Name = "Saint Bernard",
                Height = 30,
                Weight = 200}
            };

            var bigDogs = from a in animalList
                          where (a.Weight > 70) && (a.Height > 25)
                          orderby a.Name
                          select a;

            foreach (var dog in bigDogs)
            {
                Console.WriteLine("{0} weighs {1}\n", dog.Name, dog.Weight);
            }            
        }
        static void QueryAnimalData()
        {
            Animal[] animals = new[]
            {
                new Animal{Name = "German Shepherd",
                Height = 25,
                Weight = 77,
                AnimalID = 1},
                new Animal{Name = "Chihuahua",
                Height = 7,
                Weight = 4.4,
                AnimalID = 2},
                new Animal{Name = "Saint Bernard",
                Height = 30,
                Weight = 200,
                AnimalID = 3},
                new Animal{Name = "Pug",
                Height = 12,
                Weight = 16,
                AnimalID = 1},
                new Animal{Name = "Beagle",
                Height = 15,
                Weight = 23,
                AnimalID = 2}
            };

            Owner[] owners = new[]
            {
                new Owner{Name = "Doug Parks",
                OwnerID = 1},
                new Owner{Name = "Sally Smith",
                OwnerID = 2},
                new Owner{Name = "Paul Brooks",
                OwnerID = 3}
            };

            //pull data out, make brand new collection
            var nameHeight = from a in animals
                             select new
                             { 
                             a.Name, a.Height
                             };

            Array arrNameHeight = nameHeight.ToArray();

            foreach(var a in arrNameHeight)
            {
                Console.WriteLine(a.ToString());
            }

            //inner join: join info using equal values. stores values
            var innerJoin = from a in animals
                            join owner in owners on a.AnimalID equals owner.OwnerID
                            select new 
                            { 
                                OwnerName = owner.Name, 
                                AnimalName = a.Name 
                            };

            foreach(var i in innerJoin)
            {
                Console.WriteLine("{0} owns {1}\n", i.OwnerName, i.AnimalName);
            }

            //Group join
            var groupJoin = from owner in owners
                            orderby owner.OwnerID
                            join animal in animals
                            on owner.OwnerID
                            equals animal.AnimalID
                            into ownerGroup
                            select new
                            {
                                Owner = owner.Name,
                                Animals = from owner2 in ownerGroup
                                          orderby owner2.Name
                                          select owner2
                            }; //One of the most complicated queries you're ever gonna see but what it does is gonna be really, really cool

            int totalAnimals;
            foreach(var ownerGroup in groupJoin)
            {
                Console.WriteLine(ownerGroup.Owner);
                foreach(var a in ownerGroup.Animals)
                {
                    Console.WriteLine("* {0}", a.Name);
                }
            }
        }

        private static void Part16(string[] args)
        {
            //Threading allows you to execute multiple pieces of code that can share resources and data without you corrupting it
            //you must lock resources until a thread is done, or your data may become corrupted
            //finally, you have no guarantee when the thread executes
            #region one thread
            //Thread t = new Thread(Print1);
            //t.Start();
            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.Write(0);
            //}
            #endregion
            #region sleep
            //int num = 1;
            //for(int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine(num);
            //    Thread.Sleep(1000);
            //    num++;
            //}
            //Console.WriteLine("Thread ends");
            #endregion
            #region lock
            //BankAcct acct = new BankAcct(10);
            //Thread[] threads = new Thread[15];
            //Thread.CurrentThread.Name = "main";
            //for(int i = 0; i < 15;i++)
            //{
            //    Thread t = new Thread(new ThreadStart(acct.IssueWithdraw));
            //    t.Name = i.ToString();
            //    threads[i] = t;
            //}

            //for (int i = 0; i < 15; i++)
            //{
            //    Console.WriteLine("Thread {0} alive: {1}", threads[i].Name, threads[i].IsAlive);
            //    threads[i].Start();
            //    Console.WriteLine("Thread {0} alive: {1}", threads[i].Name, threads[i].IsAlive);

            //}

            //Console.WriteLine("Current Priority: {0}", Thread.CurrentThread.Priority); //Playing around w priority is D A N G E R O U S
            //Console.WriteLine("Thread {0} ending", Thread.CurrentThread.Name);
            #endregion
            #region passing data to threads
            Thread t = new Thread(() => CountTo(10));
            t.Start();
            //multiline
            new Thread(() =>
            {
                CountTo(5);
                CountTo(6);
            }).Start();

            #endregion
        }
        static void Print1()
        {
            for(int i = 0; i < 1000; i++)
            {
                Console.Write(1);
            }
        }
        static void CountTo(int maxNum)
        {
            for (int i = 0; i < maxNum; i++)
            {
                Console.WriteLine(i); 
            }
        }

        private static void Part17(string[] args)
        {
            #region directories
            DirectoryInfo currDirectory = new DirectoryInfo("."); //current directory
            DirectoryInfo dereksDir = new DirectoryInfo(@"C:\Users\toejo"); //different directory
            Console.WriteLine(dereksDir.FullName);
            Console.WriteLine(dereksDir.Name);
            Console.WriteLine(dereksDir.Parent);
            Console.WriteLine(dereksDir.Attributes);
            Console.WriteLine(dereksDir.CreationTime);

            DirectoryInfo dataDir = new DirectoryInfo(@"C:\Users\toejo\c#data"); //create a directory
            //Directory.Delete(@"C:\Users\toejo\c#data");
            string[] customers =
            {
                "Bob Smith", "Sally Smith", "Robert Smith"
            };

            string textFilePath = @"C:\Users\toejo\c#data\testfile1.txt";

            File.WriteAllLines(textFilePath, customers);

            foreach(string cust in File.ReadAllLines(textFilePath))
            {
                Console.WriteLine(cust);
            }

            DirectoryInfo myDataDir = new DirectoryInfo(@"C:\Users\toejo\c#data");
            FileInfo[] textFiles = myDataDir.GetFiles("*.txt", SearchOption.AllDirectories);

            Console.WriteLine("Matches {0}", textFiles.Length);
            foreach(FileInfo file in textFiles)
            {
                Console.WriteLine(file.Name);
                Console.WriteLine(file.Length);
            }
            #endregion
            #region filestream
            //for reading and writing bytes
            string textFilePath2 = @"C:\Users\toejo\c#data\testfile2.txt";

            FileStream fs = File.Open(textFilePath2, FileMode.Create);
            string randString = "This is a random string";
            byte[] rsByteArray = Encoding.Default.GetBytes(randString);

            fs.Write(rsByteArray, 0, rsByteArray.Length);
            fs.Position = 0;
            byte[] fileByteArray = new byte[rsByteArray.Length];
            for(int i = 0; i < rsByteArray.Length; i++)
            {
                fileByteArray[i] = (byte)fs.ReadByte();
            }
            Console.WriteLine(Encoding.Default.GetString(fileByteArray));
            fs.Close();
            #endregion
            #region streamWriter/streamReader
            string textFilePath3 = @"C:\Users\toejo\c#data\testfile3.txt";
            StreamWriter sw = File.CreateText(textFilePath3);
            sw.Write("This is a random ");
            sw.WriteLine("sentence");
            sw.WriteLine("and another sentence");

            sw.Close();
            StreamReader sr = File.OpenText(textFilePath3);
            Console.WriteLine("Peek : {0}", Convert.ToChar(sr.Peek())); //return value but it stays at the start of the file
            Console.WriteLine("1st string : {0}", Convert.ToChar(sr.ReadLine()));
            Console.WriteLine("Everything: {0}", sr.ReadToEnd());
            sr.Close();
            #endregion
            #region binaryWriter/binaryReader
            //read and write data types
            string textFilePath4 = @"C:\Users\toejo\c#data\testfile4.dat";
            FileInfo datFile = new FileInfo(textFilePath4);
            BinaryWriter bw = new BinaryWriter(datFile.OpenWrite());
            string randText = "Random Text";
            int myAge = 23;
            double height = 6.25;
            bw.Write(randText);
            bw.Write(myAge);
            bw.Write(height);
            bw.Close();
            BinaryReader br = new BinaryReader(datFile.OpenRead());
            Console.WriteLine(br.ReadString());
            Console.WriteLine(br.ReadInt32());
            Console.WriteLine(br.ReadDouble());
            br.Close();
            #endregion
        }

        private static void Part18(string[] args)
        {
            #region regular serialization
            Animal bowser = new Animal("Bowser", 54, 25);
            Stream stream = File.Open("AnimalData.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, bowser);
            stream.Close();
            bowser = null;
            stream = File.Open("AnimalData.dat", FileMode.Open);
            bf = new BinaryFormatter();
            bowser = (Animal)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine(bowser.ToString());

            bowser.Weight = 30;
            //With XML
            XmlSerializer serializer = new XmlSerializer(typeof(Animal));
            using (TextWriter tw = new StreamWriter(@"C:\Users\toejo\c#data\bowser.xml"))
            {
                serializer.Serialize(tw, bowser);
            }

            bowser = null;

            XmlSerializer deserializer = new XmlSerializer(typeof(Animal));
            TextReader reader = new StreamReader(@"C:\Users\toejo\c#data\bowser.xml");
            object obj = deserializer.Deserialize(reader);
            bowser = (Animal)obj;
            reader.Close();

            Console.WriteLine(bowser.ToString());
            #endregion
            #region serializing collections
            List<Animal> theAnimals = new List<Animal>
            {
                new Animal("Mario", 60, 30),
                new Animal("Luigi", 50, 40),
                new Animal("Toad", 40, 15),
                new Animal("Peach", 40, 35)
            };

            using(Stream fs = new FileStream(@"C:\Users\toejo\c#data\animals.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                XmlSerializer serializer2 = new XmlSerializer(typeof(List<Animal>));
                serializer2.Serialize(fs, theAnimals);
            }
            theAnimals = null;
            XmlSerializer serializer3 = new XmlSerializer(typeof(List<Animal>));
            using(FileStream fs2 = File.OpenRead(@"C:\Users\toejo\c#data\animals.xml"))
            {
                theAnimals = (List<Animal>)serializer3.Deserialize(fs2);
            }

            foreach(Animal a in theAnimals)
            {
                Console.WriteLine(a.ToString());
            }
            #endregion
        }
    }

    class BankAcct
    {
        private object acctLock = new object();
        double balance { get; set; }
        public BankAcct(double bal)
        {
            balance = bal;
        }
        public double Withdraw(double amt)
        {
            if((balance - amt) < 0)
            {
                Console.WriteLine("Sorry, {0} in account.", balance);
            }

            lock(acctLock)
            {
                if(balance >= amt)
                {
                    Console.WriteLine("Removed {0}: {1} in account", amt, balance - amt);
                    balance -= amt;
                }
                return balance;
            }

        }
        //by default, you can only point to methods without arguments and methods that return nothing/void. heres how u do it
        public void IssueWithdraw()
        {
            Withdraw(1);
        }
    }
}