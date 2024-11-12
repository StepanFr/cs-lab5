namespace lab5_3
{

    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private TKey[] keys;
        private TValue[] values;
        private int count;

        public MyDictionary()
        {
            keys = new TKey[4];
            values = new TValue[4];
            count = 0;
        }

        // Метод для добавления нового элемента
        public void Add(TKey key, TValue value)
        {
            // Проверка на дублирование ключей
            for (int i = 0; i < count; i++)
            {
                if (keys[i].Equals(key))
                {
                    throw new ArgumentException("An element with the same key already exists.");
                }
            }

            // Увеличиваем массивы, если достигнут текущий размер
            if (count == keys.Length)
            {
                Array.Resize(ref keys, keys.Length * 2);
                Array.Resize(ref values, values.Length * 2);
            }

            keys[count] = key;
            values[count] = value;
            count++;
        }

        // Индексатор для доступа к значениям по ключу
        public TValue this[TKey key]
        {
            get
            {
                for (int i = 0; i < count; i++)
                {
                    if (keys[i].Equals(key))
                    {
                        return values[i];
                    }
                }
                throw new KeyNotFoundException("The given key was not present in the dictionary.");
            }
            set
            {
                for (int i = 0; i < count; i++)
                {
                    if (keys[i].Equals(key))
                    {
                        values[i] = value;
                        return;
                    }
                }
                throw new KeyNotFoundException("The given key was not present in the dictionary.");
            }
        }

        // Свойство для получения количества элементов
        public int Count
        {
            get { return count; }
        }

        // Реализация интерфейса IEnumerable для поддержки foreach
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return new KeyValuePair<TKey, TValue>(keys[i], values[i]);
            }
        }

        // Реализация необобщенного IEnumerable для совместимости
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    // Демонстрация использования MyDictionary
    public class Program
    {
        public static void Main()
        {
            var myDict = new MyDictionary<string, int>();

            // Добавление элементов
            myDict.Add("one", 1);
            myDict.Add("two", 2);
            myDict.Add("three", 3);

            // Чтение элементов с помощью индексатора
            Console.WriteLine($"Значение по ключу 'one': {myDict["one"]}");
            Console.WriteLine($"Значение по ключу 'two': {myDict["two"]}");

            // Изменение значения по ключу
            myDict["two"] = 4;
            Console.WriteLine($"Новое значение по ключу 'two': {myDict["two"]}");
             
            // Количество элементов
            Console.WriteLine($"Количество элементов: {myDict.Count}");

            // Перебор элементов с помощью foreach
            Console.WriteLine("Все элементы в словаре:");
            foreach (var pair in myDict)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}"); 
            }

            Console.WriteLine(myDict["three"]); // Работает
            //  Console.WriteLine(myDict["four"]); // Ошибка
        }
    }

}
