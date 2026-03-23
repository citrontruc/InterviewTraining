public static class ProductExceptSelfClass
{
    public static int[] ProductExceptSelf(int[] nums)
    {
        int[] result = new int[nums.Length];
        int[] productSmallerIndexThan = new int[nums.Length];
        int[] productBiggerIndexThan = new int[nums.Length];

        // Array.Fill is very costly. In our case, we just need the first coefficient to be initialized.
        productSmallerIndexThan[0] = 1;
        productBiggerIndexThan[^1] = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            productSmallerIndexThan[i] = productSmallerIndexThan[i - 1] * nums[i - 1];
            productBiggerIndexThan[^(i + 1)] = productBiggerIndexThan[^i] * nums[^i];
        }

        for (int i = 0; i < nums.Length; i++)
        {
            result[i] = productSmallerIndexThan[i] * productBiggerIndexThan[i];
        }
        return result;
    }
}
