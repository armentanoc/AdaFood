
using AdaFood.Application.Interfaces;
using AdaFood.Application.Services;
using AdaFood.Domain.Models;
using AdaFood.ViewModels;
using AdaFood.WebAPI.Filters;
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
        [ServiceFilter(typeof(AuthFilter))]
        public IActionResult Add([FromBody] DeliveryDriverRequest deliveryDriverRequest)
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

        [HttpGet("cpf/{CPF}")]
        public IActionResult GetByCpf([FromRoute] string CPF)
        {
            if(_deliveryDriverService.GetByCPF(CPF) is DeliveryDriver deliveryDriver)
                return Ok(deliveryDriver);
            else
                return BadRequest();
        }

        [HttpGet("id/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            if(_deliveryDriverService.Get(id) is DeliveryDriver deliveryDriver)
                return Ok(deliveryDriver);
            else 
                return BadRequest();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var deliveryDrivers = _deliveryDriverService.GetAll();
            return Ok(deliveryDrivers);
        }
    }
}
