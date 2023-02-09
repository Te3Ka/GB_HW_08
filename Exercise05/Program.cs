/***********************/
/*****Te3Ka_PaynE*******/
/*Mnement4813@yandex.ru*/
/***********************/

/*
Напишите программу, которая заполнит спирально массив 4 на 4.
Например, на выходе получается вот такой массив:
01 02 03 04
12 13 14 05
11 16 15 06
10 09 08 07
*/

//Метод с указанием автора
void Author()
{
    Console.WriteLine();
    Console.WriteLine("Программа создана Te3Ka_PaynE.");
    Console.WriteLine("E-mail: Mnement4813@yandex.ru");
    Console.WriteLine();
}

// Печать двумерного массива на экран
void PrintArray2d(int[,] arrayPrint)
{
    for (int i = 0; i < arrayPrint.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < arrayPrint.GetLength(1); j++)
        {
            if (j == (arrayPrint.GetLength(1) - 1))
                Console.WriteLine(String.Format("{0,5}]", arrayPrint[i, j]));
            else
                Console.Write(String.Format("{0,5} ", arrayPrint[i, j]));
        }
    }
}

int[,] CreateSpiral2DArray(int m, int n)
{
    int[,] array2d = new int[m, n];
    int i = 0, j = 0;
    int count = 1;
    int direction = 1;
    bool correct = true;
    while (correct)
    {
        switch (direction)
        {
            case (0):
            {
                if (array2d[i, j + 1] != 0 &&
                    array2d[i + 1, j] != 0)
                {
                    array2d[i, j] = count;
                    correct = !correct;
                }
                else
                {
                    array2d[i, j] = count;
                    count++;
                    j++;
                    direction = 1;
                }
                break;
            }
            case (1):
            {
                if (j < array2d.GetLength(1) - 1 &&
                    array2d[i, j + 1] == 0)
                {
                    array2d[i, j] = count;
                    count++;
                    j++;
                }
                else
                {
                    array2d[i, j] = count;
                    direction = 2;
                }
                break;
            }
            case (2):
            {
                if (i < array2d.GetLength(0) - 1 &&
                    array2d[i + 1, j] == 0)
                {
                    array2d[i, j] = count;
                    count++;
                    i++;
                }
                else
                {
                    array2d[i, j] = count;
                    direction = 3;
                }
                break;
            }
            case (3):
            {
                if (j > 0 &&
                    array2d[i, j - 1] == 0)
                {
                    array2d[i, j] = count;
                    count++;
                    j--;
                }
                else
                {
                    array2d[i, j] = count;
                    direction = 4;
                }
                break;
            }
            case (4):
            {
                if (i > 0 &&
                    array2d[i - 1, j] == 0)
                {
                    array2d[i, j] = count;
                    count++;
                    i--;
                }
                else
                {
                    array2d[i, j] = count;
                    direction = 0;
                }
                break;
            }
        }
    }
    return array2d;
}

//Запрос на количество строк или столбцов в массиве
int GetRowsOrColumnsLengthArray2d(string columnsOrRows)
{
    Console.Write($"Сколько {columnsOrRows} будет в массиве? ");
    int.TryParse(Console.ReadLine(), out int num);
    while (num <= 0)
    {
        Console.WriteLine("Число меньше 1! Массив не может быть создан. Введите заново: ");
        int.TryParse(Console.ReadLine(), out num);
    }
    return num;
}

Console.WriteLine("Программа создаёт двумерный массив, который заполняется спирально (начинается от 1).");
Console.WriteLine("Задайте параметры массива:");
int m = GetRowsOrColumnsLengthArray2d("строк");
int n = GetRowsOrColumnsLengthArray2d("столбцов");
int[,] array2d = CreateSpiral2DArray(m, n);
PrintArray2d(array2d);

Author();