using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using KGM.Framework.Application.Dtos;
using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;

namespace KGM.Framework.Application.Services
{
    /// <summary>
    /// 部门服务实现
    /// </summary>
    public class ExpCompanyService : BaseService<ExpCompanyEntity, ExpCompanyGetDto>, IExpCompanyService
    {
        #region 私有成员
     
        private readonly IExpCompanyRepository _repository;
        private readonly IMapper _mapper;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="mapper"></param>
        public  ExpCompanyService(IExpCompanyRepository repository, IMapper mapper) : base(repository, mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }



        ///// <summary>
        ///// 获取分页信息
        ///// </summary>
        ///// <param name="returnEntity">分页entity</param>
        ///// <param name="searchDto">查询Dto</param>
        ///// <param name="sidx">排序字段</param>
        ///// <param name="IsAsc">升序降序</param>
        ///// <returns></returns>
        //public async Task<PagerEntity<ExpCompanyGetDto>> GetPagerEntity(ReturnEntity returnEntity, ExpCompanySearchDto searchDto, string sidx, bool IsAsc,string UserId) {


         
        //    if (string.IsNullOrEmpty(sidx))
        //    {
        //        sidx = "SordCode";
        //    }
          

        //    PagerEntity<ExpCompanyGetDto> pager=await  base.QueryByPagesAsync(returnEntity.rowCount, returnEntity.page,
        //          t => t.EnCode.Contains((searchDto.EnCode ?? t.EnCode)) &&
        //          t.FullName.Contains(searchDto.FullName ?? t.FullName),
        //          this.Expression(sidx), IsAsc);

        //    return pager;
        //}


        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="keyValue"></param>
        /// <returns></returns>
        public Func<ExpCompanyEntity, string> Expression(string keyValue)
        {

            Func<ExpCompanyEntity, string> exp = null;

            switch (keyValue.ToLower())
            {
                case "encode":
                    exp = u => u.EnCode;
                    break;
                case "fullname":
                    exp = u => u.FullName;
                    break;
                case "kdaccout":
                    exp = u => u.KDAccout.ToString();
                    break;
                case "kdpwd":
                    exp = u => u.KDPwd;
                    break;

                case "kdmonthaccout":
                    exp = u => u.KDMonthAccout;
                    break;

                case "apikey":
                    exp = u => u.ApiKey;
                    break;

                case "kdnid":
                    exp = u => u.KDNId;
                    break;

                case "warehouseid":
                    exp = u => u.WarehouseCode;
                    break;

                case "contacts":
                    exp = u => u.Contacts;
                    break;

                case "telephone":
                    exp = u => u.Phone;
                    break;

                case "mobilephone":
                    exp = u => u.MobilePhone;
                    break;
                case "wechat":
                    exp = u => u.WeChat;
                    break;
                case "fax":
                    exp = u => u.Fax;
                    break;
                case "address":
                    exp = u => u.Address;
                    break;
                case "creatortime":
                    exp = u => u.CreatorTime.ToString();
                    break;
                default:
                    exp = u => u.SortCode.ToString();
                    break;

            }

            return exp;
        }
        #endregion
    }
}
