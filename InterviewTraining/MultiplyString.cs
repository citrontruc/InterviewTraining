using System.Text;

public class MultiplyStringClass
{
    public static string Multiply(string num1, string num2)
    {
        num1 = ReverseString(num1);
        num2 = ReverseString(num2);
        int carryOver = 0;
        int currentSum = 0;

        StringBuilder resultString = new();
        for (int i = 0; i < num1.Length + num2.Length; i++)
        {
            for (int index1 = 0; index1 <= i; index1++)
            {
                if ((index1 < num1.Length) && (i - index1 < num2.Length))
                {
                    int index2 = i - index1;
                    currentSum +=
                        int.Parse(num1[index1].ToString()) * int.Parse(num2[index2].ToString());
                }
            }
            int interSum = carryOver + currentSum;
            carryOver = interSum / 10;
            resultString.Append((interSum % 10).ToString());
            currentSum = 0;
        }
        string result = resultString.ToString().TrimEnd('0');
        result = ReverseString(result);
        return result.Length > 0 ? result : "0";
    }

    public static string ReverseString(string stringToReverse)
    {
        char[] array = stringToReverse.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
}
