using InvestmentServiceStackWebApp.ServiceModel;
using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack.OrmLite;
using System;

namespace InvestmentServiceStackWebApp.ServiceInterface
{
    public class CustomerService: InvestmentService
    {

        public object Get(GetCustomer request)
        {
            String document = request.document;

            try
            {
                if (document == null || document.Trim().Length == 0)
                {
                    return Db.Select<Customer>("select * from dbo.Customer");
                }
                else
                {
                    var varDocument = document;
                    return Db.SqlList<Customer>("select * from dbo.Customer where document = (@varDocument)", new { varDocument });

                }
            }catch(System.Data.SqlClient.SqlException ex)
            {
                return new ErrorMessageResponse { error = ex.Message };
            }
            

        }


        public object Post(PostCustomer request)
        {
            Customer paramCustomer = request.customer;

            if(paramCustomer != null)
            {
                try
                {
                    Db.InsertOnly(() => new Customer {  document = paramCustomer.document,
                                                        name = paramCustomer.name,
                                                        phone = paramCustomer.phone });

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    return new ErrorMessageResponse { error = ex.Message };
                }
                
                Customer responseCustomer = new Customer();
                responseCustomer = Db.Select<Customer>(Db.From<Customer>().
                                                        Where(c => c.document == paramCustomer.document))[0];
                return responseCustomer;

               

            }
            else
            {
                return new PostCustomerResponse { response = "Customer object can't be null" };
            }


        }


        public object Put(PutCustomer request)
        {
            Customer paramCustomer = request.customer;
            if(paramCustomer != null)
            {
                try
                {
                    Db.UpdateOnly(new Customer
                    {
                        name = paramCustomer.name,
                        phone = paramCustomer.phone
                    },
                                    onlyFields: p => new { p.name, p.phone },
                                    where: p => p.document == paramCustomer.document);


                    return Db.Select<Customer>(Db.From<Customer>().Where(p=> p.document == paramCustomer.document));


                }catch(System.Data.SqlClient.SqlException ex)
                {
                    return new ErrorMessageResponse { error = ex.Message };
                }
            }
            else
            {
                return new PutCustomerResponse { response = "Customer object can't be null" };
            }

        }


        public object Delete(DeleteCustomer request)
        {
            String paramDocument = request.document;
            if(paramDocument != null)
            {
                try
                {
                    Db.Delete<Customer>(p => p.document == paramDocument);
                    return new DeleteCustomerResponse { response = "Customer " + paramDocument + " deleted" };
                }catch(System.Data.SqlClient.SqlException ex)
                {
                    return new ErrorMessageResponse { error = ex.Message };
                }
            }
            else
            {
                return new DeleteCustomerResponse { response = "Customer document can't be null" };
            }

        }

    }
}
