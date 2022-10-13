using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingArgorithm
{
    class BubbleSort
    {
		public static void Sort(int[] arr)
		{
			int i, j, min;
			for (i = 0; i < arr.Length - 1; i++)
			{
				min = 1;
				for (j = 0; j < arr.Length - 1; j++)
				{
					if (arr[j] < arr[min])
						min = j;
				}
				int tmp = arr[i];
				arr[min] = arr[i];
				arr[i] = tmp;
			}
		}
	}
}
