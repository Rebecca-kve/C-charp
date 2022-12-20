// See https://aka.ms/new-console-template for more information


using System;

int[,] Grid = { { 1, 2, 3, 4}, { 5, 6, 7, 8 }, { 9, 10, 11, 12}, { 13, 14, 15, 16} };
PrintArray(Grid);
Console.WriteLine();
int[,] RotatedGrid = new int[4,4];

RotatedGrid = RotateGridLeft(Grid);
PrintArray(RotatedGrid);

static int[,] RotateGridLeft(int[,] grid)
{
    int[,] result = new int[grid.GetLength(0), grid.GetLength(1)];

    for (int row = 0; row < grid.GetLength(0); row++)
    {
        for (int col = 0; col < grid.GetLength(1); col++)
        {
            result[col, grid.GetLength(0) - row - 1] = grid[row, col]; ;
        }  
    }
    return result;
}
static void PrintArray(int[,] grid)
{
    for (int row = 0; row < grid.GetLength(0); row++)
    {
        for (int col = 0; col < grid.GetLength(1); col++)
        {
            Console.Write("{0} ", grid[col, row]);
        }
        Console.WriteLine();
    }
}  