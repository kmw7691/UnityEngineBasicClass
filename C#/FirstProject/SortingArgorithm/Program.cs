using System;

namespace SortingArgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 5, 2, 3, 7, 1, 10, 4, 6, 9, 8 };
            //BubbleSort.Sort(array);
            HeapSort.Sort(array);

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
