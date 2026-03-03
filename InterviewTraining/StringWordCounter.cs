using System.Text;
using System.Text.RegularExpressions;

public static class TopWords
{
    public static List<string> Top3(string s)
    {
        StringBuilder sb = new();
        foreach (char c in s.ToLower())
        {
            if ((c >= 'a' && c <= 'z') || c == '\'' || c == ' ')
            {
                sb.Append(c);
            }
        }
        string cleanedString = Regex.Replace(
            Regex.Replace(sb.ToString().Trim(), @"\s+", " "),
            @"(?<![a-zA-Z])'(?![a-zA-Z])",
            ""
        );
        if (cleanedString.Length == 0)
            return new();
        string[] splittedString = cleanedString.Split(' ');
        var countedStrings = splittedString
            .GroupBy(
                value => value,
                (keyString, strings) => new { Key = keyString, value = strings.Count() }
            )
            .OrderBy(x => x.value)
            .ToList();
        List<string> result = new();
        for (int i = 1; i < Math.Min(countedStrings.Count(), 3) + 1; i++)
        {
            result.Add(countedStrings[^i].Key);
        }

        // Your code here
        return result;
    }
}
