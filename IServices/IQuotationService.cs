using System.Collections.Generic;
using System.Threading.Tasks;
using QuotationMgmtSystem.Data;

namespace QuotationMgmtSystem.IServices
{
    public interface IQuotationService
    {
        List<Quotation> Quotations { get; set; }
        Task LoadQuotes();
        Task<List<Quotation>> GetQuotations();
        Task<Quotation> GetQuotationById(int id);
        Task SaveQuotation(Quotation quotation, int? id);
        Task DeleteQuotation(int id);
    }
}