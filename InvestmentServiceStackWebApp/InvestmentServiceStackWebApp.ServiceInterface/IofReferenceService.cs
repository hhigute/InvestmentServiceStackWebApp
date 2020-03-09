using InvestmentServiceStackWebApp.ServiceModel;
using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack.OrmLite;

namespace InvestmentServiceStackWebApp.ServiceInterface
{
    public class IofReferenceService: InvestmentService
    {
        /* ServiceStack Free version -> limit (10 services + 10 tables)
        public object Get(GetIofReferences request)
        {
            try
            {
                if (request == null || request.day <= 0)
                {
                    return Db.Select<Iof>("select * from IofRference");
                }
                else
                {
                    var varDay = request.day;
                    return Db.SqlList<Iof>("select * from IofRference where NrDay = (@varDay)", new { varDay });
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return new ErrorMessageResponse { error = ex.Message };
            }
            

        }
        */


        

    }
}
