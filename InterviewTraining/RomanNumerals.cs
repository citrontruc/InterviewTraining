using System.Text;

public class Solution
{
    public static List<(int, string)> RomanNumerals = new()
    {
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I"),
    };

    public string IntToRoman(int num)
    {
        StringBuilder sb = new();
        foreach ((int romanValue, string numeral) in RomanNumerals)
        {
            while (romanValue <= num)
            {
                num -= romanValue;
                sb.Append(numeral);
            }
        }
        return sb.ToString();
    }
}
