using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapi.dtos.Industry;
using webapi.interfaces;
using webapi.mappers;

namespace webapi.controllers
{
    [Route("api/industry")]
    [ApiController]
    public class IndustriesController : ControllerBase
    {
        private readonly IIndustriesRepository _industriesRepository;

        public IndustriesController(IIndustriesRepository industriesRepository)
        {
            _industriesRepository = industriesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndustries()
        {
            var industries = await _industriesRepository.GetAllIndustries();

            var industriesDto = industries.Select(s => s.ToIndustryDto()).ToList();

            return Ok(industries);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdIndustry([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industry = await _industriesRepository.GetByIdIndustry(id);

            if (industry == null)
            {
                return NotFound();
            }

            return Ok(industry);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndustry([FromBody] CreateIndustryRequestDto createIndustryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var industryModel = createIndustryDto.ToIndustryFromCreateDto();

            var createdIndustry = await _industriesRepository.CreateIndustry(industryModel);

            return CreatedAtAction(nameof(GetByIdIndustry), new { id = createdIndustry.Id_Industry }, createdIndustry);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateIndustry([FromRoute] uint id, [FromBody] UpdateIndustryRequestDto industryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var industryModel = await _industriesRepository.UpdateIndustry(id, industryDto);

            if (industryModel == null)
            {
                return NotFound();
            }

            return Ok(industryModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteIndustry([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedIndustry = await _industriesRepository.DeleteIndustry(id);

            if (deletedIndustry == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}