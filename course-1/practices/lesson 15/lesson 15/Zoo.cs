using System;
using System.Collections.Generic;
using System.Text;

namespace lesson_15
{
    public class Zoo
    {
        private Animal[] _animal;
        private int _count = 0;

        public Zoo(int capacity)
        {
            if (capacity <= 0) capacity = 1;
            _animal = new Animal[capacity];

        }

        public bool Add(Animal animal)
        {
            if (_count >= _animal.Length) return false;
            _animals[_count++] = animal;
            return true;
        }

        public void MakeAllSounds()
        {
            foreach (var a in _animals)
            {
                a.MakeAllSounds();
            }
        }
    }
}
