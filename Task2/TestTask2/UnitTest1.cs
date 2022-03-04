using NUnit.Framework;
using Sorting;

namespace TestTask2
{
    public class Tests
    {
        int[][] test_arr_1_sorted_sum = {
                            new int[4]{1, 2, 3, 4},
                            new int[4]{5, 6, 7, 121},
                            new int[4]{ 0, 100, 110, 120}
                           };
        int[][] test_arr_1_sorted_sum_reversed = {
                            new int[4]{0, 100, 110, 120},
                            new int[4]{5, 6, 7, 121},
                            new int[4]{ 1, 2, 3, 4}
                           };
        int[][] test_arr_1_sorted_min = {
                            new int[4]{0, 100, 110, 120},
                            new int[4]{1, 2, 3, 4},
                            new int[4]{5, 6, 7, 121}
                           };
        int[][] test_arr_1_sorted_min_reversed = {
                            new int[4]{5, 6, 7, 121},
                            new int[4]{1, 2, 3, 4},
                            new int[4]{0, 100, 110, 120}
                           };
        int[][] test_arr_1_sorted_max = {
                            new int[4]{1, 2, 3, 4},
                            new int[4]{0, 100, 110, 120},
                            new int[4]{5, 6, 7, 121}
                           };
        int[][] test_arr_1_sorted_max_reversed = {
                            new int[4]{5, 6, 7, 121},
                            new int[4]{0, 100, 110, 120},
                            new int[4]{1, 2, 3, 4}
                           };


        public int[][] GetTestArray()
        {
            int[][] arr = {
                            new int[4]{5, 6, 7, 121},
                            new int[4]{1, 2, 3, 4},
                            new int[4]{0, 100, 110, 120}
                           };
            return arr;
        }

        [Test]
        public void TestSumSort()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new SumSortingStrategy().Sort);
            
            context.Sort(ref arr, false);
            Assert.AreEqual(arr, test_arr_1_sorted_sum);
        }

        [Test]
        public void TestSumSortReversed()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new SumSortingStrategy().Sort);

            context.Sort(ref arr, true);
            Assert.AreEqual(arr, test_arr_1_sorted_sum_reversed);
        }

        [Test]
        public void TestMinSort()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new MinSortingStrategy().Sort);

            context.Sort(ref arr, false);
            Assert.AreEqual(arr, test_arr_1_sorted_min);
        }

        [Test]
        public void TestMinSortReversed()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new MinSortingStrategy().Sort);

            context.Sort(ref arr, true);
            Assert.AreEqual(arr, test_arr_1_sorted_min_reversed);
        }

        [Test]
        public void TestMaxSort()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new MaxSortingStrategy().Sort);

            context.Sort(ref arr, false);
            Assert.AreEqual(arr, test_arr_1_sorted_max);
        }

        [Test]
        public void TestMaxSortReversed()
        {
            int[][] arr = GetTestArray();
            Context context = new Context(new MaxSortingStrategy().Sort);

            context.Sort(ref arr, true);
            Assert.AreEqual(arr, test_arr_1_sorted_max_reversed);
        }
        [Test]
        public void TestAlreadySorted()
        {
            foreach (SortDelegate myDelegate in new SortDelegate[3] { new SumSortingStrategy().Sort,
                                                                  new MinSortingStrategy().Sort,
                                                                new MaxSortingStrategy().Sort})
            {
                int[][] arr = {
                            new int[1]{-1},
                            new int[1]{0},
                            new int[1]{2}
                           };
                int[][] true_arr = {
                            new int[1]{-1},
                            new int[1]{0},
                            new int[1]{2}
                           };
                Context context = new Context(new MinSortingStrategy().Sort);
                context.Sort(ref arr, false);
                Assert.AreEqual(arr, true_arr);
            }
        }
            [Test]
            public void TestAlreadySortedReversed()
            {
                foreach (SortDelegate myDelegate in new SortDelegate[3] { new SumSortingStrategy().Sort,
                                                                  new MinSortingStrategy().Sort,
                                                                new MaxSortingStrategy().Sort})
                {
                    int[][] arr = {
                            new int[1]{-1},
                            new int[1]{0},
                            new int[1]{2}
                           };
                    int[][] true_arr = {
                            new int[1]{2},
                            new int[1]{0},
                            new int[1]{-1}
                           };
                    Context context = new Context(new MinSortingStrategy().Sort);
                    context.Sort(ref arr, true);
                    Assert.AreEqual(arr, true_arr);
                }


            }


    }
}