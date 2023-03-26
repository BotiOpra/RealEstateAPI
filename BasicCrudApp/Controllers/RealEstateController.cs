using BasicCrudApp.DataLayers.DTOs;
using BasicCrudApp.DataLayers.Entities;
using BasicCrudApp.DataLayers.Mappings;
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
        public ActionResult<List<RealEstateDto?>> GetAll()
        {
            return _realEstateService.GetAll().Select(entity =>
                        entity.ToRealEstateDto()).ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<RealEstateDto> Get(int id)
        {
            var realEstate = _realEstateService.GetRealEstateById(id)?.ToRealEstateDto();
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

        [HttpPatch("edit-name/")]
        public ActionResult<bool> Patch([FromBody] RealEstateUpdatePriceDto realEstateModel)
        {
            bool patchState = _realEstateService.EditPrice(realEstateModel);
            if (!patchState)
                return NotFound();

            return patchState;
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
