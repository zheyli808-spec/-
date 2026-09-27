using System;
using System.Collections.Generic;
using System.Linq;

using MouseModel = Mouse.Core.Models.Mouse;

namespace Mouse.Core
{
    // Класс Logic содержит всю бизнес-логику приложения.
    // Console и WinForms работают с мышками через этот класс.
    public class Logic
    {
        // Коллекция всех мышек.
        private readonly System.Collections.Generic.List<MouseModel> _mice =
    new System.Collections.Generic.List<MouseModel>();

        // Счётчик для автоматической генерации ID.
        private int _nextId = 1;


        // СОЗДАНИЕ МЫШКИ

        public MouseModel CreateMouse(
            string name,
            string color,
            int age,
            double weight,
            bool isVaccinated)
        {
            // Создаём новую мышку.
            MouseModel mouse = new MouseModel(
                _nextId,
                name,
                color,
                age,
                weight,
                isVaccinated
            );

            // Добавляем мышку в коллекцию.
            _mice.Add(mouse);

            // Увеличиваем ID для следующей мышки.
            _nextId++;

            // Возвращаем созданную мышку.
            return mouse;
        }


        // ПОЛУЧЕНИЕ ВСЕХ МЫШЕК

        public List<MouseModel> GetAllMice()
        {
            // Возвращаем копию списка,
            // чтобы внешний код не изменял внутреннюю коллекцию.
            return new List<MouseModel>(_mice);
        }


        // ПОЛУЧЕНИЕ МЫШКИ ПО ID

        public MouseModel GetMouseById(int id)
        {
            // Ищем мышку с указанным ID.
            // Если мышка не найдена, вернётся null.
            return _mice.FirstOrDefault(mouse => mouse.Id == id);
        }


        // ИЗМЕНЕНИЕ МЫШКИ

        public bool UpdateMouse(
            int id,
            string name,
            string color,
            int age,
            double weight,
            bool isVaccinated)
        {
            // Находим мышку по ID.
            MouseModel mouse = GetMouseById(id);

            // Если мышка не найдена,
            // сообщаем вызывающему коду об ошибке.
            if (mouse == null)
            {
                return false;
            }

            // Изменяем данные найденной мышки.
            mouse.Name = name;
            mouse.Color = color;
            mouse.Age = age;
            mouse.Weight = weight;
            mouse.IsVaccinated = isVaccinated;

            // Изменение прошло успешно.
            return true;
        }


        // УДАЛЕНИЕ МЫШКИ

        public bool DeleteMouse(int id)
        {
            // Находим мышку по ID.
            MouseModel mouse = GetMouseById(id);

            // Если мышка не найдена,
            // удалить её невозможно.
            if (mouse == null)
            {
                return false;
            }

            // Удаляем мышку из коллекции.
            _mice.Remove(mouse);

            // Удаление прошло успешно.
            return true;
        }


        // БИЗНЕС-ФУНКЦИЯ №1
        // ПОИСК МЫШЕК ПО ЦВЕТУ

        public List<MouseModel> GetMiceByColor(string color)
        {
            // Находим всех мышек указанного цвета.
            // Регистр букв не учитывается.
            return _mice
                .Where(mouse =>
                    mouse.Color.Equals(
                        color,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }


        // БИЗНЕС-ФУНКЦИЯ №2
        // ПОЛУЧЕНИЕ ПРИВИТЫХ МЫШЕК

        public List<MouseModel> GetVaccinatedMice()
        {
            // Оставляем только мышек,
            // у которых IsVaccinated равен true.
            return _mice
                .Where(mouse => mouse.IsVaccinated)
                .ToList();
        }
    }
}