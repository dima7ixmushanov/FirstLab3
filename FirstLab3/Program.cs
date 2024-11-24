using ThirdLabIVT2;
using static ThirdLabIVT2.LaboratoryFunctions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("1) Создать массив случайных чисел");
        Console.WriteLine("2) Повернуть двумерный массив 7x7 на 90 градусов по часовой стрелке");
        Console.WriteLine("3) Сдвинуть массив влево циклически");
        Console.WriteLine("4) Сложение и вычитание элементов двух 3x3 матриц");
        Console.WriteLine("5) Перемножить две матрицы размером 5x5");
        Console.WriteLine("6) Показать примеры работы функций");
        Console.WriteLine("7) Найти n-й элемент последовательности Фибоначчи");
        Console.WriteLine("8) Рассчитать определитель матрицы размером NxN");
        Console.WriteLine("9) Заполнить массив (второй вариант)");
        Console.WriteLine("10) Вывести на экран результат вычитания суммы элементов левой половины массива из суммы элементов правой половины массива.");

        int function_choice = int.Parse(Console.ReadLine());

        switch (function_choice)
        {
            case 1:

                LaboratoryFunctions.ArrayCreator ArrayCreator = new LaboratoryFunctions.ArrayCreator();
                ArrayCreator.TransformArray();

                break;

            case 2:

                LaboratoryFunctions.ArrayRotationer ArrayRotationer = new LaboratoryFunctions.ArrayRotationer();
                ArrayRotationer.ProcessRotation();

                break;
            case 3:

                LaboratoryFunctions.CyclicalArrayRotationer CyclicalArrayRotationer= new LaboratoryFunctions.CyclicalArrayRotationer();
                CyclicalArrayRotationer.ProcessShift();
                break;

            case 4:

                LaboratoryFunctions.MatrixCalc calculator = new LaboratoryFunctions.MatrixCalc();

                int[,] matrix1 = new int[3, 3];
                int[,] matrix2 = new int[3, 3];

                Console.WriteLine("Введите элементы для первого массива 3x3:");
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        matrix1[i, j] = int.Parse(Console.ReadLine());

                Console.WriteLine("Введите элементы для второго массива 3x3:");
                for (int i = 0; i < 3; i++)
                    for (int j = 0; j < 3; j++)
                        matrix2[i, j] = int.Parse(Console.ReadLine());

                double averageAdd;
                int[,] sumMatrix = calculator.AddMatrix(matrix1, matrix2, out averageAdd);

                Console.WriteLine("Результат сложения:");
                calculator.PrintMatrix(sumMatrix);
                Console.WriteLine($"Среднее значение элементов (сложение): {averageAdd}");

                double averageSubtract;
                int[,] diffMatrix = calculator.SubtractMatrix(matrix1, matrix2, out averageSubtract);

                Console.WriteLine("Результат вычитания:");
                calculator.PrintMatrix(diffMatrix);
                Console.WriteLine($"Среднее значение элементов (вычитание): {averageSubtract}");


                break;
            case 5:

                LaboratoryFunctions.MatrixMultiplier matrixMultiplier = new LaboratoryFunctions.MatrixMultiplier();
                matrixMultiplier.ProcessMultiplication();

                break;
            case 6:

                int[] array = { 4, -2, 7, 1, 9, -5, 3 };
                LaboratoryFunctions.ArrayOperations operations = new LaboratoryFunctions.ArrayOperations();

                Console.WriteLine("Массив: " + string.Join(", ", array));

                Console.WriteLine("Итеративная сумма: " + operations.SumIterative(array));
                Console.WriteLine("Рекурсивная сумма: " + operations.SumRecursive(array));

                Console.WriteLine("Итеративный минимум: " + operations.MinIterative(array));
                Console.WriteLine("Рекурсивный минимум: " + operations.MinRecursive(array));

                break;
            case 7:

                LaboratoryFunctions.FibonaciCalc fib_calculator = new LaboratoryFunctions.FibonaciCalc();

                Console.Write("Введите номер элемента ряда Фибоначчи: ");
                int n = int.Parse(Console.ReadLine());

                int result = fib_calculator.Fibonacci(n);
                Console.WriteLine($"{n}-й член ряда Фибоначчи: {result}");

                break;
            case 8:

                LaboratoryFunctions.DetermCalculator determinant_calculator = new LaboratoryFunctions.DetermCalculator();

                int[,] matrix = {
                        { 1, 2, 3 },
                        { 0, 4, 5 },
                        { 1, 0, 6 }
                    };

                int deter_result = determinant_calculator.CalculateDeterminant(matrix);
                Console.WriteLine("Определитель матрицы: " + deter_result);

                break;
            case 9:

                SecondVariantMatrixTask task = new SecondVariantMatrixTask(5);

                Console.WriteLine("Исходная матрица:");
                task.PrintOriginalMatrix();

                Console.WriteLine("Транспонированная матрица:");
                int[,] transposedMatrix = task.TransposeMatrix();
                task.PrintMatrix(transposedMatrix);
                break;

            case 10:

                RaznostMatrix matrixTask = new RaznostMatrix();

                matrixTask.InputArraySize();
                matrixTask.InputArrayElements();

                matrixTask.PrintArray();

                matrixTask.CalculateDifference();

                break;

        }
    }
}