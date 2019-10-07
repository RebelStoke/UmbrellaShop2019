using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UmbrellaShop.Core.DomainService;
using UmbrellaShop.Core.Entity;

namespace UmbrellaShop.Core.ApplicationService.ServiceImplementation
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _CustomerRepository;
        public CustomerService(ICustomerRepository CustomerRepository) {
            _CustomerRepository = CustomerRepository;
        }
        public Customer CreateCustomer(Customer Customer)
        {
           return _CustomerRepository.Create(Customer);
        }

        public Customer DeleteCustomer(int id)
        {
            return _CustomerRepository.Delete(id);
        }

        public List<Customer> GetCustomer()
        {
            return _CustomerRepository.ReadCustomers().ToList();
        }

        public Customer getCustomerByID(int id) {
            return _CustomerRepository.ReadByID(id);
        }

        public Customer NewCustomer(string firstName, string lastName, string address, string email, string phoneNumber, int id)
        {
            return new Customer { FirstName = firstName, LastName = lastName, Address = address, Email = email, PhoneNumber = phoneNumber, Id = id };
        }

        public Customer UpdateCustomer(int id, Customer Customer)
        {
           return _CustomerRepository.Update(id, Customer);
        }
    }
}
