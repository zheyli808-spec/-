using Mouse.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mouse.Core.Models
{
    public class Mouse : IDomainObject
    {
        public int Id { get; set; }

        [NotMapped]
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Name { get; set; }
        public string Color { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public bool IsVaccinated { get; set; }

        public Mouse()
        {
        }
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

        /// <summary>
        /// Метод позволяет удобно выводить информацию о мышке
        /// </summary>
        /// <returns>Данные о мышке</returns>
        public override string ToString()
        {
            return $"{Id}. {Name} | {Color} | {Age} лет | " +
                   $"{Weight} кг | Привита: {(IsVaccinated ? "Да" : "Нет")}";
        }
    }
}
