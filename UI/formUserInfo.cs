using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class formUserInfo : Form, Views.IView
    {

        Views.IViewContainer _ViewContainer;//<DataStore.Models.UserInfoModel> _ViewContainer;
        public formUserInfo(Views.IViewContainer viewContainer)//<DataStore.Models.UserInfoModel> 
        {
            _ViewContainer = viewContainer;
            InitializeComponent();
        }

        public async Task Populate()
        {
            await _ViewContainer.Populate().ConfigureAwait(false);
        }

        private void formUserInfo_Load(object sender, EventArgs e)
        {
            var userInfo = ((Views.UserInfoViewContainer)_ViewContainer).Data as DataStore.Models.UserInfoModel;
            this.labelUserName.Text = $"{userInfo.Employee_ID} {userInfo.First_Name} {userInfo.Department}";
        }
    }
}
