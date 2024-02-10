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
            if(Get(id) is DeliveryDriver deliveryDriver)
                return _deliveryDriverRepository.Delete(id);
            else 
                throw new Exception($"Delivery driver {id} not found. Deletion couldn't be completed.");
        }

        public DeliveryDriver Get(int id)
        {
            if(_deliveryDriverRepository.Get(id) is DeliveryDriver deliveryDriver)
                return deliveryDriver;
            else
                throw new Exception($"Delivery driver {id} not found");
        }

        public IEnumerable<DeliveryDriver> GetAll()
        {
            if(_deliveryDriverRepository.GetAll() is IEnumerable<DeliveryDriver> deliveryDrivers)
                if(deliveryDrivers.Any()) return deliveryDrivers;
            throw new Exception("Delivery drivers not found or empty.");
        }

        public DeliveryDriver GetByCPF(string cpf)
        {
            string digitsOnlyCpf = ServiceHelper.GetDigitsFromCpf(cpf);

            if (_deliveryDriverRepository.GetByCPF(digitsOnlyCpf) is DeliveryDriver deliveryDriver)
                return deliveryDriver;
            else
                throw new Exception($"Delivery driver CPF {cpf} not found");
        }

        public bool Update(DeliveryDriverRequest deliveryDriverRequest)
        {
            var newDeliveryDriverFromRequest = new DeliveryDriver(deliveryDriverRequest.Name, deliveryDriverRequest.CPF);
            return _deliveryDriverRepository.Update(newDeliveryDriverFromRequest);
        }
    }
}
