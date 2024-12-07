using System;
using System.Collections;  // Подключение пространства имен для поддержки интерфейса IEnumerable.
using System.Collections.Generic;  // Подключение пространства имен для поддержки обобщенных коллекций, таких как List<> и KeyValuePair<>.

class MyDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
{
    // Внутренний список, который будет хранить пары ключ-значение.
    private List<KeyValuePair<TKey, TValue>> items = new List<KeyValuePair<TKey, TValue>>(); // Инициализация списка пар ключ-значение.

    // Метод для добавления новой пары ключ-значение в словарь.
    public void Add(TKey key, TValue value)
    {
        items.Add(new KeyValuePair<TKey, TValue>(key, value));  // Добавление объекта KeyValuePair<TKey, TValue> в список.
    }

    // Индексатор для доступа к значению по ключу.
    public TValue this[TKey key]
    {
        get
        {
            // Поиск элемента в списке, ключ которого равен переданному ключу.
            var item = items.Find(i => EqualityComparer<TKey>.Default.Equals(i.Key, key));

            // Если элемент найден (не равен значению по умолчанию для пары ключ-значение), возвращаем его значение.
            if (!item.Equals(default(KeyValuePair<TKey, TValue>)))
            {
                return item.Value;  // Возвращаем значение, соответствующее ключу.
            }
            // Если ключ не найден, выбрасываем исключение.
            throw new KeyNotFoundException($"The key '{key}' was not found in the dictionary.");
        }
    }

    // Свойство для получения количества элементов в словаре.
    public int Count
    {
        get { return items.Count; }  // Возвращаем количество элементов в списке.
    }

    // Реализация метода для поддержки перебора коллекции с использованием foreach.
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
    {
        return items.GetEnumerator();  // Возвращаем перечислитель для перебора элементов списка.
    }

    // Неявная реализация интерфейса IEnumerable для поддержки перебора коллекции.
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();  // Используем основной перечислитель, реализованный выше.
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание словаря с ключами типа string и значениями типа int.
        MyDictionary<string, int> myDict = new MyDictionary<string, int>(); // Не используем инициализатор коллекции.

        // Добавление пар ключ-значение в словарь.
        myDict.Add("one", 1);
        myDict.Add("two", 2);
        myDict.Add("three", 3);

        // Вывод количества элементов в словаре.
        Console.WriteLine("Count: " + myDict.Count);

        // Получение значения по ключу "two" с помощью индексатора.
        Console.WriteLine("\nValue for key 'two': " + myDict["two"]);

        // Перебор всех элементов словаря с использованием foreach.
        Console.WriteLine("\nIterating through the dictionary:");
        foreach (var item in myDict)
        {
            // Вывод ключа и значения каждой пары.
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}



