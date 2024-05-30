using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class EventDto
    {
        public string Name { get; private set; }
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
    }
}
