using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//
//using Puresharp;
//
using Unity;
using Unity.Injection;
using Unity.Resolution;
using Unity.ObjectBuilder;
//
using AppConfig;
using DataAccess;
using DataStore;
using UI.Views;
using UI.UI;
//
namespace UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            using (var container = new Unity.UnityContainer().EnableDiagnostic())
            {
                string connectionInfo = @"Data Source=12.11.10.1\DATA;Initial Catalog=DATA;User ID=Data;Password=Data;Application Name=UI.NET";
                string userName = "ykov";

                container.RegisterType<IConfig, Config>(new InjectionProperty("ConnectionInfo", connectionInfo), new InjectionProperty("UserName", userName));

                //  -- DataAccess - 
                container.RegisterType<IDataAccess, DataAccess.DataAccess>();
                //

                //  -- DataStore:
                container.RegisterType<IDataStore, DataStoreManagemer>();
                //

                //  
                container.RegisterType<IViewContainer, UserInfoViewContainer>();
                //
                container.RegisterType<IView, formUserInfo>(new InjectionConstructor(       typeof(UserInfoViewContainer)  ));
               
                //
                var ctorMainPresentation = new InjectionConstructor(    typeof(formUserInfo)    );
                container.RegisterType<IPresentation, MainPresentation>(ctorMainPresentation);
                var obj = container.Resolve<MainPresentation>();
                obj.Populate().GetAwaiter().GetResult();
                obj.Show();
            }
        }
    }
}
