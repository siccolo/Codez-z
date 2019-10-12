using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views
{
    public interface IViewContainer //<T>  where T :DataStore.Models.IModel
    {
        DataStore.Models.IModel Data { get; }

        Task Populate();
    }
}
