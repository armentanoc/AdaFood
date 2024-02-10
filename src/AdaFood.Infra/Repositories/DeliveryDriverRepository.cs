using AdaFood.Domain.Models;
using AdaFood.Infra.Interfaces;

namespace AdaFood.Infra.Repositories
{
    public class DeliveryDriverRepository : Repository<DeliveryDriver>, IDeliveryDriverRepository
    {
        public DeliveryDriver? GetByCPF(string cpf)
        {
            return _entities.FirstOrDefault(deliveryDriver => deliveryDriver.CPF == cpf);
        }
    }
}
