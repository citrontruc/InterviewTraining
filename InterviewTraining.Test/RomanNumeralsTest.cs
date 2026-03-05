namespace InterviewTraining.Test;

public class RomanNumeralsTest
{
    [Theory]
    [InlineData(3749, "MMMDCCXLIX")]
    public void IntToRoman_ConvertsValueToRomanNumeral(int valueToConvert, string expectedOutput)
    {
        Solution solution = new();
        string convertedRomanNumeral = solution.IntToRoman(valueToConvert);
        Assert.Equal(expectedOutput, convertedRomanNumeral);
    }
}
