public class Intervals
{
    public static int SumIntervals((int, int)[] intervals)
    {
        if (intervals.Length == 0)
            return 0;
        for (int i = 0; i < intervals.Length / intervals.Rank - 1; i++)
        {
            for (int j = i + 1; j < intervals.Length / intervals.Rank; j++)
            {
                MergeIntervals(ref intervals[i], ref intervals[j]);
            }
        }
        int result = intervals.Aggregate(0, (a, b) => a + (b.Item2 - b.Item1));
        return result;
    }

    public static void MergeIntervals(ref (int, int) firstInterval, ref (int, int) secondInterval)
    {
        if (firstInterval.Item1 >= secondInterval.Item2)
        {
            return;
        }

        if (firstInterval.Item1 >= secondInterval.Item1)
        {
            if (firstInterval.Item2 <= secondInterval.Item2)
            {
                firstInterval = new(0, 0);
                return;
            }

            if (firstInterval.Item2 > secondInterval.Item2)
            {
                firstInterval = new(secondInterval.Item2, firstInterval.Item2);
                return;
            }
        }
        else
            MergeIntervals(ref secondInterval, ref firstInterval);
    }
}
