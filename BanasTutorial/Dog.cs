using System;
using System.Collections.Generic;
using System.Text;

namespace BanasTutorial
{
    class Dog : Animal
    {
        public string Sound2 { get; set; } = "Grrr";
        //public override void MakeSound()
        //{
        //    Console.WriteLine($"{Name} says {Sound} and {Sound2}");
        //}

        //public Dog(string name = "No Name", string sound = "No Sound", string sound2 = "No Sound2")
        //    :base(name,sound)
        //{
        //    Sound2 = sound2;
        //}
    }
}
