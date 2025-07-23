
using System.Data;

namespace OfficeCRM.Models.ViewModel
{
    public class Customer
    {

        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }

        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string pincode { get; set; }
        public int CreateBy { get;  set; }

        public string SuccessMessage { get; set; }

        public string FailureMessage { get; set; }

        public DataTable dtCustomer { get; set; }

        public DataTable dtCountry { get; set; }

        public int CountryId { get; set; }

        public string IdProofPath { get; set; }

        public IFormFile IdProof { get; set; }

        public void save()
        {
            DataAccess.Customer.save(this);
        }
        public void GetAll()
        {
            dtCustomer = DataAccess.Customer.GetAll();
        }

        public void GetByID()
        {
            DataAccess.Customer.GetByID(this);
        }

        public void Delete()
        {
            DataAccess.Customer.Delete(this.CustomerID);
        }

        public bool Validate()
        {
            if(this.CustomerName == null || this.CustomerName.Length == 0)
            {
                this.FailureMessage = "Customer Name is required";
                return false;
            }
            if (this.PhoneNo == null || this.PhoneNo.Length == 0)
            {
                this.FailureMessage = "PhoneNo is required";
                return false;
            }
            if (this.Email == null || this.Email.Length == 0)
            {
                this.FailureMessage = "Email is required";
                return false;
            }

      
            // here we use dataaccess to check that the email already exis in database or not
         //   if (!DataAccess.Customer.CheckEmailExists(this.Email))
         //   {
         //       this.FailureMessage = "Email is already exist";
        //        return false;
         //   }

            return true;
        }

        public void GetAllCountry()
        {
            dtCountry = DataAccess.Customer.GetAllCountry();
        }
    }
}
