using CustomerServiceApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceApi.Repository.Repository
{
    public interface IFormRepository
    {
        Task<IEnumerable<Form>> GetFormsByAgentIdAndDate(int agentId, DateTime date);
        Task<Form> SaveForm(Form form);
        Task<bool> DeleteForm(int formId);
    }
}