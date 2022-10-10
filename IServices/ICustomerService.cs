using System.Collections.Generic;
using System.Threading.Tasks;
using QuotationMgmtSystem.Data;

namespace QuotationMgmtSystem.IServices
{
    public interface ICustomerService
    {
        List<Customer> Customers { get; set; }
        Task LoadCustomers();
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int customerId);
        Task SaveCustomer(Customer customer, int? id);
        Task DeleteCustomer(int customerId);
    }
}