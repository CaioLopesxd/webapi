using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapi.dtos.Industry;
using webapi.models;

namespace webapi.interfaces
{
    public interface IIndustriesRepository
    {
        Task<List<Industry>> GetAllIndustries();
        Task<Industry?> GetByIdIndustry(uint id);
        Task<Industry> CreateIndustry(Industry industryModel);
        Task<Industry?> UpdateIndustry(uint id, UpdateIndustryRequestDto industryModel);
        Task<Industry?> DeleteIndustry(uint id);
        Task<bool> IndustryExists(uint id);
        Task<string> GetIndustryNameById(uint id);
    }
}