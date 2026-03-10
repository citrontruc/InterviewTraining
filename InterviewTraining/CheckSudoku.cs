public class CheckSudoku
{
    public static bool IsValidSudoku(char[][] board)
    {
        return CheckRows(board) && CheckColumns(board) && CheckSquares(board);
    }

    public static bool CheckRows(char[][] board)
    {
        for (int i = 0; i < board.Length; i++)
        {
            if (
                board[i]
                    .Where(x => x != '.')
                    .GroupBy(x => x)
                    .Where(group => group.Count() > 1)
                    .Select(group => group.Key)
                    .Count() > 0
            )
            {
                return false;
            }
        }
        return true;
    }

    public static bool CheckColumns(char[][] board)
    {
        for (int i = 0; i < board[0].Length; i++)
        {
            if (
                board
                    .Select(row => row[i])
                    .Where(x => x != '.')
                    .GroupBy(x => x)
                    .Where(group => group.Count() > 1)
                    .Select(group => group.Key)
                    .Count() > 0
            )
            {
                return false;
            }
        }
        return true;
    }

    public static bool CheckSquares(char[][] board)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                char[][] square = board
                    .Skip(0 + i * 3)
                    .Take(3)
                    .Select(row => row.Skip(0 + j * 3).Take(3).ToArray())
                    .ToArray();

                List<char> testList = [.. square[0], .. square[1], .. square[2]];
                if (
                    testList
                        .Where(x => x != '.')
                        .GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key)
                        .Count() > 0
                )
                {
                    return false;
                }
            }
        }
        return true;
    }
}
