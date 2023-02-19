// Задача 62: Заполните спирально массив 4 на 4.

// считаем последнее число и заполняем, пока не достигнем этого числа
// последнее число всегда можем посчитать путем перемножения индексов
// если равен нулю - заполняем, если не равен - поворачиваем
// и так пока не достигнем последнего числа
// загвоздка с первым нулем, но можно начать с единицы



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

int[,] SpiralFilling (int rows, int columns, int num)
{
    int[,] spiral = new int[rows, columns];
    int count = 1;
    for (int j = 0; j<columns; j++)
    {
        spiral[0, j] = count;
        count++;
    }
    for (int i = 1; i<rows; i++)
    {
        spiral[i, columns-1] = count;
        count++;
    }
    for (int j=columns-2; j>=0; j--)
    {
        spiral[rows-1, j] = count;
        count++;
    }
    while(count<17)
    {   
        int i=rows-2;
        int j=0;
        // if (spiral[i,j] == 0)
        // {
             spiral[i,j] = count;
            
            i=i-1;
        // }
        count++;
    }
    return spiral;
}

int HowManyElements(int rows, int columns)
{
    int numberOfElements = rows * columns;
    return numberOfElements;
}


Console.Clear();
Console.WriteLine("Введите количество строк: ");
int row = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество столбцов: ");
int column = int.Parse(Console.ReadLine());
int numbers = HowManyElements(row, column);
Console.WriteLine(numbers);
int[,] spir = SpiralFilling(row, column, numbers);
PrintArray(spir);

