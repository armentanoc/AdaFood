
using AdaFood.Application.Interfaces;
using AdaFood.Application.Services;
using AdaFood.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AdaFood.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDriverController : ControllerBase
    {
        private readonly IDeliveryDriverService _deliveryDriverService;

        public DeliveryDriverController(IDeliveryDriverService deliveryDriverService)
        {
            _deliveryDriverService = deliveryDriverService;
        }

        [HttpPost]
        public IActionResult AddEntregador([FromBody] DeliveryDriverRequest deliveryDriverRequest)
        {
            bool wasItAdded = _deliveryDriverService.Add(deliveryDriverRequest);

            if(wasItAdded)
            {
                var digitsOnlyCpf = ServiceHelper.GetDigitsFromCpf(deliveryDriverRequest.CPF);
                var addedDriver = _deliveryDriverService.GetByCPF(digitsOnlyCpf);
                return Created($"/api/DeliveryDriver/{addedDriver.Id}", addedDriver);
            } else
            {
                return BadRequest();
            }
        }

        [HttpGet("{CPF}")]
        public IActionResult Get([FromRoute] string CPF)
        {
            var deliveryDriver = _deliveryDriverService.GetByCPF(CPF);
            return Ok(deliveryDriver);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var deliveryDrivers = _deliveryDriverService.GetAll();
            return Ok(deliveryDrivers);
        }
    }
}
