using System.ComponentModel.DataAnnotations;

namespace AdaFood.ViewModels
{
    public record DeliveryDriverRequest
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public string CPF { get; init; }

    }
}