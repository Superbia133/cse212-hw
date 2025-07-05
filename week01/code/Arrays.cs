public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <param name="number">The base number to find multiples of</param>
    /// <param name="length">The number of multiples to generate</param>
    /// <returns>Array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of size 'length'
        // 2. Loop through indices 0 to length - 1
        // 3. Multiply the number by (i + 1) and store in the array
        // 4. Return the result array

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotates the list to the right by 'amount' positions.
    /// For example: {1,2,3,4,5,6,7,8,9} → rotated by 3 → {7,8,9,1,2,3,4,5,6}
    /// </summary>
    /// <param name="data">The list to rotate</param>
    /// <param name="amount">How many positions to rotate</param>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Find the tail (last 'amount' elements) using GetRange
        // 2. Remove that tail from the list
        // 3. Insert the tail at the front using InsertRange

        int count = data.Count;
        List<int> tail = data.GetRange(count - amount, amount);
        data.RemoveRange(count - amount, amount);
        data.InsertRange(0, tail);
    }

    /// <summary>
    /// Test the above functions when running this file directly.
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Multiples of 3, length 5:");
        var result = MultiplesOf(3, 5);
        Console.WriteLine("[" + string.Join(", ", result) + "]");

        var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Before Rotate: " + string.Join(", ", list));
        RotateListRight(list, 3);
        Console.WriteLine("After Rotate : " + string.Join(", ", list));
    }
}
