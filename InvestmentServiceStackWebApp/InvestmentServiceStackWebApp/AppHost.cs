using Funq;
using InvestmentServiceStackWebApp.ServiceInterface;
using ServiceStack;
using ServiceStack.Data;
using ServiceStack.OrmLite;
using System.Configuration;

namespace InvestmentServiceStackWebApp
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyAspNet
    public class AppHost : AppHostBase
    {
        public readonly string CONST_INVESTMENTBD = "InvestmentDB";

        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>

        public AppHost()
            : base("InvestmentServiceStackWebApp", new[] {
            typeof(InvestmentService).Assembly
            }) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());


            //Register which RDBMS provider to use
            container.Register<IDbConnectionFactory>(
               c => new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings[CONST_INVESTMENTBD].ConnectionString, 
                                                 SqlServerDialect.Provider));

        }
    }
}