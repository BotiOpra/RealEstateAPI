using BasicCrudApp.DataLayers.Entities;
using BasicCrudApp.DataLayers.Repositories;
using BasicCrudApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BasicCrudApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private RealEstateService _realEstateService { get; set; }

        public RealEstateController(RealEstateService realEstateService)
        {
            _realEstateService = realEstateService;
        }

        [HttpGet("get-all/")]
        public ActionResult<List<RealEstateEntity>> GetAll()
        {
            return _realEstateService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<RealEstateEntity> Get(int id)
        {
            var realEstate = _realEstateService.GetRealEstateById(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            return Ok(realEstate);
        }

        [HttpPost]
        public ActionResult<RealEstateEntity> Post([FromBody] RealEstateEntity realEstate)
        {
            _realEstateService.AddRealEstate(realEstate);
            return CreatedAtAction(nameof(Get), new { id = realEstate.Id }, realEstate);
        }

        [HttpPut("put/{id}")]
        public ActionResult<RealEstateEntity> Put(int id, [FromBody] RealEstateEntity realEstate)
        {
            if (id != realEstate.Id)
            {
                return BadRequest();
            }

            var existingRealEstate = _realEstateService.GetRealEstateById(id);
            if (existingRealEstate == null)
            {
                return NotFound();
            }

            _realEstateService.UpdateRealEstate(id, realEstate);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<RealEstateEntity> Delete(int id)
        {
            var existingRealEstate = _realEstateService.GetRealEstateById(id);
            if (existingRealEstate == null)
            {
                return NotFound();
            }

            _realEstateService.DeleteRealEstate(existingRealEstate);
            return NoContent();
        }
    }
}
