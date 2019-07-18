using KGM.Framework.Domain;
using KGM.Framework.Infrastructure;
using KGM.Framework.RepositoryEF.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace KGM.Framework.RepositoryEF.Repositories
{
    /// <summary>
    /// 模块的仓储方法
    /// </summary>
    public class ModuleRepository : BaseRepository<ModuleEntity, ModuleContext>, IModuleRepository
    {
        #region 构造函数
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public ModuleRepository() : base()
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
        private ModuleEntity GetByKey(ModuleContext context, object key)
        {
            return context.CurrentDbSet
                .Where(it => it.Id.Equals(key))
                .Include(it => it.ButtonEntities)
                .Include(it => it.ColumnEntities)
                .Include(it => it.FormEntities)
                .FirstOrDefault();
        }
        #endregion

        #region 重写基类的接口
        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override int Update(ModuleEntity entity)
        {
           
            using (var uow = new EFUnitOfWork<ModuleContext>(CurrentDbContext))
            {
                //更新主表
                uow.RegisterModified(entity, true);
                //得到现在所有的button,column,form                
                var buttons = uow.DbContext.Button
                    .Where(it => it.ModuleId.Equals(entity.Id));
                var columns = uow.DbContext.Column
                    .Where(it=>it.ModuleId.Equals(entity.Id));
                var forms = uow.DbContext.Form
                    .Where(it => it.ModuleId.Equals(entity.Id));
                //读取出不在当前buttons/columns/forms集合内的button/column/form,这部分作为删除对象
                var btnDeleted = buttons
                    .Where(it => !entity.ButtonEntities.Any(t => t.Id.Equals(it.Id)));
                var columnDeleted = columns
                    .Where(it=>!entity.ColumnEntities.Any(t=>t.Id.Equals(it.Id)));
                var formDeleted = forms
                    .Where(it => !entity.FormEntities.Any(t => t.Id.Equals(it.Id)));
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
                foreach (var form in formDeleted)
                {
                    //将这部分form作为删除
                    uow.RegisterDeleted(form);
                }
                //找出当前不在数据库内的buttons/columns/forms,作为新增对象
                var btnAdd = entity.ButtonEntities
                    .Where(it => !buttons.Any(t => t.Id.Equals(it.Id)));
                var columnAdd = entity.ColumnEntities
                    .Where(it=>!columns.Any(t=>t.Id.Equals(it.Id)));
                var formAdd = entity.FormEntities
                    .Where(it => !forms.Any(t => t.Id.Equals(it.Id)));

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
                foreach (var form in formAdd)
                {
                    //将这部分form作为新增
                    uow.RegisterNew(form);
                }
                //得到更新部分
                var btnModify = entity.ButtonEntities
                    .Where(it => buttons.Any(t => t.Id.Equals(it.Id)));
                var columnModify = entity.ColumnEntities
                    .Where(it=>columns.Any(t=>t.Id.Equals(it.Id)));
                var formModify = entity.FormEntities
                    .Where(it=>forms.Any(t=>t.Id.Equals(it.Id)));
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
                foreach (var form in formModify)
                {
                    //将这部分form作为新增
                    uow.RegisterModified(form);
                }
                return uow.Commit();
            }
        }
        /// <summary>
        ///查找指定主键的实体记录
        /// </summary>
        /// <param name="key"> 指定主键 </param>
        /// <returns> 符合编号的记录，不存在返回null </returns>
        public override ModuleEntity GetByKey(object key)
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
            using (var uow = new EFUnitOfWork<ModuleContext>(CurrentDbContext))
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
        /// 获取模块按钮树形
        /// </summary>
        /// <returns></returns>
        public List<ModuleEntity> QueryAllModule()
        {
            var btnentity = CurrentDbContext.Button.Where(it => true);
            List<ModuleEntity> moduleEntity = CurrentDbSet.Where(it => true).ToList();

            foreach (var item in moduleEntity)
            {
                foreach (var item2 in btnentity)
                {
                    if (item.Id == item2.ModuleId)
                    {
                        if (item.ButtonEntities == null)
                        {
                            item.ButtonEntities = new List<ModuleEntity.ButtonEntity>();
                        }
                        item.ButtonEntities.Add(item2);
                    }
                }
            }
            List<ModuleEntity> s = moduleEntity;
            return moduleEntity;
        }
        /// <summary>
        /// 分页查询 + 条件查询 + 排序
        /// </summary>
        /// <param name="pager">分页对象</param>
        /// <param name="condition">过滤条件</param>
        /// <returns></returns> 
        public PagerEntity<ModuleEntity> QueryModuleByPagers(PagerInfo pager, List<SearchCondition> condition = null)
        {
            var entity = CurrentDbSet.Where(it=>true);
            //动态增加过滤条件
            if (condition != null && condition.Count > 0)
            {
                var parser = new LambdaParser<ModuleEntity>();
                entity = entity.Where(parser.ParserConditions(condition));
            }

            var total = entity.Count();

            entity = pager.Sort == "ASC" ? entity.OrderBy(pager.SortFiled) : entity.OrderByDescending(pager.SortFiled);

            entity = entity.Skip(pager.PageSize * (pager.PageIndex - 1))
                             .Take(pager.PageSize);
            return new PagerEntity<ModuleEntity>
            {
                Entity = entity.ToList(),
                Total = total
            };
        }

        #endregion

    }
}
