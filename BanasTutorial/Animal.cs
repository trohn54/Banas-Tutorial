using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

//Used for part 5
namespace BanasTutorial
{
    class Animal
    {
        ////PART 5
        //public string name;
        //public string sound;

        //public Animal()
        //{
        //    name = "No Name";
        //    sound = "No Sound";
        //    numOfAnimals++;
        //}

        //public Animal(string name = "No Name")
        //{
        //    this.name = name;
        //    this.sound = "No Sound";
        //    numOfAnimals++;
        //}

        //public Animal(string name = "No Name", string sound = "No Sound")
        //{
        //    this.name = name;
        //    this.sound = sound;
        //    numOfAnimals++;
        //}

        //public void MakeSound()
        //{
        //    Console.WriteLine("{0} says {1}", name, sound);
        //}

        ////a static field has the same value for all objects of the animal type
        //static int numOfAnimals = 0;
        //public static int GetNumAnimals()
        //{
        //    return numOfAnimals;
        //}

        //PART 6
        //protected: can be accessed by subclasses
        //public:user can change things
        //private: just the methods in the field
        private string name;
        private string sound;

        public const string SHELTER = "Tommys animal hut"; //can't be changed anywhere

        //readonlys are consts that can be defined at runtime
        public readonly int idNum;

        public void MakeSound()
        {
            Console.WriteLine("{0} says {1}", name, sound);
        }

        //different way to do constructors
        public Animal() : this("No Sound", "No Sound") { }

        public Animal(string name) : this(name, "No Sound") { }

        public Animal(string name, string sound)
        {
            SetName(name);
            Sound = sound;

            NumOfAnimals = 1;

            Random rnd = new Random();
            idNum = rnd.Next(1, 1234234);
        }

        //setter/mutators protect fields from recieving bad data
        public void SetName(string name)
        {
            if (!name.Any(char.IsDigit)) // .Any is a LINQ thing. this checks if what was passed in is a number
            {
                this.name = name;
            }
            else
            {
                this.name = "No Name";
                Console.WriteLine("Name can't contain numbers.");
            }
        }

        //getter/ accessor provides output aside from the value that is stored
        public string GetName()
        {
            return name;
        }

        //how these are usually done
        public string Sound
        {
            get { return sound; }
            set
            {
                if (value.Length > 10)
                {
                    sound = "No Sound";
                    Console.WriteLine("Sound is too long");
                }
                sound = value;
            }
        }

        public string Owner { get; set; } = "No Owner";
        public static int numOfAnimals = 0;
        public static int NumOfAnimals
        {
            get { return numOfAnimals; }
            set { numOfAnimals += value; }
        }

    }
}
