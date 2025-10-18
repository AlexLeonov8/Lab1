using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лабораторная_работа__1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueCalculations = true;
            List<string> history = new List<string>();

            Console.WriteLine("Калькулятор с историей операций");

            while (continueCalculations)
            {
                try
                {
                    // Ввод двух чисел
                    Console.Write("Введите первое число: ");
                    int num1 = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Введите второе число: ");
                    int num2 = Convert.ToInt32(Console.ReadLine());

                    // Основной цикл меню для текущих чисел
                    bool sameNumbers = true;
                    while (sameNumbers)
                    {
                        // Показать меню
                        Console.WriteLine("\nВыберите операцию:");
                        Console.WriteLine("1. Сложение");
                        Console.WriteLine("2. Вычитание");
                        Console.WriteLine("3. Умножение");
                        Console.WriteLine("4. Деление");
                        Console.WriteLine("5. Выход");
                        Console.WriteLine("6. Ввести новые числа");
                        Console.Write("Ваш выбор: ");

                        string choice = Console.ReadLine();
                        Console.WriteLine();

                        int result = 0;
                        string operation = "";
                        bool validOperation = true;

                        switch (choice)
                        {
                            case "1": // Сложение
                                result = num1 + num2;
                                operation = $"{num1} + {num2} = {result}";
                                Console.WriteLine($"Результат: {operation}");
                                break;

                            case "2": // Вычитание
                                result = num1 - num2;
                                operation = $"{num1} - {num2} = {result}";
                                Console.WriteLine($"Результат: {operation}");
                                break;

                            case "3": // Умножение
                                result = num1 * num2;
                                operation = $"{num1} * {num2} = {result}";
                                Console.WriteLine($"Результат: {operation}");
                                break;

                            case "4": // Деление
                                if (num2 == 0)
                                {
                                    Console.WriteLine("Ошибка: Деление на ноль невозможно!");
                                    validOperation = false;
                                }
                                else
                                {
                                    result = num1 / num2;
                                    operation = $"{num1} / {num2} = {result}";
                                    Console.WriteLine($"Результат: {operation}");
                                }
                                break;

                            case "5": // Выход
                                Console.WriteLine("Выход из программы...");
                                continueCalculations = false;
                                sameNumbers = false;
                                validOperation = false;
                                break;

                            case "6": // Новые числа
                                Console.WriteLine("Переход к вводу новых чисел...");
                                sameNumbers = false;
                                validOperation = false;
                                break;

                            default:
                                Console.WriteLine("Ошибка: Неверный выбор операции!");
                                validOperation = false;
                                break;
                        }

                        // Добавление операции в историю
                        if (validOperation)
                        {
                            history.Add(operation);

                            // Ограничение истории последними 5 операциями
                            if (history.Count > 5)
                            {
                                history.RemoveAt(0);
                            }
                        }

                        // Показ истории операций
                        if (history.Count > 0)
                        {
                            Console.WriteLine("\nИстория операций (последние 5):");
                            Console.WriteLine("--------------------------------");
                            foreach (string op in history)
                            {
                                Console.WriteLine(op);
                            }
                            Console.WriteLine();
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: Введите корректные целые числа!");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Ошибка: Введенное число слишком большое!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                }
            }

            Console.WriteLine("Программа завершена. Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}

