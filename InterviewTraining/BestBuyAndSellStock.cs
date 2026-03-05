public class BestBuyAndSellStock
{
    public static int MaxProfit(int[] prices)
    {
        if (prices.Length < 2)
        {
            return 0;
        }

        List<(int, int)> listVariations = new();
        int beginVal = prices[0];
        int endVal = prices[0];
        int variation = 0;

        for (int i = 0; i < prices.Length; i++)
        {
            if (variation == 0)
            {
                variation = endVal.CompareTo(prices[i]);
                endVal = prices[i];
            }
            switch (variation * endVal.CompareTo(prices[i]))
            {
                case 0:
                    continue;
                case -1:
                    listVariations.Add((beginVal, endVal));
                    variation = endVal.CompareTo(prices[i]);
                    beginVal = endVal;
                    endVal = prices[i];
                    break;
                case 1:
                    endVal = prices[i];
                    break;
            }
        }
        listVariations.Add((beginVal, endVal));
        while (listVariations.Count() > 2)
        {
            listVariations = MergeSmallestGap(listVariations);
        }
        return listVariations.Select(x => x.Item2 - x.Item1).Where(x => x > 0).Sum();
    }

    public static List<(int, int)> MergeSmallestGap(List<(int, int)> listVariations)
    {
        List<int> listDifferences = listVariations.Select(x => x.Item2 - x.Item1).ToList();
        int i = listDifferences.IndexOf(listDifferences.Min());
        int toReplace = 0;

        if (i == 0)
        {
            toReplace = 1;
        }

        if (i == listDifferences.Count - 1)
        {
            toReplace = i - 1;
        }

        if ((i != 0) && (i != listDifferences.Count - 1))
        {
            toReplace = listDifferences[i - 1] < listDifferences[i + 1] ? i - 1 : i + 1;
        }

        if (toReplace > i)
        {
            listVariations[toReplace] =
                listVariations[i].Item2 - listVariations[i].Item1
                > listVariations[toReplace].Item2
                    - Math.Min(listVariations[toReplace].Item1, listVariations[i].Item1)
                    ? (listVariations[i].Item1, listVariations[i].Item2)
                    : (
                        Math.Min(listVariations[toReplace].Item1, listVariations[i].Item1),
                        listVariations[toReplace].Item2
                    );
        }
        else
        {
            listVariations[toReplace] =
                listVariations[toReplace].Item2 - listVariations[toReplace].Item1
                > listVariations[i].Item2
                    - Math.Min(listVariations[toReplace].Item1, listVariations[i].Item1)
                    ? (listVariations[toReplace].Item1, listVariations[toReplace].Item2)
                    : (
                        Math.Min(listVariations[toReplace].Item1, listVariations[toReplace].Item1),
                        listVariations[i].Item2
                    );
        }
        listVariations.RemoveAt(i);
        return listVariations;
    }
}
