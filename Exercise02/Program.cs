/***********************/
/*****Te3Ka_PaynE*******/
/*Mnement4813@yandex.ru*/
/***********************/

/*
Задайте прямоугольный двумерный массив.
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке
и выдаёт номер строки с наименьшей суммой элементов: 1 строка
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

//Подсчёт суммы в каждой строке и возврат минимальной суммы.
int MinimumSummaryLength(int[,] array2d)
{
	int[] summaryArray = new int[array2d.GetLength(0)];
	for (int i = 0; i < array2d.GetLength(0); i++)
	{
		for (int j = 0; j < array2d.GetLength(1); j++)
		{
			summaryArray[i] += array2d[i, j];
		}
	}
	int minSum = summaryArray[0];
	int minLengthNumber = 0;
	for (int i = 0; i < summaryArray.GetLength(0); i++)
	{
		if (minSum > summaryArray[i])
		{
			minSum = summaryArray[i];
			minLengthNumber = i;
		}
	}	
	return minLengthNumber + 1;
}

Console.WriteLine("Программа создаёт случайный двумерный массив.");
Console.WriteLine("После программа показывает строку с наименьшей суммой элементов.");

int m = GetRowsOrColumnsLengthArray2d("строк");
int n = GetRowsOrColumnsLengthArray2d("столбцов");
int min = GetMinMax("минимума");
int max = GetMinMax("максимума");

int[,] array2d = CreateRandom2DArray(m, n, min, max);
Console.WriteLine();
Console.WriteLine("Сгенерированный массив:");
PrintArray2d(array2d);

int number = MinimumSummaryLength(array2d);
Console.WriteLine("Строка с минимальной суммой элементов = " + number);
Author();