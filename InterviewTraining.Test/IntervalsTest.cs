namespace InterviewTraining.Test;

public class IntervalsTest
{
    [Fact]
    public void SumIntervals_WithEmptyListOfInput_ReturnsZero()
    {
        (int, int)[] ints = { };
        int sumIntervals = Intervals.SumIntervals(ints);
        Assert.Equal(0, sumIntervals);
    }

    [Fact]
    public void SumIntervals_WithDisctinctIntervals_ReturnsValue()
    {
        (int, int)[] ints = { (-2, -1), (-1, 0), (0, 21) };
        int sumIntervals = Intervals.SumIntervals(ints);
        Assert.Equal(23, sumIntervals);
    }

    [Fact]
    public void SumIntervals_WithJointIntervals_ReturnsValue()
    {
        (int, int)[] ints = { (5, 8), (3, 6), (1, 2) };
        int sumIntervals = Intervals.SumIntervals(ints);
        Assert.Equal(6, sumIntervals);
    }
}
