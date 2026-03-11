public class CanJump
{
    public static bool CanReach(int[] arr, int start)
    {
        if (!arr.Contains(0))
        {
            return false;
        }

        bool[] visitedIndex = new bool[arr.Length];
        Array.Fill(visitedIndex, false);
        visitedIndex[start] = true;
        return DoVisit(arr, start, visitedIndex);
    }

    public static bool DoVisit(int[] arr, int start, bool[] visitedIndex)
    {
        if (arr[start] == 0)
            return true;
        if (start - arr[start] >= 0 && !visitedIndex[start - arr[start]])
        {
            visitedIndex[start - arr[start]] = true;
            if (DoVisit(arr, start - arr[start], visitedIndex))
            {
                return true;
            }
        }
        if (start + arr[start] < arr.Length && !visitedIndex[start + arr[start]])
        {
            visitedIndex[start + arr[start]] = true;
            if (DoVisit(arr, start + arr[start], visitedIndex))
            {
                return true;
            }
        }
        return false;
    }
}
