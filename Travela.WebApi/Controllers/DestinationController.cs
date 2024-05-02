using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Travela.BusinessLayer.Abstract;
using Travela.EntityLayer.Concrete;

namespace Travela.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public IActionResult DestinationList()
        {
            var values = _destinationService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateDestination(Destination p)
        {
            _destinationService.TInsert(p);
            return Ok("Rota Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteDestination(int id)
        {
            _destinationService.TDelete(id);
            return Ok("Rota Başarı İle Silindi");
        }

        [HttpPut]
        public IActionResult UpdateDestination(Destination p)
        {
            _destinationService.TUpdate(p);
            return Ok("Rota Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetDestination/{id}")]
        public IActionResult GetDestination(int id)
        {
            return Ok(_destinationService.TGetByID(id));
        }
    }
}
