using ClinicalApp.Data;
using ClinicalApp.Interface;
using ClinicalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicalApp.Repository
{
    public class FinanctialInformationRepository : IFinancialInformationRepository
    {
        private readonly DatabaseContext _context;

        public FinanctialInformationRepository(DatabaseContext context)
        {
            _context = context;
        }

        public FinancialInformation Create(FinancialInformation financialInformation)
        {
            _context.FinancialInformations.Add(financialInformation);   
            _context.SaveChanges();
            return financialInformation;
        }

        public FinancialInformation Delete(FinancialInformation financialInformation)
        {
            _context.FinancialInformations.Attach(financialInformation);
            _context.Entry(financialInformation).State = EntityState.Deleted;
            _context.SaveChanges();
            return financialInformation;
        }

        public FinancialInformation Get(int id)
        {
            FinancialInformation finance = _context.FinancialInformations.FirstOrDefault(x => x.FinancialInfoId == id);
            return finance;
        }

        public List<FinancialInformation> GetAll()
        {
            List<FinancialInformation> finance = _context.FinancialInformations.ToList();   
            return finance;
        }

        public FinancialInformation Update(FinancialInformation financialInformation)
        {
            _context.FinancialInformations.Attach(financialInformation);
            _context.Entry(financialInformation).State = EntityState.Modified;
            _context.SaveChanges();
            return financialInformation;
        }
    }
}
