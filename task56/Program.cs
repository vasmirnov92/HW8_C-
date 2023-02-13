// Задача 56: Задайте прямоугольный двумерный массив. Напишите 
// программу, которая будет находить строку с наименьшей суммой элементов.

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

int[] SummOfRows(int[,] matrix)
{
    int[] summs = new int[matrix.GetLength(0)];
    for (int i=0; i<matrix.GetLength(0); i++)
    {
        for (int j=0; j<matrix.GetLength(1); j++)
        {
            summs[i] += matrix[i, j];
        }
    }
    return summs;
}

int IndexRowOfMinSumm(int[] summs)
{
    int index = 0;
  
    for (int i=0; i<summs.Length-1; i++)
    {
        int min = summs[i];
        if (summs[i]<summs[i+1])
        {
            index = i;
        }
        else
        {
            min = summs[i+1];
            index = i+1;
        }
    }
    return index;
}

int[] RowWithMinSumm(int[,] matrix, int indexMinRow)
{
    int[] lineMinSumm = new int[matrix.GetLength(1)];
    for (int j=0; j<matrix.GetLength(1); j++)
    {
        lineMinSumm[j] = matrix[indexMinRow, j];
    }
    return lineMinSumm;
}


Console.Clear();
Console.Write("Введите кол-во строк: ");
int row = int.Parse(Console.ReadLine()!);
Console.Write("Введите кол-во столбцов: ");
int col = int.Parse(Console.ReadLine()!);

int[,] array = GetArray(row, col, 0, 10);
PrintArray(array);
Console.WriteLine();

int[] summa = SummOfRows(array);
Console.WriteLine("Суммы элементов в строках:");
Console.WriteLine(String.Join('\t', summa));
Console.WriteLine();

int indexMinSumm = IndexRowOfMinSumm(summa);
Console.WriteLine($"Индекс строки с минимальной суммой = {indexMinSumm}");
Console.WriteLine();

Console.WriteLine("Строка с минимальной суммой:");
int[] stringMinSumm = RowWithMinSumm(array, indexMinSumm);
Console.WriteLine(String.Join('\t', stringMinSumm));



