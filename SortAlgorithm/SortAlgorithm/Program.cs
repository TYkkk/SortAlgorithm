using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SortAlgorithm
{
    class Program
    {
        public static int Min = 0;
        public static int Max = 100;
        public static int Count = 10000;

        static void Main(string[] args)
        {
            List<TimeSpan> allTime = new List<TimeSpan>();

            for (int i = 0; i < Count; i++)
            {
                int[] a = CreateRandomArray();
                allTime.Add(StartSort(ref a));
            }

            TimeSpan all = TimeSpan.Zero;
            foreach (var child in allTime)
            {
                all += child;
            }

            Console.WriteLine("总计：" + all);

            //int[] a = CreateRandomArray();
            //StartSort(ref a);

            Console.ReadLine();
        }

        public static int[] CreateRandomArray(int count = 1000)
        {
            int[] a = new int[count];

            for (int i = 0; i < count; i++)
            {
                Random random = new Random(Guid.NewGuid().GetHashCode());
                var createNum = random.Next(Min, Max);
                a[i] = createNum;
            }

            return a;
        }

        public static TimeSpan StartSort(ref int[] a)
        {
            //#region Console.Write
            //Console.Write("start:");

            //foreach (var child in a)
            //{
            //    Console.Write($"{child},");
            //}

            //Console.WriteLine();
            //#endregion

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            BubbleSort(ref a);
            //InsertSort(ref a);
            //QuickSort(ref a);

            stopwatch.Stop();

            //#region Console.Write
            //Console.WriteLine("user time:" + stopwatch.Elapsed);

            //Console.Write("result:");

            //foreach (var child in a)
            //{
            //    Console.Write($"{child},");
            //}

            //Console.WriteLine();
            //#endregion

            CheckResult(a);

            //#region Console.Write
            //Console.WriteLine();
            //Console.WriteLine("=======================");
            //#endregion

            return stopwatch.Elapsed;
        }

        public static void BubbleSort(ref int[] a, bool isAscend = true)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                bool isChange = false;
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    if (isAscend)
                    {
                        if (a[j] > a[j + 1])
                        {
                            var temp = a[j];
                            a[j] = a[j + 1];
                            a[j + 1] = temp;
                            isChange = true;
                        }
                    }
                    else
                    {
                        if (a[j] < a[j + 1])
                        {
                            var temp = a[j];
                            a[j] = a[j + 1];
                            a[j + 1] = temp;
                            isChange = true;
                        }
                    }
                }

                if (!isChange)
                {
                    return;
                }
            }
        }

        public static void InsertSort(ref int[] a, bool isAscend = true)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                if (result.Count == 0)
                {
                    result.Add(a[i]);
                }
                else
                {
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (isAscend)
                        {
                            if (a[i] < result[j])
                            {
                                result.Insert(j, a[i]);
                                break;
                            }

                            if (j == result.Count - 1)
                            {
                                result.Add(a[i]);
                                break;
                            }
                        }
                        else
                        {
                            if (a[i] > result[j])
                            {
                                result.Insert(j, a[i]);
                                break;
                            }

                            if (j == result.Count - 1)
                            {
                                result.Add(a[i]);
                                break;
                            }
                        }
                    }
                }
            }

            a = result.ToArray();
        }

        public static void QuickSort(ref int[] a, bool isAscend = true)
        {
            QuickSortMethod(0, a.Length - 1, ref a);
        }

        public static bool isFirst = true;

        public static void QuickSortMethod(int startIndex, int endIndex, ref int[] a)
        {
            if (startIndex >= endIndex)
            {
                return;
            }

            int i = startIndex;
            int j = endIndex;

            int n = 0;

            Random random = new Random();
            n = random.Next(i, j);

            while (i < j)
            {
                while (i < n && a[i] <= a[n])
                {
                    i++;
                }

                while (j > n && a[j] >= a[n])
                {
                    j--;
                }

                if (i == j)
                {
                    break;
                }

                var temp = a[i];
                a[i] = a[j];
                a[j] = temp;

                if (i == n)
                {
                    n = j;
                }
                else if (j == n)
                {
                    n = i;
                }
            }

            QuickSortMethod(startIndex, n - 1, ref a);
            QuickSortMethod(n + 1, endIndex, ref a);

        }

        public static bool CheckResult(int[] a, bool isAscend = true)
        {
            bool result = true;

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (isAscend)
                {
                    if (a[i] > a[i + 1])
                    {
                        result = false;
                        break;
                    }
                }
                else
                {
                    if (a[i] < a[i + 1])
                    {
                        result = false;
                        break;
                    }
                }
            }

            if (!result)
            {
                Console.WriteLine("**********Error**********");
            }

            return result;
        }
    }
}
