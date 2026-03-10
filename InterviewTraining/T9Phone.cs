public class T9Phone
{
    public static Dictionary<string, string> dictTranslate = new Dictionary<string, string>
    {
        { "1", "" },
        { "2", "abc" },
        { "3", "def" },
        { "4", "ghi" },
        { "5", "jkl" },
        { "6", "mno" },
        { "7", "pqrs" },
        { "8", "tuv" },
        { "9", "wxyz" },
        { "0", " " },
    };

    public static IList<string> LetterCombinations(string digits)
    {
        if (digits.Count() == 1)
        {
            List<string> resultEmpty = new();
            foreach (char oneLetter in dictTranslate[digits[0].ToString()])
            {
                resultEmpty.Add(oneLetter.ToString());
            }
            return resultEmpty;
        }
        string letters = dictTranslate[digits[0].ToString()];
        IList<string> previousLetters = LetterCombinations(digits.Substring(1));
        List<string> result = new();
        foreach (char oneLetter in letters)
        {
            foreach (string previousCombination in previousLetters)
            {
                result.Add(oneLetter.ToString() + previousCombination);
            }
        }
        return result;
    }
}
