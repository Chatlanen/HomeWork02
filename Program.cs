

int [,] Create2dArray(int row, int col, int min, int max){
    int [,] array = new int [row,col];
    for (int i =0; i<row; i++){
        for(int j = 0; j<col;j++){
            array[i,j] = new Random().Next(min, max+1);
        }
    }
    return array;
}


void Show2dArray(int [,] array){
    for(int i = 0; i<array.GetLength(0); i++){
        for(int j=0; j<array.GetLength(1); j++){
            Console.Write(array[i,j]+" ");
        }
        Console.WriteLine();
    }
}

int [,] swapLine(int [,] arr){
    int tmp = 0;
    for (int i=0; i<arr.GetLength(1); i++){
        tmp = arr[0, i];
        arr[0, i] = arr[arr.GetLength(0)-1, i];
        arr[arr.GetLength(0)-1, i] = tmp;
    }
    return arr;
}






//Задача 1: Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.

Console.WriteLine("\nЗадание 1");

int [,] arr = Create2dArray(5,6,1,20);
int n_row, n_col = 0;
Show2dArray(arr);
Console.Write ("Введите номер строки:");
n_row =  Convert.ToInt32(Console.ReadLine());
Console.Write ("Введите номер столбца:");
n_col = Convert.ToInt32(Console.ReadLine());
if (n_row < arr.GetLength(0) && n_col < arr.GetLength(1)){
    Console.WriteLine($"Значение [{n_row},{n_col}]:{arr[n_row, n_col]}");
} else {
    Console.WriteLine($"Нет такого элемента");
}


//Задача 2: Задайте двумерный массив. Напишите программу,
// которая поменяет местами первую и последнюю строку массива.

Console.WriteLine("\nЗадание 2");

arr = Create2dArray(3,4,10,99);
Show2dArray(arr);
swapLine(arr);
Console.WriteLine();
Show2dArray(arr);
Console.WriteLine();


// Задача 3: Задайте прямоугольный двумерный массив.
// Напишите программу, которая будет находить строку с наименьшей суммой элементов.

Console.WriteLine("\nЗадание 3");

void getMinSumLine(int [,] arr){
    int min = -1;
    int indx = 0;
    for(int i = 0; i<arr.GetLength(0); i++){
        int lineSum = 0;
        for(int j=0; j<arr.GetLength(1); j++){
            lineSum += arr[i,j];
        }
        min = (i == 0)?(lineSum):(min);
        if (lineSum < min){
            min = lineSum;
            indx = i;
        }
    }    
    Console.WriteLine($"Минимальная сумма {min} в строке с индексом {indx}");
}


arr = Create2dArray(3,4,-9,9);
Show2dArray(arr);
getMinSumLine(arr);

//Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. Напишите программу,
// которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива.
// Под удалением понимается создание нового двумерного массива без строки и столбца

Console.WriteLine("\nЗадание 4");

int [,] delMinLines (int [,] arr){
    int [,] res = new int [arr.GetLength(0)-1,arr.GetLength(1)-1];
    int min = arr[0,0];
    int min_i =0;
    int min_j = 0;
    for(int i = 0; i<arr.GetLength(0); i++){
        for(int j=0; j<arr.GetLength(1); j++){
        if (arr[i,j] < min){
            min = arr[i,j];
            min_i = i;
            min_j = j;
        }
        }
    } 
    Console.WriteLine($"Удаляем строку {min_i} и столбец {min_j}");
    int new_i = 0;
    int new_j = 0;
    for(int i = 0; i<arr.GetLength(0); i++){
        new_j = 0;
        if (i != min_i){
            for(int j=0; j<arr.GetLength(1); j++){
                if (j != min_j){
                    res[new_i, new_j] = arr[i,j];
                    new_j++;
                }
            }
            new_i++;
        }
    } 

    return res;
}


arr = Create2dArray(3,4,1,9);
Show2dArray(arr);
arr = delMinLines(arr);
Show2dArray(arr);