
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

                Console.Clear();

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
                Console.WriteLine("8. Показать средний вес мышек");
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

                        case "8":
                            ShowAverageWeight(logic);
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


        /// <summary>
        /// Запрашивает у пользователя данные новой мышки,
        /// создаёт мышку и выводит информацию о ней в консоль
        /// </summary>
        /// <param name="logic">Объект бизнес-логики для создания новой мышки</param>
        static void CreateMouse(Logic logic)
        {
            Console.WriteLine("\n--- СОЗДАНИЕ МЫШКИ ---");

            string name = ReadText("Имя: ");
            string color = ReadColor();
            int age = ReadInt("Возраст: ");
            double weight = ReadDouble("Вес в гр: ");
            bool vaccinated = ReadBool("Привита? (да/нет): ");

            MouseModel mouse = logic.CreateMouse(
                name, color, age, weight, vaccinated);

            Console.WriteLine("Мышка создана:");
            Console.WriteLine(mouse);
        }

        /// <summary>
        /// Получает и выводит в консоль список всех мышек,
        /// если список пуст, выводит соответствующее сообщение
        /// </summary>
        /// <param name="logic">
        /// Объект бизнес-логики для получения списка мышек
        /// </param>
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

        /// <summary>
        /// Поиск мышки по ID
        /// </summary>
        /// <param name="logic">Объект бизнес-логики для поиска мышки по ID</param>
        static void FindMouse(Logic logic)
        {
            Console.WriteLine("\n--- ПОИСК МЫШКИ ПО ID ---");

            ShowAllMice(logic);

            int id = ReadInt("Введите ID мышки: ");
            MouseModel mouse = logic.GetMouseById(id);

            if (mouse == null)
            {
                Console.WriteLine("Мышка не найдена.");
            }
            else
            {
                Console.WriteLine("\nНайденная мышка:");
                Console.WriteLine(mouse);
            }
        }


        /// <summary>
        /// Метод для изменения мышки
        /// </summary>
        /// <param name="logic">Объект бизнес-логики для изменения мышки</param>
        static void UpdateMouse(Logic logic)
        {
            Console.WriteLine("\n--- ИЗМЕНЕНИЕ МЫШКИ ---");

            ShowAllMice(logic);

            int id = ReadInt("Введите ID мышки для изменения: ");
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
            double weight = ReadDouble("Новый вес в гр: ");
            bool vaccinated = ReadBool("Привита? (да/нет): ");

            bool result = logic.UpdateMouse(
                id, name, color, age, weight, vaccinated);

            if (result)
            {
                Console.WriteLine("\nДанные успешно изменены.");

                Console.WriteLine("\nСписок мышек после изменения:");
                ShowAllMice(logic);
            }
            else
            {
                Console.WriteLine("Мышка не найдена.");
            }
        }

        /// <summary>
        /// Метод для удаления мышки
        /// </summary>
        /// <param name="logic">Объект бизнес-логики для удаления мышки</param>
        static void DeleteMouse(Logic logic)
        {
            Console.WriteLine("\n--- УДАЛЕНИЕ МЫШКИ ---");

            int id = ReadInt("ID мышки: ");

            bool result = logic.DeleteMouse(id);

            Console.WriteLine(result
                ? "Мышка успешно удалена."
                : "Мышка не найдена.");
        }

        /// <summary>
        /// Методля для поиска мышек по цвету
        /// </summary>
        /// <param name="logic">Объект бизнес-логики для поиска мышек по цвету</param>
        static void FindByColor(Logic logic)
        {
            Console.WriteLine("\n--- ПОИСК МЫШЕК ПО ЦВЕТУ ---");

            string color = ReadColor();
            List<MouseModel> mice = logic.GetMiceByColor(color);

            if (mice.Count == 0)
            {
                Console.WriteLine("Мышек такого цвета нет.");
                return;
            }

            Console.WriteLine($"\nМышки цвета «{color}»:");

            foreach (MouseModel mouse in mice)
            {
                Console.WriteLine(mouse);
            }
        }


        /// <summary>
        /// Метод для поиска привитых мышек и их вывода
        /// </summary>
        /// <param name="logic">Объект бизнес-логики для поиска привитых/непривитых мышек</param>
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


        /// <summary>
        /// Вычисляет и выводит средний вес всех мышек.
        /// </summary>
        /// <param name="logic">Объект бизнес-логики приложения.</param>
        static void ShowAverageWeight(Logic logic)
        {
            Console.WriteLine("\n--- СРЕДНИЙ ВЕС МЫШЕК ---");

            List<MouseModel> mice = logic.GetAllMice();

            if (mice.Count == 0)
            {
                Console.WriteLine("Список мышек пуст.");
                return;
            }

            double averageWeight = logic.GetAverageWeight();

            Console.WriteLine(
                $"Средний вес мышек: {averageWeight:F3} гр");
        }



        /// <summary>
        /// Запрашивает у пользователя текст и проверяет,
        /// что введённая строка не пустая
        /// </summary>
        /// <param name="message">Сообщение, выводимое перед вводом</param>
        /// <returns>Введённый текст без пробелов в начале и конце</returns>
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

        /// <summary>
        /// Запрашивает у пользователя целое число
        /// и повторяет ввод при неправильном формате
        /// </summary>
        /// <param name="message">Сообщение, выводимое перед вводом</param>
        /// <returns>Введённое целое число</returns>
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

        /// <summary>
        /// Запрашивает у пользователя вещественное число
        /// и поддерживает ввод с точкой или запятой
        /// </summary>
        /// <param name="message">Сообщение, выводимое перед вводом</param>
        /// <returns>Введённое вещественное число</returns>
        static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine();

                input = input.Replace('.', ',');

                if (double.TryParse(input, out double value) &&
                    !double.IsNaN(value) &&
                    !double.IsInfinity(value))
                    return value;

                Console.WriteLine("Введите число, например 0,03.");
            }
        }

        /// <summary>
        /// Запрашивает у пользователя ответ о наличии прививки,
        /// принимает значения «да» и «нет» без учёта регистра.
        /// </summary>
        /// <param name="message">Сообщение, выводимое перед вводом</param>
        /// <returns>true, если ответ «да», иначе false</returns>
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

        /// <summary>
        /// Выводит список доступных цветов мышек
        /// и запрашивает у пользователя номер выбранного цвета
        /// </summary>
        /// <returns>Название выбранного цвета</returns>
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
                else Console.WriteLine("Нет такого номера. Попробуйте ещё раз.");
            }
        }

    }
}
