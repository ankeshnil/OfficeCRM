using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeCRM.Models.ViewModel;

namespace OfficeCRM.Controllers
{
  
    public class CustomerController : Controller
    {
        public IActionResult AddCustomer()
        {
            Customer customer = new Customer();
            customer.GetAllCountry(); // here we call the getallcountry method from customer class
            customer.GetAll();
            return View(customer);
        }
        public IActionResult Save(Customer model)
        {
            if (model.Validate())
            {
                if (model.IdProof != null)
                {
                    string ext = Path.GetExtension(model.IdProof.FileName);
                    string newname = DateTime.Now.ToString("ddmmyyffff") + ext;
                    model.IdProofPath = "UploadedFiles/" + newname;

                    var serverFullPath = Path.GetFullPath("wwwroot/" + model.IdProofPath);

                    using (var stream = System.IO.File.Create(serverFullPath))
                    {
                        model.IdProof.CopyTo(stream);
                    }
                }
                model.save();
                model.SuccessMessage = "Customer Data Saved Successfully!!";
            }
            model.GetAllCountry();
            model.GetAll();
            return View("AddCustomer", model);
        }
        public IActionResult Edit(int id) {
            Customer customer = new Customer();
            customer.CustomerID = id;
            customer.GetByID();  // here we get the info by call getbyid from customer 
            
            customer.GetAllCountry();
            customer.GetAll();
            return View("AddCustomer", customer); // here we show the addcustomer page again
        }

        public IActionResult Delete(int id)
        {
            Customer customer = new Customer();
            customer.CustomerID = id;
            customer.Delete();

            customer.GetAllCountry();
            customer.GetAll();
            return View("AddCustomer", customer); 
        }
    }
}
