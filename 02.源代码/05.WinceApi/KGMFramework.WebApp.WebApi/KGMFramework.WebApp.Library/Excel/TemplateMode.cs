/*******************************************************************************
 * Copyright © 2017 KGMFramework 版权所有
 * Author: KGM
 * Description: KGM 快速开发平台
 * Website：http://www.kgmsoft.com.cn
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Library
{
    public class TemplateMode
    {
        /// <summary>
        /// 行号
        /// </summary>
        public int row { get; set; }
        /// <summary>
        /// 列号
        /// </summary>
        public int cell { get; set; }
        /// <summary>
        /// 数据值
        /// </summary>
        public string value { get; set; }
    }
}
