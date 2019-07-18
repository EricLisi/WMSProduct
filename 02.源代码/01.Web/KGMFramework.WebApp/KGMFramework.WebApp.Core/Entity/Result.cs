using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Entity
{
    public class Result
    {
        public Result()
        {

        }

        #region 私有成员
        private int _result;//结果
        private string _name;//名称
        #endregion

        #region 公开属性
        public int resultValue
        {
            get { return _result; }
            set { _result = value; }
        }

        public string resultText
        {
            get { return _name; }
            set { _name = value; }
        }
        #endregion
    }
}
