using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AppConfig;
using DataStore;
using DataStore.Models;

namespace UI.Views
{
    public class UserInfoViewContainer: IViewContainer//<DataStore.Models.UserInfoModel>
    {
        private IDataStore _DataStore;
        private UserInfoModel _UserInfoModel;
        private string _UserName = "";
        public IModel Data
        {
            get
            {
                return _UserInfoModel;
            }
        }

        //public UserInfoViewContainer()
        //{
        //    Console.WriteLine("UserInfoViewContainer");
        //}

        public UserInfoViewContainer( IDataStore dataStore, IConfig config) //,
        {
            _UserName = config.UserName;
            _DataStore = dataStore;
        }

        public async Task Populate()
        {
            _UserInfoModel = await _DataStore.UserInfo(_UserName).ConfigureAwait(false);// as DataStore.Models.UserInfoModel;
            return;
        }
    }
}
