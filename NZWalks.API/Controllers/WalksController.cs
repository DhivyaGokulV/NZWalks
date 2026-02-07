using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;
        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddWalk([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDTO);

            var addedWalk = await walkRepository.AddWalkAsync(walkDomainModel);
            var addedWalkDTO = mapper.Map<WalkDTO>(addedWalk);
            return CreatedAtAction(nameof(GetWalkByID), new { id = addedWalkDTO.Id}, addedWalkDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDomainModel = await walkRepository.GetAllWalksAsync();
            var walksDTO = mapper.Map<List<WalkDTO>>(walksDomainModel);
            return walksDTO is null || walksDTO.Count == 0 ? NotFound(): Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkByID(Guid id)
        {
            var walkDomainModel = await walkRepository.GetWalkAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            var walkDTO = mapper.Map<WalkDTO>(walkDomainModel);
            return Ok(walkDTO);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDTO);
            var updatedWalk = await walkRepository.UpdateWalkAsync(id, walkDomainModel);
            if (updatedWalk == null)
            {
                return NotFound();
            }
            var updatedWalkDTO = mapper.Map<WalkDTO>(await walkRepository.GetWalkAsync(id));
            return Ok(updatedWalkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.RemoveWalkAsync(id);
            if(walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDTO>(walkDomainModel));
        }
    }
}
