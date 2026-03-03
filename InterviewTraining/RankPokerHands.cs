public enum Result
{
    Win,
    Loss,
    Tie,
}

public enum HandValue
{
    HighCard,
    Pair,
    TwoPairs,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush,
}

public class PokerHand
{
    public static Dictionary<string, int> cardNumericValues = new Dictionary<string, int>
    {
        { "2", 2 },
        { "3", 3 },
        { "4", 4 },
        { "5", 5 },
        { "6", 6 },
        { "7", 7 },
        { "8", 8 },
        { "9", 9 },
        { "T", 10 },
        { "J", 11 },
        { "Q", 12 },
        { "K", 13 },
        { "A", 14 },
    };

    private List<int> _signature = new();
    private List<string> _values = new();
    private List<string> _suits = new();

    public PokerHand(string hand)
    {
        foreach (string card in hand.Split(" "))
        {
            _values.Add(card[0].ToString());
            _suits.Add(card[1].ToString());
        }
        CreateSignature();
    }

    private void CreateSignature()
    {
        _signature = _values
            .GroupBy(x => x)
            .OrderByDescending(x => x.Count())
            .ThenByDescending(x => cardNumericValues[x.Key])
            .Select(x => cardNumericValues[x.Key])
            .ToList();
    }

    public List<int> GetSignature()
    {
        return _signature;
    }

    public Result CompareWith(PokerHand hand)
    {
        if ((int)GetBestResult() > (int)hand.GetBestResult())
            return Result.Win;
        if ((int)GetBestResult() < (int)hand.GetBestResult())
            return Result.Loss;

        List<int> adversarySignature = hand.GetSignature();
        for (int i = 0; i < _signature.Count; i++)
        {
            if (_signature[i] > adversarySignature[i])
                return Result.Win;
            if (_signature[i] < adversarySignature[i])
                return Result.Loss;
        }

        return Result.Tie;
    }

    public HandValue GetBestResult()
    {
        bool isStraight = IsStraight();
        bool isFlush = IsFlush();
        HandValue cardCombination = EvaluateCardCombinations();
        if (isStraight && isFlush)
        {
            return HandValue.StraightFlush;
        }
        if (isFlush && (int)cardCombination > (int)HandValue.Flush)
        {
            return cardCombination;
        }
        if (isFlush)
        {
            return HandValue.Flush;
        }
        if (isStraight)
        {
            return HandValue.Straight;
        }
        return cardCombination;
    }

    private HandValue EvaluateCardCombinations()
    {
        var groupedCard = _values
            .GroupBy(
                x => x,
                (cardValue, cardGroup) => new { Key = cardValue, value = cardGroup.Count() }
            )
            .OrderBy(x => x.value)
            .ToList();
        if (groupedCard[^1].value == 4)
        {
            return HandValue.FourOfAKind;
        }
        if (groupedCard[^1].value == 3)
        {
            if (groupedCard[^2].value == 2)
            {
                return HandValue.FullHouse;
            }
            return HandValue.ThreeOfAKind;
        }
        if (groupedCard[^1].value == 2)
        {
            if (groupedCard[^2].value == 2)
            {
                return HandValue.TwoPairs;
            }
            return HandValue.Pair;
        }
        return HandValue.HighCard;
    }

    private bool IsFlush()
    {
        if (_suits.Distinct().ToList().Count == 1)
        {
            return true;
        }
        return false;
    }

    private bool IsStraight()
    {
        List<int> numericValue = _values.Select(x => cardNumericValues[x]).OrderBy(x => x).ToList();
        List<int> differences = numericValue
            .Zip(numericValue.Skip(1), (current, next) => next - current)
            .ToList();
        if (differences.All(x => x == 1))
        {
            return true;
        }

        if (
            _values.Contains("A")
            && _values.Contains("2")
            && _values.Contains("3")
            && _values.Contains("4")
            && _values.Contains("5")
        )
        {
            _signature = new() { 5, 4, 3, 2, 1 };
            return true;
        }

        return false;
    }
}
