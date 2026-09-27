namespace Mouse.Core.Models
{
    // Модель мышки.
    // Содержит только данные, без бизнес-логики.
    public class Mouse
    {
        // Уникальный идентификатор мышки.
        public int Id { get; set; }

        // Имя мышки.
        public string Name { get; set; }

        // Цвет мышки.
        public string Color { get; set; }

        // Возраст мышки.
        public int Age { get; set; }

        // Вес мышки.
        public double Weight { get; set; }

        // Информация о наличии прививки.
        public bool IsVaccinated { get; set; }

        // Конструктор для создания мышки.
        public Mouse(
            int id,
            string name,
            string color,
            int age,
            double weight,
            bool isVaccinated)
        {
            Id = id;
            Name = name;
            Color = color;
            Age = age;
            Weight = weight;
            IsVaccinated = isVaccinated;
        }

        // Позволяет удобно выводить информацию о мышке.
        public override string ToString()
        {
            return $"{Id}. {Name} | {Color} | {Age} лет | " +
                   $"{Weight} кг | Привита: {(IsVaccinated ? "Да" : "Нет")}";
        }
    }
}
