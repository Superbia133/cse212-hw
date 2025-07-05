public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1. Create an array of size 'length'
        // 2. Use a for loop from 0 to length - 1
        // 3. At each index i, store (number * (i + 1)) in the array
        // 4. Return the resulting array

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example: {1,2,3,4,5,6,7,8,9} → rotated 3 → {7,8,9,1,2,3,4,5,6}
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan:
        // 1. Get the count of the list
        // 2. Use GetRange to slice off the last 'amount' elements
        // 3. Remove those elements from the end
        // 4. Insert them at the beginning of the list

        int count = data.Count;
        List<int> tail = data.GetRange(count - amount, amount);
        data.RemoveRange(count - amount, amount);
        data.InsertRange(0, tail);
    }

    /// <summary>
    /// OPTIONAL: Test the above functions when running this file directly.
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("Multiples of 3, length 5:");
        var result = MultiplesOf(3, 5);
        Console.WriteLine("[" + string.Join(", ", result) + "]");

        var list = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        Console.WriteLine("Before Rotate: " + string.Join(", ", list));
        RotateListRight(list, 3);
        Console.WriteLine("After Rotate : " + string.Join(", ", list));
    }
}
