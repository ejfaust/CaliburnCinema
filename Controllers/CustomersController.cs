using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using Caliburn.Models;
using Caliburn.ViewModels;

namespace Caliburn.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext(); //since this is disposible, we override the Dispose() of the base controller class
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        /**
         * Called when clicking the Save button on the New Customer page.
         * HttpPost tag ensures this method will only be called on POST, not GET
         * 
         * By using Model Binding concept, can call Customer directly instead of NewCustomerViewModel.
         */
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //Avoid using TryUpdateModel(customerInDb)
                //Opens up security holes in your application bc user shouldn't be able to update ALL properties.

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscriberToNewsletter = customer.IsSubscriberToNewsletter;

                //alt, create a smaller Data Transfer Object and use AutoMapper
                //Mapper.Map(customer, customerInDb);
            }

            _context.SaveChanges();

            //redirect user back to /index.cshtml of the customer controller.
            return RedirectToAction("Index", "Customers");
        }

        public ViewResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel); //need to override here otherwise MVC will look for a view called Edit
        }
    }//end class CustomersController
}