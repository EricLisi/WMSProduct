﻿using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    public class RoleRepository : BaseRepository<RoleEntity, RoleContext>, IRoleRepository
    {

        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public RoleRepository() : base()
        {
        }
        #endregion

        #region 私有方法
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="context"> dbcontext </param>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        private RoleEntity GetByKey(RoleContext context, object key)
        {
            return context.CurrentDbSet
                .Where(it => it.Id.Equals(key))
                .Include(it => it.Modules)
                    .ThenInclude(it => it.Module)
                .Include(it => it.Buttons)
                    .ThenInclude(it => it.Button)
                .Include(it => it.Columns)
                    .ThenInclude(it => it.Column)
                .FirstOrDefault();
        }
        #endregion

        #region 重写基类的接口
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override int Update(RoleEntity entity)
        {

            using (var uow = new EFUnitOfWork<RoleContext>(CurrentDbContext))
            {
                //更新主表
                uow.RegisterModified(entity, true);
                //得到现在所有的button,column,Moduls                
                var buttons = uow.DbContext.RoleButton
                    .Where(it => it.RoleId.Equals(entity.Id));
                var columns = uow.DbContext.RoleColumn
                    .Where(it => it.RoleId.Equals(entity.Id));
                var moduls = uow.DbContext.RoleModule
                    .Where(it => it.RoleId.Equals(entity.Id));
                //读取出不在当前buttons/columns/Moduls集合内的button/column/Moduls,这部分作为删除对象
                var btnDeleted = buttons
                    .Where(it => !entity.Buttons.Any(t => t.Id.Equals(it.Id)));
                var columnDeleted = columns
                    .Where(it => !entity.Columns.Any(t => t.Id.Equals(it.Id)));
                var modulDeleted = moduls
                    .Where(it => !entity.Modules.Any(t => t.Id.Equals(it.Id)));
                ////循环
                foreach (var button in btnDeleted)
                {
                    //将这部分button作为删除  

                    uow.RegisterDeleted(button);
                }
                foreach (var column in columnDeleted)
                {
                    //将这部分column作为删除
                    uow.RegisterDeleted(column);
                }
                foreach (var modul in modulDeleted)
                {
                    //将这部分modul作为删除
                    uow.RegisterDeleted(modul);
                }
                //找出当前不在数据库内的buttons/columns/moduls,作为新增对象
                var btnAdd = entity.Buttons
                    .Where(it => !buttons.Any(t => t.Id.Equals(it.Id)));
                var columnAdd = entity.Columns
                    .Where(it => !columns.Any(t => t.Id.Equals(it.Id)));
                var modulAdd = entity.Modules
                    .Where(it => !moduls.Any(t => t.Id.Equals(it.Id)));

                //循环
                foreach (var button in btnAdd)
                {
                    //将这部分button作为新增
                    uow.RegisterNew(button);
                }
                foreach (var column in columnAdd)
                {
                    //将这部分column作为新增
                    uow.RegisterNew(column);
                }
                foreach (var modul in modulAdd)
                {
                    //将这部分modul作为新增
                    uow.RegisterNew(modul);
                }
                //得到更新部分
                var btnModify = entity.Buttons
                    .Where(it => buttons.Any(t => t.Id.Equals(it.Id)));
                var columnModify = entity.Columns
                    .Where(it => columns.Any(t => t.Id.Equals(it.Id)));
                var formModify = entity.Modules
                    .Where(it => moduls.Any(t => t.Id.Equals(it.Id)));
                //循环
                foreach (var button in btnModify)
                {
                    //将这部分button作为新增
                    uow.RegisterModified(button);
                }
                foreach (var column in columnModify)
                {
                    //将这部分column作为新增
                    uow.RegisterModified(column);
                }
                foreach (var modul in formModify)
                {
                    //将这部分modul作为新增
                    uow.RegisterModified(modul);
                }
                return uow.Commit();
            }
        }
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public override RoleEntity GetByKey(object key)
        {
            return GetByKey(CurrentDbContext, key);
        }

        /// <summary>
        ///删除指定编号的记录
        /// </summary>
        /// <param name="key"> 实体记录编号 </param>
        /// <returns> 操作影响的行数 </returns>
        public override int DeleteByKey(object key)
        {
            using (var uow = new EFUnitOfWork<RoleContext>(CurrentDbContext))
            {
                //设置级联删除以后,取对象必须先InClude
                var entity = GetByKey(uow.DbContext, key);

                uow.RegisterDeleted(entity);

                return uow.Commit();
            }
        }
        #endregion

        #region 自身接口实现
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 

        public PagerEntity<RoleEntity> QueryRoleByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbSet.Where(it => true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<RoleEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<RoleEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }

        #endregion

    }
}
