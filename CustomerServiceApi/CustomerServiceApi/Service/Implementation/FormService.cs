using CustomerServiceApi.Models;
using CustomerServiceApi.Repository.Repository;
using CustomerServiceApi.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CustomerServiceApi.Service.Implementation
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepository;

        public FormService(IFormRepository formRepository)
        {
            _formRepository = formRepository;
        }

        public Task<IEnumerable<Form>> GetFormsByAgentIdAndDate(int agentId, DateTime date)
        {
            return _formRepository.GetFormsByAgentIdAndDate(agentId, date);
        }

        public Task<Form> SaveForm(Form form)
        {
            return _formRepository.SaveForm(form);
        }

        public Task<bool> DeleteForm(int formId)
        {
            return _formRepository.DeleteForm(formId);
        }
    }
}