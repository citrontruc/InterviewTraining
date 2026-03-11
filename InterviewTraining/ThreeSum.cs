public class ThreeSumClass
{
    public static IList<IList<int>> ThreeSum(int[] nums)
    {
        nums.Sort();
        IList<IList<int>> result = new List<IList<int>>();
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                continue;
            if (nums[i] == 0 && nums[i + 1] == 0 && nums[i + 2] == 0)
            {
                List<int> interList = new List<int> { 0, 0, 0 };
                result.Add(interList);
                break;
            }
            if (nums[i] > 0)
            {
                break;
            }
            int j = i + 1;
            int k = nums.Length - 1;
            while (k > j)
            {
                switch (nums[k] + nums[i] + nums[j])
                {
                    case 0:
                        List<int> interList = new List<int>
                        {
                            nums[i],
                            nums[j],
                            -(nums[i] + nums[j]),
                        };
                        result.Add(interList);
                        while (j < k && nums[j] == nums[j + 1])
                            j++;
                        while (j < k && nums[k] == nums[k - 1])
                            k--;
                        j++;
                        k--;
                        break;

                    case < 0:
                        j++;
                        break;

                    case > 0:
                        k--;
                        break;
                }
            }
        }
        return result;
    }

    public static int ThreeSumClosest(int[] nums, int target)
    {
        nums.Sort();
        int minGap = int.MaxValue;
        int bestValue = int.MaxValue;
        for (int i = 0; i < nums.Count() - 2; i++)
        {
            int j = i + 1;
            int k = nums.Count() - 1;
            int currentValue = nums[i] + nums[j] + nums[k];
            while (true)
            {
                if (Math.Abs(target - currentValue) < minGap)
                {
                    minGap = Math.Abs(target - currentValue);
                    bestValue = currentValue;
                }

                if (currentValue > target)
                {
                    k--;
                }

                if (currentValue < target)
                {
                    j++;
                }

                if (currentValue == target)
                {
                    return currentValue;
                }

                if (k <= j)
                {
                    break;
                }

                currentValue = nums[i] + nums[j] + nums[k];
            }
        }
        return bestValue;
    }

    public static IList<IList<int>> FourSumNotOptimal(int[] nums, int target)
    {
        Dictionary<int, List<List<int>>> dictResultIndex = new();
        List<IList<int>> result = new();

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                int interResult = nums[i] + nums[j];
                if (!dictResultIndex.ContainsKey(interResult))
                {
                    dictResultIndex[interResult] = new();
                }
                dictResultIndex[interResult].Add(new List<int> { i, j });
            }
        }
        int[] dictKeys = dictResultIndex.Keys.ToArray();
        dictKeys.Sort();
        int leftIndex = 0;
        int rightIndex = dictKeys.Length - 1;
        while (leftIndex <= rightIndex)
        {
            switch (dictKeys[rightIndex] + dictKeys[leftIndex] - target)
            {
                case > 0:
                    rightIndex--;
                    break;
                case 0:
                    result.AddRange(
                        GetAllCombinations(
                            dictResultIndex[dictKeys[rightIndex]],
                            dictResultIndex[dictKeys[leftIndex]],
                            nums
                        )
                    );
                    leftIndex++;
                    rightIndex--;
                    break;
                case < 0:
                    leftIndex++;
                    break;
            }
        }
        return result
            .GroupBy(inner => string.Join(",", inner))
            .Select(group => group.First())
            .ToList();
    }

    public static List<List<int>> GetAllCombinations(
        List<List<int>> listA,
        List<List<int>> listB,
        int[] nums
    )
    {
        var combinations = listA
            .SelectMany(l1 => listB.Select(l2 => l1.Concat(l2).ToList()))
            .ToList();
        List<List<int>> result = new();
        foreach (List<int> combination in combinations)
        {
            if (combination.Count == combination.Distinct().Count())
            {
                result.Add(combination.Select(x => nums[x]).ToList());
            }
        }

        return result
            .GroupBy(inner => string.Join(",", inner))
            .Select(group => group.First())
            .ToList();
    }
}
