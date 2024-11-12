namespace lab5_2
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyList<T> : IEnumerable<T>
    {
        private T[] _items;  // массив для хранения элементов
        private int _count;  // текущее количество элементов

        // Свойство для получения количества элементов
        public int Count => _count;

        // Конструктор по умолчанию
        public MyList()
        {
            _items = new T[4]; // начальная ёмкость массива
            _count = 0;
        }

        // Метод для добавления элемента
        public void Add(T item)
        {
            // Если массив заполнен, увеличиваем его размер
            if (_count == _items.Length)
            {
                ResizeArray();
            }

            _items[_count] = item;
            _count++;
        }

        // Индексатор для доступа к элементам по индексу
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы списка.");

                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException("Индекс выходит за пределы списка.");

                _items[index] = value;
            }
        }

        // Метод для увеличения размера массива вдвое
        private void ResizeArray()
        {
            T[] newArray = new T[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }

        // Реализация интерфейса IEnumerable<T> для поддержки инициализатора коллекции
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        // Реализация для IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

    public class Program
    {
        public static void Main()
        {
            MyList<int> myList = new MyList<int> { 1, 2, 3, 4 };

            myList.Add(5);
            myList.Add(6);

            Console.WriteLine("Элементы списка:");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

            Console.WriteLine($"Количество элементов: {myList.Count}");

            Console.WriteLine(myList[3]); // Работает
            // Console.WriteLine(myList[7]); // Ошибка
        }
    }

}
