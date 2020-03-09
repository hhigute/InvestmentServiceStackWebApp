using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack;
using System.Collections.Generic;

namespace InvestmentServiceStackWebApp.ServiceModel
{
    [Route("/investment/bank","GET")]
    public class GetBank: IReturn<GetBankResponse>
    {
        public string Code { get; set; }
    }

    public class GetBankResponse
    {
        public List<Bank> ReferenceValues { get; set; }
    }


    [Route("/investment/bank", "POST")]
    public class PostBank : IReturn<PostBankResponse>
    {
        public Bank bank { get; set; }
    }

    public class PostBankResponse
    {
        public string response { get; set; }
    }


    [Route("/investment/bank","PUT")]
    
    public class PutBank : IReturn<PutBankResponse>
    {
        public Bank bank { get; set; }
    }

    public class PutBankResponse
    {
        public string response { get; set; }
    }

    
    [Route("/investment/bank", "DELETE")]
    [Route("/investment/bank/{Code}", "DELETE")]
    public class DeleteBank : IReturn<DeleteBankResponse>
    {
        public string Code { get; set; }
    }

    public class DeleteBankResponse
    {
        public string response { get; set; }
    }


}
