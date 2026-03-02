namespace InterviewTraining.Test;

public class MaximaDetectorTest
{
    [Fact]
    public void Detect_WithEmptyListOfInput_ReturnsZero()
    {
        List<int> ints = new();
        int maxVal = MaximaDetector.CorrectedDetect(ints);
        Assert.Equal(0, maxVal);
    }

    [Fact]
    public void Detect_WithStrictlyDecreasingValues_ShouldReturnZero()
    {
        List<int> ints = new List<int> { 10, 6, 4, 0 };
        int maxVal = MaximaDetector.CorrectedDetect(ints);
        Assert.Equal(0, maxVal);
    }

    [Fact]
    public void Detect_WithEqualValues_ShouldReturnZero()
    {
        List<int> ints = new List<int> { 10, 10, 10, 10 };
        int maxVal = MaximaDetector.CorrectedDetect(ints);
        Assert.Equal(0, maxVal);
    }

    [Fact]
    public void Detect_WithNoGapEqualityInList_ShouldReturnMaximaValue()
    {
        List<int> ints = new List<int> { 0, 4, 6, 0, 12 };
        int maxVal = MaximaDetector.CorrectedDetect(ints);
        Assert.Equal(12, maxVal);
    }

    [Fact]
    public void Detect_WithGapEquality_ShouldReturnMaximaValue()
    {
        List<int> ints = new List<int> { 2, 0, 4, 10, 100, 0, 4, 10 };
        // In case of gap equality in values, we have failure cases.
        int maxVal = MaximaDetector.CorrectedDetect(ints);
        Assert.Equal(100, maxVal);
    }
}
