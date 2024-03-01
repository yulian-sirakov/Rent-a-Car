using Bussines_Layer.Models;
using DataLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class CustomerManager
    {
        private readonly IDb<Customer, int> customerContext;

        public CustomerManager(IDb<Customer, int> customerContext)
        {
            this.customerContext = customerContext;
        }

        public async Task CreateAsync(Customer customer)
        {
            await customerContext.CreateAsync(customer);
        }

        public async Task<Customer> ReadAsync(int key, bool navigationalProperties = false, bool IsReadOnly = true)
        {
            return await customerContext.ReadAsync(key, navigationalProperties, IsReadOnly);
        }

        public async Task<ICollection<Customer>> ReadAllAsync(bool navigationalProperties = false, bool isReadOnly = true)
        {
            return await customerContext.ReadAllAsync(navigationalProperties, isReadOnly);
        }
        public async Task UpdateAsync(Customer customer, bool navigationalProperties = false)
        {
            await customerContext.UpdateAsync(customer, navigationalProperties);
        }

        public async Task DeleteAsync(int key)
        {
            await customerContext.DeleteAsync(key);
        }
    }
}
