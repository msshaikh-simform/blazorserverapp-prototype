using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using QuotationMgmtSystem.ApplicationDbContext;
using QuotationMgmtSystem.Data;
using QuotationMgmtSystem.IServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotationMgmtSystem.Services
{
    public class QuotationService : IQuotationService
    {
        private readonly AppDbContext _dbContext;
        private readonly NavigationManager _navigationManager;
        private readonly IToastService _toastService;
        public QuotationService(AppDbContext context, NavigationManager navigationManager, IToastService toastService)
        {
            _dbContext = context;
            _navigationManager = navigationManager;
            _toastService = toastService;
        }

        public List<Quotation> Quotations { get; set; } = new List<Quotation>();

        public async Task LoadQuotes()
        {
            Quotations = await GetQuotations();
        }

        public async Task<List<Quotation>> GetQuotations()
        {
            _dbContext.Customers.Load();
            return await _dbContext.Quotations.ToListAsync();
        }

        public async Task<Quotation> GetQuotationById(int quoteId)
        {
            _dbContext.Customers.Load();
            var quotation = await _dbContext.Quotations.SingleOrDefaultAsync(x => x.QuoteId == quoteId);
            return quotation;
        }

        public async Task SaveQuotation(Quotation quotation, int? id)
        {
            var dbAllQuotes = await GetQuotations();
            if (dbAllQuotes.Any(x => x.QuoteId != quotation.QuoteId && x.ProjectName.ToLower() == quotation.ProjectName.ToLower()))
            {
                _toastService.ShowError("Same alias project already exist!");
            }
            else
            {
                if (quotation.QuoteId == 0)
                {
                    await _dbContext.Quotations.AddAsync(quotation);
                }
                else
                {
                    var dbQuote = await _dbContext.Quotations.FirstOrDefaultAsync(x => x.QuoteId == quotation.QuoteId);
                    if (dbQuote != null)
                    {
                        dbQuote.CustomerId = quotation.CustomerId;
                        dbQuote.ProjectName = quotation.ProjectName;
                        dbQuote.BidReceiptDate = quotation.BidReceiptDate;
                        dbQuote.BidSubmissionDate = quotation.BidSubmissionDate;
                        dbQuote.Notes = quotation.Notes;
                    }
                }
                await _dbContext.SaveChangesAsync();

                if (id.GetValueOrDefault() == 0)
                {
                    _toastService.ShowSuccess("Quotation inserted successfully.");
                }
                else
                {
                    _toastService.ShowSuccess("Quotation updated successfully.");
                }
                _navigationManager.NavigateTo("quotes");
            }
        }

        public async Task DeleteQuotation(int quoteId)
        {
            var quotation = await _dbContext.Quotations.FirstOrDefaultAsync(x => x.QuoteId == quoteId);
            if (quotation != null)
            {
                _dbContext.Quotations.Remove(quotation);
                await _dbContext.SaveChangesAsync();

                _toastService.ShowSuccess("Quotation deleted successfully.");
                _navigationManager.NavigateTo("quotes");
            }
        }
    }
}