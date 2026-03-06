public class GraphTraversalSolution
{
    public static int FindNumberPathOfLengthK(int n, int[][] edges, int source, int destination)
    {
        if (source == destination)
        {
            return 0;
        }
        int[,] matrixAvailable = new int[n, n];
        foreach (int[] edge in edges)
        {
            matrixAvailable[edge[0], edge[1]] = 1;
            matrixAvailable[edge[1], edge[0]] = 1;
        }
        if (matrixAvailable[source, destination] != 0)
            return 1;
        int[] matrixAVector = new int[n];
        for (int i = 0; i < n; i++)
        {
            matrixAVector[i] = matrixAvailable[source, i];
        }
        for (int i = 2; i < n; i++)
        {
            matrixAVector = MatrixMultiply(matrixAVector, matrixAvailable);
            if (matrixAVector[destination] != 0)
            {
                return i;
            }
        }
        return -1;
    }

    public static int[] MatrixMultiply(int[] matrixAVector, int[,] matrixB)
    {
        int[] resultMatrix = new int[matrixAVector.Length];
        Array.Fill(resultMatrix, 0);
        for (int i = 0; i < matrixAVector.Length; i++)
        {
            for (int j = 0; j < matrixAVector.Length; j++)
            {
                resultMatrix[i] += matrixAVector[j] * matrixB[j, i];
            }
        }
        return resultMatrix;
    }

    public static bool GraphTraversal(int n, int[][] edges, int source, int destination)
    {
        if (source == destination)
        {
            return true;
        }

        Dictionary<int, List<int>> dictPaths = new();
        foreach (int[] edge in edges)
        {
            if (!dictPaths.ContainsKey(edge[0]))
            {
                dictPaths[edge[0]] = new();
            }

            if (!dictPaths.ContainsKey(edge[1]))
            {
                dictPaths[edge[1]] = new();
            }
            dictPaths[edge[0]].Add(edge[1]);
            dictPaths[edge[1]].Add(edge[0]);
        }

        Queue<int> nodesToVisit = new();
        nodesToVisit.Enqueue(source);
        while (nodesToVisit.Count > 0)
        {
            int currentNode = nodesToVisit.Dequeue();
            if (currentNode == destination)
                return true;
            if (dictPaths.ContainsKey(currentNode))
            {
                foreach (int node in dictPaths[currentNode])
                {
                    nodesToVisit.Enqueue(node);
                }
                dictPaths.Remove(currentNode);
            }
        }
        return false;
    }
}
