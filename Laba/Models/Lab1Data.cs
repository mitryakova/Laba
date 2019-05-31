using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laba.Models
{
    public class Lab1Data
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }

        public BaseModelValidationResult Validate()
        {
            var validationResult = new BaseModelValidationResult();

            if (string.IsNullOrWhiteSpace(Surname)) validationResult.Append($"Surname должно быть заполнено");
            if (string.IsNullOrWhiteSpace(Name)) validationResult.Append($"Name должно быть заполнено ");
            if (string.IsNullOrWhiteSpace(Firstname)) validationResult.Append($"Firstname должно быть заполнено");

            if (!string.IsNullOrEmpty(Name) && !char.IsUpper(Name.FirstOrDefault())) validationResult.Append($"Имя должно начинаться с большой буквы!");

            return validationResult;
        }

        public override string ToString()
        {
            return $"{Surname} {Name} {Firstname}";
        }
    }
}
