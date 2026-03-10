public class ParenthesisString
{
    public static IList<string> GenerateParenthesis(int n)
    {
        if (n == 1)
        {
            return ["()"];
        }
        List<string> result = new();
        IList<string> listPreviousAnswer = GenerateParenthesis(n - 1);
        foreach (string parenthesisFamily in listPreviousAnswer)
        {
            string parenthesisFamilyModified = "(" + parenthesisFamily;
            for (int j = 1; j < parenthesisFamily.Count() + 1; j++)
            {
                result.Add(parenthesisFamilyModified.Insert(j, ")").ToString());
            }
        }
        return result.Distinct().ToList();
    }
}
