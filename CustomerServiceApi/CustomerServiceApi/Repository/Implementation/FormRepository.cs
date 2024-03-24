using CustomerServiceApi.Models;
using CustomerServiceApi.Repository.Repository;
using CustomerServiceApi.Utility;
using Microsoft.EntityFrameworkCore;

namespace CustomerServiceApi.Repository.Implementation
{
    public class FormRepository : IFormRepository
    {
        private readonly DbContextData _context;

        public FormRepository(DbContextData context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Form>> GetFormsByAgentIdAndDate(int agentId, DateTime date)
        {
            return await _context.Forms
                .Where(f => f.AgentId == agentId && f.CreatedDate.Date == date.Date)
                .ToListAsync();
        }

        public async Task<Form> SaveForm(Form form)
        {
            if (form.FormId != null)
            {
                _context.Forms.Update(form);
            }
            else
            {
                _context.Forms.Add(form);
            }
            await _context.SaveChangesAsync();
            return form;
        }


        public async Task<bool> DeleteForm(int formId)
        {
            var form = await _context.Forms.FindAsync(formId);
            if (form == null) return false;

            _context.Forms.Remove(form);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}