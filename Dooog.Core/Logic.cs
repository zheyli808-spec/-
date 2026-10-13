using System;
using System.Collections.Generic;
using System.Linq;
using MouseModel = Mouse.Core.Models.Mouse;

namespace Mouse.Core
{
    public class Logic
    {
        // Список всех мышек.
        private readonly List<MouseModel> _mice =
            new List<MouseModel>();

        // ID следующей мышки.
        private int _nextId = 1;

        public static readonly List<string> MouseColors =
    new List<string>
    {
        "Белый",
        "Серый",
        "Чёрный",
        "Коричневый",
        "Рыжый",
        "Красный",
        "Желтый"
    };

        // 1. СОЗДАНИЕ МЫШКИ
        public MouseModel CreateMouse(
            string name,
            string color,
            int age,
            double weight,
            bool isVaccinated)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым.");

            if (!MouseColors.Contains(color))
                throw new ArgumentException("Выберите цвет из списка.");

            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным.");

            if (weight <= 0 || double.IsNaN(weight) ||
                double.IsInfinity(weight))
                throw new ArgumentException("Вес должен быть положительным числом.");

            MouseModel mouse = new MouseModel(
                _nextId,
                name,
                color,
                age,
                weight,
                isVaccinated);

            _mice.Add(mouse);
            _nextId++;

            return mouse;
        }

        // 2. ЧТЕНИЕ ВСЕХ МЫШЕК
        public List<MouseModel> GetAllMice()
        {
            return new List<MouseModel>(_mice);
        }

        // ЧТЕНИЕ МЫШКИ ПО ID
        public MouseModel GetMouseById(int id)
        {
            return _mice.FirstOrDefault(mouse => mouse.Id == id);
        }

        // 3. ИЗМЕНЕНИЕ МЫШКИ
        public bool UpdateMouse(
            int id,
            string name,
            string color,
            int age,
            double weight,
            bool isVaccinated)
        {
            MouseModel mouse = GetMouseById(id);

            if (mouse == null)
                return false;

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Имя не может быть пустым.");

            if (!MouseColors.Contains(color))
                throw new ArgumentException("Выберите цвет из списка.");

            if (age < 0)
                throw new ArgumentException("Возраст не может быть отрицательным.");

            if (weight <= 0 || double.IsNaN(weight) ||
                double.IsInfinity(weight))
                throw new ArgumentException("Вес должен быть положительным числом.");

            mouse.Name = name;
            mouse.Color = color;
            mouse.Age = age;
            mouse.Weight = weight;
            mouse.IsVaccinated = isVaccinated;

            return true;
        }

        // 4. УДАЛЕНИЕ МЫШКИ
        public bool DeleteMouse(int id)
        {
            MouseModel mouse = GetMouseById(id);

            if (mouse == null)
                return false;

            _mice.Remove(mouse);
            return true;
        }

        // 5. БИЗНЕС-ФУНКЦИЯ № 1
        // Поиск мышек по цвету.
        public List<MouseModel> GetMiceByColor(string color)
        {
            return _mice
                .Where(mouse => string.Equals(
                    mouse.Color,
                    color,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // 6. БИЗНЕС-ФУНКЦИЯ № 2
        // Получение привитых мышек.
        public List<MouseModel> GetVaccinatedMice()
        {
            return _mice
                .Where(mouse => mouse.IsVaccinated)
                .ToList();
        }
    }
}
