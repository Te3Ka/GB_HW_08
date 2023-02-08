/***********************/
/*****Te3Ka_PaynE*******/
/*Mnement4813@yandex.ru*/
/***********************/

/*
Задайте две матрицы.
Напишите программу, которая будет находить произведение двух матриц.
Например, даны 2 матрицы:
2 4 | 3 4
3 2 | 3 3
Результирующая матрица будет:
18 20
15 18
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


//Произведение двух матриц
int[,] PowTwoMatrix(int[,] arrayOne, int[,] arrayTwo)
{
	int[,] resultMatrix = new int[arrayOne.GetLength(0), arrayTwo.GetLength(1)];
	for (int i = 0; i < resultMatrix.GetLength(0); i++)
	{
		for (int j = 0; j < resultMatrix.GetLength(0); j++)
		{
			for (int k = 0; k < arrayOne.GetLength(1); k++)
			{
				resultMatrix[i, j] += arrayOne[i, k] * arrayTwo[k, j];
			}
		}
	}
	return resultMatrix;
}

Console.WriteLine("Программа создаёт два случайных двумерных массива.");
Console.WriteLine("Затем перемножает их, если это возможно.");

Console.WriteLine("Задайте параметры первой матрицы:");
int m = GetRowsOrColumnsLengthArray2d("строк");
int n = GetRowsOrColumnsLengthArray2d("столбцов");
int min = GetMinMax("минимума");
int max = GetMinMax("максимума");
int[,] array2dOne = CreateRandom2DArray(m, n, min, max);

Console.WriteLine();
Console.WriteLine("Задайте параметры второй матрицы:");
m = GetRowsOrColumnsLengthArray2d("строк");
n = GetRowsOrColumnsLengthArray2d("столбцов");
min = GetMinMax("минимума");
max = GetMinMax("максимума");
int[,] array2dTwo = CreateRandom2DArray(m, n, min, max);

Console.WriteLine();
Console.WriteLine("Сгенерированная первая матрица:");
PrintArray2d(array2dOne);
Console.WriteLine();
Console.WriteLine("Сгенерированная вторая матрица:");
PrintArray2d(array2dTwo);

if (array2dOne.GetLength(1) != array2dTwo.GetLength(0))
{
	Console.WriteLine("Выполнение умножения двух матриц невозможно,\n"
					+ "так как количество столбцов первой матрицы\n"
					+ "не равно количеству строк второй матрицы.");
	Author();
	return;
}

int[,] powMatrix = PowTwoMatrix(array2dOne, array2dTwo);
Console.WriteLine();
Console.WriteLine("Произведение двух матриц:");
PrintArray2d(powMatrix);

Author();