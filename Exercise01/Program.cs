/***********************/
/*****Te3Ka_PaynE*******/
/*Mnement4813@yandex.ru*/
/***********************/

/*
Задайте двумерный массив.
Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
В итоге получается вот такой массив:
7 4 2 1
9 5 3 2
8 4 4 2
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

//Создание случайного двумерного массива
int[,] CreateRandom2DArray(int m, int n, int min, int max)
{
    int[,] array2D = new int[m, n];
    Random random = new Random();
    for (int i = 0; i < array2D.GetLength(0); i++)
    {
        for (int j = 0; j < array2D.GetLength(1); j++)
        {
            array2D[i,j] = random.Next(min, max + 1);
        }
    }
    return array2D;
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

//Получение минимума или максимума от пользователя
int GetMinMax(string minOrMax)
{
    Console.Write($"Введите значение {minOrMax}: ");
    int.TryParse(Console.ReadLine(), out int result);
    return result;
}

// Сортировка массива по убыванию
int[,] SortArray2d(int[,] oldArray2d)
{
	int[,] sortArray2d = new int[oldArray2d.GetLength(0), oldArray2d.GetLength(1)];
	sortArray2d = oldArray2d;
	int temp = 0;
	int max = 0;
	for (int i = 0; i < sortArray2d.GetLength(0); i++)
	{
		for (int j = 0; j < sortArray2d.GetLength(1) - 1; j++)
		{
			for (int k = j + 1; k < sortArray2d.GetLength(1); k++)
			{
				max = sortArray2d[i, j];
				if (max < sortArray2d[i, k])
				{
					temp = sortArray2d[i, k];
					sortArray2d[i, k] = sortArray2d[i, j];
					sortArray2d[i, j] = temp;
				}
			}
		}
	}
	return sortArray2d;
}

Console.WriteLine("Программа создаёт случайный двумерный массив.");
Console.WriteLine("После программа сортирует каждую строку массива по убыванию и создаёт новый массив");

int m = GetRowsOrColumnsLengthArray2d("строк");
int n = GetRowsOrColumnsLengthArray2d("столбцов");
int min = GetMinMax("минимума");
int max = GetMinMax("максимума");

int[,] array2d = CreateRandom2DArray(m, n, min, max);
Console.WriteLine();
Console.WriteLine("Сгенерированный массив:");
PrintArray2d(array2d);
int[,] sortArray2d = SortArray2d(array2d);
Console.WriteLine();
Console.WriteLine("Отсортированный массив:");
PrintArray2d(sortArray2d);

Author();