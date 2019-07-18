﻿using KGM.Framework.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.Models
{
    public class AdvSearchCondtion
    {
        public SearchCondition Condition { get; set; }

        public List<KeyValuePair<string, string>> KeyValueList { get; set; }
    }
}