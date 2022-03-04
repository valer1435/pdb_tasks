using Sorting;
using System;

namespace Task2
{
   
    class Program
    {
        
        static void Main(string[] args)
        {
            int[][] arr = {
                            new int[4]{11,12,13,14},
                            new int[4]{31,32,33,25},
                            new int[4]{21,22,23,24}
                           };
            Console.WriteLine("Массив:");
            PrintArray(arr);
            Console.WriteLine("Выберите порядок сортировки:\n1-По сумме\n2-По максимальному элементу\n3-По минимальному значению");
            char key = Console.ReadKey().KeyChar;
            SortDelegate myDelegate;
            if (key == '1')
                myDelegate = new SumSortingStrategy().Sort;
            else if (key == '2')
                myDelegate = new MaxSortingStrategy().Sort;
            else if (key == '3')
                myDelegate = new MinSortingStrategy().Sort;
            else
                myDelegate = new BaseSortingStrategy().Sort;
            Context context = new Context(myDelegate);
            Console.WriteLine("Выберите вариант сортировки:\n1-По возрастанию\n2-По убыванию");
            key = Console.ReadKey().KeyChar;
            bool isReversed = false;
            if (key == '1')
                isReversed = false;
            else if (key == '2')
                isReversed = true;
            Console.WriteLine("Результат сортировки");
            context.Sort(ref arr, isReversed);
            PrintArray(arr);
        }

        public static void PrintArray(int[][] array)
        {
            foreach (int[] i in array)
            {
                System.Console.Write("[");
                foreach (int j in i)
                {
                    System.Console.Write("{0} ", j);
                }
                System.Console.Write("]\n");
            }
        }
    }
}
