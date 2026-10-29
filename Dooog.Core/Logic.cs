using System;
using System.Collections.Generic;
using System.Linq;
using MouseModel = Mouse.Core.Models.Mouse;
using Mouse.Interfaces;

namespace Mouse.Core
{
    public class Logic
    {
        private readonly IRepository<MouseModel> _repository;

        public static readonly List<string> MouseColors = new List<string>
        {
            "Белый",
            "Серый",
            "Чёрный",
            "Коричневый",
            "Рыжый",
            "Красный",
            "Желтый"
        };

        public Logic(IRepository<MouseModel> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Метод для создания мышки.
        /// </summary>
        public MouseModel CreateMouse(
            string name,
            string color,
            int age,
            double weight,
            bool isVaccinated)
        {
            ValidateMouse(name, color, age, weight);

            MouseModel mouse = new MouseModel(
                0,
                name,
                color,
                age,
                weight,
                isVaccinated);

            _repository.Add(mouse);

            return mouse;
        }

        /// <summary>
        /// Метод для получения всех мышек.
        /// </summary>
        public List<MouseModel> GetAllMice()
        {
            return _repository.GetAll();
        }

        /// <summary>
        /// Метод для получения мышки по ID.
        /// </summary>
        public MouseModel GetMouseById(int id)
        {
            return _repository.GetById(id);
        }

        /// <summary>
        /// Метод для изменения мышки по ID.
        /// </summary>
        public bool UpdateMouse(
            int id,
            string name,
            string color,
            int age,
            double weight,
            bool isVaccinated)
        {
            MouseModel mouse = _repository.GetById(id);

            if (mouse == null)
                return false;

            ValidateMouse(name, color, age, weight);

            mouse.Name = name;
            mouse.Color = color;
            mouse.Age = age;
            mouse.Weight = weight;
            mouse.IsVaccinated = isVaccinated;

            _repository.Update(mouse);

            return true;
        }

        /// <summary>
        /// Метод для удаления мышки по ID.
        /// </summary>
        public bool DeleteMouse(int id)
        {
            MouseModel mouse = _repository.GetById(id);

            if (mouse == null)
                return false;

            _repository.Delete(mouse);

            return true;
        }

        /// <summary>
        /// Первая бизнес-функция: поиск мышек по цвету.
        /// </summary>
        public List<MouseModel> GetMiceByColor(string color)
        {
            return _repository.GetAll()
                .Where(mouse => string.Equals(
                    mouse.Color,
                    color,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Вторая бизнес-функция: получение привитых мышек.
        /// </summary>
        public List<MouseModel> GetVaccinatedMice()
        {
            return _repository.GetAll()
                .Where(mouse => mouse.IsVaccinated)
                .ToList();
        }

        /// <summary>
        /// Третья бизнес-функция: расчёт среднего веса мышек.
        /// Если мышек нет, возвращает 0.
        /// </summary>
        public double GetAverageWeight()
        {
            List<MouseModel> mice = _repository.GetAll();

            if (mice.Count == 0)
                return 0;

            return mice.Average(mouse => mouse.Weight);
        }

        /// <summary>
        /// Проверяет корректность данных мышки.
        /// </summary>
        private void ValidateMouse(
            string name,
            string color,
            int age,
            double weight)
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
        }
    }
}
