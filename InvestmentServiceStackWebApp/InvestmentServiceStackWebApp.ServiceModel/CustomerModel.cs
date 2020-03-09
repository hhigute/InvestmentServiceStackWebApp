using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack;
using System;
namespace InvestmentServiceStackWebApp.ServiceModel
{
    [Route("/investment/customer", "GET")]
    [Route("/investment/customer/{document}", "GET")]
    public class GetCustomer : IReturn<GetCustomerResponse>
    {
        public String document { get; set; }
    }
    public class GetCustomerResponse
    {
        public String response { get; set; }
    }


    [Route("/investment/customer", "POST")]
    public class PostCustomer : IReturn<PostCustomerResponse>
    {
        public Customer customer { get; set; }
    }


    public class PostCustomerResponse
    {
        public String response { get; set; }
    }

    [Route("/investment/customer","PUT")]
    public class PutCustomer: IReturn<PutCustomerResponse>
    {
        public Customer customer { get; set; }
    }

    public class PutCustomerResponse
    {
        public String response { get; set; }
    }


    [Route("/investment/customer","DELETE")]
    public class DeleteCustomer: IReturn<DeleteCustomerResponse>
    {
        public String document { get; set; }
    }

    public class DeleteCustomerResponse
    {
        public string response { get; set; }
    }
}
