
using System;
using System.Collections.Generic;
using Mouse.Core;
using MouseModel = Mouse.Core.Models.Mouse;

namespace Mouse.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            bool running = true;

            while (running)
            {
                Console.WriteLine();
                Console.WriteLine("================================");
                Console.WriteLine("       УПРАВЛЕНИЕ МЫШКАМИ");
                Console.WriteLine("================================");
                Console.WriteLine("1. Создать мышку");
                Console.WriteLine("2. Показать всех мышек");
                Console.WriteLine("3. Найти мышку по ID");
                Console.WriteLine("4. Изменить мышку");
                Console.WriteLine("5. Удалить мышку");
                Console.WriteLine("6. Найти мышек по цвету");
                Console.WriteLine("7. Показать привитых мышек");
                Console.WriteLine("0. Выход");
                Console.WriteLine("================================");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            CreateMouse(logic);
                            break;

                        case "2":
                            ShowAllMice(logic);
                            break;

                        case "3":
                            FindMouse(logic);
                            break;

                        case "4":
                            UpdateMouse(logic);
                            break;

                        case "5":
                            DeleteMouse(logic);
                            break;

                        case "6":
                            FindByColor(logic);
                            break;

                        case "7":
                            ShowVaccinated(logic);
                            break;

                        case "0":
                            running = false;
                            Console.WriteLine("Программа завершена.");
                            break;

                        default:
                            Console.WriteLine("Такого пункта нет. Попробуйте ещё раз.");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ошибка: введено значение неправильного формата.");
                }

                if (running)
                {
                    Console.WriteLine();
                    Console.WriteLine("Нажмите Enter, чтобы вернуться в меню.");
                    Console.ReadLine();
                }
            }
        }


        // ВВОД ДАННЫХ НОВОЙ МЫШКИ
        static void CreateMouse(Logic logic)
        {
            Console.WriteLine("\n--- СОЗДАНИЕ МЫШКИ ---");

            string name = ReadText("Имя: ");
            string color = ReadColor();
            int age = ReadInt("Возраст: ");
            double weight = ReadDouble("Вес в кг: ");
            bool vaccinated = ReadBool("Привита? (да/нет): ");

            MouseModel mouse = logic.CreateMouse(
                name, color, age, weight, vaccinated);

            Console.WriteLine("Мышка создана:");
            Console.WriteLine(mouse);
        }

        // ВЫВОД ВСЕХ МЫШЕК
        static void ShowAllMice(Logic logic)
        {
            Console.WriteLine("\n--- ВСЕ МЫШКИ ---");

            List<MouseModel> mice = logic.GetAllMice();

            if (mice.Count == 0)
            {
                Console.WriteLine("Список мышек пуст.");
                return;
            }

            foreach (MouseModel mouse in mice)
            {
                Console.WriteLine(mouse);
            }
        }

        // ПОИСК ПО ID
        static void FindMouse(Logic logic)
        {
            Console.WriteLine("\n--- ПОИСК МЫШКИ ---");

            int id = ReadInt("Введите ID: ");
            MouseModel mouse = logic.GetMouseById(id);

            if (mouse == null)
                Console.WriteLine("Мышка не найдена.");
            else
                Console.WriteLine(mouse);
        }

        // ИЗМЕНЕНИЕ МЫШКИ
        static void UpdateMouse(Logic logic)
        {
            Console.WriteLine("\n--- ИЗМЕНЕНИЕ МЫШКИ ---");

            int id = ReadInt("ID мышки: ");
            MouseModel mouse = logic.GetMouseById(id);

            if (mouse == null)
            {
                Console.WriteLine("Мышка не найдена.");
                return;
            }

            Console.WriteLine("Текущие данные:");
            Console.WriteLine(mouse);
            Console.WriteLine("Введите новые данные.");

            string name = ReadText("Новое имя: ");
            string color = ReadColor();
            int age = ReadInt("Новый возраст: ");
            double weight = ReadDouble("Новый вес в кг: ");
            bool vaccinated = ReadBool("Привита? (да/нет): ");

            bool result = logic.UpdateMouse(
                id, name, color, age, weight, vaccinated);

            Console.WriteLine(result
                ? "Данные успешно изменены."
                : "Мышка не найдена.");
        }

        // УДАЛЕНИЕ МЫШКИ
        static void DeleteMouse(Logic logic)
        {
            Console.WriteLine("\n--- УДАЛЕНИЕ МЫШКИ ---");

            int id = ReadInt("ID мышки: ");

            bool result = logic.DeleteMouse(id);

            Console.WriteLine(result
                ? "Мышка успешно удалена."
                : "Мышка не найдена.");
        }

        // БИЗНЕС-ФУНКЦИЯ: ПОИСК ПО ЦВЕТУ
        static void FindByColor(Logic logic)
        {
            Console.WriteLine("\n--- ПОИСК ПО ЦВЕТУ ---");

            string color = ReadText("Введите цвет: ");
            List<MouseModel> mice = logic.GetMiceByColor(color);

            if (mice.Count == 0)
            {
                Console.WriteLine("Мышек такого цвета нет.");
                return;
            }

            foreach (MouseModel mouse in mice)
            {
                Console.WriteLine(mouse);
            }
        }

        // БИЗНЕС-ФУНКЦИЯ: ПРИВИТЫЕ МЫШКИ
        static void ShowVaccinated(Logic logic)
        {
            Console.WriteLine("\n--- ПРИВИТЫЕ МЫШКИ ---");

            List<MouseModel> mice = logic.GetVaccinatedMice();

            if (mice.Count == 0)
            {
                Console.WriteLine("Привитых мышек нет.");
                return;
            }

            foreach (MouseModel mouse in mice)
            {
                Console.WriteLine(mouse);
            }
        }

        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ ВВОДА

        static string ReadText(string message)
        {
            while (true)
            {
                Console.Write(message);
                string value = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(value))
                    return value.Trim();

                Console.WriteLine("Поле не должно быть пустым.");
            }
        }

        static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);

                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Введите целое число.");
            }
        }

        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                // Поддерживаем ввод и 0,03, и 0.03.
                input = input.Replace('.', ',');

                if (double.TryParse(input, out double value) &&
                    !double.IsNaN(value) &&
                    !double.IsInfinity(value))
                    return value;

                Console.WriteLine("Введите число, например 0,03.");
            }
        }

        static bool ReadBool(string message)
        {
            while (true)
            {
                Console.Write(message);
                string value = Console.ReadLine();

                if (string.Equals(value, "да",
                    StringComparison.OrdinalIgnoreCase))
                    return true;

                if (string.Equals(value, "нет",
                    StringComparison.OrdinalIgnoreCase))
                    return false;

                Console.WriteLine("Введите «да» или «нет».");
            }
        }

        static string ReadColor()
        {
            while (true)
            {
                Console.WriteLine("Выберите цвет мышки:");

                for (int i = 0; i < Logic.MouseColors.Count; i++)
                {
                    Console.WriteLine(
                        $"{i + 1}. {Logic.MouseColors[i]}");
                }

                Console.Write("Ваш выбор: ");

                if (int.TryParse(Console.ReadLine(), out int number) &&
                    number >= 1 &&
                    number <= Logic.MouseColors.Count)
                {
                    return Logic.MouseColors[number - 1];
                }

                Console.WriteLine("Нет такого номера. Попробуйте ещё раз.");
            }
        }

    }
}
