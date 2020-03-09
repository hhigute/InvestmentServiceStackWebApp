using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack;
using System.Collections.Generic;

namespace InvestmentServiceStackWebApp.ServiceModel
{
    [Route("/investment/ref/ir")]
    [Route("/investment/ref/ir/{day}")]
    public class GetIrReferences: IReturn<GetIrReferencesResponse>
    {
        public int day { get; set; }
    }

    public class GetIrReferencesResponse
    {
        public List<Ir> ReferenceValues { get; set; }
    }


}
