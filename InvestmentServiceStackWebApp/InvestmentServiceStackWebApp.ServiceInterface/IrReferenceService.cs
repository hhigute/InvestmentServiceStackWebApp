using InvestmentServiceStackWebApp.ServiceModel;
using InvestmentServiceStackWebApp.ServiceModel.Types;
using ServiceStack.OrmLite;

namespace InvestmentServiceStackWebApp.ServiceInterface
{
    public class IrReferenceService: InvestmentService
    {

        /* ServiceStack Free version -> limit (10 services + 10 tables)
         
        public object Get(GetIrReferences request)
        {

            try
            {
                if (request == null || request.day <= 0)
                {
                    return Db.Select<Ir>("select * from IRReference");
                }
                else
                {
                    var varDay = request.day;
                    return Db.SqlList<Ir>("select * from IRReference where (@varDay) between StartDay and FinishDay", new { varDay });
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
