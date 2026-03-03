namespace InterviewTraining.Test;

public class StringWordCounterTest
{
    [Fact]
    public void Top3_WithEmptystring_ReturnsEmptyList()
    {
        string testString = "";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string>(), listResult);
    }

    [Fact]
    public void Top3_WithOnlyTwoDifferentWords_ReturnsOnlyTwoEntries()
    {
        string testString = "Test test tesT value Value";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string> { "test", "value" }, listResult);
    }

    [Fact]
    public void Top3_WithOnlyTwoDifferentWordsWithPunctuation_ReturnsOnlyTwoEntries()
    {
        string testString = "Test test tesT value,!?,, Value";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string> { "test", "value" }, listResult);
    }

    [Fact]
    public void Top3_WithOnlyTwoDifferentWordsWithHyphen_ReturnsOnlyTwoEntries()
    {
        string testString = "Tes't te'st te'sT te'sT tes't test'";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string> { "te'st", "tes't", "test'" }, listResult);
    }

    [Fact]
    public void Top3_WithALotOfWhitespaces_ReturnsTopThree()
    {
        string testString = "a a a  b  c c  d d d d  e e e e e";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string> { "e", "d", "a" }, listResult);
    }

    [Fact]
    public void Top3_WithALotOfWhitespacesAndPunctuation_ReturnsTopThree()
    {
        string testString = "  , e   .. ";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string> { "e" }, listResult);
    }

    [Fact]
    public void Top3_WithOnlyPunctuationAndWhitespaces_ReturnsAnEmptyList()
    {
        string testString = "  , !/// ?   .. ";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string>(), listResult);
    }

    [Fact]
    public void Top3_WithOnlyQuotes_ReturnsAnEmptyList()
    {
        string testString = "  '' ";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string>(), listResult);
    }

    [Fact]
    public void Top3_WithALotOfWords_ReturnsTopThree()
    {
        string testString =
            "I've been on the low I've been taking my time, feel like I'm out of my mind, feeling like my life ain't mine. my life been  my life life life";
        List<string> listResult = TopWords.Top3(testString);
        Assert.Equivalent(new List<string> { "life", "my", "been" }, listResult);
    }
}
