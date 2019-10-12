using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStore.Helpers;

namespace DataStore.Models
{
    public class UserInfoModel:Model , IModel
    {
        public int Employee_ID { get; private set; }
        public string FullName { get; private set; }
        public string First_Name { get; private set; }
        public string Team { get; private set; }

        public string Department { get; private set; }
        public string Title { get; private set; }
        public int Call_Center_Agent_ID { get; private set; }

        public UserInfoModel(System.Exception exception) : base(exception) { }
        public UserInfoModel() : base() { }
        //public UserInfoModel(System.Data.DataRow dr):base(dr) {  }
        public override void Init(IModel info)
        {
            this.Employee_ID = ((UserInfoModel)info).Employee_ID;
            this.FullName = ((UserInfoModel)info).FullName;
            this.First_Name = ((UserInfoModel)info).First_Name;
            this.Team = ((UserInfoModel)info).Team;
            this.Department = ((UserInfoModel)info).Department;
            this.Title = ((UserInfoModel)info).Title;
            this.Call_Center_Agent_ID = ((UserInfoModel)info).Call_Center_Agent_ID;
        }
        /*
        public UserInfoModel(UserInfoModel info)
        {
            Init(info);
        }
        */
        public UserInfoModel(System.Data.DataRow dr)
        {
            var info = dr.ToObject<UserInfoModel>();
            Init(info);
        }
    }
}
