namespace lab5_1
{

    using System;

    public class MyMatrix
    {
        private int[,] matrix;
        private int rows;
        private int columns;
        private Random random = new Random();

        // Конструктор, инициализирующий матрицу случайными числами
        public MyMatrix(int rows, int columns, int minValue, int maxValue)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new int[rows, columns];
            Fill(minValue, maxValue);
        }

        // Метод Fill для заполнения матрицы случайными значениями
        public void Fill(int minValue, int maxValue)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = random.Next(minValue, maxValue + 1);
                }
            }
        }

        // Метод ChangeSize для изменения размера матрицы с копированием существующих значений
        public void ChangeSize(int newRows, int newColumns, int minValue, int maxValue)
        {
            int[,] newMatrix = new int[newRows, newColumns];

            // Копирование значений из старой матрицы в новую
            for (int i = 0; i < Math.Min(rows, newRows); i++)
            {
                for (int j = 0; j < Math.Min(columns, newColumns); j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }
            }

            // Заполнение новых ячеек случайными значениями, если новая матрица больше старой
            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newColumns; j++)
                {
                    if (i >= rows || j >= columns)
                    {
                        newMatrix[i, j] = random.Next(minValue, maxValue + 1);
                    }
                }
            }

            matrix = newMatrix;
            rows = newRows;
            columns = newColumns;
        }

        // Метод ShowPartialy для вывода части матрицы
        public void ShowPartialy(int startRow, int startColumn, int endRow, int endColumn)
        {
            for (int i = startRow; i <= endRow && i < rows; i++)
            {
                for (int j = startColumn; j <= endColumn && j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Метод Show для вывода всей матрицы
        public void Show()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Индексатор для доступа к элементам матрицы
        public int this[int index1, int index2]
        {
            get
            {
                if (index1 < 0 || index1 >= rows || index2 < 0 || index2 >= columns)
            {
                    throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы");
                }
                return matrix[index1, index2];
            }
            set
            {
                if (index1 < 0  || index1 >= rows || index2 < 0 || index2 >= columns)
            {
                    throw new IndexOutOfRangeException("Индексы выходят за пределы матрицы");
                }
                matrix[index1, index2] = value;
            }
        }

    }

    public class Program
    {

        public static void Main()
        {
            Console.WriteLine("Введите количество строк и столбцов:");
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите минимальное и максимальное значения для случайных чисел:");
            int minValue = int.Parse(Console.ReadLine());
            int maxValue = int.Parse(Console.ReadLine());

            MyMatrix matrix = new MyMatrix(rows, columns, minValue, maxValue);

            Console.WriteLine("Матрица:");
            matrix.Show();

            Console.WriteLine("Изменим размер матрицы:");
            matrix.ChangeSize(rows + 2, columns + 2, minValue, maxValue);
            matrix.Show();

            Console.WriteLine("Вывод подматрицы (0, 0) до (2, 3):");
            matrix.ShowPartialy(0, 0, 2, 3); 

            Console.WriteLine(matrix[1, 1]); // Работает
            // Console.WriteLine(matrix[1, 1000]); // Ошибка
        }

    }

}
