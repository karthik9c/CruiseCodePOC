﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.APIStandard.Models.Octo
{
    public class Supplier
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Endpoint { get; set; }
        public Contact Contact { get; set; }
    }
}
