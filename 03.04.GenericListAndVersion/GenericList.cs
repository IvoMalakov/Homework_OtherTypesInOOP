using System;
using System.Linq;
using GenericListVersion;

namespace GenericList
{
    [VersionAttribute(3, 11)]

    public class GenericList<T> where T : IComparable<T>
    {
        private const int defaultCapacity = 16;

        private T[] elements;
        private int currentIndex;
        private int count;

        public GenericList(int capacity = defaultCapacity)
        {
            this.elements = new T[capacity];
            this.currentIndex = 0;
            this.count = 0;
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(T element)
        {
            if (this.currentIndex >= this.elements.Length)
            {
                this.Resize();
            }

            this.elements[this.currentIndex] = element;
            currentIndex++;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (this.Count == 0)
                {
                    throw new InvalidOperationException("Invalid operation! Your list is empty.");
                }

                if (index < 0 || index >= this.Count)
                {
                    throw new IndexOutOfRangeException("Error! Invalid index");
                }

                return this.elements[index];
            }

            set { this.elements[index] = value; }
        }

        public void Remove(int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation! Your list is empty.");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Error! Invalid index");
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.count--;
        }

        public void Insert(T element, int index)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation! Your list is empty.");
            }

            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException("Error! Invalid index");
            }

            if (this.Count >= this.elements.Length)
            {
                this.Resize();
            }

            for (int i = this.Count; i >= index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.elements[index] = element;
            this.count++;
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.elements[i] = default(T);
            }

            this.count = 0;
        }

        public int FindIndex(T element)
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation! Your list is empty.");
            }

            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T Min()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation! Your list is empty.");
            }

            T min = this.elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(min) <= 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Invalid operation! Your list is empty.");
            }

            T max = this.elements[0];

            for (int i = 1; i < this.Count; i++)
            {
                if (this.elements[i].CompareTo(max) >= 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            var resultElements = this.elements.Take(this.Count);

            return String.Join(", ", resultElements);
        }

        private void Resize()
        {
            T[] newElemets = new T[this.elements.Length * 2];

            for (int i = 0; i < this.elements.Length; i++)
            {
                newElemets[i] = this.elements[i];
            }

            this.elements = newElemets;
        }

        public void GetVersion()
        {
            Type type = typeof(GenericList<T>);
            object[] allAtributes = type.GetCustomAttributes(false);

            foreach (object atribute in allAtributes)
            {
                if (atribute is VersionAttribute)
                {
                    VersionAttribute v = atribute as VersionAttribute;
                    Console.WriteLine("This program is version {0}.{1}", v.Major, v.Minor);
                }
            }
        }
    }
}