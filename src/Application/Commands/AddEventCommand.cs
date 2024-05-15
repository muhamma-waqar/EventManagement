﻿using Domain.Entities;
using Domain.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class AddEventCommand : IRequest<Event>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeEnum Type { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
