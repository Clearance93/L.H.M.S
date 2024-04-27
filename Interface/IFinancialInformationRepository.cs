using ClinicalApp.Models;

namespace ClinicalApp.Interface
{
    public interface IFinancialInformationRepository
    {
        List<FinancialInformation> GetAll();
        FinancialInformation Get(int id);   
        FinancialInformation Create(FinancialInformation financialInformation);
        FinancialInformation Update(FinancialInformation financialInformation);
        FinancialInformation Delete(FinancialInformation financialInformation);
    }
}
