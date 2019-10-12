using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.UI
{
    public class MainPresentation:IPresentation
    {
        private readonly Views.IView _FormMainView;
        
        public MainPresentation(Views.IView mainView)
        {
            _FormMainView = mainView;
        }
        
        public async Task Populate()
        {
            await _FormMainView.Populate().ConfigureAwait(false);
        }

        public void Show()
        {
            Application.Run(_FormMainView as Form);
        }

    }
}
