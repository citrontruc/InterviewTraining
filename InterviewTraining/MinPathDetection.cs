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
}
