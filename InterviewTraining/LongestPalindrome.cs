public class LongestPalindromeClass
{
    public string LongestPalindrome(string s)
    {
        string longestPalindrome = s.Length > 0 ? s[0].ToString() : "";
        int maxSize = 0;
        for (int j = 0; j < s.Length; j++)
        {
            int left = j;
            int right = j;
            bool valid = true;
            while (valid)
            {
                int newLeft = Math.Max(left - 1, 0);
                int newRight = Math.Min(right + 1, s.Length - 1);
                if ((newRight == right) || (newLeft == left) || (s[newLeft] != s[newRight]))
                {
                    valid = false;
                    continue;
                }
                else
                {
                    right = newRight;
                    left = newLeft;
                }
            }
            if ((right - left) > maxSize)
            {
                maxSize = right - left;
                longestPalindrome = s[left..(right + 1)];
            }
            if (j > 0)
            {
                if (s[j - 1] == s[j])
                {
                    left = j - 1;
                    right = j;
                    valid = true;
                    while (valid)
                    {
                        int newLeft = Math.Max(left - 1, 0);
                        int newRight = Math.Min(right + 1, s.Length - 1);
                        if ((newRight == right) || (newLeft == left) || (s[newLeft] != s[newRight]))
                        {
                            valid = false;
                            continue;
                        }
                        else
                        {
                            right = newRight;
                            left = newLeft;
                        }
                    }
                    if ((right - left) > maxSize)
                    {
                        maxSize = right - left;
                        longestPalindrome = s[left..(right + 1)];
                    }
                }
            }
        }
        return longestPalindrome;
    }
}
