public static class CombinationSumClass
{
    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        candidates.Sort();
        return FindValidCandidateCombination(new(), target, candidates);
    }

    public static IList<IList<int>> FindValidCandidateCombination(
        List<int> currentList,
        int target,
        int[] CurrentCandidateArray
    )
    {
        List<IList<int>> result = new();
        int listSum = currentList.Sum();
        int i = 0;
        while (i < CurrentCandidateArray.Length && listSum + CurrentCandidateArray[i] - target <= 0)
        {
            switch (listSum + CurrentCandidateArray[i] - target)
            {
                case 0:
                    result.Add(currentList.Append(CurrentCandidateArray[i]).ToList());
                    break;
                case < 0:
                    result.AddRange(
                        FindValidCandidateCombination(
                            currentList.Append(CurrentCandidateArray[i]).ToList(),
                            target,
                            CurrentCandidateArray[i..]
                        )
                    );
                    break;
                default:
                    break;
            }
            i++;
        }
        return result;
    }
}
