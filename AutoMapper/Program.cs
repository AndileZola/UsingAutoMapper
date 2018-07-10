using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {

            Mapper.Initialize(cfg => cfg.CreateMap<Customer, CustomerViewItem>());          
            var cus = GetAllCustomers();
            var cusf = GetAllCustomers().FirstOrDefault();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerViewItem>());
            var mapper = new Mapper(config);
            CustomerViewItem dto = Mapper.Map<CustomerViewItem>(cus);
            var dest = Mapper.Map<Customer,CustomerViewItem>(cusf, opt => opt.ConfigureMap().ForMember(x => x.FullName, m => m.MapFrom(src => src.FirstName)));
            IEnumerable<CustomerViewItem> ienumerableDest = Mapper.Map<List<Customer>, IEnumerable<CustomerViewItem>>(cus);
            ICollection<CustomerViewItem> icollectionDest = Mapper.Map<List<Customer>, ICollection<CustomerViewItem>>(cus);
            IList<CustomerViewItem> ilistDest = Mapper.Map<List<Customer>, IList<CustomerViewItem>>(cus);
            List<CustomerViewItem> listDest = Mapper.Map<List<Customer>, List<CustomerViewItem>>(cus);
            CustomerViewItem[] arrayDest = Mapper.Map<Customer[], CustomerViewItem[]>(cus.ToArray());
        }

        static List<Customer> GetAllCustomers()
        {
            return new List<Customer>
            {
                new Customer{FirstName="Andile",LastName="Zola",DateOfBirth = DateTime.Now,NumberOfOrders=10},
                new Customer{FirstName="Sanele",LastName="Zola",DateOfBirth = DateTime.Now,NumberOfOrders=10},
                new Customer{FirstName="Mondli",LastName="Zola",DateOfBirth = DateTime.Now,NumberOfOrders=10},
                new Customer{FirstName="Avumile",LastName="Zola",DateOfBirth = DateTime.Now,NumberOfOrders=10},
                new Customer{FirstName="Monde",LastName="Zola",DateOfBirth = DateTime.Now,NumberOfOrders=10},
            };
        }
    }
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumberOfOrders { get; set; }       
    }

    public class CustomerViewItem
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int NumberOfOrders { get; set; }
    }
    
}
