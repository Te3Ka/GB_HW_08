/***********************/
/*****Te3Ka_PaynE*******/
/*Mnement4813@yandex.ru*/
/***********************/

/*
Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
Массив размером 2 x 2 x 2
66(0,0,0) 25(0,1,0)
34(1,0,0) 41(1,1,0)
27(0,0,1) 90(0,1,1)
26(1,0,1) 55(1,1,1)
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
void PrintArray3d(int[,,] arrayPrint)
{
    for (int i = 0; i < arrayPrint.GetLength(0); i++)
    {
        for (int j = 0; j < arrayPrint.GetLength(1); j++)
        {
            for (int k = 0; k < arrayPrint.GetLength(2); k++)
            {
                Console.Write(String.Format("{0,6} ", arrayPrint[i, j, k]));
                Console.Write(String.Format("({0,2},", i));
                Console.Write(String.Format("{0,2},", j));
                Console.Write(String.Format("{0,2});", k));
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

//Создание случайного трёхмерного массива
int[,,] CreateRandom3DArray(int m, int n, int l, int min, int max)
{
    int[,,] array3D = new int[m, n, l];
    Random random = new Random();
    for (int i = 0; i < array3D.GetLength(0); i++)
    {
        for (int j = 0; j < array3D.GetLength(1); j++)
        {
            for (int k = 0; k < array3D.GetLength(2); k++)
            {
                array3D[i, j, k] = random.Next(min, max + 1);
                for (int o = 0; o < array3D.GetLength(0); o++)
                {
                    for (int p = 0; p < array3D.GetLength(1); p++)
                    {
                        for (int q = 0; q < array3D.GetLength(2); q++)
                        {
                            if (o == i && p == j && q == k)
                                break;
                            else
                            {
                                if (array3D[o, p, q] == array3D[i, j, k])
                                {

                                    array3D[i, j, k] = random.Next(min, max + 1);
                                    o = 0;
                                    p = 0;
                                    q = -1;

                                }
                            }
                        }
                    }
                }
            }
        }
    }
    return array3D;
}

//Запрос на размер измерений в массиве
int GetDemension(string demension)
{
    Console.Write($"{demension} измерение. Сколько элементов будет? ");
    int.TryParse(Console.ReadLine(), out int num);
    while (num <= 0)
    {
        Console.WriteLine("Число меньше 1! Массив не может быть создан. Введите заново: ");
        int.TryParse(Console.ReadLine(), out num);
    }
    return num;
}

Console.WriteLine("Программа создаёт трёхмерный массив из случайных двузначных неповторяющихся чисел.");
Console.WriteLine("Примечание: так как всего двузначных чисел 90 штук, вводить параметры матрицы\n"
                + "на большее значние элементов не стоит, это преведёт к прерыванию программы.");
Console.WriteLine("Задайте параметры для генерации массива:");
int m = GetDemension("Первое");
int n = GetDemension("Второе");
int l = GetDemension("Третье");

if ((m * n * l) > 90)
{
    Console.WriteLine("В генерируемом массиве может быть только 90 элементов.\n"
                    + "Введены размеры, превышающее ограничение.\n"
                    + "Выполнение программы прервано");
    Author();
    return;
}

int min = 10;
int max = 99;
int[,,] array3d = CreateRandom3DArray(m, n, l, min, max);
PrintArray3d(array3d);

Author();