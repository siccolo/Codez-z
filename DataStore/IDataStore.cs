﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public interface IDataStore
    {
        Task<Models.UserInfoModel> UserInfo(string userName);
    }
}
