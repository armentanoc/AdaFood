
using AdaFood.Domain.Models;
using AdaFood.ViewModels;

namespace AdaFood.Application.Interfaces
{
    public interface IDeliveryDriverService
    {
        bool Add(DeliveryDriverRequest deliveryDriverRequest);
        bool Update(DeliveryDriverRequest deliveryDriverRequest);
        bool Delete(int id);
        DeliveryDriver Get(int id);
        IEnumerable<DeliveryDriver> GetAll();
        DeliveryDriver GetByCPF(string cPF);
    }
}
