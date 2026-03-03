namespace InterviewTraining.Test;

public class RankPokerHandsTest
{
    [Theory]
    [InlineData("Highest straight flush wins", Result.Loss, "2H 3H 4H 5H 6H", "KS AS TS QS JS")]
    [InlineData(
        "Straight flush wins of 4 of a kind",
        Result.Win,
        "2H 3H 4H 5H 6H",
        "AS AD AC AH JD"
    )]
    [InlineData("Highest 4 of a kind wins", Result.Win, "AS AH 2H AD AC", "JS JD JC JH 3D")]
    [InlineData("4 Of a kind wins of full house", Result.Loss, "2S AH 2H AS AC", "JS JD JC JH AD")]
    [InlineData("Full house wins of flush", Result.Win, "2S AH 2H AS AC", "2H 3H 5H 6H 7H")]
    [InlineData("Highest flush wins", Result.Win, "AS 3S 4S 8S 2S", "2H 3H 5H 6H 7H")]
    [InlineData("Flush wins of straight", Result.Win, "2H 3H 5H 6H 7H", "2S 3H 4H 5S 6C")]
    [InlineData("Equal straight is tie", Result.Tie, "2S 3H 4H 5S 6C", "3D 4C 5H 6H 2S")]
    [InlineData("Straight wins of three of a kind", Result.Win, "2S 3H 4H 5S 6C", "AH AC 5H 6H AS")]
    [InlineData("3 Of a kind wins of two pair", Result.Loss, "2S 2H 4H 5S 4C", "AH AC 5H 6H AS")]
    [InlineData("2 Pair wins of pair", Result.Win, "2S 2H 4H 5S 4C", "AH AC 5H 6H 7S")]
    [InlineData("Highest pair wins", Result.Loss, "6S AD 7H 4S AS", "AH AC 5H 6H 7S")]
    [InlineData("Pair wins of nothing", Result.Loss, "2S AH 4H 5S KC", "AH AC 5H 6H 7S")]
    [InlineData("Highest card loses", Result.Loss, "2S 3H 6H 7S 9C", "7H 3C TH 6H 9S")]
    [InlineData("Highest card wins", Result.Win, "4S 5H 6H TS AC", "3S 5H 6H TS AC")]
    [InlineData("Equal cards is tie", Result.Tie, "2S AH 4H 5S 6C", "AD 4C 5H 6H 2C")]
    [InlineData("Twoflushes Case", Result.Loss, "3S 8S 9S 5S KS", "JH 8H AH KH QH")]
    public void Top3_WithEmptystring_ReturnsEmptyList(
        string caseName,
        Result expectedOutput,
        string playerHand,
        string otherHand
    )
    {
        PokerHand testHand = new(playerHand);
        PokerHand AdversaryHand = new(otherHand);
        Result result = testHand.CompareWith(AdversaryHand);
        Assert.Equal(expectedOutput, result);
    }
}
