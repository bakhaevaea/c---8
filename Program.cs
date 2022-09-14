using System;

class MyNewClass
{
    public static int[,] GetIntArr()
    {
        //Создает и запоняет массив случайными целыми числами
        System.Console.WriteLine("Введите количество строк ");
        int rows = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Введите количество столбцов ");
        int cols = int.Parse(Console.ReadLine());

        int [,] MyArr = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                MyArr[i,j] =  new Random().Next(-10, 10);
            }
        }
        return MyArr;
    }
    public static void PrintArr(int [,] MyArr)
    {    
        // Печать массива
        for (int i = 0; i < MyArr.GetLength(0); i++)
        {
            for (int j = 0; j < MyArr.GetLength(1); j++)
            {
                System.Console.Write($"{MyArr[i,j]}  ");
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();
    }

    public static void FindRowMin(int [,] MyArr)
    {
         // находим строку с наименьшей суммой элементов.
        int minSum = 0, rowMinSum = 0, itemSum = 0;
        for (int i = 0; i < MyArr.GetLength(0); i++)
        {
            for (int j = 0; j < MyArr.GetLength(1); j++)
            {
                itemSum += MyArr[i, j];
            }
            if (i == 0)  minSum = itemSum; 
            else if (itemSum < minSum)
            {
               minSum = itemSum; 
               rowMinSum = i;
            } 

            itemSum=0;
        } 
        System.Console.WriteLine($"Строку с наименьшей суммой элементов  {rowMinSum}");
    }

    public static int[,] sortRowArr( int [,] MyArr)
    {
        //упорядочит по убыванию элементы каждой строки двумерного массива.
        int rows = MyArr.GetLength(0), cols = MyArr.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {  /// сортировка пузырьком
                for (int k = 0; k < cols -1-j; k++)  
                {
                    if (MyArr[i, k] < MyArr[i, k+1])
                    {
                        int temp = MyArr[i, k];
                        MyArr[i,k] = MyArr[i, k+1];
                        MyArr[i,k+1] = temp;
                    }
                }
            }

        }
        return MyArr;
    }

    public static int[,]  multiArr(int[,] Arr1, int[,] Arr2)
    {
        //Произведение двух матриц
        if ( Arr1.GetLength(1) != Arr2.GetLength(0))
        {
            System.Console.WriteLine("Произведение невозможно");
            return null;
        }
        else 
        {
            int rows = Arr1.GetLength(0), cols = Arr2.GetLength(1);
            int [,] newArr = new int [rows, cols];
            for (int i = 0; i < rows; i++ )
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < Arr1.GetLength(1); k++)
                    {
                        newArr[i,j] += Arr1[i,k]*Arr2[k,j];
                    }
                }
            }
            return  newArr;
        }      
    }

    public static void GetIntArrXYZ()
    {
        //Сформируйте трёхмерный массив из неповторяющихся
        // двузначных чисел. Напишите программу, которая будет построчно выводить
        // массив, добавляя индексы каждого элемента.

        System.Console.WriteLine("Введите X ");
        int X = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Введите Y ");
        int Y = int.Parse(Console.ReadLine());

        System.Console.WriteLine("Введите Z ");
        int Z = int.Parse(Console.ReadLine());

        if (X*Y*Z > 90)
        {
            System.Console.WriteLine("Невозможно задать такой массив");
            return ;
        }
        int [,,] MyArr = new int[X, Y, Z];
        int [] numbers = new int[X*Y*Z];  //массив чисел, присутствующих в трехмерном массиве
        bool foundNum = true;
        int countNum =0; 
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                for (int k = 0; k < Z; k++)
                {
                    while (foundNum)
                    {
                        MyArr[i,j,k] =  new Random().Next(10, 100);
                        foundNum = false;
                        for (int s =0 ; s <X*Y*Z; s++)  //ищем число в массиве имеющихся чисел, чтобы исключить повторение
                        {
                            if (numbers[s] == MyArr[i,j,k])
                            {
                                foundNum = true;
                                break;
                            }
                        }
                    }
                    // не нашли число в массиве имеющихся чисел
                    numbers[countNum] = MyArr[i,j,k];
                    countNum++;
                    foundNum = true;

                }
                
            }
        }

        // Печать трехмерного массива
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                for (int k = 0; k < Z; k++)
                {
                    System.Console.Write($"{MyArr[i,j,k]} ({i}, {j}, {k})    ");
                }
                
            }
            System.Console.WriteLine();
        }
        System.Console.WriteLine();

    }
    public static int[,]  spiralArr(int rows, int cols)
    {
        //Заполните спирально массив 4 на 4.
        int [,] MyArr = new int[rows, cols];
        int number = 1;
        int curentRow = 0, curentCol = 0; 
        while ((curentRow < rows-curentRow) && (curentCol < cols-curentCol))
        {
            for (int j = curentCol; j < cols-curentCol; j++)
            {
                MyArr[curentRow,j] = number; 
                number ++;
            }
            for (int i = curentRow + 1; i < rows-curentRow; i++ )
            {
                MyArr[i,cols-curentCol-1] = number;
                number++;
            }
            for (int j = cols-curentCol-2; j >= curentCol; j-- )
            {
                MyArr[rows - curentRow-1,j] = number;
                number++;
            }
            for (int i = rows - curentRow-2; i > curentRow; i--)
            {
                MyArr[i, curentCol] = number;
                number ++;
            }
             curentRow ++;
             curentCol ++;
        }   
        return MyArr;
    }

    public static int[,] ReverArr(int [,] MyArr)
    {  //меняет местами первую и последнюю строку массива
        int Rows = MyArr.GetLength(0), Cols = MyArr.GetLength(1);
        if (Rows != Cols)
        {
            System.Console.WriteLine("До свидания");
        }
        int temp =0;
        for ( int i = 0; i < Rows; i++ )
        {
            for (int j = i; j < Cols; j++)
            {
               temp = MyArr[j,i];
               MyArr[j,i]=MyArr[i,j];
               MyArr[i,j] = temp;
            }
        }
        return MyArr;
    }
    public static int[,] SlovArr(int [,] MyArr)
    {
        // Составить частотный словарь элементов двумерного массива. 
        int rows = MyArr.GetLength(0), cols = MyArr.GetLength(1);
        int[,] slovar = new int[2, rows*cols];
        int count = 0;   //количество разных цифр в массиве
        bool found = false; 
        slovar[0,0] =MyArr[0,0];
        for ( int i = 0; i < rows; i++ )
        {
            for (int j = 0; j < cols; j++)
            {
                found = false;
                for (int k = 0; k < rows*cols; k++)
                {
                    if  (slovar[0,k] == MyArr[i,j])
                    {
                        slovar [1, k] ++;
                        found = true;
                        break;
                    } 
                    
                }
                if (!found)
                {
                    count++;
                    slovar[0, count] = MyArr[i,j];
                    slovar[1, count] = 1;
                }
                
            }
        }

        return slovar;
    }
     static void Main()
    {
        System.Console.WriteLine("Задача 54: Упорядочит по убыванию элементы каждой строки двумерного массива.");
        System.Console.WriteLine("Задача 56: Программа, которая находит строку с наименьшей суммой элементов.");
        System.Console.WriteLine("Задача 58: Программа, которая находит произведение двух матриц.");
        System.Console.WriteLine("Задача 60: Сформирует трёхмерный массив из неповторяющихся двузначных чисел.");
        System.Console.WriteLine("Задача 62: Заполните спирально массив 4 на 4.");
        
        int Task = int.Parse(Console.ReadLine());
        switch (Task)
        {
            case 54: 
            { 
                int[,]  Array = GetIntArr();
                PrintArr(Array);
                Array = sortRowArr(Array);
                PrintArr(Array);
                break;
            }
            
            case 56: 
            { 
                int[,]  Array = GetIntArr();
                PrintArr(Array);
                FindRowMin(Array);
                break;
            }
                       
            case 58: 
            { 
                System.Console.WriteLine("Первая матрица");
                int[,]  Array1 = GetIntArr();
                PrintArr(Array1);
                System.Console.WriteLine("Вторая матрица");
                int[,]  Array2 = GetIntArr();
                PrintArr(Array2);
                int [,] multi = multiArr(Array1, Array2);
                if (multi != null)
                    PrintArr(multi);
                
                break;
            }
            
            case 60: 
            { 
                GetIntArrXYZ();
                break;
            }
            
            case 62: 
            { 
                System.Console.WriteLine("Введите размерность массива ");
                int X = int.Parse(Console.ReadLine());
                int[,]  Array = spiralArr(X,X);
                PrintArr(Array);
                break;
            }

            default: break;
        }


   
    }
}