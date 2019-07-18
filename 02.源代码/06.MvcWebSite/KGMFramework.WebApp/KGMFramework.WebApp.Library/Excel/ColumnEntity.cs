/*******************************************************************************
 * Copyright © 2017 KGMFramework 版权所有
 * Author: KGM
 * Description: KGM 快速开发平台
 * Website：http://www.kgmsoft.com.cn
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KGMFramework.WebApp.Library
{ 
    public class ColumnEntity
    {
        /// <summary>
        /// 列名
        /// </summary>
        public string Column { get; set; }
        /// <summary>
        /// Excel列名
        /// </summary>
        public string ExcelColumn { get; set; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get; set; }
        /// <summary>
        /// 前景色
        /// </summary>
        public Color ForeColor { get; set; }
        /// <summary>
        /// 背景色
        /// </summary>
        public Color Background { get; set; }
        /// <summary>
        /// 字体
        /// </summary>
        public string Font { get; set; }
        /// <summary>
        /// 字号
        /// </summary>
        public short Point { get; set; }
        /// <summary>
        /// 对齐方式
        ///left 左
        ///center 中间
        ///right 右
        ///fill 填充
        ///justify 两端对齐
        ///centerselection 跨行居中
        ///distributed
        /// </summary>
        public string Alignment { get; set; }

    }
}
