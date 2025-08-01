using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n) // Line 13
    {
        if (n <= 0) // Base case
        {
            return 0;
        }

        return (n * n) + SumSquaresRecursive(n - 1); // Recursive case
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "") // Line 27
    {
        // Base case: if word is the right size, add to results
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Try every letter that hasn't been used yet
        for (int i = 0; i < letters.Length; i++)
        {
            // Remove the current letter from remaining letters
            string remaining = letters.Remove(i, 1);
            // Add it to the current word
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb stairs taking 1, 2, or 3 steps at a time using memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null) // Line 48
    {
        // Create dictionary if it doesn't exist
        if (remember == null)
        {
            remember = new Dictionary<int, decimal>();
        }

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Check if we've already solved this subproblem
        if (remember.ContainsKey(s))
        {
            return remember[s];
        }

        // Solve recursively and remember the result
        decimal ways = CountWaysToClimb(s - 1, remember) + CountWaysToClimb(s - 2, remember) + CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Replace '*' in a binary pattern with both 0 and 1 recursively.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results) // Line 71
    {
        // Base case: if no wildcards, add to results
        if (!pattern.Contains("*"))
        {
            results.Add(pattern);
            return;
        }

        // Replace the first * with 0 and 1, then recurse
        int index = pattern.IndexOf("*");

        string withZero = pattern[..index] + "0" + pattern[(index + 1)..];
        string withOne = pattern[..index] + "1" + pattern[(index + 1)..];

        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// #############
    /// # Problem 5 #
    /// #############
    /// Recursively find all valid paths through the maze from (0,0) to the end.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null) // Line 90
    {
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }

        // Add current position to the path
        currPath.Add((x, y));

        // Base case: if we've reached the end, add the path
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
        }
        else
        {
            // Try moving in each direction if valid
            if (maze.IsValidMove(currPath, x + 1, y)) // Right
            {
                SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath));
            }

            if (maze.IsValidMove(currPath, x - 1, y)) // Left
            {
                SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath));
            }

            if (maze.IsValidMove(currPath, x, y + 1)) // Down
            {
                SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath));
            }

            if (maze.IsValidMove(currPath, x, y - 1)) // Up
            {
                SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath));
            }
        }
    }
}
