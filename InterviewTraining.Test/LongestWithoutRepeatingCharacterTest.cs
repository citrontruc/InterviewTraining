namespace InterviewTraining.Test;

public class LongestWithoutRepeatingCharacterTest
{
    [Fact]
    public void LongestWithoutRepeatingCharacter_WithNoRepeatingCharacters_ReturnsLength()
    {
        string testString = "abcdefghijklmnopqrstuvwxyz";
        int maxNoRepeating = LengthOfLongestSubstringClass.LengthOfLongestSubstring(testString);
        Assert.Equal(testString.Length, maxNoRepeating);
    }

    [Fact]
    public void LongestWithoutRepeatingCharacter_WithEmptyString_Returnszero()
    {
        string testString = "";
        int maxNoRepeating = LengthOfLongestSubstringClass.LengthOfLongestSubstring(testString);
        Assert.Equal(testString.Length, maxNoRepeating);
    }

    [Fact]
    public void LongestWithoutRepeatingCharacter_WithRepeatingCharacters_ReturnsMaxLength()
    {
        string testString = "abcdebcdefghijk";
        int maxNoRepeating = LengthOfLongestSubstringClass.LengthOfLongestSubstring(testString);
        Assert.Equal(10, maxNoRepeating);
    }
}
