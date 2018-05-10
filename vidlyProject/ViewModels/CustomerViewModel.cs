using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using vidlyProject.Models;

namespace vidlyProject.ViewModels
{
    public class CustomerViewModel
    {
        public List <Customer> Customers { get; set; }
        public Customer Customer { get; set; }
    }
}