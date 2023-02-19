// Задача 60: Сформируйте трёхмерный массив из неповторяющихся 
// двузначных чисел. Напишите программу, которая будет построчно выводить 
// массив, добавляя индексы каждого элемента.

int GetUniqNumber(int[] numbers)
{
    int number = new Random().Next(1, 8);
    while (Array.IndexOf(numbers, number) != -1)
    {
        number = new Random().Next(1, 8);
    }
    return number;
}

int[ , , ] FillParallelepiped(int x, int y, int z)
{
    int[ , , ] parallelepiped = new int[x, y, z];
    int[] collection = new int[x*y*z];
    int n = 0;
    for (int i=0; i<z; i++)
    {
        for (int j=0; j<y; j++)
        {
            for (int k=0; k<z; k++)
            {
                int number = GetUniqNumber(collection);
                collection[n] = number;
                n++;
                parallelepiped[i, j, k] = number;
                // Console.WriteLine(String.Join(' ', collection)); // проверка сгенерированных цисел
            }
        }
    }
    return parallelepiped;
}

void PrintParallelepiped (int x, int y, int z, int[ , , ] parallepiped)
{
    for (int i=0; i<z; i++)
    {
        for (int j=0; j<y; j++)
        {
            for (int k=0; k<z; k++)
            {
                Console.WriteLine($"Элемент ({i}; {j}; {k}) = {parallepiped[i, j, k]}");
            }
        }
    }
}

Console.Clear();
Console.Write("Введите ширину прямоугольного параллелепипеда: ");
int row = int.Parse(Console.ReadLine()!);
Console.Write("Введите длину прямоугольного параллелепипеда: ");
int col = int.Parse(Console.ReadLine()!);
Console.Write("Введите глубину прямоугольного параллелепипеда: ");
int longer = int.Parse(Console.ReadLine()!);
int[ , , ] cube = FillParallelepiped(row, col, longer);
PrintParallelepiped(row, col, longer, cube);

