// Задача 60: Сформируйте трёхмерный массив из неповторяющихся 
// двузначных чисел. Напишите программу, которая будет построчно выводить 
// массив, добавляя индексы каждого элемента.

//                  ПРОБЛЕМА
//                  функция GetUniqNumber как будто пропускает первый элемент массива для проверки, но где именно, не понятно
//                  она ПОЧТИ работает
//                  для проверки заполняю трехменый массив 2*2*2 числами от 1 до 8
//                  если допустим ввести массив 3*3*3 - программа кращится, значит она все-таки не может заполнять массив 
//                  одинаковыми числами, но почему-то пропускает нулевой элемент массива

int GetUniqNumber(int[] numbers)
{
    int number = new Random().Next(1, 9);       // генерируем рандомное число в промежутке, указанном в функции
    for(int i=0; i<numbers.Length; i++)         // перебираем массив numbers, полученный от функции FillParallelepiped (массив collection)
    {
        while (number == numbers[i])               // сравниваем полученное число number с каждым элементом массива numbers
        {
            number = new Random().Next(1, 9);   // если какой-то элемент массива равен числу, меняем значение number на рандомное
            i=0;                                // обнуляем счетчик, чтобы заново проверять новый number на равенство элементов массива numbers
        }
  
    }
    return number;                              // если number НЕ раввно ни одному из элементов массива, вызвращаем его
}

int[ , , ] FillParallelepiped(int x, int y, int z)
{
    int[ , , ] parallelepiped = new int[x, y, z];       // создаем трехмерный массив, заполненный нулями
    int[] collection = new int[x*y*z];                  // создаем одномерный массив для хранения использованных чисел
    int n = 0;
    for (int i=0; i<z; i++)
    {
        for (int j=0; j<y; j++)
        {
            for (int k=0; k<z; k++)
            {
                // int number = GetUniqNumber(collection);      // более громоздкая запись строчек 39-41
                // collection[n] = number;                      //
                // n++;                                         //
                // parallelepiped[i, j, k] = number;            //

                collection[n] = GetUniqNumber(collection);
                parallelepiped[i, j, k] = collection[n];
                n++;

                Console.WriteLine(String.Join(' ', collection));        // для проверки выводим уникальный массив collection
                //Console.WriteLine(collection[0]);                     // поскольку проблема в нулевом элементе массива, выводим его, чтобы видеть, что он не теряется
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

