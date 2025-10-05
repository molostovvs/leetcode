using FluentAssertions;
using NUnit.Framework;

namespace _36._Valid_Sudoku;

public class Program
{
    public static void Main() {}
}

public class Solution
{
    // Long and ugly [O(n^2), O(n)]
    public bool IsValidSudoku(char[][] board)
        => IsRowsValid(board) && IsColumnsValid(board) && IsBoxesValid(board);

    private bool IsBoxesValid(char[][] board)
    {
        var set = new HashSet<char>();

        for (var row = 0; row < board.GetLength(0); row += 3)
        {
            for (var col = 0; col < board[0].GetLength(0); col += 3)
            {
                for (int i = row, j = col; i < row + 3 && j < col + 3; j++)
                {
                    var symbol = board[i][j];
                    if (char.IsDigit(symbol) && !set.Add(symbol))
                        return false;

                    if (j == col + 2)
                    {
                        i++;
                        j -= 3;
                    }
                }

                set.Clear();
            }

            set.Clear();
        }

        return true;
    }

    private bool IsColumnsValid(char[][] board)
    {
        var set = new HashSet<char>();
        for (var col = 0; col < board[0].GetLength(0); col++)
        {
            for (var row = 0; row < board.GetLength(0); row++)
                if (char.IsDigit(board[row][col]) && !set.Add(board[row][col]))
                    return false;
            set.Clear();
        }

        return true;
    }

    private bool IsRowsValid(char[][] board)
    {
        var set = new HashSet<char>();
        for (var row = 0; row < board.GetLength(0); row++)
        {
            var currentRow = board[row];
            foreach (var symbol in currentRow)
                if (char.IsDigit(symbol) && !set.Add(symbol))
                    return false;
            set.Clear();
        }

        return true;
    }
}

[TestFixture]
public class Tests
{
    private static Solution s = new();

    [Test]
    public static void ValidSudoku()
    {
        var board = new char[9][];
        board[0] = new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' };
        board[1] = new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
        board[2] = new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
        board[3] = new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
        board[4] = new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
        board[5] = new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
        board[6] = new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
        board[7] = new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
        board[8] = new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
        var result = s.IsValidSudoku(board);
        result.Should().BeTrue();
    }

    [Test]
    public static void InvalidSudoku()
    {
        var board = new char[9][];
        board[0] = new[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' };
        board[1] = new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' };
        board[2] = new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' };
        board[3] = new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' };
        board[4] = new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' };
        board[5] = new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' };
        board[6] = new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' };
        board[7] = new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' };
        board[8] = new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' };
        var result = s.IsValidSudoku(board);
        result.Should().BeFalse();
    }
}