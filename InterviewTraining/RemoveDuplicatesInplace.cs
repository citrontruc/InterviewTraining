public static class RemoveDuplicatesClass
{
    public static int RemoveDuplicatesInPlace(int[] nums)
    {
        if (nums.Length <= 2)
            return nums.Length;
        int displace = 0;
        int currentNumber = nums[0];
        int numRepetition = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == currentNumber)
            {
                numRepetition++;
                if (numRepetition > 2)
                    displace++;
            }
            else
            {
                currentNumber = nums[i];
                numRepetition = 1;
            }
            nums[i - displace] = nums[i];
        }
        return nums.Length - displace;
    }
}
