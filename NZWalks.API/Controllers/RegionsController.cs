using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepository.GetAllRegionsAsync();
            var regionDTOs = mapper.Map<List<RegionDTO>>(regions);
            return Ok(regionDTOs);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            var region = await regionRepository.GetRegionByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegion([FromBody] AddRegionRequestDTO addRegionRequestDTO)
        {
            var region = new Region
            {
                Code = addRegionRequestDTO.Code,
                Name = addRegionRequestDTO.Name,
                RegionImageUrl = addRegionRequestDTO.RegionImageUrl
            };
            region = await regionRepository.AddRegionAsync(region);
            var regionDTO = mapper.Map<RegionDTO>(region);
            return CreatedAtAction(nameof(GetRegionById), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            var regionDomainModel = new Region
            {
                Code = updateRegionRequestDTO.Code,
                Name = updateRegionRequestDTO.Name,
                RegionImageUrl = updateRegionRequestDTO.RegionImageUrl
            };
            var region = await regionRepository.UpdateRegionAsync(id, regionDomainModel);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<RegionDTO>(region);
            return Ok(regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteRegionAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
