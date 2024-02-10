using AdaFood.Application.Interfaces;
using AdaFood.Domain.Models;
using AdaFood.Infra.Interfaces;
using AdaFood.ViewModels;

namespace AdaFood.Application.Services
{
    public class DeliveryDriverService : IDeliveryDriverService
    {
        private readonly IDeliveryDriverRepository _deliveryDriverRepository;

        public DeliveryDriverService(IDeliveryDriverRepository deliveryDriverRepository)
        {
            _deliveryDriverRepository = deliveryDriverRepository;
        }

        public bool Add(DeliveryDriverRequest deliveryDriverRequest)
        {
            var digitsOnlyCpf = ServiceHelper.GetDigitsFromCpf(deliveryDriverRequest.CPF);
            var deliveryDriver = new DeliveryDriver(deliveryDriverRequest.Name, digitsOnlyCpf);
            return _deliveryDriverRepository.Add(deliveryDriver);
        }

        public bool Delete(int id)
        {
            return _deliveryDriverRepository.Delete(id);
        }

        public DeliveryDriver Get(int id)
        {
            return _deliveryDriverRepository.Get(id);
        }

        public IEnumerable<DeliveryDriver> GetAll()
        {
            return _deliveryDriverRepository.GetAll();
        }

        public DeliveryDriver GetByCPF(string cpf)
        {
            string digitsOnlyCpf = ServiceHelper.GetDigitsFromCpf(cpf);
            return _deliveryDriverRepository.GetByCPF(digitsOnlyCpf);
        }

        public bool Update(DeliveryDriverRequest deliveryDriverRequest)
        {
            var newDeliveryDriverFromRequest = new DeliveryDriver(deliveryDriverRequest.Name, deliveryDriverRequest.CPF);
            return _deliveryDriverRepository.Update(newDeliveryDriverFromRequest);
        }
    }
}
