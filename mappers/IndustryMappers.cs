using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.dtos.Industry;
using webapi.models;

namespace webapi.mappers
{
    public static class IndustryMappers
    {
        public static IndustryDto ToIndustryDto(this Industry industryModel)
        {
            return new IndustryDto
            {
                Description = industryModel.Description,
                Stocks = industryModel.Stocks.Select(c => c.ToStockDto()).ToList(),
            };
        }

        public static Industry ToIndustryFromCreateDto(this CreateIndustryRequestDto industryDto)
        {
            return new Industry
            {
                Description = industryDto.Description,
            };
        }
    }
}