using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext DbContext;
        public RegionsController(NZWalksDbContext dbContext)
        {
            DbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = DbContext.Regions.ToList();
            var regionDTOs = regions.Select(region => new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            }).ToList();
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetRegionById([FromRoute] Guid id)
        {
            var region = DbContext.Regions.FirstOrDefault(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(regionDTO);
        }

        [HttpPost]
        public IActionResult AddRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            var region = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };
            DbContext.Regions.Add(region);
            DbContext.SaveChanges();
            var regionDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var region = DbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            region.Code = updateRegionRequestDTO.Code;
            region.Name = updateRegionRequestDTO.Name;
            region.RegionImageUrl = updateRegionRequestDTO.RegionImageUrl;
            DbContext.SaveChanges();
            var regionDTO = new RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            var region = DbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            DbContext.Regions.Remove(region);
            DbContext.SaveChanges();
            return NoContent();
        }
    }
}
