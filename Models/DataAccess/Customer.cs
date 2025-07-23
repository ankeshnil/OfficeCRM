using System.Data;
 using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;


namespace OfficeCRM.Models.DataAccess
{
    public class Customer
    {
        public static void save(ViewModel.Customer customer)
        {
            using (DataManager oDM = new DataManager())
            {
                oDM.Add("@CustomerID", SqlDbType.Int, customer.CustomerID);
                oDM.Add("@CustomerName", SqlDbType.VarChar, 50, customer.CustomerName);
                oDM.Add("@Address", SqlDbType.VarChar, 150, customer.Address);
                oDM.Add("@PhoneNo", SqlDbType.VarChar, 50, customer.PhoneNo);
                oDM.Add("@Email", SqlDbType.VarChar, 150, customer.Email);
                oDM.Add("@pincode", SqlDbType.VarChar, 50, customer.pincode);
                oDM.Add("@CreateBy", SqlDbType.Int, customer.CreateBy);
                oDM.Add("@CountryId", SqlDbType.Int, customer.CountryId);
                oDM.Add("@IdProofPath", SqlDbType.VarChar , 50, customer.IdProofPath);


                oDM.CommandType = CommandType.StoredProcedure; // here we initial; the coomand type that here we call the store procedure

                oDM.ExecuteNonQuery("Customer_Update");
            }
        }
        public static DataTable GetAll()
        {
            using (DataManager oDM = new DataManager())
            {
                oDM.CommandType = CommandType.StoredProcedure;

                return oDM.ExecuteDataTable("Customer_GetAllCustomer");
            }
        }

        public static void GetByID(ViewModel.Customer customer)
        {
            using (DataManager oDM = new DataManager())
            {

                oDM.Add("@CustomerID", SqlDbType.Int, customer.CustomerID);

                oDM.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = oDM.ExecuteReader("Customer_GetByID");

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        customer.CustomerName = (dr["CustomerName"] == DBNull.Value) ? " " : dr["CustomerName"].ToString();
                        customer.Address = (dr["Address"] == DBNull.Value) ? " " : dr["Address"].ToString();
                        customer.Email = (dr["Email"] == DBNull.Value) ? " " : dr["Email"].ToString();
                        customer.PhoneNo =( dr["PhoneNo"] == DBNull.Value) ? " " : dr["PhoneNo"].ToString();
                        customer.pincode = (dr["pincode"] == DBNull.Value) ? " " : dr["pincode"].ToString();
                        customer.CountryId = (dr["CountryId"] == DBNull.Value) ? 0 :Convert.ToInt32( dr["CountryId"]);


                    }


                }
            }
        }

        public static void Delete(int CusId)
        {
            using (DataManager oDM = new DataManager())
            {
                oDM.Add("@CustomerID", SqlDbType.Int, CusId);
               
                oDM.CommandType = CommandType.StoredProcedure; 

                oDM.ExecuteNonQuery("Customer_Delete");
            }
        }

        public static DataTable GetAllCountry()
        {
            using (DataManager oDM = new DataManager())
            {
                oDM.CommandType = CommandType.StoredProcedure;

                return oDM.ExecuteDataTable("Country_GetAll");
            }
        }

    }
}