namespace Doog.Core.Models
{
    // Модель собаки.
    // Содержит только данные, без бизнес-логики.
    public class Dog
    {
        // Уникальный идентификатор собаки.
        public int Id { get; set; }

        // Кличка собаки.
        public string Name { get; set; }

        // Порода собаки.
        public string Breed { get; set; }

        // Возраст собаки.
        public int Age { get; set; }

        // Вес собаки.
        public double Weight { get; set; }

        // Информация о наличии прививки.
        public bool IsVaccinated { get; set; }

        // Конструктор для создания собаки.
        public Dog(
            int id,
            string name,
            string breed,
            int age,
            double weight,
            bool isVaccinated)
        {
            Id = id;
            Name = name;
            Breed = breed;
            Age = age;
            Weight = weight;
            IsVaccinated = isVaccinated;
        }

        // Позволяет удобно выводить информацию о собаке.
        public override string ToString()
        {
            return $"{Id}. {Name} | {Breed} | {Age} лет | " +
                   $"{Weight} кг | Привита: {(IsVaccinated ? "Да" : "Нет")}";
        }
    }
}
