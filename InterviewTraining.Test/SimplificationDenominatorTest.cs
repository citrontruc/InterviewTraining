namespace InterviewTraining.Test;

public class SimplificationDenominatorTest
{
    [Fact]
    public void convertFrac_ConvertsFractionForSimplestDenominator()
    {
        long[,] lst = new long[,]
        {
            { 2, 4 },
            { 2, 6 },
            { 2, 8 },
        };
        Assert.Equal("(6,12)(4,12)(3,12)", Fracts.convertFrac(lst));
    }
}
