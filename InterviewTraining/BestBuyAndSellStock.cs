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

    public static int MaxProfitWithTwoPass(int[] prices)
    {
        if (prices == null || prices.Length < 2)
            return 0;

        int n = prices.Length;
        int[] leftProfits = new int[n];
        int[] rightProfits = new int[n];

        // Forward pass: Max profit with one transaction ending at or before day i
        int minPrice = prices[0];
        for (int i = 1; i < n; i++)
        {
            minPrice = Math.Min(minPrice, prices[i]);
            leftProfits[i] = Math.Max(leftProfits[i - 1], prices[i] - minPrice);
        }

        // Backward pass: Max profit with one transaction starting at or after day i
        int maxPrice = prices[n - 1];
        for (int i = n - 2; i >= 0; i--)
        {
            maxPrice = Math.Max(maxPrice, prices[i]);
            rightProfits[i] = Math.Max(rightProfits[i + 1], maxPrice - prices[i]);
        }

        // Combine results
        int maxTotalProfit = 0;
        for (int i = 0; i < n; i++)
        {
            maxTotalProfit = Math.Max(maxTotalProfit, leftProfits[i] + rightProfits[i]);
        }

        return maxTotalProfit;
    }

    public static int MaxProfit(int k, int[] prices)
    {
        if (prices.Length == 0 || k == 0)
            return 0;

        // Optimization: If k is large, it's equivalent to unlimited transactions
        if (k >= prices.Length / 2)
        {
            int profit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                    profit += prices[i] - prices[i - 1];
            }
            return profit;
        }

        int[] minCosts = new int[k + 1];
        int[] maxProfits = new int[k + 1];
        Array.Fill(minCosts, int.MaxValue);

        foreach (int price in prices)
        {
            for (int j = 1; j <= k; j++)
            {
                // Best price to buy the j-th stock (offset by previous profit)
                minCosts[j] = Math.Min(minCosts[j], price - maxProfits[j - 1]);
                // Best profit to sell the j-th stock
                maxProfits[j] = Math.Max(maxProfits[j], price - minCosts[j]);
            }
        }

        return maxProfits[k];
    }

    public static int MaxProfitTest(int[] prices)
    {
        if (prices.Length < 2)
        {
            return 0;
        }
        int[] arrayProfit = new int[prices.Length];
        Array.Fill(arrayProfit, 0);
        (int minValueLeft, int maxValueLeft) = (0, 0);
        (int minValueRight, int maxValueRight) = (0, 0);

        for (int i = 0; i < prices.Length; i++)
        {
            if (
                (minValueLeft == maxValueLeft)
                || (i == minValueRight)
                || (prices[i] > prices[maxValueLeft])
            )
            {
                (minValueLeft, maxValueLeft) = GetIndexMinMax(prices[..i]);
                (minValueRight, maxValueRight) = GetIndexMinMax(prices[i..]);
                minValueRight += i;
                maxValueRight += i;
                arrayProfit[i] =
                    Math.Max(prices[maxValueLeft] - prices[minValueLeft], 0)
                    + Math.Max(0, prices[maxValueRight] - prices[minValueRight]);
            }
        }
        return arrayProfit.Max();
    }

    public static (int, int) GetIndexMinMax(int[] pricesSpan)
    {
        int indexMin = 0;
        int indexMax = Math.Max(0, pricesSpan.Length - 1);
        int minValueReached = 0;
        int maxValue = 0;

        for (int i = 0; i < pricesSpan.Length; i++)
        {
            minValueReached = pricesSpan[minValueReached] < pricesSpan[i] ? minValueReached : i;
            if (maxValue < pricesSpan[i] - pricesSpan[minValueReached])
            {
                maxValue = pricesSpan[i] - pricesSpan[minValueReached];
                indexMax = i;
                indexMin = minValueReached;
            }
        }
        return (indexMin, indexMax);
    }
}
