public class LengthOfLongestSubstringClass
{
    public static int LengthOfLongestSubstring(string s)
    {
        int result = 0;
        List<char> inter = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (!inter.Contains(s[i]))
            {
                inter.Add(s[i]);
                if (inter.Count > result)
                {
                    result = inter.Count;
                }
            }
            else
            {
                int indexRepeating = inter.IndexOf(s[i]);
                inter = inter[(indexRepeating + 1)..];
                inter.Add(s[i]);
            }
        }
        return result;
    }

    public static int LengthOfLongestSubstringWithDict(string s)
    {
        int result = 0;
        int chainCount = 0;
        int minIndex = 0;
        Dictionary<char, int> inter = new();
        for (int i = 0; i < s.Length; i++)
        {
            if (!inter.ContainsKey(s[i]))
            {
                chainCount++;
                result = result > chainCount ? result : chainCount;
            }
            else
            {
                switch (inter[s[i]] - minIndex)
                {
                    case > 0:
                        chainCount = i - inter[s[i]];
                        minIndex = inter[s[i]];
                        break;
                    case 0:
                        minIndex++;
                        break;
                    case < 0:
                        chainCount++;
                        result = result > chainCount ? result : chainCount;
                        break;
                }
            }
            inter[s[i]] = i;
        }
        return result;
    }
}
