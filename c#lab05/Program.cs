using System;

class MyMatrix
{
    // Поля для хранения матрицы и размеров
    private int[,] matrix; // Двумерный массив
    private int rows; // Число строк
    private int cols; // Число столбцов
    private Random random = new Random(); // Для генерации случайных чисел

    // Конструктор, создающий матрицу с заданными размерами и заполняющий её случайными числами
    public MyMatrix(int rows, int cols, int minValue, int maxValue)
    {
        this.rows = rows; // Устанавливаем число строк
        this.cols = cols; // Устанавливаем число столбцов
        matrix = new int[rows, cols]; // Создаем матрицу
        Fill(minValue, maxValue); // Заполняем матрицу случайными значениями
    }

    // Метод для заполнения матрицы случайными значениями
    public void Fill(int minValue, int maxValue)
    {
        for (int i = 0; i < rows; i++) // Цикл по строкам
        {
            for (int j = 0; j < cols; j++) // Цикл по столбцам
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1); // Присваиваем случайное значение элементу матрицы
            }
        }
    }

    // Метод для изменения размера матрицы с копированием существующих значений
    public void ChangeSize(int newRows, int newCols, int minValue, int maxValue)
    {
        int[,] newMatrix = new int[newRows, newCols]; // Создаем новую матрицу с новыми размерами

        // Копируем значения из старой матрицы в новую
        for (int i = 0; i < Math.Min(rows, newRows); i++) // Проходим по минимальному числу строк
        {
            for (int j = 0; j < Math.Min(cols, newCols); j++) // Проходим по минимальному числу столбцов
            {
                newMatrix[i, j] = matrix[i, j]; // Копируем значения
            }
        }

        // Заполняем новые элементы матрицы случайными значениями, если размер увеличился
        for (int i = 0; i < newRows; i++) // Проходим по всем строкам новой матрицы
        {
            for (int j = 0; j < newCols; j++) // Проходим по всем столбцам новой матрицы
            {
                if (i >= rows || j >= cols) // Если мы вышли за пределы старой матрицы
                {
                    newMatrix[i, j] = random.Next(minValue, maxValue + 1); // Заполняем случайными значениями
                }
            }
        }

        // Обновляем матрицу и её размеры
        matrix = newMatrix;
        rows = newRows;
        cols = newCols;
    }

    // Метод для вывода части матрицы, задаваемой диапазоном строк и столбцов
    public void ShowPartially(int startRow, int endRow, int startCol, int endCol)
    {
        for (int i = startRow; i <= endRow && i < rows; i++) // Проходим по заданным строкам
        {
            for (int j = startCol; j <= endCol && j < cols; j++) // Проходим по заданным столбцам
            {
                Console.Write(matrix[i, j] + "\t"); // Выводим элемент матрицы
            }
            Console.WriteLine(); // Переход на новую строку после каждого ряда
        }
    }

    // Метод для вывода всей матрицы
    public void Show()
    {
        for (int i = 0; i < rows; i++) // Проходим по строкам
        {
            for (int j = 0; j < cols; j++) // Проходим по столбцам
            {
                Console.Write(matrix[i, j] + "\t"); // Выводим элемент матрицы
            }
            Console.WriteLine(); // Переход на новую строку после каждого ряда
        }
    }

    // Индексатор для доступа к элементам матрицы по индексу
    public int this[int row, int col]
    {
        get
        {
            return matrix[row, col]; // Возвращаем элемент по указанным индексам строки и столбца
        }
        set
        {
            matrix[row, col] = value; // Устанавливаем новое значение элементу по указанным индексам
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Вводим параметры для создания матрицы
        Console.WriteLine("Введите количество строк:");
        int rows = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите количество столбцов:");
        int cols = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите минимальное значение для элементов матрицы:");
        int minValue = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите максимальное значение для элементов матрицы:");
        int maxValue = int.Parse(Console.ReadLine());

        // Создаем объект MyMatrix
        MyMatrix matrix = new MyMatrix(rows, cols, minValue, maxValue);

        // Выводим начальную матрицу
        Console.WriteLine("\nСгенерированная матрица:");
        matrix.Show();

        // Меняем размер матрицы
        Console.WriteLine("\nИзменение размера матрицы...");
        Console.WriteLine("Введите новое количество строк:");
        int newRows = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите новое количество столбцов:");
        int newCols = int.Parse(Console.ReadLine());

        matrix.ChangeSize(newRows, newCols, minValue, maxValue);

        // Выводим измененную матрицу
        Console.WriteLine("\nМатрица после изменения размера:");
        matrix.Show();

        // Выводим часть матрицы
        Console.WriteLine("\nЧастичный вывод матрицы:");
        Console.WriteLine("Введите начальную строку (нумерация с 0):");
        int startRow = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите конечную строку (нумерация с 0):");
        int endRow = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите начальный столбец (нумерация с 0):");
        int startCol = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите конечный столбец (нумерация с 0):");
        int endCol = int.Parse(Console.ReadLine());

        matrix.ShowPartially(startRow, endRow, startCol, endCol);

        // Использование индексатора для изменения элемента
        Console.WriteLine("\nИзменение элемента матрицы с помощью индексатора:");
        Console.WriteLine("Введите номер строки для изменения:");
        int rowToChange = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите номер столбца для изменения:");
        int colToChange = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите новое значение:");
        int newValue = int.Parse(Console.ReadLine());

        matrix[rowToChange, colToChange] = newValue; // Изменяем элемент с помощью индексатора

        // Выводим матрицу после изменения элемента
        Console.WriteLine("\nМатрица после изменения элемента:");
        matrix.Show();
    }
}