// Method to insert an int in an ordered list at the position it should be.

public static class SearchInsertClass
{
    public static int SearchInsert(int[] nums, int target)
    {
        if (nums.Length == 1)
        {
            return target <= nums[0] ? 0 : 1;
        }
        int halfPosition = nums.Length / 2;
        if (nums[halfPosition] == target)
        {
            return halfPosition;
        }
        if (nums[halfPosition] > target)
            return SearchInsert(nums[..halfPosition], target);
        return halfPosition + SearchInsert(nums[halfPosition..], target);
    }
}
