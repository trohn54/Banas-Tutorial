using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BanasTutorial
{
    class AnimalFarm : IEnumerable
    {
        private List<Animal> animalList = new List<Animal>();

        public AnimalFarm(List<Animal> animalList)
        {
            this.animalList = animalList;
        }

        public AnimalFarm()
        {

        }

        public Animal this[int index] //what happens whenever we call for individual pieces of this collection
        {
            get { return animalList[index]; }
            set { animalList.Insert(index, value); }
        }

        public int Count
        {
        get { return animalList.Count; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return animalList.GetEnumerator();
        }
    }
}
