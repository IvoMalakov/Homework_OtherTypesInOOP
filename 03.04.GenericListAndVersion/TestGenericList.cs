using System;

namespace GenericList
{
    public class TestGenericList
    {
        public static void Main()
        {
            GenericList<int> intList = new GenericList<int>();
            intList.Add(5);
            intList.Add(7);

            Console.WriteLine(intList);

            intList.Insert(6, 1);
            Console.WriteLine(intList);

            intList[0] = 225;
            Console.WriteLine(intList);

            intList.Remove(2);
            Console.WriteLine(intList);

            int elementFindedByIndex = intList.FindIndex(225);
            Console.WriteLine(elementFindedByIndex);

            bool haveValue = intList.Contains(6);
            Console.WriteLine(haveValue);

            Console.WriteLine();
            intList.GetVersion();
        }
    }
}