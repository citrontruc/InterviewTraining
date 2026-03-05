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
}
