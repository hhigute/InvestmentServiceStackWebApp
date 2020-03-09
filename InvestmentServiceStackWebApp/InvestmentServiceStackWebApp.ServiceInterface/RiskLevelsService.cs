using InvestmentServiceStackWebApp.ServiceModel;
using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack.OrmLite;

namespace InvestmentServiceStackWebApp.ServiceInterface
{
    public class RiskLevelsService: InvestmentService
    {

        public object Get(ListRiskLevels listRiskLevels)
        {
            try
            {
                return Db.Select<RiskLevel>("select * from RiskLevel");
            }
            catch(System.Data.SqlClient.SqlException ex)
            {
                return new ErrorMessageResponse { error = ex.Message };
            }
            
        }

    }
}
