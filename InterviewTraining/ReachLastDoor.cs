public class ReachLastDoor
{
    public static int MinTimeToReach(int[][] moveTime)
    {
        int[,] possibleMoveMatrix = new int[moveTime.Length, moveTime[0].Length];
        bool[,] visit = new bool[moveTime.Length, moveTime[0].Length];
        for (int i = 0; i < moveTime.Length; i++)
        {
            for (int j = 0; j < moveTime[0].Length; j++)
            {
                possibleMoveMatrix[i, j] = int.MaxValue;
                visit[i, j] = false;
            }
        }
        possibleMoveMatrix[0, 0] = 0;
        visit[0, 0] = true;

        Queue<(int, int)> currentNodes = new();
        List<(int, int)> possibleVariations = new List<(int, int)>
        {
            (0, 1),
            (1, 0),
            (0, -1),
            (-1, 0),
        };
        currentNodes.Enqueue((0, 0));
        while (currentNodes.Count > 0)
        {
            (int, int) currentNodeValue = currentNodes.Dequeue();
            foreach ((int, int) variation in possibleVariations)
            {
                (int, int) newNode = (
                    currentNodeValue.Item1 + variation.Item1,
                    currentNodeValue.Item2 + variation.Item2
                );
                if (
                    (newNode.Item1 >= 0)
                    && (newNode.Item2 >= 0)
                    && (newNode.Item1 < moveTime.Length)
                    && (newNode.Item2 < moveTime[0].Length)
                )
                {
                    if (!visit[newNode.Item1, newNode.Item2])
                    {
                        visit[newNode.Item1, newNode.Item2] = true;
                        possibleMoveMatrix[newNode.Item1, newNode.Item2] = Math.Max(
                            moveTime[newNode.Item1][newNode.Item2] + 1,
                            possibleMoveMatrix[currentNodeValue.Item1, currentNodeValue.Item2] + 1
                        );
                        currentNodes.Enqueue(newNode);
                    }
                    else
                    {
                        int inter = possibleMoveMatrix[newNode.Item1, newNode.Item2];
                        possibleMoveMatrix[newNode.Item1, newNode.Item2] = Math.Max(
                            moveTime[newNode.Item1][newNode.Item2] + 1,
                            Math.Min(
                                possibleMoveMatrix[newNode.Item1, newNode.Item2],
                                possibleMoveMatrix[currentNodeValue.Item1, currentNodeValue.Item2]
                                    + 1
                            )
                        );
                        if (inter != possibleMoveMatrix[newNode.Item1, newNode.Item2])
                        {
                            currentNodes.Enqueue(newNode);
                        }
                    }
                }
            }
        }
        return possibleMoveMatrix[moveTime.Length - 1, moveTime[0].Length - 1];
    }
}
