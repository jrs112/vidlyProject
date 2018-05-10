using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using vidlyProject.Models;
using vidlyProject.ViewModels;

namespace vidlyProject.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;


        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            } else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            
            _context.SaveChanges();
            return RedirectToAction("ViewCustomers", "Customer");
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }
        
        // GET: Customer
        public ActionResult ViewCustomers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

        public ActionResult ViewCustomer(int id)
        {
            var customers = _context.Customers.ToList();
            
            foreach (var customer in customers)
            {
                if (customer.Id == id)
                {
                    var viewModel = new CustomerFormViewModel
                    {
                        Customer = customer
                    };
                    return View(viewModel);
                }
            }
            return View();
        }
    }
}