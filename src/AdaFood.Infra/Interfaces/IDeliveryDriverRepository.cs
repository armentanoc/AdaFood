
using AdaFood.Domain.Models;

namespace AdaFood.Infra.Interfaces
{
    public interface IDeliveryDriverRepository : IRepository<DeliveryDriver>
    {
        public DeliveryDriver GetByCPF(string cpf);
    }
}
