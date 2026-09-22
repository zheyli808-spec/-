using System;
using System.Collections.Generic;
using System.Linq;
using Doog.Core.Models;
namespace Doog.Core
{
    // Класс Logic содержит всю бизнес-логику приложения.
    // Console и WinForms работают с собаками через этот класс.
    public class Logic
    {
        // Коллекция всех собак.
        private readonly List<Dog> _dogs = new List<Dog>();

        // Счётчик для автоматической генерации ID.
        private int _nextId = 1;

        // СОЗДАНИЕ СОБАКИ
        public Dog CreateDog(
            string name,
            string breed,
            int age,
            double weight,
            bool isVaccinated)
        {
            // Создаём новую собаку.
            Dog dog = new Dog(
                _nextId,
                name,
                breed,
                age,
                weight,
                isVaccinated
            );

            // Добавляем собаку в коллекцию.
            _dogs.Add(dog);

            // Увеличиваем ID для следующей собаки.
            _nextId++;

            // Возвращаем созданную собаку.
            return dog;
        }

        // ПОЛУЧЕНИЕ ВСЕХ СОБАК
        
        public List<Dog> GetAllDogs()
        {
            // Возвращаем копию списка,
            // чтобы внешний код не изменял внутреннюю коллекцию.
            return new List<Dog>(_dogs);
        }


        // ПОЛУЧЕНИЕ СОБАКИ ПО ID

        public Dog GetDogById(int id)
        {
            // Ищем первую собаку с указанным ID.
            // Если собака не найдена, вернётся null.
            return _dogs.FirstOrDefault(dog => dog.Id == id);
        }


        // ИЗМЕНЕНИЕ СОБАКИ

        public bool UpdateDog(
            int id,
            string name,
            string breed,
            int age,
            double weight,
            bool isVaccinated)
        {
            // Находим собаку по ID.
            Dog dog = GetDogById(id);

            // Если собака не найдена,
            // сообщаем вызывающему коду об ошибке.
            if (dog == null)
            {
                return false;
            }

            // Изменяем данные найденной собаки.
            dog.Name = name;
            dog.Breed = breed;
            dog.Age = age;
            dog.Weight = weight;
            dog.IsVaccinated = isVaccinated;

            // Изменение прошло успешно.
            return true;
        }

        // УДАЛЕНИЕ СОБАКИ


        public bool DeleteDog(int id)
        {
            // Находим собаку по ID.
            Dog dog = GetDogById(id);

            // Если собака не найдена,
            // удалить её невозможно.
            if (dog == null)
            {
                return false;
            }

            // Удаляем собаку из коллекции.
            _dogs.Remove(dog);

            // Удаление прошло успешно.
            return true;
        }

        // БИЗНЕС-ФУНКЦИЯ №1
        // ПОИСК СОБАК ПО ПОРОДЕ


        public List<Dog> GetDogsByBreed(string breed)
        {
            // Находим всех собак указанной породы.
            // OrdinalIgnoreCase позволяет не учитывать регистр.
            return _dogs
                .Where(dog =>
                    dog.Breed.Equals(
                        breed,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // БИЗНЕС-ФУНКЦИЯ №2
        // ПОЛУЧЕНИЕ ПРИВИТЫХ СОБАК


        public List<Dog> GetVaccinatedDogs()
        {
            // Оставляем только собак,
            // у которых IsVaccinated равен true.
            return _dogs
                .Where(dog => dog.IsVaccinated)
                .ToList();
        }
    }
}