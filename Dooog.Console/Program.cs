using System;
using Mouse.Core;

namespace Mouse.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();

            // Создание мышек
            logic.CreateMouse(
                "Мышка 1",
                "Белая",
                1,
                0.03,
                true);

            logic.CreateMouse(
                "Мышка 2",
                "Серая",
                2,
                0.04,
                false);

            logic.CreateMouse(
                "Мышка 3",
                "Белая",
                1,
                0.03,
                true);


            // Вывод всех мышек
            Console.WriteLine("=== ВСЕ МЫШКИ ===");

            foreach (var mouse in logic.GetAllMice())
            {
                Console.WriteLine(mouse);
            }


            // Поиск по ID
            Console.WriteLine();
            Console.WriteLine("=== МЫШКА С ID 2 ===");

            var mouseById = logic.GetMouseById(2);

            if (mouseById != null)
            {
                Console.WriteLine(mouseById);
            }


            // Бизнес-функция 1
            Console.WriteLine();
            Console.WriteLine("=== БЕЛЫЕ МЫШКИ ===");

            foreach (var mouse in logic.GetMiceByColor("Белая"))
            {
                Console.WriteLine(mouse);
            }


            // Бизнес-функция 2
            Console.WriteLine();
            Console.WriteLine("=== ПРИВИТЫЕ МЫШКИ ===");

            foreach (var mouse in logic.GetVaccinatedMice())
            {
                Console.WriteLine(mouse);
            }


            // Изменение
            Console.WriteLine();
            Console.WriteLine("=== ИЗМЕНЕНИЕ МЫШКИ ===");

            bool updated = logic.UpdateMouse(
                2,
                "Мышка 2 обновлённая",
                "Чёрная",
                3,
                0.05,
                true);

            Console.WriteLine(
                updated
                    ? "Мышка успешно изменена."
                    : "Мышка не найдена.");


            // Проверяем изменение
            mouseById = logic.GetMouseById(2);

            if (mouseById != null)
            {
                Console.WriteLine(mouseById);
            }


            // Удаление
            Console.WriteLine();
            Console.WriteLine("=== УДАЛЕНИЕ МЫШКИ ===");

            bool deleted = logic.DeleteMouse(3);

            Console.WriteLine(
                deleted
                    ? "Мышка успешно удалена."
                    : "Мышка не найдена.");


            // Проверяем удаление
            Console.WriteLine();
            Console.WriteLine("=== МЫШКИ ПОСЛЕ УДАЛЕНИЯ ===");

            foreach (var mouse in logic.GetAllMice())
            {
                Console.WriteLine(mouse);
            }


            Console.WriteLine();
            Console.WriteLine("Нажмите Enter для выхода.");
            Console.ReadLine();
        }
    }
}