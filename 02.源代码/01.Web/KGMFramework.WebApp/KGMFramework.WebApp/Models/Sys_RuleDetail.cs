using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KGMFramework.WebApp.Models
{
    public class Sys_RuleDetail
    {
        public string F_Id { get; set; }
        public string F_ParentId { get; set; }
        public string F_EnCode { get; set; }
        public string F_FullName { get; set; }
        public int F_Type { get; set; }
        public int F_Length { get; set; }
        public bool F_AnalyzeMark { get; set; }
        public string F_Table { get; set; }
        public string F_ValueFiled { get; set; }
        public string F_DisplayFiled { get; set; }
        public string F_Condition { get; set; }
        public bool F_GenerateMark { get; set; }
        public int F_GenerateRule { get; set; }
        public string F_GenerateFormatter { get; set; }
        public int F_GenerateLength { get; set; }
  
    }
}