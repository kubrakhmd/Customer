using System.IO;
using System.Xml;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Customer
{
    internal class Program
    {
        private static string path = @"C:\Users\Kubra\OneDrive\Desktop\homework\Customer\Customer\Customer\Customer.json";


        static void Main(string[] args)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer(223342, "Eliyev", "Mahmud", "0000000000"),
                new Customer(65241, "Ahmadova", "Kubra", "1111111111"),
                new Customer(233734, "Mahmudova", "Sebine", "222222222"),
                new Customer(744674, "Eliyev", "Perviz", "3333333333")
            };

            string jsonString = JsonConvert.SerializeObject(customers);
            File.WriteAllText(path, jsonString);

            GetAll();
        }

        static void Add(Customer customer)
        {
            var customers = GetCustomersFromFile();
            customers.Add(customer);
            SaveCustomersToFile(customers);
        }

        static void CustomerSearch(int id)
        {
            var customers = GetCustomersFromFile();
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Phone: {customer.PhoneNumber}");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        static void Update(int id, string newFirstName, string newLastName, string newPhoneNumber)
        {
            var customers = GetCustomersFromFile();
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customer.FirstName = newFirstName;
                customer.LastName = newLastName;
                customer.PhoneNumber = newPhoneNumber;
                SaveCustomersToFile(customers);
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        static void DeleteCustomer(int id)
        {
            var customers = GetCustomersFromFile();
            var customer = customers.FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                customers.Remove(customer);
                SaveCustomersToFile(customers);
                Console.WriteLine("Customer deleted.");
            }
            else
            {
                Console.WriteLine("Customer not found.");
            }
        }

        static void GetAll()
        {
            var customers = GetCustomersFromFile();
            foreach (var customer in customers)
            {
                Console.WriteLine($"ID: {customer.Id}, Name: {customer.FirstName} {customer.LastName}, Phone: {customer.PhoneNumber}");
            }
        }

        static List<Customer> GetCustomersFromFile()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<Customer>>(json) ?? new List<Customer>();
            }
            return new List<Customer>();
        }

        static void SaveCustomersToFile(List<Customer> customers)
        {
            string jsonString = JsonConvert.SerializeObject(customers, Formatting.Indented);
            File.WriteAllText(path, jsonString);
        }
    }
    }

