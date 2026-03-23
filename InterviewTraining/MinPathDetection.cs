public static class MinPath
{
    public static int MinPathSum(int[][] grid)
    {
        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if ((i == 0) && (j == 0))
                    continue;
                if ((i != 0) && (j != 0))
                    grid[i][j] += Math.Min(grid[i][j - 1], grid[i - 1][j]);
                if ((i == 0) && (j != 0))
                    grid[i][j] += grid[i][j - 1];
                if ((i != 0) && (j == 0))
                    grid[i][j] += grid[i - 1][j];
            }
        }
        return grid[^1][^1];
    }

    public static int MaxProductPath(int[][] grid)
    {
        long[,] maxPos = new long[grid.Length, grid[0].Length];
        long[,] minNeg = new long[grid.Length, grid[0].Length];

        for (int i = 0; i < grid.Length; i++)
        {
            for (int j = 0; j < grid[0].Length; j++)
            {
                if ((i == 0) && (j == 0))
                {
                    maxPos[i, j] = Math.Max(grid[i][j], -1);
                    minNeg[i, j] = Math.Min(grid[i][j], 1);
                }

                if ((i != 0) && (j != 0))
                {
                    maxPos[i, j] = Math.Max(
                        grid[i][j] > 0
                            ? Math.Max(maxPos[i - 1, j] * grid[i][j], maxPos[i, j - 1] * grid[i][j])
                            : Math.Max(
                                minNeg[i - 1, j] * grid[i][j],
                                minNeg[i, j - 1] * grid[i][j]
                            ),
                        -1
                    );
                    minNeg[i, j] = Math.Min(
                        grid[i][j] > 0
                            ? Math.Min(minNeg[i - 1, j] * grid[i][j], minNeg[i, j - 1] * grid[i][j])
                            : Math.Min(
                                maxPos[i - 1, j] * grid[i][j],
                                maxPos[i, j - 1] * grid[i][j]
                            ),
                        1
                    );
                }
                if ((i == 0) && (j != 0))
                {
                    maxPos[i, j] = Math.Max(
                        grid[i][j] > 0
                            ? maxPos[i, j - 1] * grid[i][j]
                            : minNeg[i, j - 1] * grid[i][j],
                        -1
                    );
                    minNeg[i, j] = Math.Min(
                        grid[i][j] > 0
                            ? minNeg[i, j - 1] * grid[i][j]
                            : maxPos[i, j - 1] * grid[i][j],
                        1
                    );
                }
                if ((i != 0) && (j == 0))
                {
                    maxPos[i, j] = Math.Max(
                        grid[i][j] > 0
                            ? maxPos[i - 1, j] * grid[i][j]
                            : minNeg[i - 1, j] * grid[i][j],
                        -1
                    );
                    minNeg[i, j] = Math.Min(
                        grid[i][j] > 0
                            ? minNeg[i - 1, j] * grid[i][j]
                            : maxPos[i - 1, j] * grid[i][j],
                        1
                    );
                }
            }
        }
        return (int)(maxPos[grid.Length - 1, grid[0].Length - 1] % (Math.Pow(10, 9) + 7));
    }
}
