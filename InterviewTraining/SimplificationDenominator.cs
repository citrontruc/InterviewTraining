using System.Text;

public class Fracts
{
    public static string convertFrac(long[,] lst)
    {
        if (lst.Length == 0)
            return "";
        long ppcm = lst[0, 1];
        for (int i = 0; i < lst.Length / lst.Rank; i++)
        {
            long gcfValue = gcf(lst[i, 0], lst[i, 1]);
            lst[i, 0] = lst[i, 0] / gcfValue;
            lst[i, 1] = lst[i, 1] / gcfValue;
            ppcm = lcm(ppcm, lst[i, 1]);
        }

        StringBuilder answerString = new();
        for (int i = 0; i < lst.Length / lst.Rank; i++)
        {
            answerString.Append($"({lst[i, 0] * ppcm / lst[i, 1]},{ppcm})");
        }
        return answerString.ToString();
    }

    static long gcf(long a, long b)
    {
        while (b != 0)
        {
            long temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static long lcm(long a, long b)
    {
        return (a / gcf(a, b)) * b;
    }
}
