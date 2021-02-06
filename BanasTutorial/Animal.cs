using System;
using System.Collections.Generic;
using System.Text;

//Used for part 5
namespace BanasTutorial
{
    class Animal
    {
        public string name;
        public string sound;

        public Animal()
        {
            name = "No Name";
            sound = "No Sound";
            numOfAnimals++;
        }

        public Animal(string name = "No Name")
        {
            this.name = name;
            this.sound = "No Sound";
            numOfAnimals++;
        }

        public Animal(string name = "No Name", string sound = "No Sound")
        {
            this.name = name;
            this.sound = sound;
            numOfAnimals++;
        }

        public void MakeSound()
        {
            Console.WriteLine("{0} says {1}", name, sound);
        }

        //a static field has the same value for all objects of the animal type
        static int numOfAnimals = 0;
        public static int GetNumAnimals()
        {
            return numOfAnimals;
        }
    }
}
