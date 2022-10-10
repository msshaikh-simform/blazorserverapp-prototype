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
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _dbContext;
        private readonly NavigationManager _navigationManager;
        private readonly IToastService _toastService;
        public CustomerService(AppDbContext context, NavigationManager navigationManager, IToastService toastService)
        {
            _dbContext = context;
            _navigationManager = navigationManager;
            _toastService = toastService;
        }

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public async Task LoadCustomers()
        {
            Customers = await GetCustomers();
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customer = await _dbContext.Customers.SingleOrDefaultAsync(x => x.CustomerId == customerId);
            return customer;
        }

        public async Task SaveCustomer(Customer customer, int? id)
        {
            var dbAllCustomer = await GetCustomers();
            if (dbAllCustomer.Any(x => x.CustomerId != customer.CustomerId && x.Name.ToLower() == customer.Name.ToLower()))
            {
                _toastService.ShowError("Same alias customer already exist!");
            }
            else 
            {
                if (customer.CustomerId == 0)
                {
                    await _dbContext.Customers.AddAsync(customer);
                }
                else
                {
                    var dbCustomer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customer.CustomerId);
                    if (dbCustomer != null)
                    {
                        dbCustomer.Name = customer.Name;
                        dbCustomer.Address = customer.Address;
                        dbCustomer.BirthDate = customer.BirthDate;
                        dbCustomer.PhoneNumber = customer.PhoneNumber;
                        dbCustomer.ZipCode = customer.ZipCode;
                    }
                }
                await _dbContext.SaveChangesAsync();

                if (id.GetValueOrDefault() == 0)
                {
                    _toastService.ShowSuccess("Customer inserted successfully.");
                }
                else
                {
                    _toastService.ShowSuccess("Customer updated successfully.");
                }
                _navigationManager.NavigateTo("customers");
            }
        }

        public async Task DeleteCustomer(int customerId)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();

                _toastService.ShowSuccess("Customer deleted successfully.");
                _navigationManager.NavigateTo("customers");
            }
        }
    }
}