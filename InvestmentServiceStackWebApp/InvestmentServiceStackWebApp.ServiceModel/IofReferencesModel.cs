using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack;
using System.Collections.Generic;

namespace InvestmentServiceStackWebApp.ServiceModel
{
    [Route("/investment/ref/iof")]
    [Route("/investment/ref/iof/{day}")]
    public class GetIofReferences : IReturn<GetIofReferencesResponse>
    {
        public int day { get; set; }

    }
    public class GetIofReferencesResponse
    {
        public List<Iof> ReferenceValues { get; set; }
    }

    public class ErrorMessageResponse
    {
        public string error { get; set; }
    }

}
