using System;
using System.Collections.Generic;
using System.Linq;
using MouseModel = Mouse.Core.Models.Mouse;

namespace Mouse.Core
{
    public class Logic
    {
        private readonly List<MouseModel> _mice =
            new List<MouseModel>();

        private int _nextId = 1;

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

        /// <summary>
        /// Метод для создания мышки
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="color">Цвет</param>
        /// <param name="age">Возраст</param>
        /// <param name="weight">Вес</param>
        /// <param name="isVaccinated">Привита или нет</param>
        /// <returns>Мышка</returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Метод для чтения всех мышек
        /// </summary>
        /// <returns>Список мышек</returns>
        public List<MouseModel> GetAllMice()
        {
            return new List<MouseModel>(_mice);
        }

        /// <summary>
        /// Метод для чтения мышек по ID
        /// </summary>
        /// <param name="id">Порядковый номер</param>
        /// <returns>Мышку по ID</returns>
        public MouseModel GetMouseById(int id)
        {
            return _mice.FirstOrDefault(mouse => mouse.Id == id);
        }

        /// <summary>
        /// Метод для изменения мышки по ее ID
        /// </summary>
        /// <param name="id">ID мышки</param>
        /// <param name="name">Новое имя</param>
        /// <param name="color">Новый цвет</param>
        /// <param name="age">Новый возраст</param>
        /// <param name="weight">Новый вес</param>
        /// <param name="isVaccinated">Привита или нет</param>
        /// <returns>
        /// true, если мышка найдена и её данные изменены;
        /// false, если мышка с указанным идентификатором не найдена.
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Метод для удаления мышки
        /// </summary>
        /// <param name="id">ID мышки</param>
        /// <returns>
        /// true, мышка нашлась и удалилась
        /// false, мышка не нашлась по ID
        /// </returns>
        public bool DeleteMouse(int id)
        {
            MouseModel mouse = GetMouseById(id);

            if (mouse == null)
                return false;

            _mice.Remove(mouse);
            return true;
        }

        /// <summary>
        /// Первая бизнес-функция: поиск мышек по цвету
        /// </summary>
        /// <param name="color">Цвет, по которому нужно найти всех мышек</param>
        /// <returns>Список мышек, по выбранному цвету</returns>
        public List<MouseModel> GetMiceByColor(string color)
        {
            return _mice
                .Where(mouse => string.Equals(
                    mouse.Color,
                    color,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        /// <summary>
        /// Вторая бизнес-функция: поиск привитых и непривитых мышек
        /// </summary>
        /// <returns>Список привитых/непривитых мышек</returns>
        public List<MouseModel> GetVaccinatedMice()
        {
            return _mice
                .Where(mouse => mouse.IsVaccinated)
                .ToList();
        }


        /// <summary>
        /// Третья бизнес-функция: рассчитывает средний вес всех мышек.
        /// </summary>
        /// <returns>
        /// Средний вес мышек в граммах.
        /// Если список пуст, возвращает 0.
        /// </returns>
        public double GetAverageWeight()
        {
            if (_mice.Count == 0)
                return 0;

            return _mice.Average(mouse => mouse.Weight);
        }

    }
}
