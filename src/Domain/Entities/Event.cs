using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public TypeEnum Type { get; private set; }
        public string Address { get; private set; }
        public string City { get; private set; }
        public string Region { get; private set; }
        public string PostalCode { get; private set; }
        public string Country { get; private set; }
        public string Phone { get; private set; }
        public DateTime startDate { get; private set; }
        public DateTime endDate { get; private set; }

        public string UserId { get; private set; }

        private Event() { }

        public static Event Create(
            string name, 
            string description, 
            int type, 
            string 
            adderss, 
            string city, 
            string region,
            string postalCode,
            string country,
            string phone,
            DateTime startDate,
            DateTime endDate)
        {
            return new Event
            {
                Name = name,
                Description = description,
                Type = (TypeEnum)type,
                Address = adderss,
                City = city,
                Region = region,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                startDate = startDate,
                endDate = endDate,
            };
        }
    }
}
