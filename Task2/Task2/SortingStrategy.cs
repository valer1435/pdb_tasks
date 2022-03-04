using System;
namespace Sorting
{
	public delegate void SortDelegate(ref int[][] array, bool reverse);
	public class Context
	{
		private SortDelegate sortDelegate;
		public Context(SortDelegate sortDelegate)
		{
			this.sortDelegate = sortDelegate;
		}

		public void Sort(ref int[][] array, bool reverse = false)
		{
			sortDelegate(ref array, reverse);
		}
	}
	public class BaseSortingStrategy
	{
		public void Sort(ref int[][] array, bool reverse)
		{
			for (int i = 0; i < array.GetLength(0); i++)
			{
				for (int j = i; j < array.GetLength(0); j++)
				{
					if ((Compare(array[i], array[j]) == 0) ^ reverse)
					{
						int[] temp = new int[array[j].Length];
						System.Array.Copy(array[j], temp, array[j].Length); // надеюсь, не является нарушением
						System.Array.Copy(array[i], array[j], array[j].Length);
						array[i] = temp;
					}
				}
			}
		}

		private int Compare(int[] array1, int[] array2)
		{
			if (Metric(array1) <= Metric(array2))
				return 1;
			else
				return 0;
		}

		public virtual int Metric(int[] arr) { throw new NotImplementedException("Don't use base class"); }

	}
	public class SumSortingStrategy : BaseSortingStrategy
	{
		public override int Metric(int[] arr)
		{
			int s = 0;
			foreach (int i in arr)
				s = s + i;
			return s;
		}

	}
	public class MaxSortingStrategy : BaseSortingStrategy
	{
		public override int Metric(int[] arr)
		{
			int maxS = int.MinValue;
			foreach (int i in arr)
				if (maxS < i)
				{
					maxS = i;
				}
			return maxS;
		}

	}

	public class MinSortingStrategy : BaseSortingStrategy
	{
		public override int Metric(int[] arr)
		{
			int minS = int.MaxValue;
			foreach (int i in arr)
				if (minS > i)
				{
					minS = i;
				}
			return minS;
		}

	}
}