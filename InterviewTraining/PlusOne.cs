public static class PlusOneClass
{
    public static int[] PlusOneRecursive(int[] digits)
    {
        if (digits.Length == 0)
            return [1];
        if (digits[^1] != 9)
        {
            digits[^1] += 1;
            return digits;
        }
        return Enumerable.Concat(PlusOneRecursive(digits[..(digits.Length - 1)]), [0]).ToArray();
    }

    public static int[] PlusOneIterative(int[] digits)
    {
        for (int i = digits.Length - 1; i > -1; i--)
        {
            if (digits[i] != 9)
            {
                digits[i] += 1;
                return digits;
            }
            else
            {
                digits[i] = 0;
            }
        }
        // Quicker to create a new one than to do a concat.
        int[] result = new int[digits.Length + 1];
        result[0] = 1;
        return result;
    }
}
