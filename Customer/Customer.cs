using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer
{
    internal class Customer
    {

        
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }

            public Customer(int id, string firstName, string lastName, string phoneNumber)
            {
                Id = id;
                FirstName = firstName;
                LastName = lastName;
                PhoneNumber = phoneNumber;
            }
        }
    }

