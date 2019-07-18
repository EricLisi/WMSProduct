using System;
using System.Collections;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

using KGMFramework.WebApp.Entity;
using KGMFramework.WebApp.IDAL;
using KGM.Pager.Entity;
using KGM.Framework.ControlUtil;

namespace KGMFramework.WebApp.BLL
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class Sys_User : BaseBLL<Sys_UserInfo>
    {
        public Sys_User()
            : base()
        {
            base.Init(this.GetType().FullName, System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
        }


        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataSet LoginSystem(LoginModel model)
        {
            ISys_User dal = baseDal as ISys_User;
            return dal.LoginSystem(model);//.Tables[0]
        }

        /// <summary>
        /// 变更部门
        /// </summary>
        /// <param name="user"></param>
        /// <param name="deptId"></param>
        /// <param name="dt"></param>
        public void ChangeDepartment(string user, string deptId, DataTable dt)
        {
            ISys_User dal = baseDal as ISys_User;
            dal.ChangeDepartment(user, deptId, dt);
        }
    }
}
