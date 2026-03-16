public class TemperatureClass
{
    public static int[] DailyTemperatures(int[] temperatures)
    {
        int[] result = new int[temperatures.Length];
        Array.Fill(result, 0);

        List<(int, int)> listValueTemperature = new();
        for (int i = temperatures.Length - 1; i > -1; i--)
        {
            bool Addend = true;
            for (int j = listValueTemperature.Count - 1; j > -1; j--)
            {
                switch (temperatures[i] - listValueTemperature[j].Item1)
                {
                    case > 0:
                        listValueTemperature.RemoveAt(j);
                        break;
                    case < 0:
                        if (result[i] == 0)
                            result[i] = listValueTemperature[j].Item2 - i;
                        break;
                    case 0:
                        listValueTemperature[j] = (temperatures[i], i);
                        Addend = false;
                        break;
                }
            }
            if (Addend)
                listValueTemperature.Add((temperatures[i], i));
        }
        return result;
    }
}
