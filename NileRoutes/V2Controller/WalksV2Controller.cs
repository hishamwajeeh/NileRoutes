using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NileRoutes.CustomActionFilters;
using NileRoutes.Interfaces;
using NileRoutes.Models.Domain;
using NileRoutes.Models.Dtos.WalkDto;

namespace NileRoutes.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
    public class WalksV2Controller : ControllerBase
    {
        private readonly IWalkRepository _walkRepository;
        private readonly IMapper _mapper;
        public WalksV2Controller(IMapper mapper, IWalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalkAsync([FromBody] AddWalkRequestDto addWalk)
        {
                var walkDomainModel = _mapper.Map<Walk>(addWalk);

                walkDomainModel = await _walkRepository.CreateWalkAsync(walkDomainModel);

                return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalksAsync([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            //var walksDomainModel = await _walkRepository.GetAllWalksAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            ////throw new Exception("Bla Bla"); // Example of an exception to test the middleware

            //return Ok(_mapper.Map<List<WalkDto>>(walksDomainModel));

            var walksDomainModel = await _walkRepository.GetAllWalksAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            var walksDto = _mapper.Map<List<WalkDto>>(walksDomainModel);

            // Example change for v2
            walksDto.ForEach(w => w.Name += " (v2)");

            return Ok(walksDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetWalkByIdAsync([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetWalkByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalk)
        {
                var walkDomainModel = _mapper.Map<Walk>(updateWalk);

                walkDomainModel = await _walkRepository.UpdateWalkAsync(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();
                }
                return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.DeleteWalkAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
