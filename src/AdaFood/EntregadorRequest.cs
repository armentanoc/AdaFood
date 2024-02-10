using System.ComponentModel.DataAnnotations;

namespace AdaFood
{
    public class EntregadorRequest
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

    }
}