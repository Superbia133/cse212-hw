using System;
using System.Diagnostics;
using System.Linq;

public static class Sorting {
    public static void Run() {
        Console.WriteLine("{0,10}{1,15}{2,15}{3,15}{4,15}", "n", "bubble-count", "insertion-count", "bubble-time", "insertion-time");
        Console.WriteLine("{0,10}{0,15}{0,15}{0,15}{0,15}", "----------");

        for (int n = 0; n <= 1000; n += 100) {
            var testData = Enumerable.Range(0, n).Reverse().ToArray();

            var bubbleData = (int[])testData.Clone();
            var insertionData = (int[])testData.Clone();

            int bubbleCount = BubbleSort(bubbleData);
            int insertionCount = InsertionSort(insertionData);

            double bubbleTime = Time(() => BubbleSort((int[])testData.Clone()), 100);
            double insertionTime = Time(() => InsertionSort((int[])testData.Clone()), 100);

            Console.WriteLine("{0,10}{1,15}{2,15}{3,15:0.00000}{4,15:0.00000}", n, bubbleCount, insertionCount, bubbleTime, insertionTime);
        }

        // Also keep your original test
        Console.WriteLine("\nOriginal Sample Output:");
        var numbers = new[] { 3, 2, 1, 6, 4, 9, 8 };
        BubbleSort(numbers); // using bubble for consistency
        Console.Out.WriteLine("int[]{{{0}}}", string.Join(", ", numbers)); // int[]{1, 2, 3, 4, 6, 8, 9}
    }

    private static double Time(Action executeAlgorithm, int times) {
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < times; i++) {
            executeAlgorithm();
        }
        sw.Stop();
        return sw.Elapsed.TotalMilliseconds / times;
    }

    /// <summary>
    /// Bubble sort with count of comparisons.
    /// Time Complexity: O(n^2)
    /// </summary>
    private static int BubbleSort(int[] data) {
        int count = 0;
        for (var sortPos = data.Length - 1; sortPos >= 0; sortPos--) {
            for (var swapPos = 0; swapPos < sortPos; ++swapPos) {
                count++;
                if (data[swapPos] > data[swapPos + 1]) {
                    (data[swapPos + 1], data[swapPos]) = (data[swapPos], data[swapPos + 1]);
                }
            }
        }
        return count;
    }

    /// <summary>
    /// Insertion sort with count of comparisons.
    /// Time Complexity: O(n^2)
    /// </summary>
    private static int InsertionSort(int[] data) {
        int count = 0;
        for (int i = 1; i < data.Length; ++i) {
            int j = i;
            while (j > 0) {
                count++;
                if (data[j - 1] > data[j]) {
                    (data[j], data[j - 1]) = (data[j - 1], data[j]);
                    j--;
                } else {
                    break;
                }
            }
        }
        return count;
    }
}
