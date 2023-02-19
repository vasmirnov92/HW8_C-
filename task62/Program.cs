// Задача 62: Заполните спирально массив 4 на 4.

// считаем последнее число и заполняем, пока не достигнем этого числа
// последнее число всегда можем посчитать путем перемножения индексов
// если равен нулю - заполняем, если не равен - поворачиваем
// и так пока не достигнем последнего числа
// загвоздка с первым нулем, но можно начать с единицы

// при заполнении будем идти не по длине масссива, а по меременным, типа leftBorder колонка, rigthBorder колонка, topBorder ряд, bottomBorder ряд
// и уменьшать их по мере заполнения массива
// 4 процесса заполнения массива
// слева направо - фиксируем ряд topBorder, идем по колонкам от leftBorder до rightBorder

// сверху вниз - фиксируем колонку rightBorder, идем по рядам от topBorder до bottomBorder

// справа налево - фиксируем ряд bottomBorder, идем по колонкам от rightborder до leftBorder

// снизу вверх - фиксируем колонку leftBorder, идем по рядам от bottomBorder до topBorder

// и повторяем пока элемент не станет равным посчитанному количеству элементов



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

    int topBorder = 0;              // ряд
    int bottomBorder = rows-1;        // ряд
    int leftBorder = 0;             // колонка
    int rightBorder = columns-1;      // колонка

    int count = 1;


    while (count <= num)
    {
        for (int j = leftBorder; j<=rightBorder; j++)     // слева направо - фиксируем ряд topBorder, идем по колонкам от leftBorder до rightBorder
        {
            spiral[topBorder, j] = count;
            count++;
            
        }
        topBorder = topBorder + 1;

        for (int i = topBorder; i<=bottomBorder; i++)            // сверху вниз - фиксируем колонку rightBorder, идем по рядам от topBorder до bottomBorder
        {
            spiral[i, rightBorder] = count;
            count++;   
        }
        rightBorder = rightBorder - 1;

        for (int j=rightBorder; j>=leftBorder; j--)        
        {
            spiral[bottomBorder, j] = count;
            count++;   
        }
        bottomBorder = bottomBorder - 1;

        for (int i = bottomBorder; i>=topBorder; i--)
        {
            spiral[i, leftBorder] = count;
            count++;
        }
        leftBorder = leftBorder + 1;
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

