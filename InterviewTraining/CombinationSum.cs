public static class CombinationSumClass
{
    public static IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
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
        for (int i = 0; i < CurrentCandidateArray.Length; i++)
        {
            switch (listSum + CurrentCandidateArray[i] - target)
            {
                case 0:
                    List<int> nextStepList = currentList.Append(CurrentCandidateArray[i]).ToList();
                    result.Add(nextStepList);
                    break;
                case < 0:
                    nextStepList = currentList.Append(CurrentCandidateArray[i]).ToList();
                    result.AddRange(
                        FindValidCandidateCombination(
                            nextStepList,
                            target,
                            CurrentCandidateArray[i..]
                        )
                    );
                    break;
                default:
                    break;
            }
        }
        return result;
    }
}
