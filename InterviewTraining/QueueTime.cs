/*
Exercice : dans un supermarché, des clients arrivent aux caisses.
Ils prennent la première caisse vide.
Dans combien de temps est-ce que tout le monde aura fait ses courses.
*/

public class Kata
{
    public static long QueueTime(int[] customers, int n)
    {
        long totalWaitTime = 0;
        int[] supermarketQueues = new int[n];
        for (int i = 0; i < customers.Length; i++)
        {
            int min = supermarketQueues.Min();

            // We compute how long it would take to free a queue.
            if (min > 0)
            {
                supermarketQueues = supermarketQueues.Select(x => x - min).ToArray();
                totalWaitTime += min;
            }
            int indexEmptyQueue = Array.FindIndex(supermarketQueues, num => num == 0);
            supermarketQueues[indexEmptyQueue] = customers[i];
        }
        totalWaitTime += supermarketQueues.Max();
        return totalWaitTime;
    }

    public static string Maskify(string cc)
    {
        if (cc.Length <= 4)
        {
            return cc;
        }
        return new string('#', cc.Length - 4) + cc.Substring(cc.Length - 4);
    }
}
