// Задача 58: Задайте две матрицы. Напишите программу, которая будет 
// находить произведение двух матриц.

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue+1);
        }
    }
    return result;
}

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            Console.Write($"{inArray[i, j]}\t "); // табуляция
        }
        Console.WriteLine();
    }
}

int[,] MultiplicationMatrix(int[,] matrix1, int[,] matrix2)
{
    int[,] multip = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
    for (int i = 0; i<matrix1.GetLength(0); i++)
    {
        for (int j = 0; j<matrix2.GetLength(1); j++)
        {
            for (int temp = 0; temp<matrix1.GetLength(1); temp++)
            {
                multip[i,j] += matrix1[i, temp]*matrix2[temp, j];
            }
        }
    }

    return multip;
}

Console.Clear();
Console.Write("Введите кол-во строк первой матрицы: ");
int row1 = int.Parse(Console.ReadLine()!);
Console.Write("Введите кол-во столбцов первой матрицы: ");
int col1 = int.Parse(Console.ReadLine()!);

int[,] array1 = GetArray(row1, col1, 0, 10);
PrintArray(array1);
Console.WriteLine();

Console.Write("Введите кол-во строк второй матрицы: ");
int row2 = int.Parse(Console.ReadLine()!);
Console.Write("Введите кол-во столбцов второй матрицы: ");
int col2 = int.Parse(Console.ReadLine()!);

int[,] array2 = GetArray(row2, col2, 0, 10);
PrintArray(array2);
Console.WriteLine();

if (col1 != row2)
{
    Console.WriteLine("Перемножить матрицы невозможно");
}

int[,] multiplicated = MultiplicationMatrix(array1, array2);
PrintArray(multiplicated);
