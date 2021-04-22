using System;

namespace MyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 3, 2, 3, 1, 2, 4, 5, 5, 6 };
            new AgorithmExample().BubbleSort(nums, SortType.ASC);
            Console.ReadLine();
        }
    }
}
