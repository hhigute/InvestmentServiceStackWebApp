using InvestmentServiceStackWebApp.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using InvestmentServiceStackWebApp.ServiceModel.Types;

namespace InvestmentServiceStackWebApp.ServiceInterface
{
    public class BankService: InvestmentService
    {
        public object Get(GetBank request)
        {
            try {
                if (request == null || request.Code == null || request.Code.Trim().Length == 0)
                {
                    return Db.Select<Bank>("select * from Bank");
                }
                else
                {
                    var varCode = request.Code;
                    return Db.SqlList<Bank>("select * from Bank where Code = (@varCode)", new { varCode });
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return new ErrorMessageResponse { error = ex.Message };
            }
            

        }


        public object Post(PostBank request)
        {
            Bank paramBank = request.bank;
            if (paramBank != null)
            {
                
                try
                {
                    Db.InsertOnly(() => new Bank {  code = paramBank.code, 
                                                    name = paramBank.name,
                                                    contactName = paramBank.contactName,
                                                    contactPhone = paramBank.contactPhone}) ;
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    return new ErrorMessageResponse { error = ex.Message };

                }

                Bank bank = new Bank();
                bank = Db.Select<Bank>(Db.From<Bank>()
                                                       .Where(c => c.code == paramBank.code))[0];

                return bank;

            }
            else
            {
                return new PostBankResponse { response = "Bank object can't be null" };
            }

            
        }

        public object Put(PutBank request)
        {
            Bank paramBank = request.bank;
            if (paramBank != null)
            {

                try
                {
                    Db.UpdateOnly(new Bank {name = paramBank.name, 
                                            contactName = paramBank.contactName,
                                            contactPhone = paramBank.contactPhone},
                                            onlyFields: p => new {p.name, p.contactName, p.contactPhone},
                                            where: p => p.code == paramBank.code);    

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    return new ErrorMessageResponse { error = ex.Message };

                }

                Bank bank = new Bank();
                bank = Db.Select<Bank>(Db.From<Bank>().Where(c => c.code == paramBank.code))[0];

                return bank;

            }
            else
            {
                return new PutBankResponse { response = "Bank object can't be null" };
            }


        }


        public object Delete(DeleteBank request)
        {
            string paramCode = request.Code;
            if (paramCode != null && paramCode.Trim().Length > 0)
            {
                try
                {
                    Db.Delete<Bank>(p => p.code == paramCode);
                    return new DeleteBankResponse { response = "Bank " + paramCode + " deleted" };
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    return new ErrorMessageResponse { error = ex.Message };
                }
                
            }
            else
            {
                return new DeleteBankResponse { response = "Bank code can't be null" };
            }
        }
    }
}
