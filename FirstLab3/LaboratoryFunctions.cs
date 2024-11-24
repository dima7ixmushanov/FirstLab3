using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLabIVT2
{
    internal class LaboratoryFunctions
    {
        public class ArrayCreator 
        {
            private Random random = new Random();

            public void TransformArray()
            {
                Console.Write("Введите количество элементов массива: ");
                if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
                {
                    Console.WriteLine("Некорректное значение. Попробуйте еще раз.");
                    return;
                }

                int[] array = new int[n];

                for (int i = 0; i < n; i++)
                {
                    array[i] = random.Next(-30, 46);
                }

                Console.WriteLine("\nМассив:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"{array[i],4} ");
                    if ((i + 1) % 10 == 0 || i == n - 1)
                    {
                        Console.WriteLine();
                    }
                }

                Console.WriteLine("\nЭлементы массива в обратном порядке (только положительные):");
                for (int i = n - 1; i >= 0; i--)
                {
                    if (array[i] >= 0)
                    {
                        Console.Write($"{array[i],4} ");
                    }
                }
                Console.WriteLine();
            }
        }

        public class ArrayRotationer 
        {

            private Random random = new Random();

            public void ProcessRotation()
            {
                int[,] matrix = new int[7, 7];
                ArrayFilling(matrix);
                Console.WriteLine("Исходный массив:");
                ArrayDisplaying(matrix);
                RotateArray(matrix);
                Console.WriteLine("\nМассив после поворота:");
                ArrayDisplaying(matrix);
            }

            private void ArrayFilling(int[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        array[i, j] = random.Next(1, 100);
                    }
                }
            }


            private void RotateArray(int[,] array)
            {
                int n = array.GetLength(0);
                for (int layer = 0; layer < n / 2; layer++)
                {
                    int first = layer;
                    int last = n - 1 - layer;
                    for (int i = first; i < last; i++)
                    {
                        int offset = i - first;

                        int top = array[first, i];

                        array[first, i] = array[last - offset, first];

                        array[last - offset, first] = array[last, last - offset];

                        array[last, last - offset] = array[i, last];

                        array[i, last] = top;
                    }
                }
            }


            private void ArrayDisplaying(int[,] array)
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        Console.Write($"{array[i, j],4} ");
                    }
                    Console.WriteLine();
                }
            }
        }
        public class CyclicalArrayRotationer
        {
            private Random random = new Random();

            public void ProcessShift()
            {
                Console.Write("Введите количество элементов массива: ");
                if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
                {
                    Console.WriteLine("Некорректное значение.");
                    return;
                }

                int[] array = new int[n];

                for (int i = 0; i < n; i++)
                {
                    array[i] = random.Next(1, 100);
                }

                Console.WriteLine("Исходный массив:");
                ArrayDisplaying(array);

                Console.Write("Введите количество позиций для сдвига влево: ");
                if (!int.TryParse(Console.ReadLine(), out int k) || k < 0)
                {
                    Console.WriteLine("Некорректное значение. Попробуйте еще раз.");
                    return;
                }

                ShiftLeft(array, k);

                Console.WriteLine($"Массив после сдвига влево на {k} позиций:");
                ArrayDisplaying(array);
            }

            private void ShiftLeft(int[] array, int k)
            {
                int n = array.Length;
                k = k % n;
                int[] temp = new int[k];

                Array.Copy(array, temp, k);

                for (int i = 0; i < n - k; i++)
                {
                    array[i] = array[i + k];
                }

                for (int i = 0; i < k; i++)
                {
                    array[n - k + i] = temp[i];
                }
            }

            private void ArrayDisplaying(int[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{array[i],4} ");
                    if ((i + 1) % 10 == 0 || i == array.Length - 1)
                    {
                        Console.WriteLine();
                    }
                }
            }




        }
        public class MatrixCalc
        {
            public int[,] AddMatrix(int[,] matrix1, int[,] matrix2, out double average)
            {
                int[,] result = new int[3, 3];
                int sum = 0;
                int totalElements = matrix1.Length * 2;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        result[i, j] = matrix1[i, j] + matrix2[i, j];
                        sum += matrix1[i, j] + matrix2[i, j];
                    }
                }

                average = (double)sum / totalElements;
                return result;
            }

            public int[,] SubtractMatrix(int[,] matrix1, int[,] matrix2, out double average)
            {
                int[,] result = new int[3, 3];
                int sum = 0;
                int totalElements = matrix1.Length * 2;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        result[i, j] = matrix1[i, j] - matrix2[i, j];
                        sum += matrix1[i, j] + matrix2[i, j];
                    }
                }

                average = (double)sum / totalElements;
                return result;


            }

            public void PrintMatrix(int[,] matrix)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(matrix[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
            }


        }

        public class MatrixMultiplier 
        {
            private Random random = new Random();

            public void ProcessMultiplication()
            {
                int[,] matrixA = new int[5, 5];
                int[,] matrixB = new int[5, 5];
                int[,] resultMatrix = new int[5, 5];

                Console.WriteLine("Первая матрица:");
                FillMatrix(matrixA);
                PrintMatrix(matrixA);

                Console.WriteLine("\nВторая матрица:");
                FillMatrix(matrixB);
                PrintMatrix(matrixB);

                MultiplyMatrix(matrixA, matrixB, resultMatrix);

                Console.WriteLine("\nРезультат матрицы после перемножения:");
                PrintMatrix(resultMatrix);
            }

            private void FillMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[i, j] = random.Next(1, 11);
                    }
                }
            }

            private void MultiplyMatrix(int[,] matrixA, int[,] matrixB, int[,] resultMatrix)
            {
                for (int i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixB.GetLength(1); j++)
                    {
                        resultMatrix[i, j] = 0;
                        for (int k = 0; k < matrixA.GetLength(1); k++)
                        {
                            resultMatrix[i, j] += matrixA[i, k] * matrixB[k, j];
                        }
                    }
                }
            }

            private void PrintMatrix(int[,] matrix)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write($"{matrix[i, j],4} ");
                    }
                    Console.WriteLine();
                }
            }
        }

        public class ArrayOperations 
        {
            public int SumIterative(int[] array)
            {
                int sum = 0;
                foreach (int num in array)
                {
                    sum += num;
                }
                return sum;
            }

            public int SumRecursive(int[] array, int index = 0)
            {
                if (index >= array.Length)
                    return 0;
                return array[index] + SumRecursive(array, index + 1);
            }

            public int MinIterative(int[] array)
            {
                int min = array[0];
                foreach (int num in array)
                {
                    if (num < min)
                    {
                        min = num;
                    }
                }
                return min;
            }

            public int MinRecursive(int[] array, int index = 0)
            {
                if (index == array.Length - 1)
                    return array[index];

                int min = MinRecursive(array, index + 1);
                return array[index] < min ? array[index] : min;
            }
        }
        public class FibonaciCalc
        {
            public int Fibonacci(int n)
            {
                if (n <= 1)
                    return 1;
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
        }

        public class DetermCalculator 
        {
            public int CalculateDeterminant(int[,] matrix)
            {
                int n = matrix.GetLength(0);

                if (n == 1)
                    return matrix[0, 0];

                if (n == 2)
                    return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

                int determinant = 0;

                for (int k = 0; k < n; k++)
                {
                    int sign = (k % 2 == 0) ? 1 : -1;
                    int[,] minor = GetMinor(matrix, 0, k);
                    determinant += sign * matrix[0, k] * CalculateDeterminant(minor);
                }

                return determinant;
            }

            private int[,] GetMinor(int[,] matrix, int rowToRemove, int colToRemove)
            {
                int n = matrix.GetLength(0);
                int[,] minor = new int[n - 1, n - 1];

                int r = 0;
                for (int i = 0; i < n; i++)
                {
                    if (i == rowToRemove)
                        continue;

                    int c = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j == colToRemove)
                            continue;

                        minor[r, c] = matrix[i, j];
                        c++;
                    }
                    r++;
                }

                return minor;

            }
        }


        public class SecondVariantMatrixTask
        {
            private int n; 
            private int[,] matrix;

            public SecondVariantMatrixTask(int size)
            {
                n = size;
                matrix = new int[n, n];
                FillMatrixWithRandomNumbers();
            }

            private void FillMatrixWithRandomNumbers()
            {
                Random random = new Random();
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = random.Next(1, 100); 
                    }
                }
            }

            public int[,] TransposeMatrix()
            {
                int[,] transposed = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        transposed[j, i] = matrix[i, j];
                    }
                }
                return transposed;
            }

            public void PrintMatrix(int[,] matrixToPrint)
            {
                for (int i = 0; i < matrixToPrint.GetLength(0); i++)
                {
                    for (int j = 0; j < matrixToPrint.GetLength(1); j++)
                    {
                        Console.Write(matrixToPrint[i, j].ToString().PadLeft(4));
                    }
                    Console.WriteLine();
                }
            }

            public void PrintOriginalMatrix()
            {
                PrintMatrix(matrix);
            }
        }

        public class RaznostMatrix
        {
            private int[] array; 
            private int n;       

            public void InputArraySize()
            {
                Console.WriteLine("Введите четное количество элементов массива (N):");

                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out n) && n > 0 && n % 2 == 0)
                    {
                        break;
                    }
                    Console.WriteLine("Ошибка! Введите положительное четное число.");
                }

                array = new int[n];
            }

            public void InputArrayElements()
            {
                Console.WriteLine($"Введите {n} элементов массива:");
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"Элемент [{i + 1}]: ");
                    while (!int.TryParse(Console.ReadLine(), out array[i]))
                    {
                        Console.WriteLine("Ошибка! Введите корректное число.");
                        Console.Write($"Элемент [{i + 1}]: ");
                    }
                }
            }

            public void PrintArray()
            {
                Console.WriteLine("Ваш массив:");
                Console.WriteLine(string.Join(" ", array));
            }

            public void CalculateDifference()
            {
                int leftSum = 0, rightSum = 0;

                for (int i = 0; i < n / 2; i++)
                {
                    leftSum += array[i];
                }

                for (int i = n / 2; i < n; i++)
                {
                    rightSum += array[i];
                }

                int result = rightSum - leftSum;
                Console.WriteLine($"Сумма левой половины: {leftSum}");
                Console.WriteLine($"Сумма правой половины: {rightSum}");
                Console.WriteLine($"Результат (правая - левая): {result}");
            }
        }
    }
}

