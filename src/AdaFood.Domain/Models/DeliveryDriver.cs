namespace AdaFood.Domain.Models
{
    public class DeliveryDriver : BaseEntity
    {
        public string Name { get; set; }
        public string CPF { get; set; }

        public DeliveryDriver(string name, string cpf) 
        {
            Name = name;
            CPF = cpf;
        }
    }
}
