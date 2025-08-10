using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NileRoutes.CustomActionFilters;
using NileRoutes.Data;
using NileRoutes.Interfaces;
using NileRoutes.Models.Domain;
using NileRoutes.Models.Dtos.RegionDto;
using System.Text.Json;

namespace NileRoutes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            _logger.LogInformation("Fetching all regions from the database.");

            var regions = await _regionRepository.GetAllRegionsAsync();

            var regionsDto = _mapper.Map<List<RegionDto>>(regions);

            _logger.LogInformation($"Found {JsonSerializer.Serialize(regionsDto)} regions.");

            if (regions == null || !regions.Any())
            {
                return NotFound("No regions found.");
            }
            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task <IActionResult> GetRegionById([FromRoute] Guid id)
        {
            var region = await _regionRepository.GetRegionByIdAsync(id);

            if (region == null)
            {
                return NotFound($"Region with ID {id} not found.");
            }

            return base.Ok(_mapper.Map<Models.Dtos.RegionDto.RegionDto>(region));
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task <IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegion)
        {
                var region = _mapper.Map<Models.Domain.Region>(addRegion);

                region = await _regionRepository.CreateRegionAsync(region);

                var regionDto = _mapper.Map<Models.Dtos.RegionDto.RegionDto>(region);

                return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);

        }

        [HttpPut]
        [Route("{id:guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task <IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegion)
        {
                var regionDomainModel = _mapper.Map<Models.Domain.Region>(updateRegion);

                regionDomainModel = await _regionRepository.UpdateRegionAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound($"Region with ID {id} not found.");
                }

                return base.Ok(_mapper.Map<Models.Dtos.RegionDto.RegionDto>(regionDomainModel));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task <IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await _regionRepository.DeleteRegionAsync(id);

            if (region == null)
            {
                return NotFound($"Region with ID {id} not found.");
            }

            return base.Ok(_mapper.Map<Models.Dtos.RegionDto.RegionDto>(region));
        }
    }
}
