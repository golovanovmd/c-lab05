using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class MyList<T> : IEnumerable<T>  // Класс MyList<T>, реализующий интерфейс IEnumerable<T> для поддержки перечисления элементов
{
    private T[] values;  // Массив для хранения элементов
    private int capacity;  // Текущий размер массива, равный количеству добавленных элементов

    // Конструктор, принимающий переменное количество аргументов (params)
    public MyList(params T[] valuesInit)
    {
        values = new T[valuesInit.Length];  // Инициализация массива размером с переданные значения
        Array.Copy(valuesInit, values, valuesInit.Length);  // Копирование переданных значений в массив
        capacity = valuesInit.Length;  // Установка емкости массива на количество переданных элементов
    }

    // Метод для добавления нового элемента в список
    public void Add(T value)
    {
        // Если массив заполнен, увеличиваем его размер
        if (capacity == values.Length)
        {
            int newCapacity = capacity == 0 ? 4 : capacity * 2;  // Увеличиваем размер массива в 2 раза или до 4, если он был пуст
            var newValues = new T[newCapacity];  // Создаем новый массив с увеличенной емкостью
            Array.Copy(values, newValues, values.Length);  // Копируем старые значения в новый массив
            values = newValues;  // Присваиваем ссылку на новый массив
        }
        values[capacity] = value;  // Добавляем новый элемент
        capacity++;  // Увеличиваем текущий размер
    }

    // Альтернативный конструктор, принимающий коллекцию элементов. Возможность перебора элемент. кол. через foreach
    public MyList(IEnumerable<T> collect)
    {
        values = new T[0];  // Инициализация пустого массива
        foreach (var item in collect)  // Перебираем коллекцию,Цикл автоматически получает текущий элемент и выполняет с ним нужные действия.
        {
            Add(item);  // Добавляем каждый элемент в массив
        }
    }

    // Индексатор для доступа к элементам по индексу
    public T this[int index]
    {
        get
        {
            return values[index];  // Возвращает элемент по индексу
        }
        set
        {
            values[index] = value;  // Устанавливает элемент по индексу
        }
    }

    // Метод для получения количества элементов в списке
    public int Count()
    {
        return capacity;  // Возвращает количество элементов
    }

    // Реализация метода GetEnumerator для поддержки foreach
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < capacity; i++)  // Перебираем элементы до текущего размера
        {
            yield return values[i];  //  возвращает элементы из метода по одному
        }
    }

    // Реализация неуниверсального метода GetEnumerator для поддержки IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();  // Возвращаем универсальный перечислитель
    }

    // Метод для печати всех элементов списка
    public void Print()
    {
        for (int i = 0; i < capacity; i++)  // Перебираем элементы до текущего размера (capacity)
        {
            Console.Write(values[i] + " ");  // Выводим каждый элемент
        }
        Console.WriteLine();  // Переход на новую строку после вывода
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание списка с начальными значениями
        MyList<int> list = new MyList<int> { 1, 2, 3, 4, 5, 6 };
        list.Print();  // Печать начальных значений
        list.Add(13);  // Добавление нового элемента
        list.Print();  // Печать после добавления

        // Печать общего количества элементов
        Console.WriteLine($"\nTotal number of elements: {list.Count()}");  // Выводим количество элементов
    }
}