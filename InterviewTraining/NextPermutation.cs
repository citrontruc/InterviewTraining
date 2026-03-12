public static class NextPermutationClass
{
    public static void NextPermutation(int[] nums)
    {
        if (nums.Length <= 1)
            return;
        (int pivot, int successor) = CheckLexicography(nums);
        if (pivot == -1)
        {
            nums.Sort();
        }
        else
        {
            int inter = nums[pivot];
            nums[pivot] = nums[successor];
            nums[successor] = inter;
            for (int i = pivot + 1; i < (nums.Length + pivot + 1) / 2; i++)
            {
                inter = nums[nums.Length - i + pivot];
                nums[nums.Length - i + pivot] = nums[i];
                nums[i] = inter;
            }
        }
    }

    public static (int, int) CheckLexicography(int[] nums)
    {
        int pivot = -1;
        int successor = -1;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] < nums[i])
            {
                pivot = i - 1;
                successor = i;
            }
            if (pivot != -1 && nums[pivot] < nums[i])
            {
                successor = i;
            }
        }
        return (pivot, successor);
    }
}
