using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentServiceStackWebApp.ServiceModel
{
    [Route("/investment/riskLevels")]
    public class ListRiskLevels: IReturn<GetRiskLevelsResponse> { }
    public class GetRiskLevelsResponse
    {
        public List<RiskLevel> RiskLevelValues { get; set; }
    }
}
